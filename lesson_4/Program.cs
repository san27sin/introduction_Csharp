using System;

namespace Lesson_4
{
    class Program
    {
        public enum Season
        {
            spring,
            autumn,
            summer,
            winter
        }
        /// <summary>
        /// Вывод ФИО
        /// </summary>
        static public void task1()
        {
            string[] firstName = new string[3]
            {
                "Саша",
                "Петя",
                "Вася"
            };

            string[] lastName = new string[3]
            {
                "Сидоров",
                "Пирогов",
                "Синицын"
            };

            string[] patronimyc = new string[3]
            {
                "Романович",
                "Иванович",
                "Александрович"
            };

            for(int i =0; i < firstName.Length; i++)
            {
                Console.WriteLine(GetFullName(firstName[i],patronimyc[i],lastName[i]));
            }
        }


        /// <summary>
        /// Возврат ФИО
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="patronimyc">отчество</param>
        /// <param name="lastName">фамилия</param>
        /// <returns></returns>
        static public string GetFullName(string name, string patronimyc, string lastName)
        {
            return name + " " + patronimyc + " " + lastName;
        }
        static public void task2()
        {
            Console.Write("Введите набор чисел через пробел: ");
            string result = Console.ReadLine();
            Console.WriteLine($"Сумма введенных чисел: {Convert(result)}");
        }


        static public int Convert(string sentence)
        {
            int sum = 0;
            string[] numbers = sentence.Split(new char[] { ' ' });
            foreach(var number in numbers)
            {
                sum += int.Parse(number);
            }
            return sum;
        }

        static public void task3()
        {
            Console.WriteLine("Введите число месяца:");
            int monthNumber = int.Parse(Console.ReadLine());
            if (monthNumber <= 12 && monthNumber >0 )
            {
                switch(Month(monthNumber))
                {
                    case Season.autumn:
                        Console.WriteLine("Весна");
                        break;
                    case Season.winter:
                        Console.WriteLine("Зима");
                        break;
                    case Season.spring:
                        Console.WriteLine("Весна");
                        break;
                    case Season.summer:
                        Console.WriteLine("Лето");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите число от 1 до 12");
            }

        }

        static public Season Month(int month)
        {
            if (month == 12 || month == 1 || month == 2)
            {
                return Season.winter;
            }

            if (month == 3 || month == 4 || month == 5)
            {
                return Season.spring;
            }

            if (month == 6 || month == 7 || month == 8)
            {
                return Season.summer;
            }

            else
                return Season.autumn;
            
        }

        static public void task4()
        {
            int fib = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(fib));
        }

        static public int Fib (int n)
        {
            if (n ==0||n==1)
                return n;
            
            return Fib(n - 1) + Fib(n - 2);
        }

        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("task 1 - 1\ntask 2 - 2\ntask 3 - 3\ntask 4 - 4");
                Console.Write("Выберите задачу: ");
                if(int.TryParse(Console.ReadLine(), out int choice))
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
    }
}
