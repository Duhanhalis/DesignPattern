using System;
using System.Collections.Generic;

// Subject arayüzü, internet bağlantısını temsil eder.
public interface IInternet
{
    void ConnectTo(string siteName);
}

// Gerçek sınıf (Real Subject), gerçek internet bağlantısını sağlar.
public class RealInternet : IInternet
{
    public void ConnectTo(string siteName)
    {
        Console.WriteLine($"Bağlanılıyor: {siteName}"); // Bağlantı kurma işlemi
    }
}

// Proxy sınıfı, erişim kontrolü yapar ve gerçek internet bağlantısını yönetir.
public class ProxyInternet : IInternet
{
    private RealInternet _realInternet = new RealInternet(); // Gerçek internet nesnesi
    private List<string> _blockedSites = new List<string>
    {
        "yasaksiteler.com", // Engellenen siteler
        "engellisite.com",
        "kötüniyetli.com"
    };

    public void ConnectTo(string siteName)
    {
        // Eğer site engellenmişse, erişim engellenir.
        if (_blockedSites.Contains(siteName.ToLower()))
        {
            Console.WriteLine($"Erişim engellendi: {siteName}");
        }
        else
        {
            _realInternet.ConnectTo(siteName); // Erişim sağlanır.
        }
    }
}

// Kullanım, ProxyInternet sınıfını kullanarak internet bağlantısını test eder.
public class Program
{
    public static void Main(string[] args)
    {
        IInternet internet = new ProxyInternet(); // Proxy nesnesi oluşturuluyor.

        // Farklı sitelere bağlantı denemeleri
        internet.ConnectTo("trt.net.tr");           // Erişim sağlanmalı
        internet.ConnectTo("yasaksiteler.com");     // Engellenmeli
        internet.ConnectTo("hurriyet.com.tr");      // Erişim sağlanmalı
        internet.ConnectTo("kötüniyetli.com");      // Engellenmeli
    }
}
