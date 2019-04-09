using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;
using System.IO;

namespace HomeWork3
{
    class htaskregex
    {
        /// <summary>
        /// находит в строке все автомобильные номера и сохраняет их в новый файл.
        /// </summary>
        static void AllAutoNumbers(string s,string FileName)
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (Match m in Regex.Matches(s, @"\b[АВЕКМНОРСТУХ]\d{3}[АВЕКМНОРСТУХ]{2}\d{2,3}\b"))
                    sw.WriteLine(m);
            }
        }

        /// <summary>
		/// Печатает содержимое файла
		/// </summary>
		/// <param name="s"></param>
		static void PrintFile(string s)
        {
            try
            {
                using (var sr = new StreamReader(s))
                {
                    while (!sr.EndOfStream)
                        WriteLine(sr.ReadLine());
                }
            }
            catch (FileNotFoundException e)
            {
                WriteLine(e.Message);
                WriteLine("Ошибка открытия файла");
            }
        }
        /*
        /// <summary>
        /// Сохранить в новую строку все содержащиеся в нём IPv4-адреса в десятичной записи с точками через разделитель.
        /// </summary>
        /// <param name="args"></param>
       static string IPv4(string s)
        {
            string s1;
            foreach (Match m in Regex.Matches(s, @"[0-255]\.[0-255]\.[0-255]\.[0-255]"))
                s1 = s1+ m.ToString;
            return s1;
        }*/

        /// <summary>
        /// Дана строка. Извлечь и распечатать все встречающиеся в ней адреса электронной почты.
        /// </summary>
        /// <param name="args"></param>
        static void MailAdress(string s)
        {
            foreach (Match m in Regex.Matches(s, @"\b\w+@\w+\.ru"))
                WriteLine(m);
        }

        static void Main(string[] args)
        {
            //находит в строке все автомобильные номера и сохраняет их в новый файл.
            WriteLine("Задание 1");
            string s = "А161СТ161 gyadgg Н001КМ01 ";
            AllAutoNumbers(s, "Auto.dat");
            PrintFile("Auto.dat");
            WriteLine();

            WriteLine("Задание 2");
            WriteLine();

            //Дана строка. Извлечь и распечатать все встречающиеся в ней адреса электронной почты.
            WriteLine("Задание 3");
            s = "lusparon99@bk.ru hsuh Hello123@mail.ru";
            MailAdress(s);
            WriteLine();
        }
    }
}
