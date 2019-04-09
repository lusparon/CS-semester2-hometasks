using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static System.Console;

namespace HomeWork4
{
    class htask01
    {
        /// <summary>
        /// Сформировать бинарный файл из N случайных вещественных чисел в диапазоне от a до b (a ≤ b).
        /// </summary>
        static void NewRandomFile(string s, int n, int a, int b)
        {
            Debug.Assert((n >= 0) && (a <= b));
            Random r = new Random();
            using (var bw = new BinaryWriter(File.Create(s)))
            {
                for (var i = 0; i < n; i++)
                    bw.Write(a + r.NextDouble() * (b - a));
            }
        }
        /// <summary>
		/// Печатает содержимое файла (для вещественных)
		/// </summary>
		/// <param name="s"></param>
		static void PrintFile(string s)
        {
            try
            {
                using (var fs = new FileStream(s, FileMode.Open))
                using (var br = new BinaryReader(fs, Encoding.ASCII))
                {
                    while (br.PeekChar() != -1)
                        WriteLine(br.ReadDouble());
                }
            }
            catch (FileNotFoundException e)
            {
                WriteLine(e.Message);
                WriteLine("Ошибка открытия файла");
            }
        }

        /// <summary>
		/// Печатает содержимое файла (для целых)
		/// </summary>
		/// <param name="s"></param>
		static void PrintFile1(string s)
        {
            try
            {
                using (var fs = new FileStream(s, FileMode.Open))
                using (var br = new BinaryReader(fs, Encoding.ASCII))
                {
                    while (br.PeekChar() != -1)
                        WriteLine(br.ReadInt32());
                }
            }
            catch (FileNotFoundException e)
            {
                WriteLine(e.Message);
                WriteLine("Ошибка открытия файла");
            }
        }

        /// <summary>
        ///Печатает лестницой 
        /// </summary>
        /// <param name="args"></param>
        static void PrintStairs(string s)
        {
            var i = 0;
            try
            {
                using (var fs = new FileStream(s, FileMode.Open))
                using (var br = new BinaryReader(fs, Encoding.ASCII))
                {
                    if (fs.Length == 0)
                        WriteLine("< empty file >");
                    while (br.PeekChar() != -1)
                    {
                        i += 1;
                        for (var j = 0; j < i; j++)
                            Write(br.ReadDouble());
                        WriteLine();
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                WriteLine("Ошибка открытия файла");
            }

        }

        /// <summary>
        /// Дано целое число N ≥ 0. Создать бинарный файл целых чисел, содержащий первые N чётных чисел.
        /// </summary>
        /// <param name="args"></param>
        static void CreateEven(int n, string s)
        {
            Debug.Assert(n >= 0);
            using (var bw = new BinaryWriter(File.Create(s)))
            {
                for (var i = 1; i < n + 1; i++)
                    bw.Write(i * 2);
            }

        }
        /// <summary>
        /// Дано целое число K > 0 и файл, содержащий неотрицательные целые числа.
        /// Вывести K-й элемент файла (элементы нумеруются от 1). Если такой элемент отсутствует, то вывести −1.
        /// </summary>
        /// <param name="args"></param>
        static int Numberk(string s, int k)
        {
            Debug.Assert(k > 0);
            var a = 0;
            using (var br = new BinaryReader(File.Open(s, FileMode.Open), Encoding.ASCII))
            {
                var c = 0;
                while (c !=k)
                {
                    c++;
                    if (br.PeekChar() != -1)
                        a = br.ReadInt32();
                    else
                        a = -1;
                }
            }
            return a;
        }

        /// <summary>
		/// создает файл и заполняет его массивом целых чисел
		/// </summary>
		/// <param name="path"></param>
		/// <param name="a"></param>
		static void CreateFile(string path, params int[] a)
        {
            try
            {
                using (var bw = new BinaryWriter(File.Create(path)))
                {
                    for (var i = 0; i < a.Length; i++)
                        bw.Write(a[i]);
                }
            }
            catch (FileNotFoundException e)
            {
                WriteLine(e.Message);
                WriteLine("Ошибка открытия файла");
            }
        }

        delegate bool Predicate(int x);
        /// <summary>
        /// Дан бинарный файл целых чисел. Удалить все его элементы, следующие за первым элементом файла, удовлетворяющим предикату.
        /// </summary>
        /// <param name="args"></param>
        static void DeleteAfterPred(string s, Predicate func)
        {
            using (var br = new BinaryReader(File.Open(s, FileMode.Open)))
            using (var bw = new BinaryWriter(File.Create("temp.dat")))
            {
                while (br.PeekChar() != -1)
                {
                    var a = br.ReadInt32();
                    if (func(a))
                        break;
                    else
                        bw.Write(a);
                }
            }
            File.Delete(s);
            File.Move("temp.dat", s);
        }


        static void Main(string[] args)
        {
            //задание 2
            WriteLine("задание 2");
            NewRandomFile("NewFile0.dat", 6, 0, 10);
            PrintFile("NewFile0.dat");
            WriteLine();

            //задание 3
            WriteLine("задание 3");
            PrintStairs("NewFile0.dat");
            WriteLine();

            //задание 4
            WriteLine("задание 4");
            CreateEven(7, "NewFile1.dat");
            PrintFile1("NewFile1.dat");
            WriteLine();

            //задание 5
            WriteLine("задание 5");
            CreateFile("NewFile2.dat", 1, 2, 3, 4, 5);
            int k = 5;
            WriteLine($"Элемент с номером {k}= {Numberk("NewFile2.dat", k)}");
            WriteLine();

            //задание 7
            WriteLine("задание 7");
            WriteLine("Файл 1");
            CreateFile("NewFile3.dat", 1, 2, 3, 4, 5,6,7,8,9,10);
            DeleteAfterPred("NewFile3.dat", x => x > 5);
            PrintFile1("NewFile3.dat");

            WriteLine("Файл 2");
            CreateFile("NewFile4.dat", 11,13,56,23,1,0,3);
            DeleteAfterPred("NewFile4.dat", x => (x % 2 == 0));
            PrintFile1("NewFile4.dat");

            WriteLine("Файл 3");
            CreateFile("NewFile5.dat", 1,2,3,4,-1,12,34);
            DeleteAfterPred("NewFile5.dat", x => x <0);
            PrintFile1("NewFile5.dat");
        }
    }
}
