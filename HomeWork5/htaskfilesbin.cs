using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Diagnostics;

namespace HomeWork5
{
    class htaskfilesbin
    {
        /// <summary>
        /// Дан бинарный файл целых чисел. Вывести его содержимое в обратном порядке.
        /// </summary>
        /// <param name="args"></param>
        static void PrintReverse(string s)
        {
            using (var fs = File.Open(s, FileMode.Open))
            using (var br = new BinaryReader(fs))
            {
                var m = new int[fs.Length/sizeof(int)];
                var i = 0;
                while(br.PeekChar()!=-1)
                {
                    m[i] = br.ReadInt32();
                    i++;
                }
                Array.Reverse(m);
                foreach (var n in m)
                    WriteLine(n);
            }
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
        /// <summary>
		/// создает файл и заполняет его массивом вещественных чисел
		/// </summary>
		/// <param name="path"></param>
		/// <param name="a"></param>
		static void CreateFileDouble(string path, params double[] a)
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
        /// <summary>
        /// Дан бинарный файл целых чисел. Вывести его содержимое.
        /// </summary>
        /// <param name="args"></param>
        static void PrintFile(string s)
        {
            using (var fs = File.Open(s, FileMode.Open))
            using (var br = new BinaryReader(fs))
            {
                while (br.PeekChar() != -1)
                    WriteLine(br.ReadInt32());
            }
        }
        /// <summary>
        /// Дан бинарный файл вещественных чисел. Вывести его содержимое.
        /// </summary>
        /// <param name="args"></param>
        static void PrintFileDouble(string s)
        {
            using (var fs = File.Open(s, FileMode.Open))
            using (var br = new BinaryReader(fs, Encoding.ASCII))
            {
                while (br.PeekChar() != -1)
                    WriteLine(br.ReadDouble());
            }
        }
        /// <summary>
        /// Дан непустой бинарный файл с чётным количеством вещественных чисел. Удалить его вторую половину 
        /// </summary>
        /// <param name="args"></param>
        static void DeleteHalf(string s)
        {
            using (var fs = File.Open(s, FileMode.Open))
            using (var br = new BinaryReader(fs,Encoding.ASCII))
            using (var bw = new BinaryWriter(File.Create("time.dat"), Encoding.ASCII))
            {
                Debug.Assert((fs.Length / sizeof(double)) % 2 == 0, "Нечетное количество элементов в файле");
                var i = 0;
                while (fs.Length / sizeof(double) / 2 > i)
                {
                    bw.Write(br.ReadDouble());
                    i++;
                }
            }
            File.Delete(s);
            File.Move("time.dat", s);

        }

        /// <summary>
        /// Дан бинарный файл целых чисел. Поменять местами его максимальный и минимальный элементы.
        /// </summary>
        /// <param name="args"></param>
        private static void ReplaceMinMax(string s)
        {
                var max = int.MinValue;
                var min = int.MaxValue;
                long indmax = 0;           
                long indmin = 0;           
                using (var fs = File.Open(s, FileMode.Open))
                using (var br = new BinaryReader(fs, Encoding.ASCII))
                using (var bw = new BinaryWriter(fs, Encoding.ASCII))
                {
                    while (br.PeekChar() != -1)
                    {
                        int m = br.ReadInt32();
                        if (m > max)
                        {
                            max = m;
                            indmax = fs.Position - sizeof(int);
                        }
                        if (m < min)
                        {
                            min = m;
                            indmin = fs.Position - sizeof(int);
                        }
                    }
                    fs.Seek(indmax, SeekOrigin.Begin);
                    bw.Write(min);
                    fs.Seek(indmin, SeekOrigin.Begin);
                    bw.Write(max);
                }
        }
        static void Main(string[] args)
        {
            //Задание 1
            WriteLine("Задание 1");
            WriteLine("файл 1 ");
            CreateFile("File1.dat", 1,2,3);
            PrintFile("File1.dat");
            WriteLine("файл 1 в обратнои порядке");
            PrintReverse("File1.dat");
            WriteLine();

            WriteLine("файл 2 ");
            CreateFile("File2.dat");
            PrintFile("File2.dat");
            WriteLine("файл 2 в обратнои порядке");
            PrintReverse("File2.dat");
            WriteLine();

            WriteLine("файл 3 ");
            CreateFile("File3.dat", 1);
            PrintFile("File3.dat");
            WriteLine("файл 3 в обратнои порядке");
            PrintReverse("File3.dat");
            WriteLine();

            WriteLine("файл 4 ");
            CreateFile("File4.dat", 1, 2);
            PrintFile("File4.dat");
            WriteLine("файл 4 в обратнои порядке");
            PrintReverse("File4.dat");
            WriteLine();

            //Задание 3
            WriteLine("Задание 3");
            CreateFileDouble("Task3.1.dat", 3.14,5.7,1.34,23.4);
            WriteLine("исходный файл 1 ");
            PrintFileDouble("Task3.1.dat");
            DeleteHalf("Task3.1.dat");
            WriteLine("конечный файл 1");
            PrintFileDouble("Task3.1.dat");
            WriteLine();

            CreateFileDouble("Task3.2.dat", 10.34,15.67);
            WriteLine("исходный файл 2 ");
            PrintFileDouble("Task3.2.dat");
            DeleteHalf("Task3.2.dat");
            WriteLine("конечный файл 2");
            PrintFileDouble("Task3.2.dat");
            WriteLine();

            CreateFileDouble("Task3.3.dat", 10.34, 15.67,100.12,2.3,4.7,1.2);
            WriteLine("исходный файл 3 ");
            PrintFileDouble("Task3.3.dat");
            DeleteHalf("Task3.3.dat");
            WriteLine("конечный файл 3");
            PrintFileDouble("Task3.3.dat");
            WriteLine();

            //Задание 4
            WriteLine("Задание 4");
            CreateFile("task4.dat", 1, 2, 3, 4, 5);
            WriteLine("исходный файл 1 ");
            PrintFile("task4.dat");
            ReplaceMinMax("task4.dat");
            WriteLine("конечный файл 1");
            PrintFile("task4.dat");
            WriteLine();

            CreateFile("task4.dat", 10,23,45,11,3,45,67,0,-10);
            WriteLine("исходный файл 2 ");
            PrintFile("task4.dat");
            ReplaceMinMax("task4.dat");
            WriteLine("конечный файл 2");
            PrintFile("task4.dat");
            WriteLine();

            CreateFile("task4.dat", 0,1,2,12,-3,2);
            WriteLine("исходный файл 3 ");
            PrintFile("task4.dat");
            ReplaceMinMax("task4.dat");
            WriteLine("конечный файл 3");
            PrintFile("task4.dat");
            WriteLine();
        }
    }
}
/*Задание 1
файл 1
1
2
3
файл 1 в обратнои порядке
3
2
1

файл 2
файл 2 в обратнои порядке

файл 3
1
файл 3 в обратнои порядке
1

файл 4
1
2
файл 4 в обратнои порядке
2
1

Задание 3
исходный файл 1
3,14
5,7
1,34
23,4
конечный файл 1
3,14
5,7

исходный файл 2
10,34
15,67
конечный файл 2
10,34

исходный файл 3
10,34
15,67
100,12
2,3
4,7
1,2
конечный файл 3
10,34
15,67
100,12

Задание 4
исходный файл 1
1
2
3
4
5
конечный файл 1
5
2
3
4
1

исходный файл 2
10
23
45
11
3
45
67
0
-10
конечный файл 2
10
23
45
11
3
45
-10
0
67

исходный файл 3
0
1
2
12
-3
2
конечный файл 3
0
1
2
-3
12
2*/
