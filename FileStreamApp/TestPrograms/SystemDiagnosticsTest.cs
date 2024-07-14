using FileStreamApp;

namespace TestApp.TestPrograms;

public class SystemDiagnosticsTest : ITestProgram
{
    public void Run()
    {
        Console.WriteLine("--------------Process-----------------------------");
        var proc = Process.GetProcessesByName("VisualStudio")[0]; // для MacOS
        var modules = proc.Modules;

        foreach (ProcessModule module in modules)
            Console.WriteLine($"Name: {module.ModuleName}  FileName: {module.FileName}");

        Console.WriteLine("--------------AppDomain-----------------------------");
        var domain = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {domain.FriendlyName}");
        Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
        Console.WriteLine();

        var assemblies = domain.GetAssemblies();
        foreach (var asm in assemblies)
            Console.WriteLine(asm.GetName().Name);
    }
}