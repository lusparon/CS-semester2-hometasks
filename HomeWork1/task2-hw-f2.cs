using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        static void Main()
        {
            // Вычислите значение функции y = 4(x–3)^6 – 7(x–3)^3 + 2 для двух заданных с клавиатуры значений x.
            Console.WriteLine("Введите два значения : ");
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int t = (x1 - 3) * (x1 - 3) * (x1 - 3);
            Console.WriteLine("Значние функции для " + x1 + " = " + (4 * t * t - 7 * t + 2));
            t = (x2 - 3) * (x2 - 3) * (x2 - 3);
            Console.WriteLine("Значние функции для " + x2 + " = " + (4 * t * t - 7 * t + 2));
        }
    }
}
/*Введите два значения :
3
3
Значние функции для 3 = 2
Значние функции для 3 = 2

 Введите два значения :
12
6
Значние функции для 12 = 2120663
Значние функции для 6 = 2729*/

