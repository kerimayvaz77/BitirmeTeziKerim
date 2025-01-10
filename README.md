# 🎓 Düzce Üniversitesi Web Sitesi Projesi

## 📝 Proje Hakkında
Bu proje, Düzce Üniversitesi için geliştirilmiş modern ve kullanıcı dostu bir web sitesi uygulamasıdır. ASP.NET Core MVC mimarisi kullanılarak geliştirilmiş olup, üniversite personeli ve öğrencileri için çeşitli yönetim araçları sunmaktadır.

### 🌟 Özellikler
- 🔐 Güvenli Admin Paneli
- 📊 Personel ve Öğrenci Sayıları Yönetimi
- 📢 Duyuru Sistemi
- 🎨 Modern ve Responsive Tasarım
- 🔄 Oturum Yönetimi (7 gün süren cookie tabanlı authentication)
- 📱 Mobil Uyumlu Arayüz

## 🛠️ Kullanılan Teknolojiler
- ⚡ ASP.NET Core MVC
- 🎯 Entity Framework Core
- 🗄️ SQLite Veritabanı
- 🎨 Bootstrap
- 📱 Responsive Design
- 🔐 Cookie Authentication

## 🆕 Son Yapılan Güncellemeler
1. 🔄 Veritabanı SQLite'a geçirildi (Daha taşınabilir bir yapı için)
2. 🔐 Gelişmiş oturum yönetimi eklendi:
   - 7 gün süren oturum
   - Tarayıcı kapansa bile devam eden oturum
   - Otomatik giriş özelliği
3. 🎨 Arayüz iyileştirmeleri

## 🚀 Kurulum
1. Projeyi klonlayın:
```bash
git clone [https://github.com/kerimayvaz77/BitirmeTeziKerim.git]
```

2. Proje dizinine gidin:
```bash
cd BitirmeTeziKerim
```

3. Bağımlılıkları yükleyin:
```bash
dotnet restore
```

4. Veritabanını oluşturun:
```bash
dotnet ef database update
```

5. Projeyi çalıştırın:
```bash
dotnet run
```

## 👥 Admin Girişi
- 📧 Email: kerim@kerim.com
- 🔑 Şifre: admin123

## 📁 Proje Yapısı
```
BitirmeTeziKerim/
├── Controllers/         # MVC Controllers
├── Models/             # Veritabanı Modelleri
├── Views/              # Razor View Dosyaları
├── wwwroot/           # Statik Dosyalar (CSS, JS, Images)
└── Startup.cs         # Uygulama Konfigürasyonu
```

## 🔧 Gereksinimler
- 🔷 .NET 8.0 SDK
- 📝 Visual Studio 2022 veya VS Code
- 🗄️ SQLite

## 📝 Lisans
Bu proje [MIT](LICENSE) lisansı altında lisanslanmıştır.

## 👨‍💻 Geliştirici
- 👤 Kerim Ayvaz
- 🎓 Düzce Üniversitesi
- 📅 2024

## 🤝 Katkıda Bulunma
1. Bu projeyi fork edin
2. Feature branch'i oluşturun (`git checkout -b feature/YeniOzellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/YeniOzellik`)
5. Pull Request oluşturun

## 📞 İletişim
Sorularınız için: [kerimayvaz7@gmail.com ] 