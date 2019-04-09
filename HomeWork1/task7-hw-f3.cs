using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        //найти сумму 1+A+A^2+A^3+…+A^N.
        static double SumPow(double a, int n)
        {
            double s = 0;
            double apow = 1.0;
            for (int i = 0; i < n+1; i++)
            {
                s = s + apow;
                apow = apow * a;
            }
            return s;
        }

        static void Main()
        {
            Console.WriteLine("Введите A и N : ");
            double a = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Сумма 1+A+A^2+A^3+…+A^N = " + SumPow(a, n));
        }
    }
}
/*Введите A и N :
5
3
Сумма 1+A+A^2+A^3+:+A^N = 156

 Введите A и N :
3
4
Сумма 1+A+A^2+A^3+:+A^N = 121*/
