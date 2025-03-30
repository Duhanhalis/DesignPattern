# Factory Design Pattern Notu

Amaç: Nesne oluşturma işlemini merkezi bir yapıda yönetmek ve istemciyi nesne oluşturma detaylarından soyutlamak.

## Açıklamalar

- `INotification`  
  Ortak arayüz. Tüm bildirim sınıfları bu arayüzü implement eder (`Send` metodu).

- `SMSNotification`, `EmailNotification`, `PushNotification`  
  `INotification` arayüzünü uygular. Her biri kendi kanalına özel `Send` işlemini tanımlar.

- `NotificationFactory`  
  Bildirim türüne göre uygun nesneyi üretir. `switch` ile tür kontrolü yapar.

- `CreateNotification("sms")`  
  İlgili sınıf örneğini döndürür (örneğin `SMSNotification`).

- `Program.Main()`  
  Factory kullanılarak farklı bildirim türleri oluşturulup `Send()` ile çalıştırılır.

## Kullanım Senaryosu

- Tür bilgisine göre uygun sınıfın oluşturulması gerekiyorsa (örneğin: log, ödeme, bildirim vb.).
- Yeni tür eklendiğinde sadece `Factory` sınıfı güncellenir, diğer kodlar etkilenmez.
