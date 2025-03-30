// Prototype arayüzü
public interface IUserPrototype
{
    // Klonlama işlemi için bir metot tanımlanıyor. Bu metot, IUserPrototype türünde bir nesne döndürecektir.
    IUserPrototype Clone();
}

// Somut prototip sınıfı
public class UserProfile : IUserPrototype
{
    // Kullanıcı adı ve yaşı için özellikler tanımlanıyor.
    public string Name { get; set; }
    public int Age { get; set; }

    // Klonlama metodu, mevcut nesnenin bir kopyasını oluşturmak için kullanılıyor.
    public IUserPrototype Clone()
    {
        // Basit (shallow) klonlama işlemi gerçekleştiriliyor. Bu, mevcut nesnenin yüzeysel bir kopyasını döndürür.
        return (IUserPrototype)this.MemberwiseClone();
    }

    // Kullanıcı bilgilerini gösteren bir metot.
    public void ShowInfo()
    {
        // Kullanıcı adı ve yaşı konsola yazdırılıyor.
        Console.WriteLine($"Kullanıcı: {Name}, Yaş: {Age}");
    }
}

// Kullanım örneği
public class Program
{
    public static void Main(string[] args)
    {
        // Orijinal kullanıcı nesnesi oluşturuluyor.
        UserProfile originalUser = new UserProfile
        {
            Name = "Ahmet", // Kullanıcı adı "Ahmet" olarak ayarlanıyor.
            Age = 30 // Kullanıcı yaşı 30 olarak ayarlanıyor.
        };

        Console.WriteLine("--- Orijinal ---");
        originalUser.ShowInfo(); // Orijinal kullanıcının bilgileri gösteriliyor.

        // Kopyalanmış kullanıcı nesnesi oluşturuluyor.
        UserProfile clonedUser = (UserProfile)originalUser.Clone(); // Orijinal kullanıcıdan klon alınıyor.
        clonedUser.Name = "Mehmet"; // Klonlanmış kullanıcının adı "Mehmet" olarak değiştiriliyor.
        clonedUser.Age = 25; // Klonlanmış kullanıcının yaşı 25 olarak değiştiriliyor.

        Console.WriteLine("\n--- Klonlanmış ---");
        clonedUser.ShowInfo(); // Klonlanmış kullanıcının bilgileri gösteriliyor.

        Console.WriteLine("\n--- Orijinal (değişmedi) ---");
        originalUser.ShowInfo(); // Orijinal kullanıcının bilgileri tekrar gösteriliyor, değişmediği için aynı kalıyor.
    }
}
