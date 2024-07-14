namespace MyApp;

public class Program
{
    private static void Main(string[] args)
    {
        var number = 5;
        var result = Square(number);
        Console.WriteLine($"Квадрат {number} равен {result}");
    }

    private static int Square(int n)
    {
        return n * n;
    }
}