using System;
using System.Collections.Generic;

// Bileşen arayüzü (Component)
// Bu arayüz, dosya sistemi öğelerinin ortak bir davranışını tanımlar. 
// Her öğe, kendisini görüntülemek için bir Display metodu sağlar.
public interface IFileSystemItem
{
    void Display(string indent = "");
}

// Yaprak sınıf (Leaf) – Dosya
// Dosya sınıfı, IFileSystemItem arayüzünü uygular ve bir dosyanın adını tutar. 
// Display metodu, dosya adını görüntüler.
public class File : IFileSystemItem
{
    public string Name { get; set; }

    public File(string name)
    {
        Name = name;
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}- Dosya: {Name}");
    }
}

// Bileşik sınıf (Composite) – Klasör
// Klasör sınıfı, IFileSystemItem arayüzünü uygular ve içinde birden fazla dosya veya klasör tutabilir. 
// AddItem metodu, yeni bir öğe eklemek için kullanılır. Display metodu, klasör adını ve içindeki öğeleri görüntüler.
public class Directory : IFileSystemItem
{
    public string Name { get; set; }
    private List<IFileSystemItem> _items = new List<IFileSystemItem>();

    public Directory(string name)
    {
        Name = name;
    }

    public void AddItem(IFileSystemItem item)
    {
        _items.Add(item);
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}+ Klasör: {Name}");
        foreach (var item in _items)
        {
            item.Display(indent + "  ");
        }
    }
}

// Kullanım
// Program sınıfı, dosya ve klasörleri oluşturur ve bunları bir hiyerarşi içinde düzenler. 
// Ana klasör, dosyaları ve alt klasörleri içerir. Display metodu ile tüm yapıyı görüntüler.
public class Program
{
    public static void Main(string[] args)
    {
        // Dosyalar
        var file1 = new File("belge.txt");
        var file2 = new File("foto.jpg");
        var file3 = new File("muzik.mp3");

        // Klasörler
        var musicFolder = new Directory("Müzikler");
        musicFolder.AddItem(file3);

        var root = new Directory("Ana Klasör");
        root.AddItem(file1);
        root.AddItem(file2);
        root.AddItem(musicFolder);

        // Görüntüleme
        root.Display();
    }
}
