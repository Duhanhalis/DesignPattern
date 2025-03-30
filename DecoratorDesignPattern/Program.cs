using System;

// Bileşen arayüzü (Component)
public interface INotifier
{
    void Send(string message);
}

// Temel sınıf (Concrete Component)
public class BasicNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"[Temel Bildirim] {message}"); // Temel bildirim mesajını konsola yazdırır.
    }
}

// Dekoratör sınıfı (Base Decorator)
public abstract class NotifierDecorator : INotifier
{
    protected INotifier _wrappedNotifier; // Sarılı bildirim nesnesi.

    public NotifierDecorator(INotifier notifier)
    {
        _wrappedNotifier = notifier; // Sarılı nesneyi alır.
    }

    public virtual void Send(string message)
    {
        _wrappedNotifier.Send(message); // Sarılı nesneye mesaj gönderir.
    }
}

// SMS özelliği ekleyen dekoratör
public class SMSNotifier : NotifierDecorator
{
    public SMSNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message); // Önce sarılı nesneye mesaj gönderir.
        Console.WriteLine($"[SMS] {message}"); // SMS bildirimi mesajını konsola yazdırır.
    }
}

// E-posta özelliği ekleyen dekoratör
public class EmailNotifier : NotifierDecorator
{
    public EmailNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message); // Önce sarılı nesneye mesaj gönderir.
        Console.WriteLine($"[E-Posta] {message}"); // E-posta bildirimi mesajını konsola yazdırır.
    }
}

// Push bildirimi özelliği ekleyen dekoratör
public class PushNotifier : NotifierDecorator
{
    public PushNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message); // Önce sarılı nesneye mesaj gönderir.
        Console.WriteLine($"[Push Bildirimi] {message}"); // Push bildirimi mesajını konsola yazdırır.
        
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        // Temel bildirim
        INotifier notifier = new BasicNotifier();
        // Temel bildirim nesnesi oluşturulur.
    }
}
