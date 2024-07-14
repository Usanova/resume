using FileStreamApp;

namespace TestApp.TestPrograms;

using System;
using System.Linq;

public class DebugFeatures : ITestProgram
{
    public void Run()
    {
        var names = new[] { "Sergei", "Misha", "Andrey" };
        var random = new Random();
        var people =
            Enumerable.Range(0, 25)
                .Select(i => new Man(names[random.Next(names.Length)], random.Next(50)))
                .ToArray();
        Debugger.Break();
        Console.WriteLine("sjsjs");
        for (var i = 0; i < 10000; i++)
        {
            var y = new Random().Next(1000);
        }
    }

    [DebuggerDisplay("Name = {Name}, Age = {Age}")]
    internal class Man
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public Man(string name, int age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        ///     Age.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        ///     Name.
        /// </summary>
        public string Name { get; private set; }
    }
}