# Adapter Design Pattern Notu

Amaç: Uyumlu olmayan sınıfların birlikte çalışmasını sağlamak.

## Açıklamalar

- `IPrinter`  
  Hedef arayüz. Uygulamanın beklediği yazdırma davranışını tanımlar.

- `OldPrinter`  
  Eski sistemde kullanılan sınıf. Yeni arayüze uymadığı için doğrudan kullanılamaz.

- `PrinterAdapter`  
  `OldPrinter`'ı `IPrinter` arayüzüne uyarlar. Eski metodu çağırarak yeni sistemle entegre eder.

- `ModernPrinter`  
  Yeni arayüze doğrudan uyan sınıf.

- `Program.Main()`  
  Hem yeni sistem hem de adaptör üzerinden eski sistem birlikte kullanılır.

## Kullanım Senaryosu

- Mevcut sistemi bozmadan eski sistemleri yeni yapıya entegre etmek.
