using System;
using System.Collections.Generic;

// Multiton sınıfı, belirli bir anahtar ile birden fazla örneği yönetir
public class DatabaseConnection
{
    // Tüm örnekleri saklamak için bir sözlük kullanılır
    private static Dictionary<string, DatabaseConnection> _instances = new Dictionary<string, DatabaseConnection>();
    // Çoklu iş parçacığı erişimini kontrol etmek için bir lock nesnesi
    private static readonly object _lock = new object();

    // Bağlantı adını tutan özellik
    public string ConnectionName { get; private set; }

    // Özel yapıcı, dışarıdan erişimi engeller
    private DatabaseConnection(string name)
    {
        ConnectionName = name;
        Console.WriteLine($"{ConnectionName} bağlantısı oluşturuldu.");
    }

    // Belirli bir anahtar ile örneği almak için statik yöntem
    public static DatabaseConnection GetInstance(string name)
    {
        lock (_lock) // Eşzamanlı erişimi kontrol etmek için lock kullanılır
        {
            // Eğer belirtilen anahtar için bir örnek yoksa, yeni bir örnek oluştur
            if (!_instances.ContainsKey(name))
            {
                _instances[name] = new DatabaseConnection(name);
            }
            // Mevcut örneği döndür
            return _instances[name];
        }
    }

    // SQL sorgusu çalıştırmak için yöntem
    public void Query(string sql)
    {
        Console.WriteLine($"[{ConnectionName}] Sorgu çalıştırılıyor: {sql}");
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        // MSSQL bağlantısı oluşturuluyor
        var conn1 = DatabaseConnection.GetInstance("MSSQL");
        conn1.Query("SELECT * FROM Users");

        // MySQL bağlantısı oluşturuluyor
        var conn2 = DatabaseConnection.GetInstance("MySQL");
        conn2.Query("SELECT * FROM Products");

        // MSSQL bağlantısı tekrar alınıyor, aynı örnek olmalı
        var conn3 = DatabaseConnection.GetInstance("MSSQL"); // Aynı örnek

        // conn1 ve conn3'ün aynı olup olmadığını kontrol et
        Console.WriteLine($"\nconn1 ve conn3 aynı mı? {(conn1 == conn3 ? "Evet" : "Hayır")}");
    }
}
