public class Program
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("İlk log mesajı.");
        logger2.Log("İkinci log mesajı.");

        Console.WriteLine($"logger1 ve logger2 aynı mı? {(logger1 == logger2 ? "Evet" : "Hayır")}");
    }
}
