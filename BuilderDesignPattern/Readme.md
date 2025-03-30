# Builder Design Pattern Notu

Amaç: Karmaşık nesneleri adım adım inşa etmek.

## Açıklamalar

- `Computer`  
  Ürün sınıfı. CPU, RAM, Storage gibi özellikler içerir.

- `IComputerBuilder`  
  Ürünü inşa etmek için gerekli adımları tanımlar.

- `GamingComputerBuilder`, `OfficeComputerBuilder`  
  Farklı yapıdaki ürünleri oluşturur. Aynı adımları farklı içerikle uygular.

- `ComputerDirector`  
  İnşa sürecini sıralı şekilde yönetir.

- `Program.Main()`  
  Oyun ve ofis bilgisayarları ayrı builder'lar ile oluşturulup konsola yazdırılır.

## Kullanım Senaryosu

- Nesne oluşturma süreci sabit, içeriği farklıysa (rapor, belge, form, cihaz).
