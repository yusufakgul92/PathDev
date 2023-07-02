# PathDev
PathDev
Diğer servislere PathDev.ApiGateway.OcelotApiGw projesi üzerinden https://localhost:7243 adresiyle erişebilirsiniz.

Sepet Servisi

Mevcut Sepeti Al: https://localhost:7243/gateway/Cart/GetCart adresine GET isteği ile ulaşabilirsiniz.
Sepete Ekleme: https://localhost:7243/gateway/Cart/AddOrUpdateCart adresine POST isteği ile yapılır.
Ürün Servisi

Ürün Ekleme: https://localhost:7243/gateway/Product/AddOrUpdateProduct adresine POST isteği ile yapılır. Ancak kullanıcının IsSystemRole = true olarak tanımlanması gerekmektedir.
Ürün Listeleme: https://localhost:7243/gateway/Product/GetProducts adresine GET isteği ile ulaşabilirsiniz.
Kullanıcı Servisi:

Kullanıcı Girişi: https://localhost:7243/gateway/Customer/Login servisine UserName=customer1@example.com&Password=123456 gibi bir sorgu dizesi ile istek göndererek giriş yapabilirsiniz.
Eğer bilgiler doğruysa, size bir token verilir ve bu token ile işlemlerinizi gerçekleştirebilirsiniz.
Sipariş Servisi:

Sipariş Listeleme: https://localhost:7243/gateway/Order/GetMyOrders linkine GET isteği yapılarak ulaşabilirsiniz.
Sipariş Ekleme: https://localhost:7243/gateway/Order/AddOrder linkine GET isteği yapılarak oluşturulur.
Sipariş oluşturma servisi öncelikle RabbitMQ'ya istek yapar, daha sonra bu isteği PathDev.ApiGateway.OcelotApiGw konsol uygulaması üzerinden tüketerek sipariş oluşturma işlemi gerçekleşir.

Ne yazık ki, DB bağlantılarını statik olarak appsettings.json dosyasına ve context üzerinden DB değişikliği yapabilmem için PathDevDbContextFactory sınıfına yazdım. Bu projede loglamayı MongoDB üzerinde oluşturmadım. Yetkilendirme aşamasında istekleri logluyor.
