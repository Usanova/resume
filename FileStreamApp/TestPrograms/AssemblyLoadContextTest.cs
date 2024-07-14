using System.Reflection;
using System.Runtime.Loader;
using FileStreamApp;

namespace TestApp.TestPrograms;

using System;

public class AssemblyLoadContextTest : ITestProgram
{
    public void Run()
    {
        Square(8);
// очистка памяти
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine();
// смотрим, какие сборки после выгрузки
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            Console.WriteLine(asm.GetName().Name);
    }

    private void Square(int number)
    {
        var context = new AssemblyLoadContext("Square", true);
        // установка обработчика выгрузки
        context.Unloading += Context_Unloading;

        // получаем путь к сборке MyApp
        var assemblyPath = @"/Users/usanovaanastasia/Projects/resumr/MyApp/bin/Debug/net8.0/MyApp.dll";
        // загружаем сборку
        var assembly = context.LoadFromAssemblyPath(assemblyPath);

        // получаем тип Program из сборки MyApp.dll
        var type = assembly.GetType("MyApp.Program");
        if (type != null)
        {
            // получаем его метод Square
            var squareMethod = type.GetMethod("Square", BindingFlags.Static | BindingFlags.NonPublic);
            // вызываем метод
            var result = squareMethod?.Invoke(null, new object[] { number });
            if (result is int)
                // выводим результат метода на консоль
                Console.WriteLine($"Квадрат числа {number} равен {result}");
        }

        // смотим, какие сборки у нас загружены
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            Console.WriteLine(asm.GetName().Name);

        // выгружаем контекст
        context.Unload();
    }

// обработчик выгрузки контекста
    private void Context_Unloading(AssemblyLoadContext obj)
    {
        Console.WriteLine("Библиотека MyApp выгружена");
    }
}