# Albion Smart Sniffer - Kurulum Kılavuzu

## 1. Gereksinimler

### Python Kütüphaneleri
```bash
pip3 install -r requirements.txt
```

VEYA tek tek:
```bash
pip3 install scapy keyboard websockets
```

### Linux İçin Özel
```bash
sudo apt-get install python3-scapy
```

### Windows İçin
- Npcap kurulu olmalı: https://nmap.org/npcap/
- Yönetici olarak çalıştırın

## 2. Dosya Yapısı

```
dersnotlari2/
├── albion_smart_sniffer.py      # Ana sniffer (Request/Response desteği)
├── zqradar_correct_parser.py    # DOĞRU parser (Op 21, Op 2)
├── zqradar_real_parser.py       # Temel Photon parser
└── requirements.txt
```

## 3. Kullanım

### Mod 1: Rota Kayıt (Space tuşu ile)
```bash
sudo python3 albion_smart_sniffer.py
# Seçim: 1
# Oyunda hareket et, Space tuşuna bas
# Ctrl+C ile bitir → route.json kaydedilir
```

### Mod 2: WebSocket Server
```bash
sudo python3 albion_smart_sniffer.py
# Seçim: 2
# ws://localhost:5002 adresinde yayın yapar
# Botlar buraya bağlanabilir
```

### Mod 3: Sadece İzleme
```bash
sudo python3 albion_smart_sniffer.py
# Seçim: 3
# Sadece paketleri gösterir
```

## 4. Nasıl Çalışır?

### Local Player Pozisyonu
- **Request (Op 21)**: Player move → Parameters[1][0], Parameters[1][1]
- **Response (Op 2)**: Join map → Parameters[9][0], Parameters[9][1]
- **NOT Event 3**: Sadece BAŞKA oyuncular için!

### Kaynaklar
- **Event 38**: NewSimpleHarvestableObject (basit kaynak spawn)
- **Event 40**: NewHarvestableObject (detaylı kaynak)

## 5. Sorun Giderme

### "dosya hemen kapanıyor"
→ Bağımlılıklar kurulu değil, `pip3 install -r requirements.txt` çalıştır

### "Permission denied"
→ Root/Admin izni gerekli:
```bash
sudo python3 albion_smart_sniffer.py
```

### "No module named 'scapy'"
→ Scapy kurulmamış:
```bash
pip3 install scapy
# VEYA Linux'ta:
sudo apt-get install python3-scapy
```

### Paket gelmiyor
- Albion Online açık olmalı
- UDP port 5056 dinleniyor mu kontrol et
- Oyunda hareket et (Request 21 gönderilmeli)

## 6. Rota Sistemi

### Kayıt
1. Mod 1'i seç
2. Oyunda istediğin rotayı yürü
3. Önemli noktlarda Space tuşuna bas (manuel waypoint)
4. Veya 2 saniye aralıklarla otomatik kaydet
5. Ctrl+C → `route.json` kaydedilir

### Format (route.json)
```json
[
  {"x": 123.4, "y": 567.8, "name": "WP1"},
  {"x": 234.5, "y": 678.9, "name": "WP2"}
]
```

### Playback (TODO)
- Bot route.json'u okur
- Her waypoint'e sırayla gider
- Yakındaki kaynakları toplar

## 7. Teknolojiler

- **Scapy**: UDP packet sniffing
- **Photon Protocol 16**: Binary deserialization
- **ZQRadar**: Açık kaynak radar (kaynak kodundan çevrildi)
- **WebSocket**: Gerçek zamanlı veri aktarımı

---

**UYARI**: Bu araç sadece eğitim amaçlıdır!
