using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Class1
    {
        //Возвращает количество вещественных корней квадратного уравнения
        static int SqrtCount(int a, int b, int c)
        {
            double d = b * b - 4 * a * c;
            if (d > 0)
                return 2;
            else
                if (d == 0)
                return 1;
            else return 0;

        }

        static void Main()
        {
            Console.WriteLine("Введите A , B , C : ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Результат равен : "+ SqrtCount(a,b,c));
        }
    }
}
/*Введите A , B , C :
1
3
2
Результат равен : 2
Введите A , B , C :
1
4
4
Результат равен : 1

    Введите A , B , C :
5
2
3
Результат равен : 0
*/
