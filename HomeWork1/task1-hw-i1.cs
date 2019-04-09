using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дано трехзначное число. Обнулить в нем разряд десятков.

            Console.WriteLine("Введите трехзначное число : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Результат равен : " + ((a / 100 )*100+ a % 10));
        }
    }
}
/*Введите трехзначное число :
123
Результат равен : 103*

Введите трехзначное число :
-345
Результат равен : -305/
