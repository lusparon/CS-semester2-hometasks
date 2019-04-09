using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Diagnostics;
using static System.Console;

namespace HomeWork14
{
    class main
    {
        static void Main(string[] args)
        {
            var text1 = new TextStatistics("Привет , как дела ? как как как дела дела Привет Попугай");
            WriteLine("Строка : "+text1.Text);
            WriteLine();
            //количество слов в тексте 
            WriteLine("количество слов в тексте : " + text1.Count);
            WriteLine();
            //содержится ли слово в тексте 
            WriteLine("содержится ли слово 'как' в тексте ? " + text1.Contains("как"));
            WriteLine();
            //индексное свойство
            WriteLine($"Количество повторений слова 'как' в тексте : {text1["как"]} ");
            WriteLine();
            //Поиск любого слова с минимальным числом вхождений в текст, не меньшим заданного значения
            WriteLine(text1.WordMoreThen(3));
            WriteLine();
            //Поиск любого слова с максимальным числом вхождений в текст, не превышающим заданное значение
            WriteLine(text1.WordLessThen(2));
            WriteLine();
            //Печать статистики по словам в алфавитном порядке.
            text1.PrintAlph();
            WriteLine();
            //Получение списка (односвязного или двусвязного) с информацией о словах, начинающихся на заданную непустую подстроку.
            foreach (var x in text1.ListWithWords("П"))
                WriteLine(x.word+" ; "+x.count);
        }
    }
}
