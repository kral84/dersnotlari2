# Windows Kurulum Rehberi - Adım Adım

Albion Online bot araçlarını Windows'ta çalıştırmak için izlenmesi gereken adımlar.

---

## 📋 Hangi Aracı Kullanmalıyım?

### Python Araçları (ÖNERİLİR - Bot için)
- ✅ Rota kayıt sistemi (Space tuşu)
- ✅ Otomatik waypoint kaydetme
- ✅ route.json export
- ✅ WebSocket server
- **Kullanım:** Bot çalıştırmak, rota kaydetmek

### JavaScript Araçları (Debug için)
- ✅ Daha hızlı (native parser)
- ✅ Raw paket dump
- ✅ Pozisyon takibi
- **Kullanım:** Debugging, protokol analizi

---

## 🚀 PYTHON KURULUMU (Önerilir)

### ADIM 1: Npcap Kurulumu
**Npcap paket yakalama için GEREKLİ!**

1. İndir: https://nmap.org/npcap/
2. `npcap-1.79.exe` çalıştır (veya en son versiyon)
3. Kurulum seçenekleri:
   - ✅ **"Install Npcap in WinPcap API-compatible Mode"** (ÖNEMLİ!)
   - ✅ "Support raw 802.11 traffic" (isteğe bağlı)
4. **"Install"** → **"Next"** → **"Finish"**
5. **Bilgisayarı yeniden başlat** (önemli!)

---

### ADIM 2: Python Kurulumu

1. İndir: https://www.python.org/downloads/
2. **Python 3.10 veya üstü** (örnek: Python 3.11)
3. Kurulumda:
   - ✅ **"Add Python to PATH"** (ÇOK ÖNEMLİ!)
   - "Install Now" veya "Customize installation"
4. Kurulum tamamlandı → **CMD açıp test et:**
   ```cmd
   python --version
   ```
   Çıktı: `Python 3.11.x` görmeli

---

### ADIM 3: Git ile Projeyi İndir

**Seçenek A: Git ile (Önerilir)**
1. Git indir: https://git-scm.com/download/win
2. CMD veya PowerShell aç:
   ```cmd
   cd C:\Users\KULLANICI_ADIN\Desktop
   git clone https://github.com/kral84/dersnotlari2.git
   cd dersnotlari2
   ```

**Seçenek B: ZIP ile**
1. GitHub'dan ZIP indir
2. Masaüstüne çıkar
3. CMD aç:
   ```cmd
   cd C:\Users\KULLANICI_ADIN\Desktop\dersnotlari2
   ```

---

### ADIM 4: Python Bağımlılıklarını Kur

**CMD'yi YÖNETİCİ OLARAK AÇ!** (sağ tık → "Yönetici olarak çalıştır")

```cmd
cd C:\Users\KULLANICI_ADIN\Desktop\dersnotlari2
pip install -r requirements.txt
```

**VEYA tek tek:**
```cmd
pip install scapy
pip install keyboard
pip install websockets
```

**Test et:**
```cmd
python -c "import scapy; print('✅ Scapy OK')"
python -c "import keyboard; print('✅ Keyboard OK')"
python -c "import websockets; print('✅ Websockets OK')"
```

Hepsi "OK" göstermeli!

---

### ADIM 5: Python Bot'u Çalıştır

**CMD'yi YÖNETİCİ OLARAK AÇ!**

```cmd
cd C:\Users\KULLANICI_ADIN\Desktop\dersnotlari2
python albion_smart_sniffer.py
```

**Çıktı:**
```
╔══════════════════════════════════════════════════╗
║   Albion Smart Sniffer - DOĞRU Parser          ║
╚══════════════════════════════════════════════════╝

⚠️  UYARI:
   - Root/Admin izni gerekli!
   - Npcap/WinPcap kurulu olmalı!

Mod seçin:
1. Konsol + Rota Kayıt (Space ile)
2. WebSocket Server (ws://localhost:5002)
3. Sadece İzleme (rota kayıt YOK)

Seçim (1/2/3): _
```

**Mod seçenekleri:**
- **1** → Rota kayıt (Space tuşu + otomatik)
- **2** → WebSocket server (bot için)
- **3** → Sadece izleme (test için)

---

### ADIM 6: Albion Online'da Test Et

1. **Albion Online'ı aç**
2. **Oyuna gir** (herhangi bir harita)
3. **Hareket et** (W/A/S/D veya mouse)
4. CMD'de göreceksin:
   ```
   📍 Local Player: (1234.5, 5678.9)
   ```

**Rota kaydetmek için (Mod 1):**
- **Space tuşu** → Manuel waypoint ekle
- **Ctrl+C** → Kaydet ve çık
- **route.json** dosyası oluşturuldu!

---

## 🟢 JAVASCRIPT KURULUMU (İsteğe Bağlı)

### ADIM 1: Npcap Kurulumu
**Yukarıdaki Python ADIM 1 ile aynı!** (Zaten yaptıysan atla)

---

### ADIM 2: Node.js Kurulumu

1. İndir: https://nodejs.org/
2. **LTS versiyonu** seç (örnek: 20.x)
3. Kurulum → "Next" → "Next" → "Install"
4. **CMD açıp test et:**
   ```cmd
   node --version
   npm --version
   ```

---

### ADIM 3: Node.js Bağımlılıklarını Kur

**CMD'yi YÖNETİCİ OLARAK AÇ!**

```cmd
cd C:\Users\KULLANICI_ADIN\Desktop\dersnotlari2
npm install
```

**Hata alırsan:**
```cmd
npm install --global --production windows-build-tools
npm install
```

---

### ADIM 4: JavaScript Araçlarını Çalıştır

**CMD'yi YÖNETİCİ OLARAK AÇ!**

**Position Finder:**
```cmd
node zqradar_position_finder.js
```

**Raw Data Dumper:**
```cmd
node zqradar_raw_data.js my_packets.json
```

---

## 🚨 SORUN GİDERME

### "Npcap not found" / "Permission denied"
- ✅ Npcap kurulu mu? → https://nmap.org/npcap/
- ✅ CMD'yi **Yönetici olarak** açtın mı?
- ✅ Bilgisayarı yeniden başlattın mı?

### "Python/pip komut bulunamadı"
- ✅ Python kurulumda **"Add to PATH"** seçildi mi?
- ✅ CMD'yi kapat ve tekrar aç
- ✅ Yoksa PATH'e manuel ekle:
  ```
  Sistem → Gelişmiş Ayarlar → Ortam Değişkenleri → PATH → Ekle:
  C:\Users\KULLANICI\AppData\Local\Programs\Python\Python311
  ```

### "ModuleNotFoundError: No module named 'scapy'"
```cmd
pip install scapy
```

### "KeyboardInterrupt çalışmıyor"
- ✅ CMD'yi **Yönetici olarak** aç
- ✅ `keyboard` kütüphanesi kurulu mu?
  ```cmd
  pip install keyboard
  ```

### "Paket gelmiyor"
- ✅ Albion Online açık mı?
- ✅ Oyunda hareket ediyor musun?
- ✅ Npcap doğru kuruldu mu?
- ✅ Windows Firewall engelliyor mu?

### "cap" kurulumu başarısız (Node.js)
```cmd
npm install --global --production windows-build-tools
npm install cap
```

---

## 📊 ÇIKTILARI KONTROL ET

### Python: route.json
```cmd
type route.json
```

Göreceksin:
```json
[
  {"x": 1234.5, "y": 5678.9, "name": "WP1"},
  {"x": 1240.2, "y": 5680.1, "name": "WP2"}
]
```

### JavaScript: player_position.json
```cmd
type player_position.json
```

### JavaScript: packets.json
```cmd
type packets.json
```

---

## 🎯 HIZLI BAŞLANGIÇ

**En Hızlı Yol (Python):**
```cmd
# 1. Npcap kur → https://nmap.org/npcap/
# 2. Python kur → https://www.python.org/
# 3. CMD Yönetici olarak:

pip install scapy keyboard websockets
cd C:\Users\KULLANICI\Desktop\dersnotlari2
python albion_smart_sniffer.py

# 4. Seçim: 1 (Rota kayıt)
# 5. Albion Online'da hareket et
# 6. Space tuşu ile waypoint ekle
# 7. Ctrl+C ile kaydet
```

---

## 📚 Daha Fazla Bilgi

- Python rehberi: `KURULUM.md`
- JavaScript rehberi: `README_JAVASCRIPT.md`
- Nasıl çalışır: Bu README'nin üst kısımları

---

## ✅ KONTROL LİSTESİ

Başlamadan önce kontrol et:

- [ ] Npcap kurulu (https://nmap.org/npcap/)
- [ ] Bilgisayar yeniden başlatıldı
- [ ] Python 3.10+ kurulu (`python --version`)
- [ ] pip çalışıyor (`pip --version`)
- [ ] CMD Yönetici olarak açıldı
- [ ] Albion Online açık ve oyunda
- [ ] `scapy`, `keyboard`, `websockets` kurulu
- [ ] Proje klasörüne cd yapıldı

Hepsi ✅ ise → `python albion_smart_sniffer.py`

**Başarılar! 🚀**
