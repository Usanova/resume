// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization;
using ProtoBuf;

Console.WriteLine("Hello, World!");

var a = new A { One = 1, Two = "two" };

using var steam = new MemoryStream();
Serializer.Serialize(steam, a);
var a_byte = steam.ToArray();

using var stream = new MemoryStream(a_byte);
var b = Serializer.Deserialize<B>(stream);

using var steamB = new MemoryStream();
Serializer.Serialize(steamB, b);
var b_byte = steam.ToArray();

using var streamB2 = new MemoryStream(b_byte);
var b2 = Serializer.Deserialize<B>(streamB2);

Console.WriteLine($"{b.One} {b.Two}");


[DataContract]
internal class A
{
    [DataMember(Order = 1)] public int One { get; set; }

    [DataMember(Order = 2)] public string Two { get; set; }
}

[DataContract]
internal class C
{
    [DataMember(Order = 1)] public double Three { get; set; }
}

[DataContract]
internal class B
{
    [DataMember(Order = 1)] public int One { get; set; }

    [DataMember(Order = 2)] public string Two { get; set; }

    [DataMember(Order = 3)] public int[] Three { get; set; }
}