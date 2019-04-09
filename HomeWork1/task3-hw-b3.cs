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
            // Даны координаты поля шахматной доски.проверить истинность высказывания: «Данное поле является белым»

            Console.WriteLine("Введите координаты поля шахматной доски : ");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Данное поле является белым ? " + ((x + y) % 2 != 0));
        }
            
    }
}
/*Введите координаты поля шахматной доски :
2
3
Данное поле является белым ? True

 Введите координаты поля шахматной доски :
6
7
Данное поле является белым ? True*/
