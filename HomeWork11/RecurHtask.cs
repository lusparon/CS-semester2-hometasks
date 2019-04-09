using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace HomeWork11
{
    class RecurHtask
    {
        /// <summary>
        /// Умный конструктор для узла бинарного дерева
        /// </summary>
        /// <param name="data">Значение поля данных узла</param>
        /// <param name="left">Левое поддерево</param>
        /// <param name="right">Правое поддерево</param>
        static TreeNode<T> MkTNode<T>(
                    T data,
                    TreeNode<T> left = null,
                    TreeNode<T> right = null) => new TreeNode<T>(data, left, right);


        /// <summary>
        /// Дано непустое бинарное дерево целых чисел. Найти его минимальный элемент.
        /// </summary>
        /// <param name="args"></param>
        static int MinTree(TreeNode<int> root)
        {
            Debug.Assert(root != null);
            var min = int.MaxValue;
            MinTreeHelp(root, ref min);
            return min;
        }
        static void MinTreeHelp(TreeNode<int> root, ref int min)
        {
            if (root == null)
                return;
            if (root.data < min)
                min = root.data;
            MinTreeHelp(root.left, ref min);
            MinTreeHelp(root.right, ref min);
        }
        /// <summary>
        /// Дан непустой линейный односвязный список. Найти ссылку на его последний узел.
        /// </summary>
        /// <param name="args"></param>
        static LinkedListNode<int> LastElem(LinkedListNode<int> first)
        {
            Debug.Assert(first != null);
            LinkedListNode<int> last = null;
            LastElemHelp(first, ref last);
            return last;
        }
        static void LastElemHelp(LinkedListNode<int> first, ref LinkedListNode<int> last)
        {
            if (first == null)
                return;
            if (first.Next == null)
                last = first;
            LastElemHelp(first.Next, ref last);
        }

        /// <summary>
        /// Создает односвязный линейный список
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
        /// Дан непустой линейный односвязный список целых чисел. Найти ссылку на его максимальный элемент
        /// </summary>
        /// <param name="args"></param>
        static LinkedListNode<int> MaxElemList(LinkedListNode<int> first)
        {
            Debug.Assert(first != null);
            LinkedListNode<int> max = new LinkedListNode<int>(int.MinValue);
            MaxElemListHelp(first, ref max);
            return max;
        }
        static void MaxElemListHelp(LinkedListNode<int> first, ref LinkedListNode<int> max)
        {
            if (first == null)
                return;
            if (first.Value > max.Value)
                max = first;
            MaxElemListHelp(first.Next, ref max);
        }

        /// <summary>
        /// сохраняет все разряды целого неотрицательного числа в заданной системе счисления в линейный двусвязный список.
        /// </summary>
        /// <param name="args"></param>
        static LinkedList<int> DigitNumber(int x, int sistem)
        {
            Debug.Assert(x > 0);
            var l = new LinkedList<int>();
            DigitNumberHelp(x, sistem,ref l);
            return l;
        }
        static void DigitNumberHelp(int x , int sistem,ref LinkedList<int> l)
        {
            if (x == 0 )
                return;
            l.AddFirst(x%sistem);
            DigitNumberHelp(x/sistem,sistem,ref l);
        }

        /// <summary>
        /// Вывести значение логического выражения, заданного в виде строки S. 
        /// </summary>
        /// <param name="args"></param>
        static bool LogValue(string s)
        {
            if (s == "T")
                return true;
            if (s == "F")
                return false;
            if (s.StartsWith("OR"))
                return LogValue(s);//заглушка
            return false;//заглушка
        }

        /// <summary>
        /// Сформировать односвязный линейный список, состоящий из первых N (N ≥ 0) факториалов в прямом порядке.
        /// </summary>
        /// <param name="args"></param>
        static LinkedList<int> MakeFactorialsList(int n )
        {
            Debug.Assert(n>=0);
            var l = new LinkedList<int>();
            MakeFactorialsListHelp(n,ref l);
            return l;
        }

        static void MakeFactorialsListHelp(int n , ref LinkedList<int> l)
        {
            if (n == 1)
                l.AddFirst(1);
            else if (n == 0)
                l = null;
            else
            {
                l.AddFirst(FactCalc(n));
                MakeFactorialsListHelp(n - 1, ref l);
            }
        }


        /// <summary>
        /// считает факториал числа
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int FactCalc(int n)
        {
            Debug.Assert(n >= 1);
            if (n == 1 )
                return 1;
            return n * FactCalc(n - 1);
        }
        static bool CheckSList(LinkedList<int> x, params int[] a)
        {
            return x.SequenceEqual(a);
        }


        static void Main(string[] args)
        {
            //ЧАСТЬ А

            //задание 1
            Debug.Assert(MinTree(MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5))))==1);
            Debug.Assert(MinTree(MkTNode(10, MkTNode(24), MkTNode(-3, MkTNode(0), MkTNode(-5))))==-5);
            Debug.Assert(MinTree(MkTNode(12, MkTNode(7), MkTNode(10, MkTNode(8), MkTNode(9))))== 7);
            Debug.Assert(MinTree(MkTNode(-9, MkTNode(23), MkTNode(0))) == -9);
            Debug.Assert(MinTree(MkTNode(2, MkTNode(1), MkTNode(19, MkTNode(88), MkTNode(45)))) == 1);
            WriteLine("Задание 1 : тесты успешны!");
            WriteLine();

            //задание 2
            Debug.Assert(LastElem(CreateSList(1, 2, 3, 4, 5, 6, 7, 8, 9)).Value==9 );
            Debug.Assert(LastElem(CreateSList(10, 13, 15, 7, 25)).Value == 25);
            Debug.Assert(LastElem(CreateSList(5, 3, 17, 0)).Value == 0);
            WriteLine("Задание 2 : тесты успешны!");
            WriteLine();

            //задание 3
            Debug.Assert(MaxElemList(CreateSList(1, 2, 3, 4, 5, 6, 7, 8, 9)).Value == 9);
            Debug.Assert(MaxElemList(CreateSList(10, 13, 15, 7, 25)).Value == 25);
            Debug.Assert(MaxElemList(CreateSList(5, 3, 17, 0)).Value == 17);
            Debug.Assert(MaxElemList(CreateSList(12,32,12,45,67,0)).Value == 67);
            WriteLine("Задание 3 : тесты успешны!");
            WriteLine();

            //задание 4
            var a = DigitNumber(123,10); 
            Debug.Assert(a.SequenceEqual(new int[] {1,2,3 }));
            a = DigitNumber(2, 2);
            Debug.Assert(a.SequenceEqual(new int[] { 1,0 }));
            a = DigitNumber(4, 2);
            Debug.Assert(a.SequenceEqual(new int[] { 1, 0,0 }));
            a = DigitNumber(245, 10);
            Debug.Assert(a.SequenceEqual(new int[] { 2,4,5 }));
            a = DigitNumber(9,3);
            Debug.Assert(a.SequenceEqual(new int[] { 1,0,0 }));
            WriteLine("Задание 4 : тесты успешны!");
            WriteLine();

            //Задание 6
            Debug.Assert(MakeFactorialsList(0) == null, "test #1");
            Debug.Assert(CheckSList( MakeFactorialsList(1),1),"test #2");
            Debug.Assert(CheckSList( MakeFactorialsList(2),1, 2), "test #3");
            Debug.Assert(CheckSList(  MakeFactorialsList(4),1, 2, 6, 24),"test #4");
            Debug.Assert(CheckSList(MakeFactorialsList(6), 1, 2, 6, 24, 120, 720), "test #5");
            WriteLine("Задание 6 : тесты успешны!");


        }
    }

    // --------------------------- Узел бинарного дерева ---------------------------
    /// <summary>
    /// Узел бинарного дерева
    /// </summary>
    public class TreeNode<T>

    {
        /// <summary>
        /// Поле данных
        /// </summary>
        public T data;

        /// <summary>
        /// Левое поддерево
        /// </summary>
        public TreeNode<T> left;

        /// <summary>
        /// Правое поддерево
        /// </summary>
        public TreeNode<T> right;

        /// <summary>
        /// Инициализирует узел бинарного дерева значением data поля данных
        /// и поддеревьями left, right
        /// </summary>
        /// <param name="data">Значение поля данных узла</param>
        /// <param name="left">Левое поддерево</param>
        /// <param name="right">Правое поддерево</param>
        public TreeNode(T data, TreeNode<T> left = null, TreeNode<T> right = null)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }

    }
