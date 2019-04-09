using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Diagnostics;

namespace HomeWork6
{
    /// <summary>
    /// Перечислимый тип для месяца
    /// </summary>
    enum MyMonth : long { january=1, february, march, april, may, june, july, august, september, october, november, december }
    class htask
    {
        public class Date
        {
            public int day;
            public MyMonth month;
            public int year;
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="day"></param>
            /// <param name="month"></param>
            /// <param name="year"></param>
            public Date(int day, MyMonth month, int year)
            {
                Debug.Assert( (int)month>=1 && (int)month<=12);
                this.day = day;
                this.month = month;
                this.year = year;
            }
            /// <summary>
            /// Печать даты без перехода на новую строку
            /// </summary>
            public void Print()
            {
                if ((int)this.month>=10)
                    Write($"{this.day}/{(int)this.month}/{this.year}");
                else
                    Write($"{this.day}/0{(int)this.month}/{this.year}");
            }
            /// <summary>
            /// Печать даты с переходом на новую строку
            /// </summary>
            public void PrintLn()
            {
                Print();
                WriteLine();
            }
            /// <summary>
            /// Возвращает истину, если текущая дата больше, чем дата-параметр, и ложь в противном случае
            /// </summary>
            /// <param name="d"></param>
            /// <returns></returns>
            public bool IsMore(Date d)
            {
                if (this.year > d.year)
                    return true;
                else
                    if (this.year == d.year)
                    {
                        if (this.month > d.month)
                            return true;
                        else
                            if (this.month == d.month)
                            {
                                if (this.day > d.day)
                                    return true;
                                else
                                    return false;
                            }
                    }
                return false;
            }
        }
        /// <summary>
        /// Создаёт новый текстовый файл из одной строки, в которой через пробел записаны первые слова строк исходного файла, заканчивающиеся на заданную подстроку.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="newpart"></param>
        /// <param name="pref"></param>
        static void CreateNewtxt(string s, string news, string pref)
        {
            string s1 = "";
            foreach (var x in File.ReadLines(s))
            {
                if (x!="")
                {
                    var ss = x.Split(' ');
                    bool cond = true;
                    foreach (var y in ss)
                    {
                        if (cond && y.EndsWith(pref))
                        {
                            cond = false;
                            s1 += y + " ";
                        }
                    }
                }
            }
            File.WriteAllText(news, String.Join(" ", s1));
        }
        /// <summary>
        /// Находит наибольшую дату в файле
        /// </summary>
        /// <param name="args"></param>
        static string MaxDate(string s)
        {
            var maxdate = new Date(1, MyMonth.january,1);
            foreach (var x in File.ReadLines(s))
            {
                if (x!="")
                {
                    var ss = x.Split(' ');
                    foreach (var y in ss)
                    {
                        string[] d=y.Split('/');
                        var newdate = new Date(int.Parse(d[0]),(MyMonth)int.Parse(d[1]), int.Parse(d[2]));
                        if (newdate.IsMore(maxdate))
                            maxdate = newdate;
                    }
                }
            }
            int smonth = (int)maxdate.month;
            var s1 = "";
            if (smonth>=10)
                s1 = maxdate.day.ToString() + "/" + ((int)maxdate.month) + "/" + maxdate.year.ToString();
            else
                s1 = maxdate.day.ToString() + "/0" + ((int)maxdate.month) + "/" + maxdate.year.ToString();
            return s1;
        }
        /// <summary>
        /// Находит наибольшую дату в файле, используя ReadAllText
        /// </summary>
        /// <param name="args"></param>
        static string MaxDate2(string s)
        {
            var q = File.ReadAllText(s);
            var maxdate = new Date(1, MyMonth.january, 1);
            var q1 = q.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split('/'));
            var q2 = q1.Select(x => new Date(int.Parse(x[0]), (MyMonth)(int.Parse(x[1])), int.Parse(x[2])));
            foreach (var x in q2)
            {
                if (x.IsMore(maxdate))
                    maxdate = x;
            }
            int smonth = (int)maxdate.month;
            var s1 = "";
            if (smonth >= 10)
                s1 = maxdate.day.ToString() + "/" + ((int)maxdate.month) + "/" + maxdate.year.ToString();
            else
                s1 = maxdate.day.ToString() + "/0" + ((int)maxdate.month) + "/" + maxdate.year.ToString();
            return s1;
        }
        static void Main(string[] args)
        {
            //задание 5
            CreateNewtxt("input-files/task5/1.txt", "NewFile.txt","llo");

            //extratask 1
            WriteLine("extratask 1");
            Debug.Assert(MaxDate("input-files/many.txt") == "15/12/2034");
            Debug.Assert(MaxDate("input-files/empty.txt") == "1/01/1");
            Debug.Assert(MaxDate("input-files/one.txt") == "2/07/1999");
            WriteLine("Тесты прошли успешно!");
            WriteLine();

            //extratask 2
            WriteLine("extratask 2");
            Debug.Assert(MaxDate2("input-files/many.txt") == "15/12/2034");
            Debug.Assert(MaxDate2("input-files/empty.txt") == "1/01/1");
            Debug.Assert(MaxDate2("input-files/one.txt") == "2/07/1999");
            WriteLine("Тесты прошли успешно!");
        }
    }
}
