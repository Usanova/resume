// See https://aka.ms/new-console-template for more information

var two = new A(2);

var array = new[] { new A(1), two, new A(3), new A(4) };
var evens = array.Where(m => m.Value % 2 == 0);

two.Value = 3;

foreach (var a in evens) Console.WriteLine(a);
Console.WriteLine();

two.Value = 2;

foreach (var a in evens) Console.WriteLine(a);

Console.WriteLine();


internal class A
{
    public A(int num)
    {
        Num = num;
        Value = num;
    }

    public int Value { get; set; }

    public int Num { get; set; }

    public override string ToString()
    {
        return $"{Value}:{Num}";
    }
}