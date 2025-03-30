using System;

// Receiver – Komutu gerçekleştiren sınıf
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Lamba açıldı."); // Lamba açıldığında konsola mesaj yazdırılır.
    }

    public void TurnOff()
    {
        Console.WriteLine("Lamba kapatıldı."); // Lamba kapandığında konsola mesaj yazdırılır.
    }
}

// Command arayüzü
public interface ICommand
{
    void Execute(); // Komutun gerçekleştirilmesi için Execute metodu tanımlanır.
}

// Concrete Command – Lamba açma komutu
public class TurnOnCommand : ICommand
{
    private Light _light; // Lamba nesnesini tutan değişken

    public TurnOnCommand(Light light)
    {
        _light = light; // Constructor ile lamba nesnesi atanır.
    }

    public void Execute()
    {
        _light.TurnOn(); // Lamba açma işlemi gerçekleştirilir.
    }
}

// Concrete Command – Lamba kapama komutu
public class TurnOffCommand : ICommand
{
    private Light _light; // Lamba nesnesini tutan değişken

    public TurnOffCommand(Light light)
    {
        _light = light; // Constructor ile lamba nesnesi atanır.
    }

    public void Execute()
    {
        _light.TurnOff(); // Lamba kapama işlemi gerçekleştirilir.
    }
}

// Invoker – Komutu tetikleyen sınıf
public class RemoteControl
{
    private ICommand _command; // Komut nesnesini tutan değişken

    public void SetCommand(ICommand command)
    {
        _command = command; // Verilen komut atanır.
    }

    public void PressButton()
    {
        _command.Execute(); // Butona basıldığında komut gerçekleştirilir.
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        Light light = new Light(); // Yeni bir lamba nesnesi oluşturulur.

        ICommand turnOn = new TurnOnCommand(light); // Lamba açma komutu oluşturulur.
        ICommand turnOff = new TurnOffCommand(light); // Lamba kapama komutu oluşturulur.

        RemoteControl remote = new RemoteControl(); // Uzaktan kumanda nesnesi oluşturulur.

        Console.WriteLine("--- Uzaktan Kumanda: AÇ ---");
        remote.SetCommand(turnOn); // Açma komutu uzaktan kumandaya atanır.
        remote.PressButton(); // Butona basılarak lamba açılır.

        Console.WriteLine("--- Uzaktan Kumanda: KAPAT ---");
        remote.SetCommand(turnOff); // Kapama komutu uzaktan kumandaya atanır.
        remote.PressButton(); // Butona basılarak lamba kapatılır.
    }
}
