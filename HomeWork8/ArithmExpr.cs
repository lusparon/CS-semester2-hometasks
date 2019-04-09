using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace HomeWork8
{
    class ArithmExpr
    {
        /// <summary>
        /// Преобразовывает выражения из инфиксной в постфиксную форму
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string POLIZ(string s)
        {
            var ss = s.Split();
            var st = new Stack<string>();
            var res = "";
            foreach (var a in ss)
                if (int.TryParse(a,out var r ))
                    res += a + ' ';
                else if (a == "(")
                    st.Push(a);
                else if (a == ")")
                {
                    while (st.Count != 0 && st.Peek() != "(")
                        res += st.Pop() + ' ';
                    st.Pop();
                }
                else if ((a == "+") || (a == "-") || (a == "*") || (a == "/"))
                {
                    if (a == "+" || a == "-")
                        while (st.Count != 0 && ((st.Peek() == "+") || (st.Peek() == "-") || (st.Peek() == "*") || (st.Peek() == "/")))
                            res += st.Pop() + ' ';
                    if (a == "*" || a == "/")
                        while (st.Count != 0 && ((st.Peek() == "*") || (st.Peek() == "/")))
                            res += st.Pop() + ' ';
                    st.Push(a);
                }
            while (st.Count != 0)
            {
                res += st.Pop();
                if (st.Count != 0)
                    res += ' ';
            }
            return res;

        }
        /// <summary>
        /// Вычисляет значение выражения в инфиксной форме
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int Calc(string s)
        {
            var expr = POLIZ(s);
            var ss = expr.Split(' ');
            var st = new Stack<int>();
            foreach (var x in ss)
                if (int.TryParse(x, out var r))
                    st.Push(int.Parse(x));
                else if (x == "+")
                    st.Push(st.Pop() + st.Pop());
                else if (x == "-")
                    st.Push(st.Pop() - st.Pop());
                else if (x == "*")
                    st.Push(st.Pop() * st.Pop());
                else if (x == "/")
                    st.Push(st.Pop() / st.Pop());
            return st.Pop();
        }
        /// <summary>
        /// Выводит словарь <преобразованное выражение , его значение>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static Dictionary<string,int> Arithm(string s)
        {
            var d1 = new Dictionary<string,int>();
            var d2 = new Dictionary<string,int>();
            foreach ( var a in File.ReadAllLines(s))
            {
                if (a.Contains("EVAL"))
                {
                    string str1 = a.Remove(0,4);
                    foreach (var b1 in a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        if (d1.ContainsKey(b1))
                            str1 = str1.Replace(b1, d1[b1].ToString());
                    d2[str1] = Calc(str1);
                }
                else
                {
                    var a1 = a.Split('=');
                    d1[a1[0]] = int.Parse(a1[1]);
                }
            }
            return d2;
        }
           
        static void Main(string[] args)
        {
            WriteLine("Файл 1");
            var s = "input-files/1.txt";
            foreach (var a in Arithm(s))
                WriteLine(a);
            WriteLine();

            WriteLine("Файл 2");
            s = "input-files/2.txt";
            foreach (var a in Arithm(s))
                WriteLine(a);
        }
    }
}
