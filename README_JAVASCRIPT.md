# ZQRadar JavaScript Tools

ZQRadar kütüphanesini kullanarak Albion Online paketlerini yakalayan JavaScript araçları.

## 📦 Gereksinimler

### Node.js Kurulumu
```bash
# Ubuntu/Debian
sudo apt-get install nodejs npm

# Windows
# https://nodejs.org/ adresinden indir
```

### Bağımlılıklar
```bash
npm install
```

VEYA manuel:
```bash
npm install cap buffercursor
```

### Linux İçin Özel
```bash
# libpcap kurulumu
sudo apt-get install libpcap-dev

# node-gyp için (cap build etmek için)
sudo apt-get install build-essential
```

### Windows İçin
- **Npcap** kurulumu gerekli: https://nmap.org/npcap/
- **Visual Studio Build Tools** (node-gyp için)

---

## 🛠️ Araçlar

### 1. Position Finder (`zqradar_position_finder.js`)

Local player pozisyonunu yakalar ve kaydeder.

#### Kullanım:
```bash
# Linux/Mac
sudo node zqradar_position_finder.js

# Windows (Admin CMD)
node zqradar_position_finder.js
```

VEYA npm script:
```bash
sudo npm run position
```

#### Çıktı:
```
╔══════════════════════════════════════════════════╗
║   ZQRadar Position Finder (JavaScript)          ║
╚══════════════════════════════════════════════════╝

📡 Device: eth0
🔌 Port: 5056
💾 Log file: player_position.json

✅ Capture started! Waiting for Albion Online packets...

📍 Position: (1234.56, 5678.90) [MOVE]
📍 Position: (1235.12, 5679.34) [MOVE]
🗺️  Map joined!
📍 Position: (1000.00, 2000.00) [JOIN]
```

#### Output Dosyası (`player_position.json`):
```json
{
  "lastUpdate": "2024-11-06T12:34:56.789Z",
  "currentPosition": {
    "x": 1234.56,
    "y": 5678.90,
    "timestamp": 1699274096789,
    "source": "MOVE"
  },
  "totalUpdates": 156,
  "history": [
    {"x": 1234.56, "y": 5678.90, "timestamp": 1699274096789, "source": "MOVE"},
    {"x": 1235.12, "y": 5679.34, "timestamp": 1699274098789, "source": "MOVE"}
  ]
}
```

---

### 2. Raw Data Dumper (`zqradar_raw_data.js`)

Tüm Photon paketlerini raw olarak yakalar.

#### Kullanım:
```bash
# Varsayılan output (packets.json)
sudo node zqradar_raw_data.js

# Custom output dosyası
sudo node zqradar_raw_data.js my_packets.json
```

VEYA npm script:
```bash
sudo npm run raw
```

#### Çıktı:
```
╔══════════════════════════════════════════════════╗
║   ZQRadar Raw Data Dumper (JavaScript)          ║
╚══════════════════════════════════════════════════╝

📡 Device: eth0
🔌 Port: 5056
💾 Output: packets.json
📦 Max packets in memory: 1000
⏱️  Flush interval: 5000ms

✅ Capture started! Press Ctrl+C to stop.

💾 Flushed 523 packets to packets.json
📊 Stats: 1523 total | 1489 parsed | 34 errors | 523 in memory
```

#### Output Dosyası (`packets.json`):
```json
{
  "exportTime": "2024-11-06T12:34:56.789Z",
  "totalCaptured": 1523,
  "totalParsed": 1489,
  "totalErrors": 34,
  "packets": [
    {
      "timestamp": "2024-11-06T12:34:50.123Z",
      "captureTime": 1699274090123,
      "peerId": 4567,
      "messageType": "OperationRequest",
      "messageTypeCode": 2,
      "operationCode": 21,
      "operationName": "Move",
      "position": {
        "x": 1234.56,
        "y": 5678.90
      },
      "special": "LOCAL_PLAYER_MOVE",
      "parameters": {
        "1": [1234.56, 5678.90],
        "253": 21
      }
    },
    {
      "timestamp": "2024-11-06T12:34:51.456Z",
      "messageType": "OperationResponse",
      "operationCode": 2,
      "operationName": "Join",
      "position": {
        "x": 1000.0,
        "y": 2000.0
      },
      "special": "LOCAL_PLAYER_JOIN",
      "parameters": {
        "0": "MapID_12345",
        "9": [1000.0, 2000.0],
        "103": 2,
        "253": 2
      }
    },
    {
      "timestamp": "2024-11-06T12:34:52.789Z",
      "messageType": "EventData",
      "eventCode": 40,
      "parameters": {
        "252": 40
      }
    }
  ]
}
```

---

## 🎯 Nasıl Çalışır?

### 1. Paket Yakalama
```javascript
const Cap = require('cap').Cap;
const decoders = require('cap').decoders;

// UDP port 5056'yı dinle (Albion Online)
const filter = 'udp and (dst port 5056 or src port 5056)';
c.open(device, filter, bufSize, buffer);
```

### 2. Photon Parser
```javascript
const PhotonParser = require('./ZQRadar/scripts/classes/PhotonPacketParser');

// ZQRadar'ın kendi parser'ını kullan
const parser = new PhotonParser();
parser.handle(payload);
```

### 3. Local Player Pozisyonu
```javascript
// OperationRequest (messageType = 2)
if (messageType === 2 && opCode === 21) {
    // Operation 21 = MOVE
    const x = parameters[1][0];
    const y = parameters[1][1];
}

// OperationResponse (messageType = 3)
if (messageType === 3 && opCode === 2) {
    // Operation 2 = JOIN
    const x = parameters[9][0];
    const y = parameters[9][1];
}
```

---

## 📊 Message Types

| Code | Name | Açıklama |
|------|------|----------|
| 2 | OperationRequest | Client → Server (hareket, attack vb.) |
| 3 | OperationResponse | Server → Client (join map, stats vb.) |
| 4 | EventData | Server broadcast (diğer oyuncular, kaynaklar) |

## 🔧 Operation Codes

| Code | Name | Açıklama |
|------|------|----------|
| 2 | Join | Haritaya giriş |
| 21 | Move | Player hareketi (LOCAL PLAYER!) |
| 35 | ChangeCluster | Harita değişimi |

---

## 🚨 Sorun Giderme

### "Network device not found"
```bash
# Root/Admin izni gerekli
sudo node zqradar_position_finder.js
```

### "cap" kurulum hatası (Linux)
```bash
sudo apt-get install libpcap-dev build-essential
npm install cap
```

### "cap" kurulum hatası (Windows)
1. Npcap kur: https://nmap.org/npcap/
2. Visual Studio Build Tools kur
3. `npm install --global windows-build-tools` (Admin CMD)
4. `npm install cap`

### Paket gelmiyor
- Albion Online açık olmalı
- Oyunda hareket et (Request 21 tetiklenir)
- Doğru network interface seçilmiş mi kontrol et

---

## 🆚 Python vs JavaScript

| Özellik | Python (`albion_smart_sniffer.py`) | JavaScript (bu araçlar) |
|---------|-----------------------------------|-------------------------|
| **Rota kayıt** | ✅ Space tuşu + otomatik | ⚠️ Sadece pozisyon log |
| **Hız** | 🐢 Orta | 🚀 Hızlı (native parser) |
| **Bağımlılık** | scapy, keyboard | cap, buffercursor |
| **Parser** | Python'a çevrilmiş | Orijinal ZQRadar |
| **WebSocket** | ✅ Server mode | ❌ YOK |
| **Raw dump** | ❌ YOK | ✅ Tam paket dump |

**Tavsiye:**
- **Geliştirme/Debug**: JavaScript (daha hızlı, orijinal parser)
- **Bot çalıştırma**: Python (rota kayıt, keyboard desteği)

---

## 📚 Kaynak Kod

### Position Finder Mantığı
```javascript
function handlePhotonPacket(payload) {
    const parser = new PhotonParser();
    
    parser.on('packet', (photonPacket) => {
        photonPacket.commands.forEach(command => {
            const messageType = command.data[1];
            const parameters = command.parameters || {};
            
            // MOVE request
            if (messageType === 2 && parameters[253] === 21) {
                const x = parameters[1][0];
                const y = parameters[1][1];
                tracker.updatePosition(x, y, 'MOVE');
            }
            
            // JOIN response
            else if (messageType === 3 && parameters[253] === 2) {
                const x = parameters[9][0];
                const y = parameters[9][1];
                tracker.updatePosition(x, y, 'JOIN');
            }
        });
    });
    
    parser.handle(payload);
}
```

---

## 🎓 Öğrenim Kaynakları

- **ZQRadar GitHub**: https://github.com/Zeldruck/Albion-Online-ZQRadar
- **Photon Protocol**: https://doc.photonengine.com/en-us/realtime/current/reference/binary-protocol
- **Node.js cap**: https://github.com/mscdex/cap

---

**⚠️ UYARI**: Bu araçlar sadece eğitim amaçlıdır!
