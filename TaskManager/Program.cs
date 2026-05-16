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
            if (ch == "time"){setTime();}
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

    enum calendar
    {
        year,
        month,
        day,
        hour,
        minute,
    }

    static DateTime setTime()
    {
        DateTime now = DateTime.Now;
        int[] targetTime = new int[5];
        targetTime[(int)calendar.year] = now.Year;
        targetTime[(int)calendar.month] = now.Month;
        targetTime[(int)calendar.day] = now.Day;
        targetTime[(int)calendar.hour] = now.Hour;
        targetTime[(int)calendar.minute] = now.Minute;
        byte focus = 0;
        bool process = true;
        while (process)
        {
            Console.Clear();
            Console.WriteLine($"{targetTime[0]}|{targetTime[1]}|{targetTime[2]}|{targetTime[3]}:{targetTime[4]}"); 
            ConsoleKey ch = Console.ReadKey().Key;
            
            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    targetTime[focus] += 1;
                    break;
                case ConsoleKey.DownArrow:
                    targetTime[focus] -= 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (focus > 0){focus -= 1;}
                    break;
                case ConsoleKey.RightArrow:
                    if (focus < 4){focus += 1;}
                    break;
                case ConsoleKey.Escape:
                    process = false;
                    break;
            }
        }
        DateTime target =  new DateTime(targetTime[0], targetTime[1], targetTime[2], targetTime[3], targetTime[4], 0);
        return target;
    }


}