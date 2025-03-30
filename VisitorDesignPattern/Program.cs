using System;
using System.Collections.Generic;

// Visitor Arayüzü: Donanım bileşenlerini ziyaret etmek için gerekli metotları tanımlar.
public interface IHardwareVisitor
{
    void VisitCPU(CPU cpu); // CPU bileşenini ziyaret etme metodu
    void VisitRAM(RAM ram); // RAM bileşenini ziyaret etme metodu
}

// Element Arayüzü: Donanım bileşenlerinin ziyaretçi kabul etmesini sağlar.
public interface IHardwareComponent
{
    void Accept(IHardwareVisitor visitor); // Ziyaretçiyi kabul etme metodu
}

// Concrete Element – CPU: Donanım bileşeni olarak CPU'yu temsil eder.
public class CPU : IHardwareComponent
{
    public string Model { get; set; } = "Intel Core i7"; // CPU modelini tutar

    public void Accept(IHardwareVisitor visitor)
    {
        visitor.VisitCPU(this); // Ziyaretçiyi CPU'ya yönlendirir
    }
}

// Concrete Element – RAM: Donanım bileşeni olarak RAM'i temsil eder.
public class RAM : IHardwareComponent
{
    public int SizeGB { get; set; } = 16; // RAM boyutunu gigabayt cinsinden tutar

    public void Accept(IHardwareVisitor visitor)
    {
        visitor.VisitRAM(this); // Ziyaretçiyi RAM'e yönlendirir
    }
}

// Concrete Visitor – Raporlayıcı: Donanım bileşenlerini raporlamak için ziyaretçi.
public class DiagnosticVisitor : IHardwareVisitor
{
    public void VisitCPU(CPU cpu)
    {
        Console.WriteLine($"CPU Modeli: {cpu.Model}"); // CPU modelini konsola yazdırır
    }

    public void VisitRAM(RAM ram)
    {
        Console.WriteLine($"RAM Boyutu: {ram.SizeGB} GB"); // RAM boyutunu konsola yazdırır
    }
}

// Kullanım: Programın başlangıç noktası
public class Program
{
    public static void Main(string[] args)
    {
        // Donanım bileşenlerinin listesi oluşturulur
        List<IHardwareComponent> components = new List<IHardwareComponent>
        {
            new CPU(), // CPU bileşeni eklenir
            new RAM()   // RAM bileşeni eklenir
        };

        IHardwareVisitor diagnostic = new DiagnosticVisitor(); // Raporlayıcı ziyaretçi oluşturulur

        Console.WriteLine("--- Donanım Teşhisi Başladı ---"); // Teşhis sürecinin başlangıcı
        foreach (var component in components)
        {
            component.Accept(diagnostic); // Her bileşen için ziyaretçi kabul edilir
        }
    }
}
