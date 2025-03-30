# Prototype Design Pattern Notu

Amaç: Mevcut bir nesnenin kopyasını oluşturmak.

## Açıklamalar

- `IUserPrototype`  
  Klonlama davranışını tanımlar.

- `UserProfile`  
  `Clone()` metodu ile nesnenin yüzeysel (shallow) kopyasını döner. `MemberwiseClone()` kullanılır.

- `ShowInfo()`  
  Kullanıcı bilgilerini konsola yazdırır.

- `Program.Main()`  
  - `originalUser` oluşturulur.
  - `clonedUser`, `Clone()` ile kopyalanır.
  - `clonedUser`’da değişiklik yapılır.
  - Orijinal nesne değişmeden kalır.

## Kullanım Senaryosu

- Nesne oluşturma maliyetliyse ve aynı yapıdaki nesneler gerekiyorsa kullanılır.
- Form kopyalama, oyun karakterleri, ayar profilleri gibi durumlarda kullanışlıdır.
