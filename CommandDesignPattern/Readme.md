# Command Design Pattern Notu

Amaç: İstekleri nesne olarak sarmalayarak, işlemleri geri alma, sıralama ve kuyruklama gibi esneklikler sağlamak.

## Açıklamalar

- `ICommand`  
  Komut arayüzü. `Execute()` ile işlem tanımlanır.

- `TurnOnCommand`, `TurnOffCommand`  
  Komutun nasıl uygulanacağını içerir. `Light` nesnesi üzerinden çalışır.

- `Light`  
  Gerçek işlemi yapan sınıf (receiver). Açma ve kapama metotları içerir.

- `RemoteControl`  
  Komutu çalıştıran sınıf (invoker). Atanan komutu çalıştırır.

- `Program.Main()`  
  Lamba ve komutlar oluşturulur. Kumanda üzerinden aç/kapat işlemleri yapılır.

## Kullanım Senaryosu

- Uzaktan kumandalar, menü işlemleri, undo/redo sistemleri, işlem sıralama kuyrukları gibi yapılarda kullanılır.
