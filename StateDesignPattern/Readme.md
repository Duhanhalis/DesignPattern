# State Design Pattern Notu

Amaç: Nesnenin durumuna göre davranışını değiştirmek. Davranış, duruma bağlı olarak farklı nesnelerle temsil edilir.

## Açıklamalar

- `IPlayerState`  
  Ortak arayüz. `PressPlay()` metodu ile duruma göre işlem yapılır.

- `StoppedState`, `PlayingState`, `PausedState`  
  Her biri farklı oynatıcı durumunu temsil eder. `PressPlay()` çağrıldığında uygun duruma geçiş yapar.

- `MediaPlayer`  
  Mevcut durumu tutar. `PressPlay()` çağrısı, o anki duruma göre işlem yapar ve durumu günceller.

- `Program.Main()`  
  Durumlar arası geçiş sırasıyla simüle edilir: Stopped → Playing → Paused → Playing.

## Kullanım Senaryosu

- Duruma bağlı davranışların gerektiği durumlarda (örnek: medya oynatıcı, sipariş durumu, trafik ışığı).
