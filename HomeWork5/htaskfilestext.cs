using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HomeWork5
{
    class htaskfilestext
    {
        /// <summary>
        ///  Дан текстовый файл. Определить количество символов с заданным кодом.
        /// </summary>
        static int CountSymbols(string s,int c)
        {
            var count = 0;
            using (var sr = new StreamReader(s))
            {
                while(!sr.EndOfStream)
                {
                    if (sr.Read() == c)
                        count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Создать текстовый файл, содержащий все целые двузначные чётные числа по K > 0 чисел на каждой строке.
        /// </summary>
        static void CreateSpecialFile(int k)
        {
            Debug.Assert(k > 0);
            using (var sw = new StreamWriter("NewFile.txt"))
            {
                var m = 10;
                for (var i = 0; i < 45 / k; i++)
                {
                    for (var j = 0; j < k; j++)
                    {
                        sw.Write(m);
                        m+=2;
                    }
                    sw.WriteLine();
                }
                for (var i = 0; i < 45 % k; i++)
                {
                    sw.Write(m);
                    m += 2;
                }
            }
        }
        /// <summary>
        /// Дан текстовый файл, в котором каждый абзац текста начинается с красной строки из пяти пробелов. Определить количество абзацев в тексте.
        /// </summary>
        static int ParagraphCount(string s)
        {
            var f = 0;
            var count = 0;
            using (var sr = new StreamReader(s))
            {
                while (!sr.EndOfStream)
                {
                    int x = sr.Read();
                    if (x == ' ')
                        f++;
                    else
                        f = 0;
                    if (f==5)
                    {
                        count++;
                        f = 0;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Дан текстовый файл. Определить количество строк файла, совпадающих с его первой строкой.
        /// </summary>
        static int CountEqual(string s)
        {
            var count = 0;
            using (var sr = new StreamReader(s))
            {
                var s1 = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var s2 = sr.ReadLine();
                    if (s1 == s2)
                        count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Дан текстовый файл, содержащий целые числа . Найти наибольшее число в файле.
        /// </summary>
        static int MaxInt(string s)
        {
            var max = int.MinValue;
            using (var sr = new StreamReader(s))
            {
                while (!sr.EndOfStream)
                {
                    foreach (var n in sr.ReadLine().Split())
                        if (n!= " " && n != "")
                        {
                            if (int.Parse(n) > max)
                                max = int.Parse(n);
                        }
                }
            }
            return max;
        }
        /// <summary>
        /// Дан текстовый файл, содержащий слова, разделённые пробелами или символами конца строки. Посчитать количество слов в этом файле
        /// </summary>
        static int CountWord(string s)
        {
            int count = 0;
            var f = false;
            using (var sr = new StreamReader(s))
            {
                while (!sr.EndOfStream)
                {
                    var n = sr.Read();
                    if (n != ' ')
                        f = true;
                    if ((n == ' ' || n == '\n') && f)
                    {
                        count++;
                        f = false;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Дан текстовый файл. Заменить в нем все подряд идущие пробелы на один пробел.
        /// </summary>
        static void ReplaceProbels(string s)
        {
            using (var sw = new StreamWriter("temp.txt"))
            using (var sr = new StreamReader(s, Encoding.ASCII))
            {

                while (!sr.EndOfStream)
                {
                    var s1 = sr.ReadLine();
                    s1 = Regex.Replace(s1, @"\s+", " ");
                    sw.Write(s1);
                    sw.WriteLine();
                }
            }
            File.Delete(s);
            File.Move("temp.txt", s);
        }
        static void Main()
        {
            //задание5
            Debug.Assert(CountSymbols("input-files/text1.txt", 97)==5);
            Debug.Assert(CountSymbols("input-files/empty.txt", 97) == 0);
            Debug.Assert(CountSymbols("input-files/text2.txt", 97) == 11);
            WriteLine("Задание 5 : тесты успешны!");

            //задание6
            CreateSpecialFile(10);

            //задание7
            Debug.Assert(ParagraphCount("input-files/paragraph1.txt")==2);
            Debug.Assert(ParagraphCount("input-files/paragraph2.txt") == 3);
            Debug.Assert(ParagraphCount("input-files/paragraph3.txt") == 0);
            WriteLine("Задание 7 : тесты успешны!");

            //задание8
            Debug.Assert(CountEqual("input-files/task8.1.txt") == 2);
            Debug.Assert(CountEqual("input-files/task8.2.txt") == 3);
            Debug.Assert(CountEqual("input-files/task8.3.txt") == 0);
            WriteLine("Задание 8 : тесты успешны!");

            //задание9
            Debug.Assert(MaxInt("input-files/max1.txt") == 100);
            Debug.Assert(MaxInt("input-files/max2.txt") == -3);
            Debug.Assert(MaxInt("input-files/max3.txt") == 89);
            WriteLine("Задание 9 : тесты успешны!");

            //задание10
            Debug.Assert(CountWord("input-files/word1.txt") == 5);
            Debug.Assert(CountWord("input-files/word2.txt") == 4);
            Debug.Assert(CountWord("input-files/word3.txt") == 1);
            WriteLine("Задание 10 : тесты успешны!");

            //задание11
            ReplaceProbels("input-files/htask-txt/probels1.txt");
            ReplaceProbels("input-files/htask-txt/probels2.txt");
            ReplaceProbels("input-files/htask-txt/probels3.txt");

        }
    }
}
