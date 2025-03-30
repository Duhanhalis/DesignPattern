using System;

// Strategy arayüzü, ödeme yöntemlerini tanımlamak için kullanılır.
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// Concrete Strategy – Kredi Kartı, kredi kartı ile ödeme işlemini gerçekleştirir.
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Kredi kartıyla {amount} TL ödendi.");
    }
}

// Concrete Strategy – PayPal, PayPal ile ödeme işlemini gerçekleştirir.
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"PayPal ile {amount} TL ödendi.");
    }
}

// Concrete Strategy – Kripto para, kripto para ile ödeme işlemini gerçekleştirir.
public class CryptoPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Kripto para ile {amount} TL ödendi.");
    }
}

// Context – Ödeme işlemini yöneten sınıf, hangi ödeme stratejisinin kullanılacağını belirler.
public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    // Ödeme stratejisini ayarlamak için kullanılır.
    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    // Ödeme işlemini gerçekleştirmek için kullanılır.
    public void ExecutePayment(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("Lütfen bir ödeme yöntemi seçin.");
            return;
        }

        _paymentStrategy.Pay(amount);
    }
}

// Kullanım
public class Program
{
    public static void Main(string[] args)
    {
        var paymentContext = new PaymentContext();

        Console.WriteLine("--- Kredi Kartı ile Ödeme ---");
        paymentContext.SetPaymentStrategy(new CreditCardPayment());
        paymentContext.ExecutePayment(250);

        Console.WriteLine("\n--- PayPal ile Ödeme ---");
        paymentContext.SetPaymentStrategy(new PayPalPayment());
        paymentContext.ExecutePayment(150);

        Console.WriteLine("\n--- Kripto Para ile Ödeme ---");
        paymentContext.SetPaymentStrategy(new CryptoPayment());
        paymentContext.ExecutePayment(1000);
    }
}
