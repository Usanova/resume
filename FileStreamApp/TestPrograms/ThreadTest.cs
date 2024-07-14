using FileStreamApp;

namespace TestApp.TestPrograms;

public class ThreadTest : ITestProgram
{
    private readonly bool _isBackground;

    public ThreadTest(bool isBackground)
    {
        _isBackground = isBackground;
    }

    public void Run()
    {
        var t = new Thread(Worker);
        t.IsBackground = _isBackground;
        t.Start();
        Console.WriteLine("Return from main");
    }

    private void Worker()
    {
        Thread.Sleep(10000);
        Console.WriteLine("Returning from worker");
    }
}