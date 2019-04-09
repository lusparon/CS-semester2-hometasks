using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace HomeWork14
{
    public class TextStatistics
    {
        private string text;

        ///Подсчитывает количество вхождений каждого слова с помощью БДП в строке
        static TreeNode<CntString> CountWords(string s)
        {
            TreeNode<CntString> root = null;
            foreach (var x in s.Split(new char[] { ' ', '&', '?', ',', ':', '.', '!', ';' },StringSplitOptions.RemoveEmptyEntries))
                AddWord(ref root, x);
            return root;
        }

        ///Добавляет новый узел со словом в дерево, либо увеличивает число его вхождения на 1
        static void AddWord(ref TreeNode<CntString> root, string x)
        {
                if (root == null)
                    root = new TreeNode<CntString>(new CntString(x,1), null, null);
                else if (x.CompareTo(root.data.word) < 0)
                    AddWord(ref root.left, x);
                else if (x.CompareTo(root.data.word) > 0)
                    AddWord(ref root.right, x);
                else if (x.CompareTo(root.data.word) == 0)
                    root.data.count++;
        }
        public string Text
        {
            get { return text; }
            set {
                Debug.Assert(value != null && value != "");
                text = value;
            }
        }

        /// <summary>
        /// Количество слов в тексте
        /// </summary>
        public int Count
        {
            get { return text.Split(new char[] {' ','&','?',',',':','.','!',';'},StringSplitOptions.RemoveEmptyEntries).Count(); }
     
        }

        //конструктор
        public TextStatistics(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Проверка наличия заданного слова в тексте
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Contains(string word)
        {
            Debug.Assert(word != null && word !="");
            var root = CountWords(text);
            return ContainsHelp(ref root, word);
        }
        static bool ContainsHelp(ref TreeNode<CntString> root ,string word )
        {
            if (root == null)
                return false;
            if (root.data.word == word)
                return true;
            return ContainsHelp(ref root.left, word) || (ContainsHelp(ref root.right, word));
        }

        ///индексное свойство
        public int this[string word]
        {
           get {
                if (!text.Contains(word))
                    return 0;
                else return FindInBST(CountWords(text), word);
            }
        }

        static int FindInBST(TreeNode<CntString> root,string word  )
        {
            if (root == null)
                return 0;
            else if (root.data.word == word)
                return root.data.count;
            else if (word.CompareTo(root.data.word) < 0)
                return FindInBST(root.left, word);
            //else if (word.CompareTo(root.data.word)>0)
                return FindInBST(root.right, word);
        }

        //Поиск любого слова с минимальным числом вхождений в текст, не меньшим заданного значения
        public string WordMoreThen(int x)
        {
            var min = new CntString("a",int.MaxValue);
            var root = CountWords(text);
            var q = new Queue<TreeNode<CntString>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var a = q.Dequeue();
                if (a.data.count >= x && a.data.count < min.count)
                    min = a.data;
                if (a.left != null)
                    q.Enqueue(a.left);
                if (a.right != null)
                    q.Enqueue(a.right);
            }
            return min.word;
        }

        //Поиск любого слова с максимальным числом вхождений в текст, не превышающим заданное значение 
        public string WordLessThen(int x)
        {
            var max = new CntString("a", 1);
            var root = CountWords(text);
            var q = new Queue<TreeNode<CntString>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var a = q.Dequeue();
                if (a.data.count <= x && a.data.count >= max.count)
                    max = a.data;
                if (a.left != null)
                    q.Enqueue(a.left);
                if (a.right != null)
                    q.Enqueue(a.right);
            }
            return max.word;
        }

        /// Вспомогательная процедура печати содержимого бинарного дерева 
        /// при инфиксном обходе
        static void InfixPrintTree(TreeNode<CntString> root)
        {
            if (root == null) return;
            InfixPrintTree(root.left);
            Console.WriteLine("Слово : "+"'"+root.data.word+"'" + " ; "+"Количество повторений : "+root.data.count);
            InfixPrintTree(root.right);
        }

        //Печать статистики по словам в алфавитном порядке.
        public void PrintAlph()
        {
            var root = CountWords(text);
            WriteLine("СТАТИСТИКА ТЕКСТА :");
            InfixPrintTree(root);
        }

        //Получение списка (односвязного или двусвязного) с информацией о словах, начинающихся на заданную непустую подстроку.
        public LinkedList<CntString> ListWithWords(string s)
        {
            var l = new LinkedList<CntString>();
            var root = CountWords(text);
            var q = new Queue<TreeNode<CntString>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var a = q.Dequeue();
                if (a.data.word.StartsWith(s))
                    l.AddLast(a.data);
                if (a.left != null)
                    q.Enqueue(a.left);
                if (a.right != null)
                    q.Enqueue(a.right);
            }
            return l;
        }

    }
}
