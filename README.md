**Kullanılan Teknolojiler:**
- .Net 8 Web API
- JavaScript, CSS ve HTML
- MSSQL
- EF Core 8
- ASP.NET Idenity
- Fluent Validation
- AutoMapper
- SignalR

**Uygulama Hakkında:**
- Katmanlı Miamrı yapısı kullanıldı.
- Dependency Injection kullanıldı. IoC kullanıldı.
- Generic Repository, unitofwork pattern kullanıldı.
- Ef core kullanıldığı için Uygulamayı çalıştırmadan önce Update-Database yapılmalıdır. Bu şekilde tablolar ve Seed veriler (LibraryHall, Desk, Seat) otomatik oluşturulur
- Login ve Register işlemleri için ASP.NET Identity kütüphanesi kullanıldı.
- Rezervasyon işlemlerinde, kütüphanenin açık olma ve aynı userın aynı hafta içerisinde 2 kere rezervasyon yapmış olma durumuna bakılmaktadır.
- SignalR kütüphanesi kullanıcılara ve rezervasyon işlemi başarılı şekilde gerçekleştirildiğinde tüm istemcilere gösterilecek şekilde toast message eklendi.
