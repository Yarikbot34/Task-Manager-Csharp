using System;
using System.Runtime.InteropServices.ComTypes;

namespace TaskManager;


class Program
{
    static void Main(string[] args)
    {
        Target.LoadFromFile();
        int focusTarget = 0;
        Target.targets[focusTarget].inFocus = true;
        while (true)
        {
            bool targetsNotNull = Target.targets.Count > 0;
            Console.Clear();
            Console.WriteLine("Текущие задачи. Для навигации используйте стрелки вверх и вниз\nРедактировать заметку R; Новая заметка N; Удалить заметку D;\n Выйти Q");
            if (targetsNotNull)
            {
                foreach (Target t in Target.targets)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            else
            {
                Console.WriteLine("Нет заметок для отображения");
            }

            ConsoleKey ch = Console.ReadKey(true).Key;
            if (ch == ConsoleKey.UpArrow && focusTarget > 0 && targetsNotNull)
            {
                Target.targets[focusTarget].inFocus = false;
                focusTarget--;
                Target.targets[focusTarget].inFocus = true;
            }
            else if (ch == ConsoleKey.DownArrow && focusTarget < Target.targets.Count - 1 && targetsNotNull)
            {
                Target.targets[focusTarget].inFocus = false;
                focusTarget++;
                Target.targets[focusTarget].inFocus = true;
            }
            else if (ch == ConsoleKey.N)
            {
                addTarget();
            }
            else if (ch == ConsoleKey.D && targetsNotNull)
            {
                Target.targets.RemoveAt(focusTarget);
                focusTarget--;
            }
            else if (ch == ConsoleKey.R && targetsNotNull)
            {
                editTarget(focusTarget);
            }
        }
    }

    static void addTarget()
    {
        Console.Write("Название цели: ");
        string name = Console.ReadLine();
        Console.Write("Описание цели: ");
        string description = Console.ReadLine();
        DateTime end = setTime();
        Target target = new Target(name, description,  end);
    }


    static void editTarget(int focus)
    {
        int editFocus = 0;
        string[] options = new string[4]{"Изменить название","Изменить описание", "Изменить конечную дату", "Выход"};
        while (true)
        {
            Console.Clear();
            Console.WriteLine(Target.targets[focus].ToString());
            for (int i = 0; i < options.Length; i++)
            {
                if (editFocus == i)
                {
                    Console.WriteLine("▓" + options[i]);
                }
                else
                {
                    Console.WriteLine("░" + options[i]);
                }
            }
            ConsoleKey editCh = Console.ReadKey(true).Key;
            if (editCh == ConsoleKey.UpArrow && editFocus > 0)
            {
                editFocus--;
            } else if (editCh == ConsoleKey.DownArrow && editFocus < 3)
            {
                editFocus++;
            } else if (editCh == ConsoleKey.Enter)
            {
                switch (editFocus)
                {
                    case 0:
                        Console.WriteLine("Введите новое имя заметки");
                        Target.targets[focus].setName(Console.ReadLine());
                        break;
                    case 1:
                        Console.WriteLine("Введите описание для заметки");
                        Target.targets[focus].setDesc(Console.ReadLine());
                        break;
                    case 2:
                        Target.targets[focus].setTargetDate(setTime());
                        break;
                    case 3:
                        return;
                }

                ;
            }
        }
    }
    
    
    static DateTime setTime()
    {
        
        DateTime now = DateTime.Now;
        int[] targetTime = new int[5];
        targetTime[0] = now.Year;
        targetTime[1] = now.Month;
        targetTime[2] = now.Day;
        targetTime[3] = now.Hour;
        targetTime[4] = now.Minute;
        byte focus = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Установите срок задачи | Нажмите Enter для подтверждения");
            Console.WriteLine($"{targetTime[0]}|{targetTime[1]}|{targetTime[2]}|{targetTime[3]}:{targetTime[4]}");
            PrintCursor(targetTime, focus);
            ConsoleKey ch = Console.ReadKey().Key;

            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    targetTime[focus] = calcBorder(targetTime[focus] + 1, focus);
                    break;
                case ConsoleKey.DownArrow:
                    targetTime[focus] = calcBorder(targetTime[focus] - 1, focus);
                    break;
                case ConsoleKey.LeftArrow:
                    if (focus > 0)
                    {
                        focus -= 1;
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (focus < 4)
                    {
                        focus += 1;
                    }

                    break;
                case ConsoleKey.Enter:
                    try
                    {
                        DateTime target = new DateTime(targetTime[0], targetTime[1], targetTime[2], targetTime[3],
                            targetTime[4], 0);
                        if (target < DateTime.Now)
                        {
                            Console.WriteLine("Дата окончания не может быть раньше даты создания.");
                            break;
                        }
                        Console.Clear();
                        return target;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Неверный формат даты, попробуйте ещё раз");
                        Console.ReadLine();
                        break;
                    }

            }
        }
    }

    private static int calcBorder(int x, byte index)
    {
        switch (index)
        {
            case 0:
                x = x%DateTime.MaxValue.Year;
                break;
            case 1:
                x = x%12;
                break;
            case 2:
                x = x%(DateTime.MaxValue.Day);
                break;
            case 3:
                x = x%(DateTime.MaxValue.Hour+1);
                break;
            case 4:
                x = x%(DateTime.MaxValue.Minute+1);
                break;
            default:
                x = x;
                break;
        }
        x = Math.Abs(x);
        return x;
    }

    private static void PrintCursor(int[] targetTime, byte focus)
    {
        string cursor = "";
        for (byte i = 0; i < focus; i++)
        {
            cursor += new string(' ', targetTime[i].ToString().Length + 1);
        }
        cursor += new string('#' , targetTime[focus].ToString().Length);
        Console.WriteLine(cursor);
    }
}