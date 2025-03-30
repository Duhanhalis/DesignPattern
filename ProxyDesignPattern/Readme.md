# Proxy Design Pattern Notu

Amaç: Bir nesneye erişimi kontrol etmek veya işlem öncesi/sonrası ek davranışlar eklemek.

## Açıklamalar

- `IInternet`  
  Ortak arayüz. `ConnectTo()` metodunu tanımlar.

- `RealInternet`  
  Gerçek nesne. Siteye bağlanır.

- `ProxyInternet`  
  Gerçek nesneye erişimden önce kontrol yapar. Yasaklı siteler listesi içerir. Uygunsa gerçek nesneye yönlendirir.

- `Program.Main()`  
  Proxy nesnesi üzerinden bağlantılar yapılır. Engelli sitelere erişim reddedilir.

## Kullanım Senaryosu

- Güvenlik, yetkilendirme, önbellekleme, loglama gibi durumlarda erişim kontrolü için kullanılır.
