using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;


int[] a = { 1, 2, 3 };
var en = MyEnum.one;
Console.WriteLine(typeof(MyEnum));

var val = Enum.GetValues<MyEnum>();
PrintEnum(val);

Point p;
p.X = 9;

var al = new ArrayList();
al.AddRange(new[] { "ss", "ff" });

var td = new TestDelegate(Test1);
td += delegate { return 1; };
td += i => { return 1; };
td += Test1;
//return 2
Console.WriteLine(td(0));
TestDelegateParametr(Test1);

td = TestLocalVarDelegate();
TestLocalVarDelegate2();
Console.WriteLine(td(0));
Console.WriteLine(td(0));
Console.WriteLine(td(0));

static TestDelegate TestLocalVarDelegate()
{
    var u = 4;
    TestDelegate d = delegate { return u++; };
    u++;
    return d;
}

static void TestLocalVarDelegate2()
{
    var k = 5;
    var array = new int[10];
    Console.WriteLine(k);
}

static void TestDelegateParametr(TestDelegate tg)
{
    Console.WriteLine();
}


var person1 = new { Name = "Tom", Age = 55 };
var person2 = new { Name = "Tom", Age = 55 };
var person3 = new { Nik = "Tom", Age = 55 };
Console.WriteLine(person1.Equals(person2)); // true
Console.WriteLine(person1.Equals(person3)); // false

var point = new Point();
Console.WriteLine(new ToStringClass());
int[] array = null;
var tc = new TestClass();
try
{
    ThrowException();
}
catch (MyException e)
{
    Console.WriteLine(e.StackTrace);
    Console.WriteLine(e.InnerException.StackTrace);
}

var arrayLINQ = new[] { "ggg g", "hhhh h", "aaa", "fff f", "bbb" };
var LINQRes_ = from ar in arrayLINQ
    where ar.Contains(" ")
    select new { g = ar };
var LINQRes = arrayLINQ.Where(ar => ar.Contains(" "));
Console.WriteLine(LINQRes.GetType().Name);
var process = Process.GetCurrentProcess();
Console.WriteLine($"{process.Id} {process.ProcessName}");
GetProcessThreads(process.Id);

var myObject = new MyObject();
var bf = new BinaryFormatter();
Stream oStream = new FileStream(@"/Users/usanovaanastasia/Desktop/книги/по программированию/просто/просто.txt",
    FileMode.Create);
bf.Serialize(oStream, myObject); // a = 111; b = 112;
oStream.Position = 0;
myObject = (MyObject)bf.Deserialize(oStream); //


var type = Type.GetType(nameof(TestClass));
foreach (var mi in type.GetMethods()) Console.WriteLine(mi);

var attributeName = type.GetCustomAttributes(false)
    .Select(a => a as MyAttribute)
    .Where(a => a != null)
    .Select(a => a.Text)
    .Single(); // lalalala

var testClassSerrialize = new TestClass();
var testClassSerrializeJson = JsonSerializer.Serialize(testClassSerrialize);


var p1 = new Point[3];
Console.WriteLine(p1[0].X);
Animal tuch = new Tuch();
Console.WriteLine(tuch is Cit);
Console.WriteLine(tuch is Tuch);
TestClass tcc = "Sss";
string s = "tcc";
var t1c = new Test1Class();
var testDelegate = new TestDelegate(t1c.Test1);
string nullStr = null;
Console.WriteLine($"Document not found. CompanyDocId: '{nullStr}'");
testDelegate += Test1;
Delegate d = testDelegate;
Console.WriteLine($"{d.Method} {d.Target}");
foreach (var del in d.GetInvocationList()) Console.WriteLine($"{del.Method} {del.Target}");
try
{
    Throw2();
}
catch (Exception e)
{
    Console.WriteLine(e.StackTrace);
}

var u = new[] { 1 };
u = null;
Console.WriteLine("-----------");
Console.WriteLine(u?.ToList().ToArray());
//TODO: сделай нормально, а плохо убери
Debug.Assert(0 > 5, "zero less than five");


Console.ReadLine();

static void Throw2()
{
    Throw1();
}

//FIXME: поправь меня
static void Throw1()
{
    throw new Exception();
}

static void TestEnumMethod(MyEnum e)
{
    Console.WriteLine(e);
}

static int Test1(int i)
{
    Console.WriteLine("Test1");
    return 1;
}

static int Test2(int i)
{
    Console.WriteLine("Test2");
    return 2;
}

static void ThrowInnerException()
{
    throw new InnerException();
}

static void ThrowException()
{
    try
    {
        ThrowInnerException();
    }
    catch (InnerException e)
    {
        throw new MyException(e);
    }
}

static void GetProcessThreads(int pid)
{
    var p = Process.GetProcessById(pid);
    foreach (ProcessThread t in p.Threads) Console.WriteLine($"{t.Id} {t.BasePriority}");

    foreach (ProcessModule t in p.Modules) Console.WriteLine($"{t.ModuleName}");
}

void PrintEnum(MyEnum[] myEnums)
{
    foreach (var v in myEnums) Console.WriteLine($"{v} - {(byte)v}");
    List<TestClass> list;

    {
        Console.WriteLine();
    }
}


public delegate int TestDelegate(int i);

internal enum MyEnum : byte
{
    one,
    two
}

internal struct Point
{
    public Point()
    {
        X = 1;
        Y = 2;
    }

    public int X;
    public int Y;
}

public class Test1Class
{
    public int Test1(int i)
    {
        Console.WriteLine("Test1");
        return 1;
    }
}

public class TPointCollection : IEnumerable
{
    private Point[] _points;

    public string Name { get; set; }

    public IEnumerator GetEnumerator()
    {
        foreach (var p in _points) yield return p;

        foreach (var p in _points) yield return p;
        var t = 0;
    }
}

internal class A
{
}

internal class ToStringClass
{
}

[MyAttribute(Text = "lalalala")]
internal class TestClass : IShape
{
    public static string Warning = "warning";
    public string s;

    public TestClass()
    {
        Property = "property";
    }

    public A a { get; set; } = new();
    public string Property { get; }

    int IShape.Points
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public event TestDelegate TestEvent;

    public void Testing()
    {
        TestEvent(0);
    }

    public static implicit operator TestClass(string s)
    {
        return new TestClass();
    }

    public static implicit operator string(TestClass s)
    {
        return s.Property;
    }

    public static explicit operator TestClass(int s)
    {
        return new TestClass();
    }

    public static explicit operator int(TestClass s)
    {
        return 1;
    }

    ~TestClass()
    {
        Console.Beep();
    }
}

[Serializable]
public class MyObject : ISerializable
{
    public int a;
    public int b;

    protected MyObject(SerializationInfo serializationInfo, StreamingContext streamingContext)
    {
        a = serializationInfo.GetInt32("a");
        b = 112;
    }

    public MyObject()
    {
        a = 1;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("a", 111);
        info.AddValue("b", "bbb");
    }

    [OnSerializing]
    internal void OnSerializingMethod(StreamingContext context)
    {
        b = 3;
        a = 1;
    }
}

internal static class MyExtensions
{
    public static void Extensions(this TestClass tc)
    {
        Console.WriteLine(tc);
    }
}

internal interface IShape
{
    public int Points { get; set; }
}

public class InnerException : Exception
{
}

public class MyException : Exception
{
    public MyException(Exception innerException) : base("", innerException)
    {
    }
}


public class MyAttribute : Attribute
{
    public string Text { get; set; }
}

public class Animal
{
}

public class Cit : Animal
{
}

[Serializable]
[DebuggerDisplay("FirstName={FirstName}, LastName={LastName}")]
public class Tuch : Cit
{
}