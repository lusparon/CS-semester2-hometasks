using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        //Даны два целых числа с одинаковым количеством разрядов. Найти их поразрядную сумму по модулю 10.
        static int BitSum(int a, int b)
        {
            int s = 0;
            int i = 0;//количество разрядов в числе 
            int a1 = a;
            while (a1>0)
            {
                i++;
                a1 = a1 / 10;
            }
            int ten = 1;
            for (int i1=0 ; i1<i ; i1++)
            {
                s = s + (a % 10 + b % 10)%10*ten;
                a = a / 10;
                b = b / 10;
                ten = ten * 10;
            }
            return s;
        }

        static void Main()
        {
            Console.WriteLine("Введите 2 целых числа с одинаковым количеством разрядов : ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Поразрядная сумма A и B = " + BitSum(a, b));
        }
    }
}
/*Введите 2 целых числа с одинаковым количеством разрядов :
123
456
Поразрядная сумма A и B = 579

Введите 2 целых числа с одинаковым количеством разрядов :
345
597
Поразрядная сумма A и B = 832
*/
