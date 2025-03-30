# Facade Design Pattern Notu

Amaç: Karmaşık alt sistemleri basitleştirmek ve tek bir arayüzden yönetmek.

## Açıklamalar

- `VideoLoader`, `VideoDecoder`, `VideoEncoder`, `VideoSaver`  
  Alt sistem sınıfları. Her biri tek bir işlemi yapar.

- `VideoConverter`  
  Facade sınıfı. Alt sistemleri içeriden kullanarak işlemleri tek bir metotta birleştirir (`ConvertVideo`).

- `Program.Main()`  
  Facade kullanılarak video dönüştürme işlemi sade ve basit şekilde yapılır.

## Kullanım Senaryosu

- Kullanıcının alt sistem detaylarını bilmeden işlemleri tek bir yerden yapmasını sağlamak (örnek: medya oynatıcılar, dış servis işlemleri).
