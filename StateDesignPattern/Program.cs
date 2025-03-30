using System;

// State arayüzü: Medya oynatıcı durumlarını tanımlamak için bir arayüz
public interface IPlayerState
{
    void PressPlay(MediaPlayer player); // Oynat tuşuna basıldığında çağrılan metot
}

// Concrete State – Durdurulmuş durumda: Müzik duraklatıldığında bu durum kullanılır
public class StoppedState : IPlayerState
{
    public void PressPlay(MediaPlayer player)
    {
        Console.WriteLine("Müzik oynatılıyor."); // Kullanıcıya müziğin oynatıldığı bilgisi verilir
        player.SetState(new PlayingState()); // Oynatma durumuna geçiş yapılır
    }
}

// Concrete State – Oynatılıyor: Müzik çalarken bu durum kullanılır
public class PlayingState : IPlayerState
{
    public void PressPlay(MediaPlayer player)
    {
        Console.WriteLine("Müzik duraklatıldı."); // Kullanıcıya müziğin duraklatıldığı bilgisi verilir
        player.SetState(new PausedState()); // Duraklatma durumuna geçiş yapılır
    }
}

// Concrete State – Duraklatılmış durumda: Müzik duraklatıldığında bu durum kullanılır
public class PausedState : IPlayerState
{
    public void PressPlay(MediaPlayer player)
    {
        Console.WriteLine("Müzik devam ediyor."); // Kullanıcıya müziğin devam ettiği bilgisi verilir
        player.SetState(new PlayingState()); // Oynatma durumuna geri geçiş yapılır
    }
}

// Context: Medya oynatıcı sınıfı, mevcut durumu yönetir
public class MediaPlayer
{
    private IPlayerState _state; // Mevcut durumu tutan değişken

    public MediaPlayer()
    {
        // Başlangıç durumu: Medya oynatıcı ilk açıldığında duraklatılmış durumdadır
        _state = new StoppedState();
    }

    public void SetState(IPlayerState state)
    {
        _state = state; // Mevcut durumu günceller
    }

    public void PressPlay()
    {
        _state.PressPlay(this); // Mevcut duruma göre PressPlay metodu çağrılır
    }
}

// Kullanım: Programın başlangıç noktası
public class Program
{
    public static void Main(string[] args)
    {
        MediaPlayer player = new MediaPlayer(); // Yeni bir medya oynatıcı oluşturulur

        Console.WriteLine("--- Oynat tuşuna basılıyor ---");
        player.PressPlay(); // Stopped → Playing

        Console.WriteLine("--- Tekrar oynat tuşuna basılıyor ---");
        player.PressPlay(); // Playing → Paused

        Console.WriteLine("--- Tekrar oynat tuşuna basılıyor ---");
        player.PressPlay(); // Paused → Playing
    }
}
