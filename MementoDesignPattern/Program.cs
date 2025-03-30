using System;
using System.Collections.Generic;

// Memento: geçmiş durumu saklayan sınıf
public class TextMemento
{
    public string Content { get; private set; }

    // Memento sınıfı, içerik oluşturulurken geçmiş durumu saklar
    public TextMemento(string content)
    {
        Content = content;
    }
}

// Originator: durumu oluşturur ve geri yükler
public class TextEditor
{
    public string Content { get; private set; }

    // Kullanıcı yeni metin yazdıkça mevcut içeriği günceller
    public void Type(string newText)
    {
        Content += newText;
    }

    // Mevcut durumu kaydeder ve bir Memento nesnesi döner
    public TextMemento Save()
    {
        return new TextMemento(Content);
    }

    // Geçmişte kaydedilen durumu geri yükler
    public void Restore(TextMemento memento)
    {
        Content = memento.Content;
    }

    // Mevcut içeriği gösterir
    public void Show()
    {
        Console.WriteLine($"Mevcut içerik: {Content}");
    }
}

// Caretaker: memento nesnelerini saklar
public class History
{
    private Stack<TextMemento> _history = new Stack<TextMemento>();

    // Memento nesnesini yedekler
    public void Backup(TextMemento memento)
    {
        _history.Push(memento);
    }

    // Son kaydedilen durumu geri alır
    public TextMemento Undo()
    {
        if (_history.Count > 0)
            return _history.Pop();

        return null; // Eğer geri alınacak durum yoksa null döner
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        // Metin yazma işlemleri
        editor.Type("Merhaba");
        history.Backup(editor.Save());

        editor.Type(", dünya!");
        history.Backup(editor.Save());

        editor.Type(" Bu bir testtir.");
        editor.Show(); // Mevcut içeriği gösterir

        Console.WriteLine("\n--- Geri alınıyor ---");
        editor.Restore(history.Undo()); // Son durumu geri yükler
        editor.Show();

        Console.WriteLine("\n--- Bir kez daha geri alınıyor ---");
        editor.Restore(history.Undo()); // Bir önceki durumu geri yükler
        editor.Show();
    }
}
