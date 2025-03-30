using System;

// Handler arayüzü
public abstract class SupportHandler
{
    protected SupportHandler _nextHandler;

    // Bir sonraki işleyiciyi ayarlamak için kullanılan metot
    public void SetNext(SupportHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    // İstekleri işlemek için soyut metot
    public abstract void HandleRequest(string message, int severity);
}

// Concrete Handler – Seviye 1
public class LevelOneSupport : SupportHandler
{
    public override void HandleRequest(string message, int severity)
    {
        // Eğer şiddet seviyesi 1 veya daha düşükse, destek sağlanır
        if (severity <= 1)
        {
            Console.WriteLine($"[Seviye 1] Destek sağlandı: {message}");
        }
        // Aksi takdirde, bir sonraki işleyiciye yönlendirilir
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(message, severity);
        }
        // Eğer işleyici yoksa, sorun çözülemedi mesajı gösterilir
        else
        {
            Console.WriteLine("Sorun çözülemedi.");
        }
    }
}

// Concrete Handler – Seviye 2
public class LevelTwoSupport : SupportHandler
{
    public override void HandleRequest(string message, int severity)
    {
        // Eğer şiddet seviyesi 2 veya daha düşükse, destek sağlanır
        if (severity <= 2)
        {
            Console.WriteLine($"[Seviye 2] Destek sağlandı: {message}");
        }
        // Aksi takdirde, bir sonraki işleyiciye yönlendirilir
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(message, severity);
        }
        // Eğer işleyici yoksa, sorun çözülemedi mesajı gösterilir
        else
        {
            Console.WriteLine("Sorun çözülemedi.");
        }
    }
}

// Concrete Handler – Seviye 3
public class LevelThreeSupport : SupportHandler
{
    public override void HandleRequest(string message, int severity)
    {
        // Eğer şiddet seviyesi 3 veya daha düşükse, destek sağlanır
        if (severity <= 3)
        {
            Console.WriteLine($"[Seviye 3] Destek sağlandı: {message}");
        }
        // Eğer şiddet seviyesi 3'ten büyükse, destek kapsamı dışında mesajı gösterilir
        else
        {
            Console.WriteLine("Bu seviyedeki sorun destek kapsamı dışında.");
        }
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        // Zinciri kur
        var level1 = new LevelOneSupport();
        var level2 = new LevelTwoSupport();
        var level3 = new LevelThreeSupport();

        // İşleyiciler arasında bağlantı kurulur
        level1.SetNext(level2);
        level2.SetNext(level3);

        Console.WriteLine("--- Kullanıcı talepleri işleniyor ---");
        // Farklı şiddet seviyelerine sahip talepler işlenir
        level1.HandleRequest("Şifre sıfırlama isteği", 1);
        level1.HandleRequest("Hesap kilitlendi", 2);
        level1.HandleRequest("Sunucu çökmesi", 3);
        level1.HandleRequest("Veri kaybı ve geri yükleme", 4);
    }
}
