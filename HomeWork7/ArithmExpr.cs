using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class ArithmExpr
    {
        static string POLIZ(string s)
        {
            var ss = s.Split();
            var st = new Stack<string>();
            var res = "";
            foreach ( var a in ss)
                if (char.IsDigit(a[0]))
                    res += a + ' ';
                else if (a == "(")
                    st.Push(a);
                else if (a==")")
                {
                    while (st.Count!=0 && st.Peek() != "(")
                        res += st.Pop() + ' ';
                      st.Pop();
                }
                else if ((a=="+")||(a=="-")|| (a == "*") || (a == "/"))
                {
                    if (a == "+" || a  == "-")
                        while (st.Count!=0 && ( (st.Peek() == "+") || (st.Peek() == "-") || (st.Peek() == "*") || (st.Peek() == "/")))
                            res += st.Pop() + ' ';
                    if (a == "*" || a == "/")
                        while (st.Count != 0 && ((st.Peek() == "*") || (st.Peek() == "/")))
                            res += st.Pop() + ' ';
                    st.Push(a);
                }
            while (st.Count!=0)
            {
                res += st.Pop();
                if (st.Count != 0)
                    res += ' ';
            }
            return res;

        }
        static int Calc(string s)
        {
            var expr = POLIZ(s);
            var ss = expr.Split(' ');
            var st = new Stack<int>();
            foreach (var x in ss)
                if (char.IsDigit(x[0]))
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
        static void Main(string[] args)
        {
            var s = "2 + 3 * 4";
            Console.WriteLine(Calc(s));
            s = "( 2 + 3 ) * 4";
            Console.WriteLine(Calc(s));
            s = "1 * ( 4 + 3 )";
            Console.WriteLine(Calc(s));
        }
    }
}
