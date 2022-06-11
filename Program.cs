using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Properties.Settings.Default.greeting);
            if(string.IsNullOrEmpty(Properties.Settings.Default.name))
            {
                Console.Write("Введите имя: ");
                Properties.Settings.Default.name = Console.ReadLine();
                Console.Write("\nВведите возраст: ");
                Properties.Settings.Default.age = int.Parse(Console.ReadLine());
                Console.Write("\nВведите род деятельности: ");
                Properties.Settings.Default.activity = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine($"Имя:{Properties.Settings.Default.name}\nВозраст:{Properties.Settings.Default.age}\nРод деятельности:{Properties.Settings.Default.activity}");
            }
            Console.ReadKey(true);        }
    }
}
