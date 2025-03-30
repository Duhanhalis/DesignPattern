// Singleton
public class Logger
{
    // Logger sınıfının tekil örneğini tutmak için kullanılan özel bir değişkendir. 
    // Bu değişken, Logger sınıfının yalnızca bir kez oluşturulmasını ve 
    // uygulama boyunca bu örneğin kullanılmasını sağlar.
    private static Logger _instance;
    
    // Bu değişken, Logger sınıfının örneğini oluştururken çoklu iş parçacıklarının (thread) aynı anda erişimini kontrol etmek için kullanılır.
    private static readonly object _lock = new object();

    // Private constructor
    private Logger() { }

    // Static method to get the instance
    public static Logger GetInstance()
    {
        // Eğer örnek yoksa, yeni bir örnek oluştur
        if (_instance == null)
        {
            // Çoklu iş parçacıklarının aynı anda erişimini kontrol etmek için lock kullanılır
            lock (_lock)
            {
                // Eğer örnek yine yoksa, yeni bir örnek oluştur
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}
