namespace Animals;

public class Cat
{
    public void SayMeow()
    {
        Console.WriteLine("Meow!");
    }

    public void SayMeow(int times)
    {
        for (var i = 0; i < times; i++)
            Console.Write("Meow! ");
        Console.WriteLine();
    }
}