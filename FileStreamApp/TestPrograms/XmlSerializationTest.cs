using System.Xml.Serialization;

namespace FileStreamApp.TestPrograms;

public class XmlSerializationTest : ITestProgram
{
    public void Run()
    {
        var car = new Car
        {
            Speed = 5,
            Wheels = 4,
            Radio = new Radio
            {
                Volume = 2
            }
        };

        var listOfCars = new[] { car, car };

        var xs = new XmlSerializer(typeof(Car[]));
        using var fs = File.Create("XmlSerializationTest");
        xs.Serialize(fs, listOfCars);
        Console.WriteLine("Car saved to xml");
    }

    public class Car
    {
        [XmlAttribute] public int Speed { get; set; }
        [XmlAttribute] public int Wheels { get; set; }

        public Radio Radio { get; set; }
    }

    public class Radio
    {
        public int Volume { get; set; }
    }
}