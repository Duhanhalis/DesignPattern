using System;

// Ürün Arayüzü
// INotification arayüzü, bildirim göndermek için gerekli olan Send metodunu tanımlar.
public interface INotification
{
    void Send(string message);
}

// Somut Ürünler
// SMSNotification sınıfı, INotification arayüzünü uygulayarak SMS gönderme işlevselliğini sağlar.
public class SMSNotification : INotification
{
    public void Send(string message)
    {
        // Konsola SMS gönderildi mesajını yazdırır.
        Console.WriteLine($"SMS gönderildi: {message}");
    }
}

// EmailNotification sınıfı, INotification arayüzünü uygulayarak e-posta gönderme işlevselliğini sağlar.
public class EmailNotification : INotification
{
    public void Send(string message)
    {
        // Konsola e-posta gönderildi mesajını yazdırır.
        Console.WriteLine($"E-posta gönderildi: {message}");
    }
}

// PushNotification sınıfı, INotification arayüzünü uygulayarak push bildirimi gönderme işlevselliğini sağlar.
public class PushNotification : INotification
{
    public void Send(string message)
    {
        // Konsola push bildirimi gönderildi mesajını yazdırır.
        Console.WriteLine($"Push bildirimi gönderildi: {message}");
    }
}

// NotificationFactory sınıfı, bildirim nesnelerini oluşturmak için kullanılan bir fabrika sınıfıdır.
public class NotificationFactory
{
    // CreateNotification metodu, verilen türde bir bildirim nesnesi oluşturur.
    public INotification CreateNotification(string type)
    {
        // Türü kontrol ederek uygun bildirim nesnesini döner.
        switch (type.ToLower())
        {
            case "sms":
                return new SMSNotification(); // SMS bildirimi oluşturur.
            case "email":
                return new EmailNotification(); // E-posta bildirimi oluşturur.
            case "push":
                return new PushNotification(); // Push bildirimi oluşturur.
            default:
                // Geçersiz bir tür verilirse hata fırlatır.
                throw new ArgumentException("Geçersiz bildirim türü");
        }
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

            INotification sms = factory.CreateNotification("sms");
            sms.Send("SMS ile bilgilendirme yapıldı.");

            INotification email = factory.CreateNotification("email");
            email.Send("E-posta ile bilgilendirme yapıldı.");

            INotification push = factory.CreateNotification("push");
            push.Send("Push bildirimi ile bilgilendirme yapıldı.");
        }
    }

