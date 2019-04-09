using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;


namespace HomeWork11
{
    class TreeHTask
    {
        /// <summary>
        /// Вывести элементы дерева при постфиксном обходе
        /// </summary>
        /// <param name="args"></param>
        static void PostfixPrintTree<T>(TreeNode<T> root)
        {
            if (root == null)
                return;
            PostfixPrintTree(root.left);
            PostfixPrintTree(root.right);
            Write($"{root.data} ");
        }

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
        ///  процедура печати дерева с переходом на новую строку 
        /// </summary>
        static void InfixPrintln(TreeNode<int> tree, bool f = true)
        {
            if (tree == null)
            {
                WriteLine("<empty line>");
                return;
            }
            if (tree.left != null)
                InfixPrintln(tree.left, false);
            Write(tree.data + " ");
            if (tree.right != null)
                InfixPrintln(tree.right, f);
            else if (f)
                WriteLine();
        }

        /// <summary>
        /// Дано непустое бинарное дерево целых чисел. Найти ссылку (то есть значение типа TreeNode<int>) на его минимальный элемент.
        /// </summary>
        static TreeNode<int> MinInTree(TreeNode<int> root)
        {
            Debug.Assert(root != null);
            var min = new TreeNode<int>(int.MaxValue);
            MinInTreeHelp(root,ref min);
            return min;
        }
        static void MinInTreeHelp(TreeNode<int> root, ref TreeNode<int> min)
        {
            if (root == null)
                return;
            if (root.data < min.data)
                min = root;
            MinInTreeHelp(root.left,ref min);
            MinInTreeHelp(root.right,ref min);

        }

        /// <summary>
        /// Дано бинарное дерево целых чисел. Уменьшить значения чётных вершин в два раза.
        /// </summary>
        static void Div2(TreeNode<int> root)
        {
            if (root == null)
                return;
            Div2(root.left);
            Div2(root.right);
            if (root.data % 2 == 0)
                root.data = root.data / 2;
        }
        /// <summary>
        /// Дано непустое бинарное дерево целых чисел. Найти сумму значений в листьях.
        /// </summary>
        static int SumLists(TreeNode<int> root)
        {
            Debug.Assert(root != null);
            var sum = 0;
            SumListsHelp(root,ref sum);
            return sum;
        }
        static void SumListsHelp(TreeNode<int> root,ref int sum)
        {
            if (root == null)
                return;
            if (root.left == null && root.right == null)
                sum += root.data;
            SumListsHelp(root.left,ref sum);
            SumListsHelp(root.right,ref sum);
        }

        /// <summary>
        /// Дано бинарное дерево целых чисел (оно может быть пустым). Добавить к листьям с нечётными значениями правые ветви с числом -1.
        /// </summary>
        static void AddToList(TreeNode<int> root)
        {
            if (root == null)
                return;
            AddToList(root.left);
            AddToList(root.right);
            if (root.left == null && root.right == null && root.data % 2 != 0)
                root.right = new TreeNode<int>(-1);
        }

        /// <summary>
        /// Дано бинарное дерево целых чисел. Удалить все листья с нечётными значениями.
        /// </summary>
        static TreeNode<int> DeleteLists(TreeNode<int> root)
        {
            if (root == null)
                return null;
            DeleteListsHelp(ref root);
            return root;
        }
        static void DeleteListsHelp(ref TreeNode<int> root)
        {
            if (root.left != null)
                DeleteListsHelp(ref root.left);
            if (root.right != null)
                DeleteListsHelp(ref root.right);
            if (root.left == null && root.right == null && root.data % 2 != 0)
                root = null;
        }

        /// <summary>
        /// Дано бинарное дерево. Создать его точную копию.
        /// </summary>
        static TreeNode<T> CopyTree<T>(TreeNode<T> root)
        {
            if (root == null)
                return null;
            var l = root;
            CopyTreeHelp(root,ref l);
            return l;
        }
        static void CopyTreeHelp<T>(TreeNode<T> root,ref TreeNode<T> l)
        {
            if (root == null)
                return ;
            if (root.left!= null )
            {
                l.data = root.data;
                CopyTreeHelp(root.left,ref l.left);
            }
            if (root.right != null)
            {
                l.data = root.data;
                CopyTreeHelp(root.right, ref l.right);
            }
        }
        static void Main()
        {
            //задание 1
            WriteLine("Задание 1");
            PostfixPrintTree(MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5))));
            TreeNode<int> l= null;
            PostfixPrintTree(l);
            WriteLine();
            PostfixPrintTree(MkTNode(1));
            WriteLine();
            WriteLine();

            //задание 2
            WriteLine("Задание 2");
            InfixPrintln(MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5))),true);
            InfixPrintln(l,true);
            InfixPrintln(MkTNode(1), true);
            WriteLine();
            WriteLine();

            //задание 3
            Debug.Assert(MinInTree((MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5))))).data == 1);
            Debug.Assert(MinInTree(MkTNode(1, MkTNode(2, MkTNode(4, MkTNode(8)), MkTNode(5, MkTNode(9), MkTNode(10))), MkTNode(3, MkTNode(6), MkTNode(7, MkTNode(11))))).data== 1);
            Debug.Assert(MinInTree((MkTNode(-7, MkTNode(23), MkTNode(3, MkTNode(-14), MkTNode(5))))).data == -14);
            Debug.Assert(MinInTree((MkTNode(5, MkTNode(0), MkTNode(73, MkTNode(-98), MkTNode(65))))).data == -98);
            WriteLine("Задание 3 : тесты успешны!");
            WriteLine();

            //задание 4
            WriteLine("Задание 4");
            WriteLine("Пример 1");
            var root = MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            Div2(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            WriteLine("Пример 2");
            root = MkTNode(1, MkTNode(2, MkTNode(4, MkTNode(8)), MkTNode(5, MkTNode(9), MkTNode(10))), MkTNode(3, MkTNode(6), MkTNode(7, MkTNode(11))));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            Div2(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            WriteLine("Пример 3");
            root = MkTNode(-7, MkTNode(23), MkTNode(3, MkTNode(-14), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            Div2(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            WriteLine("Пример 4");
            root = MkTNode(2, MkTNode(4), MkTNode(6, MkTNode(8), MkTNode(10)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            Div2(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            //задание 5
            WriteLine("Задание 5");
            WriteLine("Пример 1");
            root = MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5)));
            Write("сумма значений в листьях = ");
            WriteLine(SumLists(root));
            WriteLine();

            WriteLine("Пример 2");
            root = MkTNode(1, MkTNode(2, MkTNode(4, MkTNode(8)), MkTNode(5, MkTNode(9), MkTNode(10))), MkTNode(3, MkTNode(6), MkTNode(7, MkTNode(11))));
            Write("сумма значений в листьях = ");
            WriteLine(SumLists(root));
            WriteLine();

            WriteLine("Пример 3");
            root = MkTNode(-7, MkTNode(23), MkTNode(3, MkTNode(-14), MkTNode(5)));
            Write("сумма значений в листьях = ");
            WriteLine(SumLists(root));
            WriteLine();

            WriteLine("Пример 4");
            root = MkTNode(2, MkTNode(4), MkTNode(6, MkTNode(8), MkTNode(10)));
            Write("сумма значений в листьях = ");
            WriteLine(SumLists(root));
            WriteLine();

            WriteLine("Пример 5");
            root = MkTNode(5, MkTNode(5));
            Write("сумма значений в листьях = ");
            WriteLine(SumLists(root));
            WriteLine();

            //задание 6
            WriteLine("Задание 6");
            WriteLine("Пример 1");
            root = MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            AddToList(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            WriteLine("Пример 2");
            root = MkTNode(1, MkTNode(2, MkTNode(4, MkTNode(8)), MkTNode(5, MkTNode(9), MkTNode(10))), MkTNode(3, MkTNode(6), MkTNode(7, MkTNode(11))));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            AddToList(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            WriteLine("Пример 3");
            root = MkTNode(-7, MkTNode(23), MkTNode(3, MkTNode(-14), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            AddToList(root);
            WriteLine("Конечное дерево");
            InfixPrintln(root);
            WriteLine();

            //задание 7
            WriteLine("Задание 7");
            WriteLine("Пример 1");
            root = MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Конечное дерево");
            InfixPrintln(DeleteLists(root));
            WriteLine();

            WriteLine("Пример 2");
            root = MkTNode(1, MkTNode(2, MkTNode(4, MkTNode(8)), MkTNode(5, MkTNode(9), MkTNode(10))), MkTNode(3, MkTNode(6), MkTNode(7, MkTNode(11))));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            DeleteLists(root);
            WriteLine("Конечное дерево");
            InfixPrintln(DeleteLists(root));
            WriteLine();

            WriteLine("Пример 3");
            root = MkTNode(-7, MkTNode(23), MkTNode(3, MkTNode(-14), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Конечное дерево");
            InfixPrintln(DeleteLists(root));
            WriteLine();

            WriteLine("Пример 4");
            root = MkTNode(1);
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Конечное дерево");
            InfixPrintln(DeleteLists(root));
            WriteLine();

            WriteLine("Пример 5");
            root = MkTNode(4, MkTNode(6), MkTNode(9, MkTNode(-8), MkTNode(15)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Конечное дерево");
            InfixPrintln(DeleteLists(root));
            WriteLine();

            //задание 8
            WriteLine("Задание 8");
            WriteLine("Пример 1");
            root = MkTNode(1, MkTNode(2), MkTNode(3, MkTNode(4), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Копия дерева");
            InfixPrintln(CopyTree(root));
            WriteLine();

            WriteLine("Пример 2");
            root = MkTNode(-7, MkTNode(23), MkTNode(3, MkTNode(-14), MkTNode(5)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Копия дерева");
            InfixPrintln(CopyTree(root));
            WriteLine();

            WriteLine("Пример 3");
            root = MkTNode(1);
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Копия дерева");
            InfixPrintln(CopyTree(root));
            WriteLine();

            WriteLine("Пример 4");
            root = MkTNode(4, MkTNode(6), MkTNode(9, MkTNode(-8), MkTNode(15)));
            WriteLine("Исходное дерево");
            InfixPrintln(root);
            WriteLine("Копия дерева");
            InfixPrintln(CopyTree(root));
            WriteLine();


        }
    }

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
/*Задание 1
2 4 5 3 1
1

Задание 2
2 1 4 3 5
<empty line>
1


Задание 3 : тесты успешны!

Задание 4
Пример 1
Исходное дерево
2 1 4 3 5
Конечное дерево
1 1 2 3 5

Пример 2
Исходное дерево
8 4 2 9 5 10 1 6 3 11 7
Конечное дерево
4 2 1 9 5 5 1 3 3 11 7

Пример 3
Исходное дерево
23 -7 -14 3 5
Конечное дерево
23 -7 -7 3 5

Пример 4
Исходное дерево
4 2 8 6 10
Конечное дерево
2 1 4 3 5

Задание 5
Пример 1
сумма значений в листьях = 11

Пример 2
сумма значений в листьях = 44

Пример 3
сумма значений в листьях = 14

Пример 4
сумма значений в листьях = 22

Пример 5
сумма значений в листьях = 5

Задание 6
Пример 1
Исходное дерево
2 1 4 3 5
Конечное дерево
2 1 4 3 5 -1

Пример 2
Исходное дерево
8 4 2 9 5 10 1 6 3 11 7
Конечное дерево
8 4 2 9 -1 5 10 1 6 3 11 -1 7

Пример 3
Исходное дерево
23 -7 -14 3 5
Конечное дерево
23 -1 -7 -14 3 5 -1

Задание 7
Пример 1
Исходное дерево
2 1 4 3 5
Конечное дерево
2 1 4 3

Пример 2
Исходное дерево
8 4 2 9 5 10 1 6 3 11 7
Конечное дерево
8 4 2 5 10 1 6 3

Пример 3
Исходное дерево
23 -7 -14 3 5
Конечное дерево
-7 -14 3

Пример 4
Исходное дерево
1
Конечное дерево
<empty line>

Пример 5
Исходное дерево
6 4 -8 9 15
Конечное дерево
6 4 -8 9

Задание 8
Пример 1
Исходное дерево
2 1 4 3 5
Копия дерева
2 1 4 3 5

Пример 2
Исходное дерево
23 -7 -14 3 5
Копия дерева
23 -7 -14 3 5

Пример 3
Исходное дерево
1
Копия дерева
1

Пример 4
Исходное дерево
6 4 -8 9 15
Копия дерева
6 4 -8 9 15*/
