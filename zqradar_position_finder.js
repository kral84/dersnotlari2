#!/usr/bin/env node
/**
 * ZQRadar Position Finder
 * Local player pozisyonunu bulur ve kaydeder
 * 
 * Kullanım:
 *   node zqradar_position_finder.js
 * 
 * Gereksinimler:
 *   npm install cap buffercursor
 */

const Cap = require('cap').Cap;
const decoders = require('cap').decoders;
const PhotonParser = require('./ZQRadar/scripts/classes/PhotonPacketParser');
const fs = require('fs');
const path = require('path');

// ============================================================================
// CONFIGURATION
// ============================================================================

const CONFIG = {
    port: 5056,                          // Albion Online UDP port
    logFile: 'player_position.json',     // Pozisyon log dosyası
    logInterval: 2000,                   // 2 saniyede bir kaydet
    verbose: true                        // Detaylı log
};

// ============================================================================
// GLOBAL STATE
// ============================================================================

let localPlayerPosition = null;
let lastLogTime = 0;
let totalPackets = 0;
let positionUpdates = 0;

// ============================================================================
// POSITION TRACKER
// ============================================================================

class PositionTracker {
    constructor() {
        this.positions = [];
        this.currentPos = null;
    }

    updatePosition(x, y, source) {
        this.currentPos = { x, y, timestamp: Date.now(), source };
        
        if (CONFIG.verbose) {
            console.log(`📍 Position: (${x.toFixed(2)}, ${y.toFixed(2)}) [${source}]`);
        }

        positionUpdates++;

        // Periyodik olarak kaydet
        const now = Date.now();
        if (now - lastLogTime >= CONFIG.logInterval) {
            this.savePosition();
            lastLogTime = now;
        }
    }

    savePosition() {
        if (!this.currentPos) return;

        this.positions.push(this.currentPos);

        // JSON dosyasına yaz
        const data = {
            lastUpdate: new Date().toISOString(),
            currentPosition: this.currentPos,
            totalUpdates: positionUpdates,
            history: this.positions.slice(-10)  // Son 10 pozisyon
        };

        fs.writeFileSync(CONFIG.logFile, JSON.stringify(data, null, 2));
    }
}

// ============================================================================
// PHOTON PACKET HANDLER
// ============================================================================

const tracker = new PositionTracker();

function handlePhotonPacket(payload) {
    totalPackets++;

    try {
        const parser = new PhotonParser();
        
        parser.on('packet', (photonPacket) => {
            // Her command'ı parse et
            photonPacket.commands.forEach(command => {
                if (!command || !command.data) return;

                try {
                    // Message type kontrol et
                    const messageType = command.data[1];
                    const parameters = command.parameters || {};

                    // OperationRequest (messageType = 2)
                    if (messageType === 2) {
                        const opCode = parameters[253];
                        
                        // Operation 21 = MOVE
                        if (opCode === 21 && parameters[1] && parameters[1].length >= 2) {
                            tracker.updatePosition(parameters[1][0], parameters[1][1], 'MOVE');
                        }
                    }
                    
                    // OperationResponse (messageType = 3)
                    else if (messageType === 3) {
                        const opCode = parameters[253];
                        
                        // Operation 2 = JOIN MAP
                        if (opCode === 2 && parameters[9] && parameters[9].length >= 2) {
                            tracker.updatePosition(parameters[9][0], parameters[9][1], 'JOIN');
                            
                            if (CONFIG.verbose) {
                                console.log(`🗺️  Map joined!`);
                            }
                        }
                    }
                } catch (err) {
                    // Skip parse errors
                }
            });
        });

        parser.handle(payload);
    } catch (error) {
        // Skip packet errors
    }
}

// ============================================================================
// PACKET CAPTURE
// ============================================================================

function startCapture() {
    console.log('╔══════════════════════════════════════════════════╗');
    console.log('║   ZQRadar Position Finder (JavaScript)          ║');
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
    console.log(`💾 Log file: ${CONFIG.logFile}\n`);

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

    console.log('✅ Capture started! Waiting for Albion Online packets...\n');

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
        console.log(`📊 Stats: ${totalPackets} packets | ${positionUpdates} position updates`);
    }, 10000);

    // Ctrl+C handler
    process.on('SIGINT', () => {
        console.log('\n\n👋 Stopping...');
        tracker.savePosition();
        console.log(`💾 Saved to ${CONFIG.logFile}`);
        console.log(`📈 Total: ${positionUpdates} position updates from ${totalPackets} packets`);
        process.exit(0);
    });
}

// ============================================================================
// MAIN
// ============================================================================

startCapture();
