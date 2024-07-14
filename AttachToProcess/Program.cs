// See https://aka.ms/new-console-template for more information

using AttachToProcess;

var ac = new AttachedTestClass();


Console.ReadLine();

// call AttachedTestClass
ac.DebugMethod();