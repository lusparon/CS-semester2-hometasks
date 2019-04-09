using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace Calculator
{
    class MainProgram
    {
        static void Main(string[] args)
        {
			//ДОМАШНЕЕ ЗАДАНИЕ
			// инициализация
			var calc = new AddRatioCalculator(); Debug.Assert(calc.ToString() == "0", "test-1");

			// набор числа
			calc.Digit(3); Debug.Assert(calc.ToString() == "3", "test-2-1");
			calc.Dot(); Debug.Assert(calc.ToString() == "3,", "test-2-2");
			calc.Digit(1); Debug.Assert(calc.ToString() == "3,1", "test-2-3");

			calc.CE();

			// три слагаемых: целое + дробное + целое
			calc.Digit(1); Debug.Assert(calc.ToString() == "1");    // 1
			calc.Plus(); Debug.Assert(calc.ToString() == "1");    // +
			calc.Digit(2); Debug.Assert(calc.ToString() == "2");    // 2
			calc.Dot(); Debug.Assert(calc.ToString() == "2,");   // .
			calc.Digit(3); Debug.Assert(calc.ToString() == "2,3");  // 3
			calc.Plus(); Debug.Assert(calc.ToString() == "3,3");  // +
			calc.Digit(4); Debug.Assert(calc.ToString() == "4");    // 4
			calc.Result(); Debug.Assert(calc.ToString() == "7,3");  // =

			// не очищая результат прибавим ещё дробное
			calc.Plus(); Debug.Assert(calc.ToString() == "7,3");    // +
			calc.Digit(2); Debug.Assert(calc.ToString() == "2");      // 2
			calc.Digit(1); Debug.Assert(calc.ToString() == "21");     // 1
			calc.Dot(); Debug.Assert(calc.ToString() == "21,");    // .
			calc.Digit(5); Debug.Assert(calc.ToString() == "21,5");   // 3
			calc.Digit(5); Debug.Assert(calc.ToString() == "21,55");  // 3
			calc.Result(); Debug.Assert(calc.ToString() == "28,85");  // =
			WriteLine("Тесты пройденны успешно!!!");


			var calc2 = new LastCalculator();
			//проверка ChangeSign
			//55.5+5=
			calc2.Digit(5);
			calc2.Digit(5);
			calc2.Dot();
			calc2.Digit(5);
			calc2.Plus();
			calc2.Digit(5);
			calc2.Result();
			WriteLine("До смены знака : "+calc2.ToString());
			calc2.ChangeSign();
			WriteLine("После смены знака : "+calc2.ToString());
			calc2.ChangeSign();//вернули знак

			//проверка DoubleZero
			//5
			calc2.CE();
			calc2.Digit(5);
			WriteLine("До : "+calc2.ToString());
			calc2.DoubleZero();
			WriteLine("После : "+calc2.ToString());

			//проверка clearlast
			//123.45
			WriteLine("Пример 1");
			calc2.CE();
			calc2.Digit(1);
			calc2.Digit(2);
			calc2.Digit(3);
			calc2.Dot();
			calc2.Digit(4);
			calc2.Digit(5);
			WriteLine("До : "+ calc2.ToString());
			calc2.ClearLast();
			WriteLine("После : "+calc2.ToString());
			WriteLine();

			WriteLine("Пример 2");
			//12345
			calc2.CE();
			calc2.Digit(1);
			calc2.Digit(2);
			calc2.Digit(3);
			calc2.Digit(4);
			calc2.Digit(5);
			WriteLine("До : " + calc2.ToString());
			calc2.ClearLast();
			WriteLine("После : " + calc2.ToString());
			WriteLine();






		}
    }
}
