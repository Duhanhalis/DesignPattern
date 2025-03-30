using System;

// Template: Dışa aktarma işleminin adımlarını tanımlar, bazıları soyut olarak bırakılır
public abstract class DataExporter
{
    // Dışa aktarma sürecini başlatan metot
    public void Export()
    {
        Connect();      // Veritabanına bağlan
        FetchData();    // Verileri al
        FormatData();   // Verileri uygun formata dönüştür
        Save();         // Verileri kaydet
    }

    // Soyut metotlar, her bir dışa aktarma türü için özelleştirilmelidir
    protected abstract void Connect();
    protected abstract void FetchData();
    protected abstract void FormatData();
    protected abstract void Save();
}

// Concrete class – PDF dışa aktarma işlemi
public class PdfExporter : DataExporter
{
    protected override void Connect()
    {
        Console.WriteLine("[PDF] Veritabanına bağlanıldı."); // PDF için veritabanı bağlantısı
    }

    protected override void FetchData()
    {
        Console.WriteLine("[PDF] Veriler alındı."); // PDF için verilerin alınması
    }

    protected override void FormatData()
    {
        Console.WriteLine("[PDF] Veriler PDF formatına dönüştürüldü."); // Verilerin PDF formatına dönüştürülmesi
    }

    protected override void Save()
    {
        Console.WriteLine("[PDF] Dosya 'rapor.pdf' olarak kaydedildi."); // PDF dosyasının kaydedilmesi
    }
}

// Concrete class – Excel dışa aktarma işlemi
public class ExcelExporter : DataExporter
{
    protected override void Connect()
    {
        Console.WriteLine("[Excel] Veritabanına bağlanıldı."); // Excel için veritabanı bağlantısı
    }

    protected override void FetchData()
    {
        Console.WriteLine("[Excel] Veriler alındı."); // Excel için verilerin alınması
    }

    protected override void FormatData()
    {
        Console.WriteLine("[Excel] Veriler Excel formatına dönüştürüldü."); // Verilerin Excel formatına dönüştürülmesi
    }

    protected override void Save()
    {
        Console.WriteLine("[Excel] Dosya 'rapor.xlsx' olarak kaydedildi."); // Excel dosyasının kaydedilmesi
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- PDF Dışa Aktarma ---");
        DataExporter pdfExporter = new PdfExporter(); // PDF dışa aktarma nesnesi oluştur
        pdfExporter.Export(); // PDF dışa aktarma işlemini başlat

        Console.WriteLine("\n--- Excel Dışa Aktarma ---");
        DataExporter excelExporter = new ExcelExporter(); // Excel dışa aktarma nesnesi oluştur
        excelExporter.Export(); // Excel dışa aktarma işlemini başlat
    }
}
