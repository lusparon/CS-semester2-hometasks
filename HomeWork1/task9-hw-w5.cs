using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        //Вычислить количество чисел в наборе, меньших K, а также количество чисел, делящихся на K нацело.
        static void CountLessK(int k, ref int count, ref int countDivK)
        {
            count = 0;//количество чисел в наборе, меньших K
            countDivK = 0;//количество чисел, делящихся на K нацело
            Console.WriteLine("Введите последовательность");
            while (true)
            {
                int a = int.Parse(Console.ReadLine());
                if (a == 0)
                    break;
                if (a < k)
                    count++;
                if (a % k == 0)
                    countDivK++;
            }
        }

        static void Main()
        {
            Console.WriteLine("Введите число K : ");
            int k = int.Parse(Console.ReadLine());
            int count = 0;
            int count1 = 0;
            CountLessK(k, ref count, ref count1);
            Console.WriteLine("Количество чисел в наборе, меньших K = " + count + "\n" + "Количество чисел, делящихся на K нацело = " + count1);
        }
    }
}
/*Введите число K :
10
Введите последовательность
1
4
5
14
23
1
0
Количество чисел в наборе, меньших K = 4
Количество чисел, делящихся на K нацело = 0
--------------------------------------------
Введите число K :
5
Введите последовательность
1
5
10
4
3
15
0
Количество чисел в наборе, меньших K = 3
Количество чисел, делящихся на K нацело = 3
*/
