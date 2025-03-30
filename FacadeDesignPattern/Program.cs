using System;

// Alt sistemler (subsystems)
public class VideoLoader
{
    // Video dosyasını yükleyen metot.
    public void Load(string fileName)
    {
        Console.WriteLine($"{fileName} dosyası yüklendi.");
    }
}

public class VideoDecoder
{
    // Video dosyasını çözümlenmesini sağlayan metot.
    public void Decode(string fileName)
    {
        Console.WriteLine($"{fileName} dosyası çözümlendi.");
    }
}

public class VideoEncoder
{
    // Video dosyasını belirli bir formatta kodlayan metot.
    public void Encode(string format)
    {
        Console.WriteLine($"Video {format} formatında kodlandı.");
    }
}

public class VideoSaver
{
    // Kodlanmış video dosyasını kaydeden metot.
    public void Save(string outputName)
    {
        Console.WriteLine($"{outputName} başarıyla kaydedildi.");
    }
}

// Facade
public class VideoConverter
{
    // Video dönüştürme işlemi için gerekli alt sistem nesneleri.
    private VideoLoader _loader = new VideoLoader();
    private VideoDecoder _decoder = new VideoDecoder();
    private VideoEncoder _encoder = new VideoEncoder();
    private VideoSaver _saver = new VideoSaver();

    // Video dönüştürme sürecini yöneten metot.
    public void ConvertVideo(string inputFileName, string outputFileName, string format)
    {
        _loader.Load(inputFileName); // Dosyayı yükle.
        _decoder.Decode(inputFileName); // Dosyayı çözümlen.
        _encoder.Encode(format); // Dosyayı kodla.
        _saver.Save(outputFileName); // Dosyayı kaydet.
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        VideoConverter converter = new VideoConverter(); // Video dönüştürücü nesnesi oluştur.

        Console.WriteLine("--- Video Dönüştürme Başladı ---");
        converter.ConvertVideo("film.mp4", "film_converted.avi", "AVI"); // Video dönüştürme işlemi.
        Console.WriteLine("--- Video Dönüştürme Bitti ---");
    }
}
