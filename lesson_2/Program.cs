using System;

namespace Lesson_2
{
    class Program
    {
        static double averageTemp = 0;
        static int month = 0;

        [Flags]
       public enum Week
        {
            None = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 64,
            Saturday = 128,
            Sunday = 256,
            All = ~None
        }


        /*
        enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        */
        static void task1()
        {
            //Сделать проверку данных введенным пользователем
            Console.Write("Введите минимальную температуру за сутки: ");
            double minTemp = double.Parse(Console.ReadLine());
            Console.Write("Введите максимальную температуру за сутки: ");
            double maxTemp = double.Parse(Console.ReadLine());
            Program.averageTemp = (maxTemp + minTemp)/ 2;
            Console.WriteLine($"Среднесуточная температура:{Program.averageTemp}");
        }

        static void task2()
        {
            Console.WriteLine("Введите номер текущего месяца: ");
            Program.month = int.Parse(Console.ReadLine());
            string[] months = new string[]
       {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
       };

            if (month > 0 && month <= 12)
            {
                Console.WriteLine(months[month-1]);
            }
            else
            {
                Console.WriteLine("Некорректное число!");
                task2();
            }
        }

        static void task3()
        {
            Console.Write("Введите чило для проверки на четность: ");
            int number = int.Parse(Console.ReadLine());
            if(number%2==0)
            {
                Console.WriteLine("Число четное!");
            }
            else
            {
                Console.WriteLine("Число нечетное!\nЕще раз проверить?" );
                string answer = Console.ReadLine();
                if (answer == "yes")
                {
                    task3();
                }
            }
        }

        static void task4()
        {
            string name = "Alex";
            string surname = "Sinitsyn";
            double sum = 4567.43;
            string currency = "rub";
            int workerNumber = 123;
            long inn = 1234231423142314;

            Console.WriteLine($"КАССОВЫЙ ЧЕК КОРРЕКЦИИ\nИТОГ ={sum} {currency}\n" +
                $"Сотрудник:{name} {surname}\nтабельный номер {workerNumber}\n" +
                $"Дата покупки {DateTime.Now}\nИНН {inn}");
        }

        static void task5()
        {
            if((Program.month == 12 || Program.month == 1 || Program.month == 2) && Program.averageTemp > 0)
            {
                Console.WriteLine("Дождливая зима");
            }
            else
            {
                Console.WriteLine("Посмотри лучше прогноз погоды");
            }
        }

        static void task6()
        {
            Console.Write("Введите название офиса: ");
            string nameOffice = Console.ReadLine();
            Week days = Week.None;

            string answer = "no";
            string day = null;
            do
            {
                Console.WriteLine($"Какой день работает {nameOffice}?");
                day = Console.ReadLine();
                if (day == "Понедельник")
                {
                    days |= Week.Monday;
                }    
                if (day == "Вторник")
                {
                    days |= Week.Tuesday;
                }
                if (day == "Среда")
                {
                    days |= Week.Wednesday;
                }    
                if (day == "Четверг")
                {
                    days |= Week.Thursday;
                }    
                if (day == "Пятница")
                {
                    days |= Week.Friday;
                }
                if (day == "Суббота")
                {
                    days |= Week.Saturday;
                }
                if (day == "Воскресенье")
                {
                    days |= Week.Sunday;
                }    
                Console.WriteLine("Продолжить выбор рабочих дней?");
                answer = Console.ReadLine();

            } while (answer == "yes");
            Console.WriteLine(days.ToString("G"));
        }

        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("Выберите задачу:\ntask 1 - 1\ntask 2 - 2\ntask 3 - 3\ntask 4 - 4\ntask 5 - 5\ntask 6 - 6");
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
                    case 5:
                        task5();
                        break;
                    case 6:
                        task6();
                        break;


                    default:
                        Console.WriteLine("Некорректное число!");
                        break;

                }
                Console.Write("Вернуться к списку задач?");
                answer = Console.ReadLine();
            } while (answer == "yes");


            
        }
    }
}
