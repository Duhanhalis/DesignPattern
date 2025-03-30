# Template Method Design Pattern Notu

Amaç: Bir algoritmanın iskeletini tanımlayıp, bazı adımların alt sınıflar tarafından özelleştirilmesini sağlamak.

## Açıklamalar

- `DataExporter`  
  Şablon metot `Export()`, işlem adımlarını sırayla çalıştırır. Alt sınıflar bazı adımları kendine göre uygular.

- `PdfExporter`, `ExcelExporter`  
  `Connect()`, `FetchData()`, `FormatData()`, `Save()` adımlarını kendi formatlarına göre uygular.

- `Program.Main()`  
  PDF ve Excel formatları için dışa aktarma işlemi yapılır.

## Kullanım Senaryosu

- Süreç adımlarının sırası sabit, içerikleri farklıysa (örnek: dışa aktarma, belge oluşturma).
