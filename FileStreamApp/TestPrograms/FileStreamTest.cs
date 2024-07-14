using System.Text;

namespace FileStreamApp.TestPrograms;

public class FileStreamTest : ITestProgram
{
    public void Run()
    {
        using var fs = File.Create(@"MyMessage.txt");

        var s = "Hello world!";
        var writedBytes = Encoding.Default.GetBytes(s);
        fs.Write(writedBytes);

        fs.Position = 0;

        var readedBytes = new byte[fs.Length];
        fs.Read(readedBytes, 0, (int)fs.Length);

        var resultString = Encoding.Default.GetString(readedBytes);

        Console.WriteLine(resultString);

        var fileInfo = new FileInfo(@".\MyMessage.txt");
        Console.WriteLine(fileInfo.FullName);
    }
}