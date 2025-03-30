# Memento Design Pattern Notu

Amaç: Nesnenin iç durumunu, daha sonra geri dönebilmek için dışarıdan erişilmeden saklamak.

## Açıklamalar

- `TextMemento`  
  Yalnızca içeriği saklayan sınıf. Dışarıdan değiştirilmez.

- `TextEditor`  
  Durum oluşturur ve `Save()` ile kaydeder, `Restore()` ile geri yükler. Kullanıcı içerik ekler.

- `History`  
  Memento’ları saklar. `Undo()` ile en son kaydı geri alır.

- `Program.Main()`  
  Kullanıcı metin yazar. Geri alma işlemleriyle önceki içeriklere dönülür.

## Kullanım Senaryosu

- Geri alma (undo-redo), versiyon kontrol, geçici yedekleme gibi işlemler için kullanılır.
