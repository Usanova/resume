using System.Xml.Linq;
using FileStreamApp;

namespace TestApp.TestPrograms;

public class LinqXmlTest : ITestProgram
{
    public void Run()
    {
        var doc =
            new XElement("Families",
                new XElement("Virus", "Ploxoy"),
                new XElement("Malyshevy", new XAttribute("count", 5),
                    new XElement("Serezha", "Vesely"),
                    new XElement("Nastya", "Vredny"),
                    new XElement("Tuch", "Igrivy"),
                    new XElement("Virus", "Ploxoy")));
        Console.WriteLine(doc);
        Console.WriteLine();
        doc.Descendants("Virus").Remove();
        Console.WriteLine(doc);
    }
}