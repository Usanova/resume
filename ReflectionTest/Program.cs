// See https://aka.ms/new-console-template for more information

using System.Reflection;

Console.WriteLine("Hello, World!");
var a = Assembly.LoadFrom(@"/Users/usanovaanastasia/Projects/resumr/ReflectionTest/bin/Debug/net7.0/Animals.dll");
var catType = a.GetType("Animals.Cat");
var cat = Activator.CreateInstance(catType);
var mi = catType.GetMethod("SayMeow", new Type[0]);
mi.Invoke(cat, new object[0]);
mi = catType.GetMethod("SayMeow", new[] { typeof(int) });
mi.Invoke(cat, new object[] { 4 });
Console.ReadLine();