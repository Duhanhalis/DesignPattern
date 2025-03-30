# Chain of Responsibility Design Pattern Notu

Amaç: Bir isteği, zincir şeklinde bağlı nesneler üzerinden sırayla işleyerek uygun olanın işlemesini sağlamak.

## Açıklamalar

- `SupportHandler`  
  Handler arayüzü. Zincir oluşturmak için `SetNext()`, işlem için `HandleRequest()` metodu içerir.

- `LevelOneSupport`, `LevelTwoSupport`, `LevelThreeSupport`  
  Farklı seviye destek sağlayıcıları. Şiddet seviyesine göre isteği işler veya sıradaki işleyiciye iletir.

- `Program.Main()`  
  Zincir kurulur ve talepler gönderilir. Uygun handler talepleri karşılar, destek dışındaysa mesaj verilir.

## Kullanım Senaryosu

- Teknik destek, onay akışları, log/filtre işlemleri gibi sırayla işleme ihtiyacı olan sistemlerde kullanılır.
