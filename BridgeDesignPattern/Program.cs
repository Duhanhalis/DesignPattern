using System;

// Implementor (arayüz)
// Bu arayüz, şekil çizim işlemlerini gerçekleştiren sınıflar için bir temel sağlar.
public interface IDrawingAPI
{
    void DrawCircle(double x, double y, double radius);
    void DrawSquare(double x, double y, double sideLength);
}

// Concrete Implementor 1
// Vektörel çizim yapabilen bir sınıf. Çember ve kare çizim işlemlerini gerçekleştirir.
public class VectorDrawing : IDrawingAPI
{
    public void DrawCircle(double x, double y, double radius)
    {
        Console.WriteLine($"[Vektörel] Çember çizildi. Merkez: ({x}, {y}), Yarıçap: {radius}");
    }

    public void DrawSquare(double x, double y, double sideLength)
    {
        Console.WriteLine($"[Vektörel] Kare çizildi. Köşe: ({x}, {y}), Kenar: {sideLength}");
    }
}

// Concrete Implementor 2
// Pikselli çizim yapabilen bir sınıf. Çember ve kare çizim işlemlerini gerçekleştirir.
public class RasterDrawing : IDrawingAPI
{
    public void DrawCircle(double x, double y, double radius)
    {
        Console.WriteLine($"[Pikselli] Çember çizildi. Merkez: ({x}, {y}), Yarıçap: {radius}");
    }

    public void DrawSquare(double x, double y, double sideLength)
    {
        Console.WriteLine($"[Pikselli] Kare çizildi. Köşe: ({x}, {y}), Kenar: {sideLength}");
    }
}

// Abstraction
// Şekil sınıfı, çizim API'sini kullanarak şekil çizmeyi sağlar.
public abstract class Shape
{
    protected IDrawingAPI _drawingAPI;

    protected Shape(IDrawingAPI drawingAPI)
    {
        _drawingAPI = drawingAPI;
    }

    public abstract void Draw();
}

// Refined Abstraction 1
// Çember şekli için özel bir sınıf. Çizim işlemi için gerekli bilgileri tutar.
public class Circle : Shape
{
    private double _x, _y, _radius;

    public Circle(double x, double y, double radius, IDrawingAPI drawingAPI)
        : base(drawingAPI)
    {
        _x = x;
        _y = y;
        _radius = radius;
    }

    public override void Draw()
    {
        _drawingAPI.DrawCircle(_x, _y, _radius);
    }
}

// Refined Abstraction 2
// Kare şekli için özel bir sınıf. Çizim işlemi için gerekli bilgileri tutar.
public class Square : Shape
{
    private double _x, _y, _side;

    public Square(double x, double y, double side, IDrawingAPI drawingAPI)
        : base(drawingAPI)
    {
        _x = x;
        _y = y;
        _side = side;
    }

    public override void Draw()
    {
        _drawingAPI.DrawSquare(_x, _y, _side);
    }
}

// Kullanım
// Program sınıfı, şekilleri çizmek için gerekli nesneleri oluşturur ve çizer.
public class Program
{
    public static void Main(string[] args)
    {
        Shape circle = new Circle(5, 10, 7, new VectorDrawing());
        Shape square = new Square(0, 0, 15, new RasterDrawing());

        Console.WriteLine("--- Şekiller Çiziliyor ---");
        circle.Draw();
        square.Draw();
    }
}
