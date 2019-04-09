using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        //возвращает минимум из двух переданных вещественных чисел.
        static double MinDouble(double a,double b)
        {
            return (a > b) ? b : a;
        }
        static void Main()
        {
            Console.WriteLine("Введите два числа : ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Минимальное из введенных : " + MinDouble(a, b));
        }
    }
}
/*Введите два числа :
3,4
3,5
Минимальное из введенных : 3,4

Введите два числа :
-15,4
23,7
Минимальное из введенных : -15,4

    */
