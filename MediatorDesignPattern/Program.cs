using System;
using System.Collections.Generic;

// Mediator arayüzü: Kullanıcılar arasındaki iletişimi yönetir
public interface IChatMediator
{
    void SendMessage(string message, User sender); // Mesaj gönderme metodu
    void RegisterUser(User user); // Kullanıcı kaydetme metodu
}

// Concrete Mediator: ChatRoom, kullanıcıları kaydeder ve mesajları iletir
public class ChatRoom : IChatMediator
{
    private List<User> _users = new List<User>(); // Kullanıcıların listesi

    public void RegisterUser(User user)
    {
        _users.Add(user); // Yeni kullanıcıyı listeye ekler
    }

    public void SendMessage(string message, User sender)
    {
        // Mesajı tüm kullanıcılara iletir, gönderen kullanıcı hariç
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.Receive(message, sender.Name); // Kullanıcıya mesajı iletir
            }
        }
    }
}

// Katılımcı (Colleague): Kullanıcı sınıfı, mesaj gönderme ve alma işlemlerini yönetir
public class User
{
    public string Name { get; private set; } // Kullanıcının adı
    private IChatMediator _chatRoom; // Mediator referansı

    public User(string name, IChatMediator chatRoom)
    {
        Name = name; // Kullanıcı adı atanır
        _chatRoom = chatRoom; // Mediator atanır
        _chatRoom.RegisterUser(this); // Kullanıcı mediator'a kaydedilir
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} gönderdi: {message}"); // Mesaj gönderildiği bilgisi
        _chatRoom.SendMessage(message, this); // Mesaj mediator üzerinden gönderilir
    }

    public void Receive(string message, string senderName)
    {
        Console.WriteLine($"{Name} aldı ← {senderName}: {message}"); // Mesaj alındığı bilgisi
    }
}

// Kullanım: Programın başlangıç noktası
public class Program
{
    public static void Main(string[] args)
    {
        IChatMediator chatRoom = new ChatRoom(); // Yeni bir chat odası oluşturulur

        // Kullanıcılar oluşturulup chat odasına kaydedilir
        var ali = new User("Ali", chatRoom);
        var ayse = new User("Ayşe", chatRoom);
        var veli = new User("Veli", chatRoom);

        // Kullanıcılar mesaj gönderir
        ali.Send("Merhaba arkadaşlar!");
        ayse.Send("Selam Ali!");
        veli.Send("Nasılsınız?");
    }
}
