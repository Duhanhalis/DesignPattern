# Mediator Design Pattern Notu

Amaç: Nesneler arasında doğrudan iletişimi engelleyerek, iletişimi merkezi bir yapı üzerinden yönetmek.

## Açıklamalar

- `IChatMediator`  
  Ortak arayüz. Kullanıcı kaydı ve mesaj iletiminden sorumlu.

- `ChatRoom`  
  Mediator görevi görür. Kullanıcıları kaydeder, mesajı gönderen dışındaki kullanıcılara iletir.

- `User`  
  Mesaj gönderip alabilen katılımcıdır. Tüm iletişim `ChatRoom` üzerinden yapılır.

- `Program.Main()`  
  Üç kullanıcı oluşturulup odaya eklenir. Her biri sırayla mesaj gönderir, diğerleri alır.

## Kullanım Senaryosu

- Chat sistemleri, UI kontroller arası iletişim, uçak trafiği kontrol sistemleri gibi merkezi iletişim gereken yerlerde kullanılır.
