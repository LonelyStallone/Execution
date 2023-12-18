using System.Diagnostics;
using System.Reflection;

string path = @"..\..\..\..\Excecution.Test\bin\Debug\net6.0\Excecution.Test.dll";
FileInfo fileInfo = new FileInfo(path);

Assembly asm = Assembly.LoadFile(fileInfo.FullName); 

foreach (Type type in asm.GetTypes())
{
    Console.WriteLine(type.FullName);
}

StackTrace stackTrace = new StackTrace();

// Get all the stack frames
StackFrame[] stackFrames = stackTrace.GetFrames();

// Iterate through the stack frames and print the method names
foreach (StackFrame stackFrame in stackFrames)
{
    Console.WriteLine(stackFrame.GetMethod().Name);
}