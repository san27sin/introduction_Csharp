using System;
using System.Diagnostics;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //lesson_6
            Console.SetCursorPosition(5, 0);
            Console.Write("Имя образа");
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("ID");
            Console.Write("================================================================");
            Console.SetCursorPosition(60, 1);
            Console.WriteLine("===========");
            int row = 1;
            foreach (Process process in Process.GetProcesses())
            {
                // выводим id и имя процесса
                Console.Write($"\t{process.ProcessName}");
                Console.SetCursorPosition(50, ++row);
                Console.Write("|");
                Console.SetCursorPosition(60, row++);
                Console.WriteLine($"{process.Id}");
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            int id = 0;
            string processName = string.Empty;
            bool found = false;
            bool research = false;
            Console.Write("Завершить процесс по имени или ID? ");
            string answer = Console.ReadLine();
            if(answer =="ID" || answer =="id")
            {
                Console.Write("Введите ID: ");
                id = int.Parse(Console.ReadLine());
                research = true;
            }
            if(answer == "name process" || answer == "по имени" || answer == "имени")
            {
                Console.Write("Введите имя процесса: ");
                processName = Console.ReadLine();
                research = true;
            }
            
            try
            {

                if (research == true)
                {
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (id == process.Id || processName == process.ProcessName)
                        {
                            found = true;
                            process.Kill();
                            Console.WriteLine("Process is killed!");                
                            break;
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("Введенный процесс не найден!");
                    }
                }

                if (research == false)
                {
                    Console.WriteLine("Некорректный тип данных!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
