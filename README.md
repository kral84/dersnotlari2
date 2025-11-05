# Albion Online Otomasyon Projeleri

ZQRadar kütüphanesi ile ve kendi packet sniffer'ımızla Albion Online otomasyon sistemleri.

## ⚠️ UYARI

Bu projeler **eğitim amaçlıdır**! Albion Online'da kullanmak **ban** sebebidir!

---

## 🗂️ Projeler

### 1. **zqradar_route_bot.py**
ZQRadar WebSocket'e bağlanarak rota tabanlı otomasyon.

**Özellikler:**
- ZQRadar'dan gerçek zamanlı veri alır (ws://localhost:5002)
- WASD klavye ile hareket
- Gerçek pozisyon takibi
- Rota üzerinde kaynak toplama

**Gereksinimler:**
- ZQRadar açık olmalı (localhost:5001)

### 2. **zqradar_smart_bot.py**
W2S (World-to-Screen) problemi çözümlü akıllı bot.

**Özellikler:**
- Space tuşu ile rota kaydetme
- ZQRadar transformPoint formülü kullanımı
- Kamera + Ekran merkezi yöntemi
- Mouse tıklama ile hareket
- Kalibrasyon desteği

**Mod 1: Rota Kaydet**
```bash
python zqradar_smart_bot.py
> Seçim: 1
# Oyunda gez, Space'e basarak waypoint kaydet
# Ctrl+C ile bitir → route.json
```

**Mod 2: Rotayı Oynat**
```bash
python zqradar_smart_bot.py
> Seçim: 2
# route.json yüklenir, bot çalışır
```

### 3. **albion_packet_sniffer.py** ⭐ YENİ!
Kendi packet sniffer'ımız - ZQRadar'ın yaptığını biz yapalım!

**Ne Yapar:**
- UDP port 5056'yı dinler (Albion Online sunucu trafiği)
- Photon paketlerini parse eder
- Oyuncu pozisyonlarını çıkarır
- Kaynak bilgilerini çıkarır
- WebSocket ile yayınlar (ZQRadar gibi)

**Mod 1: Konsol Çıktısı**
```bash
sudo python3 albion_packet_sniffer.py
> Seçim: 1
```

**Mod 2: WebSocket Server**
```bash
sudo python3 albion_packet_sniffer.py
> Seçim: 2
# ws://localhost:5002 üzerinden yayın yapar
```

---

## 📦 Kurulum

```bash
# Python kütüphaneleri
pip install -r requirements.txt

# Windows için: Npcap kur
# https://npcap.com/

# Linux için: libpcap
sudo apt-get install libpcap-dev
```

---

## 🔧 Nasıl Çalışır?

### ZQRadar Yöntemi
```
Oyun ↔️ Sunucu
     ⬇️ (UDP 5056)
  ZQRadar (Npcap)
     ⬇️ (Photon Parser)
  Veri Çıkartma
     ⬇️ (WebSocket 5002)
  Botlarımız
```

### Kendi Sniffer'ımız
```
Oyun ↔️ Sunucu
     ⬇️ (UDP 5056)
  albion_packet_sniffer.py (Scapy)
     ⬇️ (SimplePhotonParser)
  Veri Çıkartma
     ⬇️ (WebSocket 5002)
  Botlarımız
```

---

## 📚 Teknik Detaylar

### Koordinat Sistemleri

**Dünya Koordinatları** (World Space):
```python
player_x = 123.45  # Oyun dünyasında X
player_y = 678.90  # Oyun dünyasında Y
```

**Ekran Koordinatları** (Screen Space):
```python
screen_x = 850  # Ekranda piksel X
screen_y = 420  # Ekranda piksel Y
```

**World-to-Screen Dönüşümü (ZQRadar formülü):**
```javascript
transformPoint(x, y) {
    const angle = -0.785398;  // -45° izometrik
    let newX = x * angle - y * angle;
    let newY = x * angle + y * angle;
    newX *= 4;   // Scale
    newY *= 4;
    newX += 250; // Offset
    newY += 250;
    return { x: newX, y: newY };
}
```

⚠️ **NOT:** Bu ZQRadar'ın web haritası için! Oyun ekranı için kalibrasyon gerekli.

### Photon Protokolü

Albion Online, Photon Engine kullanır:
- Binary protokol
- UDP üzerinden iletişim
- Port: 5056
- Command-based sistem

Paket yapısı (basitleştirilmiş):
```
[Header] [Command Type] [Parameters...]
```

---

## 🐛 Sorun Giderme

### ZQRadar'a bağlanamıyor

**Sebep:** ZQRadar açık değil veya WebSocket çalışmıyor.

**Çözüm:**
1. ZQRadar'ı başlat (localhost:5001)
2. "Launch Radar" butonuna tıkla
3. WebSocket'in çalıştığını kontrol et

### Packet sniffer çalışmıyor

**Sebep 1:** Root/Admin izni yok.
```bash
# Linux
sudo python3 albion_packet_sniffer.py

# Windows
# Sağ tık → Yönetici olarak çalıştır
```

**Sebep 2:** Npcap/WinPcap kurulu değil.
- Windows: https://npcap.com/
- Linux: `sudo apt-get install libpcap-dev`

### Mouse tıklaması yanlış yere gidiyor

**Sebep:** W2S kalibrasyonu gerekli.

**Çözüm:**
```python
# zqradar_smart_bot.py içinde
scale_factor = 10.0  # Bu değeri değiştir!

# Bot çok yakına tıklıyorsa: Artır (15.0, 20.0)
# Bot çok uzağa tıklıyorsa: Azalt (5.0, 3.0)
```

---

## 🎯 Gelecek Özellikler

- [ ] Gerçek Photon protokol parser'ı
- [ ] Otomatik W2S kalibrasyonu
- [ ] PvP saldırı tespiti
- [ ] Envanter yönetimi
- [ ] Market botu
- [ ] GUI arayüz

---

## 📄 Lisans

MIT License - Eğitim amaçlıdır.

## 🤝 Katkıda Bulunma

Pull request'ler kabul edilir! Ama unutma: Bu sadece eğitim amaçlı.

---

**Geliştirici:** Claude + kral84
**İlham:** [ZQRadar](https://github.com/Zeldruck/Albion-Online-ZQRadar)
