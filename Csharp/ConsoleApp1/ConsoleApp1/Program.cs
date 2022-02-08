// See https://aka.ms/new-console-template for more information

using ConsoleApp1.qq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Person p1 = new Person("joe", 19, 163.0, 80); // new Person()

        Console.WriteLine(p1._age);
        p1.SayHi();
        Console.WriteLine(p1.IsAdult());
        p1 = new Person("Mary", 15, 152.0, 40);
        p1.SayHi();
        Console.WriteLine(p1.IsAdult());
        Console.WriteLine(p1.Height);
        Console.WriteLine(p1.Width);
        Console.WriteLine(p1.getAmount());

        Tool.SayHi();

        Student s1 = new Student("hao", "singsisn", 18, 179.0, 70);

        Console.WriteLine(p1.getAmount());
        Console.WriteLine(s1.getSchool());
    }
}


