# Strategy Design Pattern Notu

Amaç: Farklı algoritmalar veya davranışlar arasında çalışma zamanında seçim yapabilmek.

## Açıklamalar

- `IPaymentStrategy`  
  Ortak strateji arayüzü. `Pay()` metodu tanımlı.

- `CreditCardPayment`, `PayPalPayment`, `CryptoPayment`  
  Farklı ödeme yöntemlerini temsil eden sınıflar.

- `PaymentContext`  
  Stratejiyi dışarıdan alır ve seçilen stratejiye göre ödeme işlemini gerçekleştirir.

- `Program.Main()`  
  Strateji değiştirilerek aynı arayüzle farklı ödeme yöntemleri uygulanır.

## Kullanım Senaryosu

- Farklı iş kuralları, algoritmalar veya kullanıcı tercihlerine göre dinamik davranış gerektiren durumlarda kullanılır.
