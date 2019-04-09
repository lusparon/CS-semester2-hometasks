using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace HomeWork1Recur
{
    class RecurHTask
    {
        delegate bool MyPredOfDouble(double x);
        delegate bool MyPred<T>(T x);
        /// <summary>
        /// (Активирующая) Находит сумму всех вещественных чисел A, A + h, A + 2h , … в диапазоне [A, B], удовлетворяющих заданному предикату.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        static double ActSumPred(double a, double b, double h, MyPredOfDouble pred)
        {
            Debug.Assert(a <= b, "A<=B in SumPred!");
            return SumPred(a, b, h, pred);
        }
        /// <summary>
        /// (Вспомогательная) Находит сумму всех вещественных чисел A, A + h, A + 2h , … в диапазоне [A, B], удовлетворяющих заданному предикату.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        static double SumPred(double a, double b, double h, MyPredOfDouble pred)
        {
            Debug.Assert(a<=b+h, "A<=B+h in SumPred!");
            if (a > b)
                return 0;
            if (a == b)
                return a;
            if (pred(a))
            {
                if (a == b)
                    return a;
                return a + SumPred(a + h, b, h, pred);
            }
            return SumPred(a + h, b, h, pred);
        }
        /// <summary>
        /// Определяет, является ли строка палиндромом
        /// </summary>
        /// <param name="args"></param>
        static bool IsPalindrom(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return true;
            return NewIsPalindrom(s,0,s.Length-1);
        }
        static bool NewIsPalindrom(string s, int a, int b)
        {
            if (a >= b)
                return true;
            if (s[a] == s[b])
                return NewIsPalindrom(s, a + 1, b - 1);
            return false;
        }
        /// <summary>
        /// Выводит все разряды целого числа, начиная со старшего.
        /// </summary>
        /// <param name="a"></param>
        static void PrintRankOfDigit(int a)
        {
            var k = 0;
            NewPrintRankOfDigit(a, ref k);
            WriteLine();
        }
        static void NewPrintRankOfDigit(int a,ref int k)
        {
            if (a < 10)
            {
                Write($"{k} ");
                return;
            }
            k++;
            NewPrintRankOfDigit(a / 10,ref k);
            k--;
            Write($"{k} ");
        }
        /// <summary>
        /// Выводит все разряды целого числа, начиная со старшего. С переходом на новую строку
        /// </summary>
        /// <param name="a"></param>
        static void PrintLnRankOfDigit(int a)
        {
            PrintRankOfDigit(a);
            WriteLine();
        }
        /// <summary>
        /// Определяет максимальный элемент
        /// </summary>
        /// <param name="args"></param>
        static int MaxOfSeq(params int[] a)
        {
            var m = int.MinValue;
            var k = 0;
            return NewMaxOfSeq(ref m,ref k, a);
        }
        static int NewMaxOfSeq(ref int m,ref int k, params int[] a)
        {
            if (a.Length == k)
                return m;
            m = Math.Max(m, a[k]);
            k++;
            return NewMaxOfSeq(ref m,ref k, a);
        }
        /// <summary>
		/// Создает Односвязный список
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="elems"></param>
		/// <returns></returns>
		static LinkedListNode<T> CreateSList<T>(params T[] elems)
        {
            if ((elems == null) || (elems.Length == 0))
            {
                return null;
            }
            var l = new LinkedList<T>(elems);
            return l.First;
        }
        /// <summary>
        /// Везвращает ссылку на максимальный элемент односвязного списка
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        static LinkedListNode<double> MaxOfNode(LinkedListNode<double> l)
        {
            if (l == null)
                return null;
            var m = l;
            NewMaxOfNode(l, ref m);
            return m;
        }
        static LinkedListNode<double> NewMaxOfNode(LinkedListNode<double> l,ref LinkedListNode<double> m)
        {
            if (l == null)
                return m;
            if (l.Value > m.Value)
                m = l;
            return NewMaxOfNode(l.Next, ref m);
        }
        /// <summary>
        /// Возвращает ссылку на первый элемент, удовлетворяющий предикату.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        static LinkedListNode<T> FirstPredNode<T>(LinkedListNode<T> l, MyPred<T> pred)
        {
            if (l == null)
                return null;
            if (pred(l.Value))
                return l;
            return FirstPredNode(l.Next, pred);
        }
        /// <summary>
        /// Считать кол-во элементов, удовлетворяющих предикату.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        static int CountPredNode<T>(LinkedListNode<T> l, MyPred<T> pred)
        {
            if (l == null)
                return 0;
            var k = 0;
            NewCountPredNode(l, pred, ref k);
            return k;
        }
        static LinkedListNode<T> NewCountPredNode<T>(LinkedListNode<T> l, MyPred<T> pred,ref int k)
        {
            if (l == null)
                return null;
            if (pred(l.Value))
                k++;
            return NewCountPredNode(l.Next, pred,ref k);
        }
        /// <summary>
        /// Проверяет, начинается ли первый список со второго.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static bool StartsWith(LinkedListNode<int> a, LinkedListNode<int> b)
        {
            if (a == null && b != null)
                return false;
            if (b == null)
                return true;
            if (a.Value == b.Value)
                return StartsWith(a.Next, b.Next);
            return false;
        }
        /// <summary>
        /// Формирует односвязный линейный список из первых N чисел Фибоначчи
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static LinkedListNode<int> Fib(int n)
        {
            Debug.Assert(n>=0, "n>=0 in Fib!");
            if (n == 0)
                return null;
            var a = 1;
            var b = 1;
            var l = new LinkedList<int>();
            NewFib(n, a, b, ref l);
            return l.First;
        }
        static void NewFib(int n,int a, int b,ref LinkedList<int> l)
        {
            if (n == 1)
            {
                l.AddLast(a);
                return;
            }
            l.AddLast(a);
            NewFib(n - 1, b, a + b,ref l);
        }
        /// <summary>
        /// Создает из односвязного списка массив
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        static int[] CreateMassif(LinkedListNode<int> l)
        {
            var n = new LinkedList<int>();
            NewCreateMassif(l, ref n);
            int[] a = new int[n.Count];
            for (var i = 0; i < n.Count; i++)
            {
                a[i] = int.Parse(l.Value.ToString());
                l=l.Next;
            }
            return a;
        }
        static LinkedListNode<int> NewCreateMassif(LinkedListNode<int> l,ref LinkedList<int> n)
        {
            if (l!=null)
            {
                n.AddLast(l.Value);
                return NewCreateMassif(l.Next,ref n);
            }
            return null;
        }
        /// <summary>
        /// Равны ли массивы
        /// </summary>
        /// <param name="args"></param>
        static bool IsEqual(int[]a,int[] b)
        {
            if (a == null && b == null)
                return true;
            if (a.Length != b.Length)
                return false;
            for (var i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            //Часть B:
            WriteLine("Часть B: рекурсия и списки");
            WriteLine();
            //Задание #1
            WriteLine("Задание 1");
            Debug.Assert(MaxOfNode(CreateSList(10.0,-15.4,25.7)).Value == 25.7, "test #1");
            Debug.Assert(MaxOfNode(CreateSList(12,23,-19.8,12)).Value == 23, "test #2");
            Debug.Assert(MaxOfNode(CreateSList(132.0 ,23 ,-9, 47,256)).Value == 256, "test #3");
            Debug.Assert(MaxOfNode(CreateSList(10.0)).Value == 10, "test #4");
            Debug.Assert(MaxOfNode(null) == null, "test #4");
            WriteLine("Тесты успешно пройдены!");

            WriteLine();
            //Задание #2
            WriteLine("Задание #2");
            Debug.Assert(FirstPredNode(CreateSList(-5,-10,-3),x=>(x>=0)) == null, "test #1");
            Debug.Assert(FirstPredNode(CreateSList(-7,18,-5,6), x => (x >= 0)).Value == 18, "test #2");
            Debug.Assert(FirstPredNode(CreateSList("Hello", "World", "My", "Name"), x => (x[0] == 'M')).Value == "My", "test #3");
            Debug.Assert(FirstPredNode(CreateSList("Is", "Lusparon", "How", "Are","you"), x => (x[0] == 'H')).Value == "How", "test #4");
            Debug.Assert(FirstPredNode(CreateSList("Break"), x => (x[0] == 'м')) == null, "test #5");
            Debug.Assert(FirstPredNode(CreateSList("World"), x => (x[0] == 'W')).Value== "World", "test #6");
            Debug.Assert(FirstPredNode<string>(null, x => (x[0] == 'L'))==null, "test #7");
            WriteLine("Тесты успешно пройдены!");

            WriteLine();
            //Задание #3
            WriteLine("Задание #3");
            Debug.Assert(CountPredNode(CreateSList(-5,-7), x => (x >= 0)) == 0, "test #1");
            Debug.Assert(CountPredNode(CreateSList(15,-18,23,-8), x => (x >= 0)) == 2, "test #2");
            Debug.Assert(CountPredNode(CreateSList(2,4,6,13,11,15,8), x => (x%2==0)) == 4, "test #3");
            Debug.Assert(CountPredNode(CreateSList('A', 'B', 'C', 'D'), x => char.IsLetter(x)) == 4, "test #4");
            Debug.Assert(CountPredNode(CreateSList("Hello", "World", "My", "Name"), x => (x[0] == 'H')) == 1, "test #5");
            Debug.Assert(CountPredNode(CreateSList("Hello"), x => (x[0] == 'K')) == 0, "test #6");
            WriteLine("Тесты успешно пройдены!");

            WriteLine();
            //Задание #4
            WriteLine("Задание #4");
            Debug.Assert(StartsWith(CreateSList(1,2,3,4,5,6), CreateSList(1,2,3)), "test #1");
            Debug.Assert(StartsWith(CreateSList(3, -4, 15, 0, -246, 85), CreateSList(3, -4)), "test #2");
            Debug.Assert(!StartsWith(CreateSList(12,-90,234,56,1,25), CreateSList(1,2,3)), "test #3");
            Debug.Assert(!StartsWith(CreateSList(89), CreateSList(1,2)), "test #4");
            Debug.Assert(StartsWith(CreateSList(1,2,3), null), "test #5");
            Debug.Assert(StartsWith(null, null), "test #6");
            Debug.Assert(!StartsWith(null, CreateSList(666)), "test #7");
            WriteLine("Тесты успешно пройдены!");

            WriteLine();
            //Задание #5
            WriteLine("Задание #5");
            int[] a = new int[]{ };
            Debug.Assert(IsEqual(CreateMassif(Fib(0)), a), "test #1");
            a = new int[] {1};
            Debug.Assert(IsEqual(CreateMassif(Fib(1)), a), "test #2");
            a = new int[] { 1,1 };
            Debug.Assert(IsEqual(CreateMassif(Fib(2)), a), "test #3");
            a = new int[] { 1, 1,2 };
            Debug.Assert(IsEqual(CreateMassif(Fib(3)), a), "test #4");
            a = new int[] { 1, 1, 2,3 };
            Debug.Assert(IsEqual(CreateMassif(Fib(4)), a), "test #5");
            a = new int[] { 1, 1, 2, 3, 5 };
            Debug.Assert(IsEqual(CreateMassif(Fib(5)), a), "test #6");
            WriteLine("Тесты успешно пройдены!");
        }
    }
}

