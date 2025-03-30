# Singleton Design Pattern Notu

Amaç: Uygulama genelinde tek bir nesne örneği kullanılmasını sağlamak.

## Açıklamalar

- `private static Logger _instance;`  
  Singleton nesnesini tutar. Sadece bir kez oluşturulur.

- `private static readonly object _lock = new object();`  
  Çoklu thread erişimini kontrol etmek için lock nesnesi.

- `private Logger() { }`  
  Dışarıdan nesne oluşturulmasını engeller.

- `public static Logger GetInstance()`  
  Singleton örneğini döner. Eğer örnek yoksa oluşturur, varsa mevcut olanı verir. Double-check locking uygulanır.

- `Log(string message)`  
  Konsola log mesajı yazar.

- `Main()`  
  `Logger.GetInstance()` çağrısıyla aynı nesne iki kez alınır. Karşılaştırma sonucu "Evet" çıkar çünkü aynı örnektir.

## Kullanım Senaryosu

- Loglama, config yönetimi, cache gibi tekil kaynaklar için kullanılır.
