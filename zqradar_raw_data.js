#!/usr/bin/env node
/**
 * ZQRadar Raw Data Dumper
 * Tüm Photon paketlerini raw olarak yakalar ve kaydeder
 * 
 * Kullanım:
 *   node zqradar_raw_data.js [output_file]
 * 
 * Örnekler:
 *   node zqradar_raw_data.js                    # packets.json'a yaz
 *   node zqradar_raw_data.js my_packets.json    # custom dosya
 * 
 * Gereksinimler:
 *   npm install cap buffercursor
 */

const Cap = require('cap').Cap;
const decoders = require('cap').decoders;
const PhotonParser = require('./ZQRadar/scripts/classes/PhotonPacketParser');
const fs = require('fs');

// ============================================================================
// CONFIGURATION
// ============================================================================

const CONFIG = {
    port: 5056,                              // Albion Online UDP port
    outputFile: process.argv[2] || 'packets.json',  // Output dosyası
    maxPackets: 1000,                        // Max packet sayısı (memory için)
    flushInterval: 5000,                     // 5 saniyede bir diske yaz
    verbosePackets: false,                   // Her paketi konsola yazdır
    captureAll: true                         // Tüm paketleri yakala (parse hatası olsa bile)
};

// ============================================================================
// GLOBAL STATE
// ============================================================================

let capturedPackets = [];
let totalPackets = 0;
let parsedPackets = 0;
let errorPackets = 0;
let lastFlushTime = Date.now();

// ============================================================================
// PACKET TYPES
// ============================================================================

const MESSAGE_TYPES = {
    2: 'OperationRequest',
    3: 'OperationResponse',
    4: 'EventData'
};

const OPERATION_CODES = {
    2: 'Join',
    21: 'Move',
    35: 'ChangeCluster'
};

// ============================================================================
// RAW DATA COLLECTOR
// ============================================================================

class RawDataCollector {
    constructor() {
        this.packets = [];
    }

    addPacket(packetData) {
        this.packets.push({
            timestamp: new Date().toISOString(),
            captureTime: Date.now(),
            ...packetData
        });

        parsedPackets++;

        if (CONFIG.verbosePackets) {
            console.log(`📦 [${packetData.messageType}] Op: ${packetData.operationCode || 'N/A'}`);
        }

        // Memory limit kontrolü
        if (this.packets.length > CONFIG.maxPackets) {
            this.packets.shift();  // En eski paketi sil
        }

        // Periyodik flush
        const now = Date.now();
        if (now - lastFlushTime >= CONFIG.flushInterval) {
            this.flush();
            lastFlushTime = now;
        }
    }

    addRawPacket(hexData, reason) {
        this.packets.push({
            timestamp: new Date().toISOString(),
            captureTime: Date.now(),
            messageType: 'RAW',
            parseError: reason,
            hexData: hexData
        });

        errorPackets++;

        if (this.packets.length > CONFIG.maxPackets) {
            this.packets.shift();
        }
    }

    flush() {
        if (this.packets.length === 0) return;

        const data = {
            exportTime: new Date().toISOString(),
            totalCaptured: totalPackets,
            totalParsed: parsedPackets,
            totalErrors: errorPackets,
            packets: this.packets
        };

        try {
            fs.writeFileSync(CONFIG.outputFile, JSON.stringify(data, null, 2));
            console.log(`💾 Flushed ${this.packets.length} packets to ${CONFIG.outputFile}`);
        } catch (error) {
            console.error(`❌ File write error: ${error.message}`);
        }
    }

    getStats() {
        return {
            total: totalPackets,
            parsed: parsedPackets,
            errors: errorPackets,
            inMemory: this.packets.length
        };
    }
}

// ============================================================================
// PHOTON PACKET PARSER
// ============================================================================

const collector = new RawDataCollector();

function handlePhotonPacket(payload) {
    totalPackets++;

    try {
        const parser = new PhotonParser();
        
        parser.on('packet', (photonPacket) => {
            // Her command'ı parse et
            photonPacket.commands.forEach(command => {
                if (!command || !command.data) return;

                try {
                    const messageType = command.data[1];
                    const messageTypeName = MESSAGE_TYPES[messageType] || `Unknown(${messageType})`;
                    
                    const packetData = {
                        peerId: photonPacket.peerId,
                        flags: photonPacket.flags,
                        timestamp: photonPacket.timestamp,
                        messageType: messageTypeName,
                        messageTypeCode: messageType,
                        commandType: command.commandType,
                        channelId: command.channelId,
                        sequenceNumber: command.sequenceNumber
                    };

                    // Parameters varsa ekle
                    if (command.parameters) {
                        const opCode = command.parameters[253];
                        packetData.operationCode = opCode;
                        packetData.operationName = OPERATION_CODES[opCode] || `Op${opCode}`;
                        packetData.parameters = command.parameters;
                        
                        // Özel bilgiler
                        if (messageType === 2 && opCode === 21) {
                            // MOVE request
                            if (command.parameters[1] && command.parameters[1].length >= 2) {
                                packetData.position = {
                                    x: command.parameters[1][0],
                                    y: command.parameters[1][1]
                                };
                                packetData.special = 'LOCAL_PLAYER_MOVE';
                            }
                        } else if (messageType === 3 && opCode === 2) {
                            // JOIN response
                            if (command.parameters[9] && command.parameters[9].length >= 2) {
                                packetData.position = {
                                    x: command.parameters[9][0],
                                    y: command.parameters[9][1]
                                };
                                packetData.special = 'LOCAL_PLAYER_JOIN';
                            }
                        } else if (messageType === 4) {
                            // Event
                            const eventCode = command.parameters[252];
                            packetData.eventCode = eventCode;
                        }
                    }

                    collector.addPacket(packetData);

                } catch (err) {
                    // Parse hatası - raw hex olarak kaydet
                    if (CONFIG.captureAll) {
                        const hexData = payload.toString('hex').substring(0, 200);
                        collector.addRawPacket(hexData, err.message);
                    }
                }
            });
        });

        parser.handle(payload);
    } catch (error) {
        // Packet parse hatası
        if (CONFIG.captureAll) {
            const hexData = payload.toString('hex').substring(0, 200);
            collector.addRawPacket(hexData, error.message);
        }
    }
}

// ============================================================================
// PACKET CAPTURE
// ============================================================================

function startCapture() {
    console.log('╔══════════════════════════════════════════════════╗');
    console.log('║   ZQRadar Raw Data Dumper (JavaScript)          ║');
    console.log('╚══════════════════════════════════════════════════╝\n');

    const c = new Cap();
    const device = Cap.findDevice();

    if (!device) {
        console.error('❌ Network device not found!');
        console.error('   Run as Administrator/Root');
        process.exit(1);
    }

    console.log(`📡 Device: ${device}`);
    console.log(`🔌 Port: ${CONFIG.port}`);
    console.log(`💾 Output: ${CONFIG.outputFile}`);
    console.log(`📦 Max packets in memory: ${CONFIG.maxPackets}`);
    console.log(`⏱️  Flush interval: ${CONFIG.flushInterval}ms\n`);

    const filter = `udp and (dst port ${CONFIG.port} or src port ${CONFIG.port})`;
    const bufSize = 4096;
    const buffer = Buffer.alloc(bufSize);

    try {
        const linkType = c.open(device, filter, bufSize, buffer);
        c.setMinBytes && c.setMinBytes(0);
    } catch (error) {
        console.error('❌ Capture failed:', error.message);
        console.error('   Run as Administrator/Root');
        process.exit(1);
    }

    console.log('✅ Capture started! Press Ctrl+C to stop.\n');

    // Paket yakalama
    c.on('packet', function (nbytes, trunc) {
        const ret = decoders.Ethernet(buffer);
        const ipRet = decoders.IPV4(buffer, ret.offset);
        const udpRet = decoders.UDP(buffer, ipRet.offset);

        const payload = buffer.slice(udpRet.offset, nbytes);
        handlePhotonPacket(payload);
    });

    // İstatistik göster
    setInterval(() => {
        const stats = collector.getStats();
        console.log(`📊 Stats: ${stats.total} total | ${stats.parsed} parsed | ${stats.errors} errors | ${stats.inMemory} in memory`);
    }, 10000);

    // Ctrl+C handler
    process.on('SIGINT', () => {
        console.log('\n\n👋 Stopping...');
        collector.flush();
        
        const stats = collector.getStats();
        console.log(`\n📈 Final Stats:`);
        console.log(`   Total packets: ${stats.total}`);
        console.log(`   Parsed: ${stats.parsed}`);
        console.log(`   Errors: ${stats.errors}`);
        console.log(`   Saved to: ${CONFIG.outputFile}`);
        
        process.exit(0);
    });
}

// ============================================================================
// MAIN
// ============================================================================

startCapture();
