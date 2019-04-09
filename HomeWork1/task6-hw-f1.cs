using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        //Находит произведение всех целых чисел, кратных трём, от A до B включительно.
        static double ProdMultiple(int a,int b)
        {
            double p = 1;
            for (int i = a; i < (b + 1); i++)
                if (i % 3 == 0)
                    p = p * i;
            if (p == 1)
                p = 0;
            return p;
        }

        static void Main()
        {
            Console.WriteLine("Введите 2 числа : ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Произведение всех целых чисел, кратных трём, от A до B = " + ProdMultiple(a, b));
        }
    }
}
/*Введите 2 числа :
1
6
Произведение всех целых чисел, кратных трём, от A до B = 18

Введите 2 числа :
4
5
Произведение всех целых чисел, кратных трём, от A до B = 0
*/
