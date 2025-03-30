# Composite Design Pattern Notu

Amaç: Nesneleri ağaç yapısında (hiyerarşik) organize edip, yaprak ve bileşik nesneleri aynı şekilde işlemek.

## Açıklamalar

- `IFileSystemItem`  
  Ortak arayüz. `Display()` metodu tanımlar.

- `File` (Leaf)  
  Tekil dosyayı temsil eder. `Display()` metodu sadece dosya adını yazdırır.

- `Directory` (Composite)  
  Klasörü temsil eder. İçinde dosya veya başka klasör tutabilir. `Display()` ile içeriği hiyerarşik olarak gösterir.

- `Program.Main()`  
  Dosyalar ve klasörler oluşturulup birbirine eklenir. `Display()` ile tüm yapı gösterilir.

## Kullanım Senaryosu

- Dosya sistemleri, menü yapıları, organizasyon şemaları gibi ağaç yapılar için uygundur.
