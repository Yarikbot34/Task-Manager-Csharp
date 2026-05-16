using System;
namespace TaskManager;


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            foreach (Target t in Target.targets)
            {
                Console.WriteLine(t.ToString());
            }
            string ch = Console.ReadLine();
            if (ch == "q"){break;}
            if (ch == "add"){addTarget();}
        }
    }

    static void addTarget()
    {
        Console.Write("Название цели: ");
        string name = Console.ReadLine();
        Console.Write("Описание цели: ");
        string description = Console.ReadLine();
        Target target = new Target(name, description,  DateTime.Now.AddDays(5));
    }
}