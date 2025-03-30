using System;

// Hedef arayüz (Client'ın kullanmak istediği şey)
// Bu arayüz, yazıcıların uygulama tarafından nasıl kullanılacağını tanımlar.
public interface IPrinter
{
    void Print(string document);
}

// Uyarlanacak eski sınıf (Legacy class)
// Bu sınıf, eski yazıcı sistemini temsil eder ve eski yazdırma yöntemini içerir.
public class OldPrinter
{
    public void PrintOldWay(string text)
    {
        Console.WriteLine($"[ESKİ YAZICI] Yazdırılıyor: {text}");
    }
}

// Adapter sınıfı (Eski yapıyı yeni arayüze uyarlar)
// Bu sınıf, eski yazıcıyı yeni arayüzle uyumlu hale getirir.
public class PrinterAdapter : IPrinter
{
    private readonly OldPrinter _oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        _oldPrinter = oldPrinter;
    }

    public void Print(string document)
    {
        _oldPrinter.PrintOldWay(document); // Eski metodu çağırıyoruz
    }
}

// Yeni sistemde kullanılan sınıf
// Bu sınıf, modern yazıcıyı temsil eder ve yeni yazdırma yöntemini içerir.
public class ModernPrinter : IPrinter
{
    public void Print(string document)
    {
        Console.WriteLine($"[MODERN YAZICI] Yazdırılıyor: {document}");
    }
}

// Kullanım
// Program sınıfı, yazıcıların nasıl kullanılacağını gösterir.
public class Program
{
    public static void Main(string[] args)
    {
        // Yeni yazıcı doğrudan kullanılır
        IPrinter modernPrinter = new ModernPrinter();
        modernPrinter.Print("Rapor.pdf");

        // Eski yazıcı adaptör aracılığıyla kullanılır
        IPrinter adaptedOldPrinter = new PrinterAdapter(new OldPrinter());
        adaptedOldPrinter.Print("Fatura.docx");
    }
}
