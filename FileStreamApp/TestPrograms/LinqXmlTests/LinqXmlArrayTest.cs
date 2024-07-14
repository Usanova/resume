using System.Xml.Linq;
using FileStreamApp;

namespace TestApp.TestPrograms;

public class LinqXmlArrayTest : ITestProgram
{
    public void Run()
    {
        var persons = new[]
        {
            new { Name = "Serezha", Age = 30 },
            new { Name = "Nastya", Age = 24 }
        };

        var x = new XElement("Persons",
            from p in persons
            select new XElement("Person",
                new XElement("Name", p.Name),
                new XElement("Age", p.Age)));

        Console.WriteLine(x);
    }
}