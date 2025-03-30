# Multiton Design Pattern Notu

Amaç: Her benzersiz anahtar için yalnızca bir nesne örneği oluşturmak (Singleton'ın çoklu versiyonu).

## Açıklamalar

- `DatabaseConnection`  
  Her bağlantı adı (örneğin "MSSQL", "MySQL") için bir örnek oluşturur ve saklar. Aynı isimle tekrar çağrılırsa aynı nesne döner.

- `_instances`  
  Anahtar-ad bazlı tüm nesneleri tutar.

- `GetInstance(name)`  
  Verilen adla daha önce nesne oluşturulmuşsa onu döner, yoksa yeni oluşturur.

- `Query()`  
  SQL sorgusunu simüle eder.

- `Program.Main()`  
  Farklı isimlerle bağlantılar oluşturulur. Aynı isimle tekrar çağrıldığında aynı nesne alınır.

## Kullanım Senaryosu

- Konfigürasyona göre birden fazla tekil nesne gerekliyse (farklı veritabanı bağlantıları, dil yöneticileri vb.).
