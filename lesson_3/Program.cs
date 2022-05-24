using System;

namespace Lesson_3
{
    class Program
    {
        static void PrintArray<T>(T [,]array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i,j]}\t");
                }
                Console.WriteLine();
            }
        }


        static void task1()
        {
            Random random = new Random();
            int[][] arr = new int[10][];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[i+1];
                for(int j = 0; j < arr[i].Length;j++)
                {
                    arr[i][j] = random.Next(100);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]}\t");
                }
                Console.WriteLine();
            }
        }

        static void task2()
        {
            Console.WriteLine("Телефонный справочник: ");
            string[,] phonebook = new string[5, 2];
            for(int i = 0; i < phonebook.GetLength(0);i++)
            {
                for(int j = 0; j < phonebook.GetLength(1);j++)
                {
                    if(j==0)
                    {
                        Console.Write("Введите имя: ");
                        phonebook[i, j] = Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Введите телефон/email: ");
                        phonebook[i, j] = Console.ReadLine();
                    }
                }
            }
            PrintArray(phonebook);
        }

        static void task3()
        {
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            char[] letters = word.ToCharArray();
            char temp;
            for (int i = 0, j = letters.Length-1; i < letters.Length/2;i++,j--)
            {
                temp = letters[i];
                letters[i] = letters[j];
                letters[j] = temp;
            }
            Console.WriteLine(new String(letters));
        }

        static void task4()
        {
            char[,] field = new char[10, 10];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = 'o';
                }
            }

            PrintArray(field);
            int x = 0;
            int y = 0;
            int ship = 3;
            do
            {
                Console.WriteLine($"\nВыберите где поставить {ship--} корабля по X и Y?");
                Console.Write("X: ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Y: ");
                y = int.Parse(Console.ReadLine());
                if((x>=0 && x<=9)&&(y >= 0 && y <= 9))
                {
                    field[x, y] = 'x';
                }
                else
                {
                    Console.WriteLine("Некорректные координаты");
                }

            } while (ship>0);
            PrintArray(field);
        }

        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("task 1 - 1\ntask 2 - 2\ntask 3 - 3\ntask 4 - 4");
                Console.Write("Выберите задачу: ");
                int choice = int.Parse(Console.ReadLine());
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
                    default:
                        Console.WriteLine("Некорректное число!");
                        break;

                }
                Console.Write("Вернуться к списку задач?");
                answer = Console.ReadLine();
            } while (answer == "yes" || answer == "да");
        }
    }
}
