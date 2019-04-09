using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace HomeWork3
{
    class htaskstr
    {
        /// <summary>
        ///  Дана строка, содержащая целые числа, разделенные двоеточиями. Сформируйте целочисленный массив, содержащий эти числа.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int[] StringToArray(string s, char c = ':')
        {
            Debug.Assert(c != '_');
            Debug.Assert(char.IsDigit(c) != true );
            return s.Split(c).Select(x => int.Parse(x)).ToArray();
        }

        /// <summary>
        /// Даны две строки. Дополните более короткую пробельными символами так, чтобы их длина стала одинаковой
        /// </summary>
        /// <param name="args"></param>
        static void AddString(ref string s1, ref string s2)
        {
            var k = Math.Max(s1.Length, s2.Length);
            s1 = s1.PadLeft(k, ' ');
            s2 = s2.PadLeft(k, ' ');
        }

        /// <summary>
        ///Проверяет равенство массивов
        /// </summary>
        /// <param name="args"></param>
        static bool ArrsAreEqual(int[] a, int[] b)
        {
            bool k = true;
            if (a.Length != b.Length)
                k = false;
            else
                for (var i = 0; i < a.Length; i++)
                    if (a[i] != b[i])
                    {
                        k = false;
                        break;
                    }
            return k;
        }

        /// <summary>
        /// Выполняет соответствующую операцию и формирует строку, содержащую результат вычислений
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static string Operations(string s , char c)
        {
            int[] m = s.Split(' ').Select(x => int.Parse(x)).ToArray();
            string s1 = "";
            switch (c)
            {
                case ('+'):
                    s1 =  $"{m[0]} + {m[1]} = {m[0] + m[1]}";
                    break;
                case ('-'):
                    s1 = $"{m[0]} - {m[1]} = {m[0] - m[1]}";
                    break;
                case ('*'):
                    s1 = $"{m[0]} * {m[1]} = {m[0] * m[1]}";
                    break;
            }
            return s1;
        }

        /// <summary>
        /// Дано целое число L (> 0) и массив строк A. Вывести последнюю строку из A, начинающуюся с цифры и имеющую длину L.
        /// Если требуемых строк в массиве A нет, то вывести строку «Not found».
        /// </summary>
        /// <param name="args"></param>
        static string LastString(int l,string[] a)
        {
            Debug.Assert(l >= 0);
            var s1 = "";
            for (var i = 0; i < a.Length; i++)
                  if (char.IsDigit(a[i][0]) && (a[i].Length == l))
                    s1 = a[i];
            if (s1 == "")
                s1 = "Not found";
            return s1;
        }
        static void Main(string[] args)
        {
            //задание 1
            var a = StringToArray("10:20:30:40:50:60");
            var b = new int[6] { 10, 20, 30, 40, 50, 60 };
            Debug.Assert(ArrsAreEqual(a, b));
            a = StringToArray("-100");
            b = new int[1] {-100};
            Debug.Assert(ArrsAreEqual(a, b));
            a = StringToArray("-10:12:45:0:98");
            b = new int[5] {-10,12,45,0,98};
            Debug.Assert(ArrsAreEqual(a, b));
            WriteLine("Задание 1 : тесты успешны ");
            WriteLine();


            //Задание 2
            var s1 = "abcdefgh";
            var s2 = "abcdef";
            AddString(ref s1, ref s2);
            Debug.Assert((s1 == "abcdefgh") && (s2 == "  abcdef"));
            s1 = "";
            s2 = "abcdef";
            AddString(ref s1, ref s2);
            Debug.Assert((s1 == "      ") && (s2 == "abcdef"));
            s1 = "";
            s2 = "";
            AddString(ref s1, ref s2);
            Debug.Assert((s1 == "") && (s2 == ""));
            s1 = "123456789";
            s2 = "123";
            AddString(ref s1, ref s2);
            Debug.Assert((s1 == "123456789") && (s2 == "      123"));
            WriteLine("Задание 2 : тесты успешны ");
            WriteLine();

            //Задание 3
            string s3 = "10 10";
            char c = '+';
            Debug.Assert(Operations(s3, c) == "10 + 10 = 20");
            s3 = "15 20";
            c = '-';
            Debug.Assert(Operations(s3, c) == "15 - 20 = -5");
            s3 = "10 5";
            c = '*';
            Debug.Assert(Operations(s3, c) == "10 * 5 = 50");
            WriteLine("Задание 3 : тесты успешны ");
            WriteLine();

            //Задание 4
            int l = 7;
            var g = new string[5] { "1234567","asdfghg", "1df", "1Helloo", "ets" };
            Debug.Assert(LastString(l, g) == "1Helloo");
            l = 3;
            g = new string[5] { "123", "2asd", "1df", "1Helloo", "ets" };
            Debug.Assert(LastString(l, g) == "1df");
            l = 15;
            g = new string[5] { "123", "2asd", "1df", "1Helloo", "ets" };
            Debug.Assert(LastString(l, g) == "Not found");
            WriteLine("Задание 4 : тесты успешны ");
        }
    }
}
