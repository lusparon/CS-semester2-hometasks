using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace HomeWork2
{
    class Program
    {
        /// <summary>
        /// Дан целочисленный массив. На его основе создать новый массив, в котором удалены все вхождения заданного числа.
        /// </summary>
        /// <param name="args"></param>
        static int [] ClearArray(int [] a,int b)
        {
            Debug.Assert(a != null );
            return a.Where(x => x != b).ToArray();
        }

        /// <summary>
        /// Дан целочисленный массив A размера N (> 0). Заполнить его степенями двойки от первой до N-й
        /// </summary>
        /// <param name="args"></param>
        static void PowerOfTwo(ref int [] a)
        {
            Debug.Assert(a != null);
            int s = 2;
           for (var i = 0; i < a.Length ;i++ )
            {
                a[i] = s;
                s *= 2;
            }
        }

        /// <summary>
        /// Дан массив вещественных чисел. Поменять местами его максимальный и минимальный элементы
        /// </summary>
        /// <param name="args"></param>
        static void ChangeMinMax(ref double [] a)
        {
            Debug.Assert(a != null);
            double max = a[0];
                double min = a[0];
                int maxin = 0;
                int minin = 0;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        maxin = i;
                    }
                    if (a[i] < min)
                    {
                        min = a[i];
                        minin = i;
                    }
                }
                var t = a[maxin];
                a[maxin] = a[minin];
                a[minin] = t;
        }

        /// <summary>
        /// Дан массив целых чисел с чётным количеством элементов. Поменять местами его первую и вторую половины
        /// </summary>
        /// <param name="args"></param>
        static void ChangeHalf(ref int [] a)
        {
            Debug.Assert(a != null);
            Debug.Assert(a.Length % 2 == 0);
            int n = a.Length / 2;
            for (int i = 0; i < n; i++)
            {
                var t = a[i];
                a[i] = a[i + n];
                a[i + n] = t;
            }

        }

        /// <summary>
        /// Дан массив целых чисел. Обнулить все его двузначные элементы и вернуть их количество.
        /// </summary>
        /// <param name="args"></param>
       static void DeleteDouble(ref int [] a, out int c)
        {
            Debug.Assert(a != null);
            c = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > 9 && a[i] < 100)
                {
                    a[i] = 0;
                    c++;
                }
        }

        /// <summary>
        /// Дан массив вещественных чисел. Найти сумму и произведение его элементов
        /// </summary>
        /// <param name="args"></param>
        static void SumAndProd(double[] a, out double sum, out double prod)
        {
            Debug.Assert(a != null);
            sum = 0.0;
            prod = 1.0;
            for (int i = 0; i <a.Length; i++)
            {
                sum += a[i];
                prod *= a[i];
            }
        }

        /// <summary>
        /// Дана квадратная целочисленная матрица порядка M. Подсчитать сумму элементов на её побочной диагонали
        /// </summary>
        /// <param name="args"></param>
        static int MatrDiagonaleSum(int [,] a )
        {
            Debug.Assert(a != null);
            Debug.Assert(a.GetLength(0) == a.GetLength(1));
            int m = a.GetLength(0);
            int sum = 0;
            for (int i = 0; i < m; i++)
                sum += a[i, m - 1 - i];
            return (sum);
        }

        /// <summary>
        /// Найти сумму и произведение элементов K-го столбца данной матрицы
        /// </summary>
        /// <param name="args"></param>
        static void SumAndProdMatr(double[,] a, int k, out double sum, out double prod)
        {
            Debug.Assert(a != null);
            Debug.Assert(k >= 1 && k <=a.GetLength(1));
            sum = 0.0;
            prod = 1.0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                sum += a[i, k - 1];
                prod *= a[i, k - 1];
            }
        }

        /// <summary>
        /// Формирует целочисленную матрицу размера M × N, у которой все элементы J-го столбца имеют значение X·J (J = 1, …, N)
        /// </summary>
        /// <param name="args"></param>
        static int[,] MatrixGeneration(int m, int n, int x)
        {
            int[,] a = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = (j + 1) * x;
            return a;
        }
        static void Main(string[] args)
        {
            WriteLine("Задание 1 ");
            int[] a = { 2, 2, 3, 2, 1 };
            foreach (var x in ClearArray(a, 2))
                WriteLine(x);
            WriteLine();

            WriteLine("Задание 2 ");
            int [] b  = {1,2,4,2,5,6,7};
            PowerOfTwo(ref b);
            foreach (var x in b)
                WriteLine(x);
            WriteLine();

            WriteLine("Задание 3 ");
            double[] c = { 10.0,2.0,3.0,4.0,5.0,6.0,-10.0 };
            ChangeMinMax(ref c);
            foreach (var x in c)
                WriteLine(x);
            WriteLine();

            WriteLine("Задание 4 ");
            int[] d = { 1, 2, 3,4,5,6,7,8 };
            ChangeHalf(ref d);
            foreach (var x in d)
                WriteLine(x);
            WriteLine();

            WriteLine("Задание 5 ");
            int[] d1 = { 11, 14, 3, 4, 35, 6, 37, 18 };
            int count = 0;
            DeleteDouble(ref d1, out count);
            foreach (var x in d1)
                WriteLine(x);
            WriteLine("Количество двузначных эл-тов массива: "+ count);
            WriteLine();

            WriteLine("Задание 6 ");
            double[] c1 = { 10.0, 2.0, 3.0, 4.0, 5.0, 6.0, -10.0 };
            double sum = 0.0;
            double prod = 1.0;
            SumAndProd(c1, out sum, out prod);
            WriteLine("Сумма элементов массива = " + sum);
            WriteLine("Произведение элементов массива = " + prod);
            WriteLine();

            WriteLine("Задание 7 ");
            int[,] m = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            WriteLine("Сумма элементов побочной диагонали = " + MatrDiagonaleSum(m));
            WriteLine();

            WriteLine("Задание 8 ");
            double[,] m1 = new double[3, 4] { { 1, 2, 3,12 }, { 4, 5,4, 6 }, { 7, 8,4, 9 } };
            double sum1 = 0.0;
            double prod1 = 1.0;
            SumAndProdMatr(m1, 3, out sum1, out prod1);
            WriteLine("Сумма элементов K-го столбца = " + sum1);
            WriteLine("Произведение  элементов K-го столбца = " + prod1);
            WriteLine();

            WriteLine("Задание 9 ");
            int x1 = 5;
            int m2 = 4;
            int n = 7;
            int[,] matr = new int[m2, n];
            matr = MatrixGeneration(m2, n, x1);
            for (int i = 0; i < m2; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", matr[i, j]);
                Console.WriteLine();
            }


        }
    }
}
