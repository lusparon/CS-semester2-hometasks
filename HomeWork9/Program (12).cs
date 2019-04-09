using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace lesson
{
	class Program
	{
		static Dictionary<string, HashSet<String>> IPv4(string s)
		{
            var d = new Dictionary<string, HashSet<String>>();
            var m1 = new HashSet<string>();
            var m2 = new HashSet<string>();
            var m3 = new HashSet<string>();
            foreach (var a in File.ReadAllLines(s))
			{
				var a1 = a.Split('.');
                if (int.Parse(a1[0]) >= 0 && int.Parse(a1[0]) <= 127)
                    m1.Add(a);
                else if (int.Parse(a1[0]) >= 128 && int.Parse(a1[0]) <= 191)
                    m2.Add(a);
                else if (int.Parse(a1[0]) >= 192 && int.Parse(a1[0]) <= 224)
                    m3.Add(a); 
			}
            d.Add("Класс А",m1);
            d.Add("Класс B", m2);
            d.Add("Класс C", m3);
            return d;
        }

        static void PrintIP(Dictionary<string, HashSet<String>> d)
        {
            foreach ( var a in d )
            {
                Write(a.Key + " : ");
                foreach (var a1 in a.Value)
                    WriteLine(a1 + ' ');
                WriteLine();
            }
        }
        static int CountBranches(string path)
        {
            return File.ReadAllLines(path).Select(x => x.Split().Where(y => y != "").Count() - 1).Sum();
        }

        ///Подсчет веток в графе и отображение матрицы инциндентости
        static void Graph(string path)
        {
            int cB = 0;
            var sAr = File.ReadAllLines(path);
            var dictId = new Dictionary<string, int>();
            int id = 0;
            int[,] matr = new int[sAr.Length, CountBranches(path)];
            for (int i = 0; i < sAr.Length; i++)
            {
                var sa = sAr[i].Split().Where(x => x != "").ToArray();
                if (!dictId.ContainsKey(sa[0]))
                {
                    dictId.Add(sa[0], id);
                    id++;
                }
                for (int j = 1; j < sa.Length; j++)
                {
                    if (!dictId.ContainsKey(sa[j]))
                    {
                        dictId.Add(sa[j], id);
                        id++;
                    }
                    matr[dictId[sa[j]], cB] = 1;
                    matr[dictId[sa[0]], cB] = -1;
                    cB++;
                }
            }
            WriteLine("Количество веток  = " + cB);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                    Write($"{matr[i, j],3}");
                WriteLine();
            }
        }


        static void Main(string[] args)
		{

            //задание 1
             WriteLine("задание 1");
             var s1 = "1.txt";
             PrintIP(IPv4(s1));
             WriteLine();

            //задание 2
            WriteLine("задание 2");
            var s = "2.txt";
            Graph(s);



        }
	}
}