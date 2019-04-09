using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PDD
{
	class main
	{
		static void Main(string[] args)
		{
			//проверка класса Справочник
			var s = new Directory("Справочник 1");
			WriteLine("Иссходный справочник : ");
			s.Println();
			WriteLine();
			s.Name = "Другой справочник";
			WriteLine("Конечный справочник : ");
			s.Println();
			WriteLine();

			//проверка класса Правонарушения
			var p = new Offense("Нарушение правил применения ремней безопасности или мотошлемов", 
				"Управление транспортным средством водителем, не пристегнутым ремнем безопасности",500);
			p.Println();
			WriteLine();
			WriteLine("Размер штрафа : "+p.Fine);
			WriteLine("Описание правонарушения : "+ p.Description);
			WriteLine("Название статьи : "+ p.Article);
            WriteLine();

            //Проверка добавления правонарушения из текстового файла
            var s1 = new Directory("Справочник 2");
            s1.AddOffence("1.txt");
            s1.Println();

            //проверка индексного свойства
            WriteLine("проверка индексного свойства :" + s1["12.6"]);
            WriteLine();

            //проверка подсчета суммы
            s1.AddOffence("2.txt");
            WriteLine("Сумма к оплате : "+s1.SumToPay("12.6","15.2"));
		}
	}
}
