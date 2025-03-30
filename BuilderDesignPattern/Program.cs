// Ürün (Product) sınıfı, bilgisayarın temel özelliklerini tanımlar.
public class Computer
{
    public string CPU { get; set; }
    
    public string RAM { get; set; }
    
    public string Storage { get; set; }

    // Bilgisayar bilgilerini konsola yazdıran metot.
    public void ShowInfo()
    {
        Console.WriteLine($"CPU: {CPU}, RAM: {RAM}, Depolama: {Storage}");
    }
}

// Soyut Builder arayüzü, bilgisayar inşa etme işlemlerini tanımlar.
public interface IComputerBuilder
{
    // CPU inşa etme metodu.
    void BuildCPU();
    
    // RAM inşa etme metodu.
    void BuildRAM();
    
    // Depolama inşa etme metodu.
    void BuildStorage();
    
    // İnşa edilen bilgisayarı döndüren metot.
    Computer GetComputer();
}

// Concrete Builder - Oyun Bilgisayarı sınıfı, IComputerBuilder arayüzünü uygular.
public class GamingComputerBuilder : IComputerBuilder
{
    // Oyun bilgisayarı için bir Computer nesnesi oluşturuluyor.
    private Computer _computer = new Computer();

    // Oyun bilgisayarının CPU'sunu belirleyen metot.
    public void BuildCPU()
    {
        _computer.CPU = "Intel Core i9"; // Oyun bilgisayarı için yüksek performanslı bir işlemci.
    }

    // Oyun bilgisayarının RAM'ini belirleyen metot.
    public void BuildRAM()
    {
        _computer.RAM = "32GB DDR5"; // Yüksek hızlı bellek.
    }

    // Oyun bilgisayarının depolama alanını belirleyen metot.
    public void BuildStorage()
    {
        _computer.Storage = "1TB NVMe SSD"; // Hızlı depolama çözümü.
    }

    // İnşa edilen oyun bilgisayarını döndüren metot.
    public Computer GetComputer()
    {
        return _computer;
    }
}

// Concrete Builder - Ofis Bilgisayarı sınıfı, IComputerBuilder arayüzünü uygular.
public class OfficeComputerBuilder : IComputerBuilder
{
    // Ofis bilgisayarı için bir Computer nesnesi oluşturuluyor.
    private Computer _computer = new Computer();

    // Ofis bilgisayarının CPU'sunu belirleyen metot.
    public void BuildCPU()
    {
        _computer.CPU = "Intel Core i3"; // Ofis kullanımı için yeterli bir işlemci.
    }

    // Ofis bilgisayarının RAM'ini belirleyen metot.
    public void BuildRAM()
    {
        _computer.RAM = "8GB DDR4"; // Temel ofis uygulamaları için yeterli bellek.
    }

    // Ofis bilgisayarının depolama alanını belirleyen metot.
    public void BuildStorage()
    {
        _computer.Storage = "512GB SSD"; // Hızlı ve yeterli depolama alanı.
    }

    // İnşa edilen ofis bilgisayarını döndüren metot.
    public Computer GetComputer()
    {
        return _computer;
    }
}

// Director sınıfı, bilgisayar inşa sürecini yönetir.
public class ComputerDirector
{
    // Kullanılacak builder nesnesi.
    private IComputerBuilder _builder;

    // Constructor ile builder nesnesi atanır.
    public ComputerDirector(IComputerBuilder builder)
    {
        _builder = builder;
    }

    // Bilgisayar inşa etme sürecini yöneten metot.
    public void BuildComputer()
    {
        _builder.BuildCPU(); // CPU inşa et.
        _builder.BuildRAM(); // RAM inşa et.
        _builder.BuildStorage(); // Depolama inşa et.
    }

    // İnşa edilen bilgisayarı döndüren metot.
    public Computer GetComputer()
    {
        return _builder.GetComputer();
    }
}

// Kullanım örneği
public class Program
{
    public static void Main(string[] args)
    {
        // Oyun bilgisayarı inşa etme süreci.
        var gamingBuilder = new GamingComputerBuilder(); // Oyun bilgisayarı için builder oluştur.
        var director = new ComputerDirector(gamingBuilder); // Director nesnesi oluştur.
        director.BuildComputer(); // Bilgisayarı inşa et.
        Computer gamingPC = director.GetComputer(); // İnşa edilen bilgisayarı al.

        Console.WriteLine("--- Oyun Bilgisayarı ---");
        gamingPC.ShowInfo(); // Oyun bilgisayarının bilgilerini göster.

        // Ofis bilgisayarı inşa etme süreci.
        var officeBuilder = new OfficeComputerBuilder(); // Ofis bilgisayarı için builder oluştur.
        director = new ComputerDirector(officeBuilder); // Yeni bir Director nesnesi oluştur.
        director.BuildComputer(); // Bilgisayarı inşa et.
        Computer officePC = director.GetComputer(); // İnşa edilen bilgisayarı al.

        Console.WriteLine("\n--- Ofis Bilgisayarı ---");
        officePC.ShowInfo(); // Ofis bilgisayarının bilgilerini göster.
    }
}
