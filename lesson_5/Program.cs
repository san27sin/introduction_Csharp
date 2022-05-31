using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("task 1 - 1\ntask 2 - 2\ntask 3 - 3\ntask 4 - 4\ntask 5 - 5");
                Console.Write("Выберите задачу: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            task1();
                            break;
                        case 2:
                            task2();
                            break;
                        case 3:
                            task3();
                            break;
                        case 4:
                            task4();
                            break;
                        case 5:
                            task5();
                            break;
                        default:
                            Console.WriteLine("Некорректное число!");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода!");
                }


                Console.Write("Вернуться к списку задач?");
                answer = Console.ReadLine();
            } while (answer == "yes" || answer == "да");
        }

        private static void task5()
        {
            ToDo[] toDoList = new ToDo[]
            {
                new ToDo(),
                new ToDo(),
                new ToDo(),
                new ToDo(),
                new ToDo(),
                new ToDo()
            };

            toDoList[0].Title = "Помыть посуду.";
            toDoList[1].Title = "Убрать квартиру.";
            toDoList[2].Title = "Вынести мусор";
            toDoList[3].Title = "Сделать ДЗ.";
            toDoList[4].Title = "Убрать за котом.";
            toDoList[5].Title = "Отдохнуть.";

            string toJson = JsonSerializer.Serialize(toDoList);
            File.WriteAllText("task.json", toJson);

            string fromJson = File.ReadAllText("task.json");

            ToDo[] toDoListFromJson = JsonSerializer.Deserialize<ToDo[]>(fromJson);

            PrintTasks(toDoListFromJson);


            
            for (int i = 0; i < toDoListFromJson.Length; i++)
            {
                Console.WriteLine($"Выполнил задачу №{i+1}?");
                string answer = Console.ReadLine();
                if (answer == "yes" || answer == "да")
                {
                    toDoListFromJson[i].IsDone = true;
                }
            }
            PrintTasks(toDoListFromJson);
            File.WriteAllText("task.json",JsonSerializer.Serialize(toDoListFromJson));      
                        
        }
        
        private static void PrintTasks(ToDo[] tasks)
        {
            int count = 1;
            foreach (ToDo task in tasks)
            {
                string status = task.IsDone == false ? "[-]" : "[x]";
                Console.WriteLine($"№{count++}:{task.Title} " + "\t"+status);
            }
        }

        private static void task4()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string text = null; 
            PrintDir(new DirectoryInfo(@"C:\Users\sin27\OneDrive\Desktop\test"), "", true,ref text);
            File.WriteAllText("roots.txt", text);
        }

        static void PrintDir(DirectoryInfo dir, string indent, bool lastDirectory,ref string text)
        {
            Console.Write(indent);
            text += indent;
            Console.Write(lastDirectory ? "└─" : "├─");//посмотреть как было у автора, ошибка в writeline
            text += lastDirectory ? "└─" : "├─";
            indent += lastDirectory ? " " : "|";
            text += lastDirectory ? " " : "|";
            DirectoryInfo[] subDirects = dir.GetDirectories();//возвращает текущую (массив) директорию, в глубь никто лезть не будет

            
            FileInfo[] subFiles = dir.GetFiles();

            
            if (subFiles.Length > 0)
            {
                int count = 1;
                Console.Write(dir.Name + " : ");
                foreach (var file in subFiles)
                {
                    if(count == subFiles.Length)
                    {
                        Console.Write(file.Name);
                        text += file.Name;
                    }
                    else
                    {
                        Console.Write(file.Name + " ; ");
                        text += file.Name + " ; ";
                    }
                    count++;
                }
                Console.WriteLine();
                text += "\n";
            }
            else
            {
                Console.WriteLine(dir.Name);
                text += dir.Name + "\n";
            }
            


            for (int i = 0; i < subDirects.Length;i++)//пройтись по каждой из этой директории
            {
                PrintDir(subDirects[i],indent, i == subDirects.Length-1, ref text);
            }
        }


        private static void task3()
        {
            List<byte> toFile = new List<byte>();

            string answer = null;
            do
            {
                Console.Write("Введите число от 0 до 255?");
                if (byte.TryParse(Console.ReadLine(), out byte number))
                {
                    toFile.Add(number);
                    Console.Write("Хотите ввести еще число от 0 до 255?");
                    answer = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Некорректный ввод данных!");
                    Console.WriteLine("Повторить ввод?");
                    answer = Console.ReadLine();
                }
            } while (answer == "yes" || answer == "да");

            File.WriteAllBytes("bytes.bin", toFile.ToArray());
        }

        private static void task2()
        {
            File.WriteAllText("startup.txt", DateTime.Now.ToString());
        }

        private static void task1()
        {
            Console.Write("Введите название файла: ");
            string fileName = Console.ReadLine() + ".txt";
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            File.WriteAllText(fileName, text);
        }
    }
}
