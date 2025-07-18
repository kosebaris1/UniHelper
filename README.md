# 🎓 UniHelper

UniHelper, üniversite öğrencileri ile üniversite adaylarını buluşturan, doğrulanmış kullanıcı temelli bir soru-cevap platformudur. Bilgi kirliliğini önlemek ve doğrudan deneyim paylaşımını sağlamak amacıyla tasarlanmıştır.

---

## 🚀 Proje Hakkında

UniHelper; yalnızca doğrulanmış üniversite öğrencilerinin içerik oluşturabildiği, aday öğrencilerin ise detaylı ve güvenilir bilgi alabileceği bir ortam sunar.

✔ Doğrulanmış öğrenci sistemi  
✔ Üniversite, bölüm, şehir ve etiket bazlı soru filtreleme  
✔ Beğeni, yorum, profil yönetimi  
✔ Gelişmiş admin paneli  
✔ Yapay zekâ destekli öneri sistemi (Google Gemini API)

---

## 🎯 Amaç ve Hedefler

- 📌 Üniversite adaylarının, gerçek üniversite öğrencilerinden birebir bilgi alabilmesi
- ✅ Bilgi kirliliğini azaltmak için doğrulanmış üyelik sistemi
- 🔍 Şehir, üniversite, bölüm, etiket bazlı gelişmiş filtreleme
- 👤 Kullanıcı profilleri, istatistikler, rozet sistemi
- 🛠️ Admin paneli ile içerik ve kullanıcı yönetimi
- 🤖 Yapay zekâ tabanlı otomatik özet önerileri
- 🌐 Açık kaynaklı, geliştirilebilir bir akademik örnek platform

---

## 🏗️ Mimari Yapı

- **ASP.NET Core MVC**: Sunucu tarafı uygulama çatısı
- **Onion Architecture (Katmanlı Mimari)**:
  - Domain Katmanı
  - Application Katmanı (CQRS + MediatR)
  - Persistence Katmanı (Entity Framework Core)
  - Web Katmanı (MVC Controller + Razor Views)
- **CQRS**: Komut ve sorguların ayrımı, test edilebilir yapı
- **Dependency Injection**: Gevşek bağlı servisler

---

## ⚙️ Kullanılan Teknolojiler ve Araçlar

- **ASP.NET Core MVC**: Modern web geliştirme çatısı
- **Entity Framework Core**: ORM ve Migration desteği
- **MediatR & CQRS**: Katmanlar arası mesajlaşma ve ayrım
- **AutoMapper**: DTO ↔️ Entity dönüşümleri
- **SQL Server**: Veritabanı yönetimi
- **jQuery & AJAX**: Dinamik veri işlemleri
- **Toastr.js**: Kullanıcı bildirimleri
- **Bootstrap**: Responsive arayüz
- **JWT**: Kimlik doğrulama ve oturum yönetimi
- **Google Gemini API**: Yapay zekâ ile özetleme

---

> Özetle projede yer alan bazı bölümler:

- Tüm Sorular Sayfası (filtreleme destekli)
- Soru Detay Sayfası (Yapay Zekâ Özeti)
- Cevap Yazma ve Beğeni Sistemi
- Mobil Uyumlu Tasarım
- Profil Sayfası ve Alt Sekmeler
- Admin Panel Dashboard
- API Katmanı (CQRS yapısı)
- JWT ile Kimlik Doğrulama

---

## 🤖 Yapay Zekâ Özelliği

UniHelper, Google Gemini API entegrasyonu ile sorulara verilen cevaplardan **otomatik özetler** üretir.

✅ Gemini API üzerinden metin analizi  
✅ Öneri kartı olarak kullanıcıya gösterim  
✅ Ücretsiz planlı erişim (60 istek/gün limiti)  
✅ API Key gizli konfigürasyonda tutulur

---

## 🛡️ Güvenlik ve Yetkilendirme

- ASP.NET Core Identity altyapısı
- JWT tabanlı kimlik doğrulama
- Kullanıcı rollerine göre erişim kontrolü:
  - **Admin**: Tam yetki
  - **Doğrulanmış Öğrenci**: Tüm etkileşim özellikleri
  - **Aday Öğrenci**: Soru sorabilme
- Admin onayı olmadan içerik oluşturulamaz

---

## 🗺️ Katkı Sağlama

Projeyi geliştirmek isteyenler için önerilen adımlar:

1. Reposu klonlayın
2. Yeni bir branch oluşturun
3. Değişikliklerinizi yapın
4. Pull Request (PR) açın

Katkıda bulunacak herkese şimdiden teşekkürler! 💛

---

## 📑 Lisans

MIT License.

---

## ✉️ İletişim

> Geliştirici ekibi:
>
> - Muhammed Mert Sayan – mertsayandev@gmail.com.
> - Nahit Furkan Öznamlı – furkanoznamli10@gmail.com
> - Barış Köse – kosebaris462@gmail.com

---

## ⭐ Projeyi Destekle

- Star verin ⭐
- Forklayın 🍴
- Kullanıp geri bildirim bırakın 💬

---




