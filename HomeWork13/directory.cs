using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;
using System.Text.RegularExpressions;
using System.IO;

namespace PDD
{
	public class Directory
	{
		public string fname;
		public System.DateTime lasttime;
        public Dictionary<string, Offense> database { get; private set ; }

        public string Name
		{
			get{ return fname;}
			set{
				Debug.Assert(value!=null && value !="");
					fname =value;
				lasttime = DateTime.Now;}
		}
		public DateTime LastTime
		{
			get { return lasttime; }
		}
        public Directory(string Name)
		{
			this.Name = Name;
            database = new Dictionary<string, Offense>();
        }

		/// <summary>
		/// процедура печати содержимого класса
		/// </summary>
		public void Println()
		{
			WriteLine($"Название справочника : {this.Name} ; Дата последнего обновления : {this.LastTime}");
            WriteLine("Все правонарушения : ");
            foreach (var s in database)
                s.Value.Println();
            WriteLine();
		}
        /// <summary>
        /// метод удаления статьи с правонарушением
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOffence(string id)
        {
            Debug.Assert(database.ContainsKey(id),"Статьи нет в справочнике.");
            Debug.Assert(Regex.IsMatch(id,@"\b<\d+>(\.\d+)*"));
            database.Remove(id);
            lasttime = DateTime.Now;
        }
        /// <summary>
        /// метод добавления статьи с правонарушением
        /// </summary>
        /// <param name="s"></param>
        public void AddOffence(string s )
        {
            var s1 = File.ReadAllText(s,Encoding.GetEncoding(1251)).Split('&');
            s1[0] = Regex.Replace(s1[0]," ","");
            //Debug.Assert(Regex.IsMatch(s1[0], @"\b<\d+>(\.\d+)*"));
            database[s1[0]] = new Offense(s1[1],s1[2],int.Parse(s1[3]));
            lasttime = DateTime.Now;
        }
        /// <summary>
        /// метод для обновления размера штрафа заданной статьи.
        /// </summary>
        /// <param name="id"></param>
        public void UpdateFine(string id,int x)
        {
            //Debug.Assert(Regex.IsMatch(s1[0], @"\b<\d+>(\.\d+)*"));
            database[id].Fine = x;
        }
        /// <summary>
        /// индексное свойство
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[string index]    // Indexer declaration  
        {
            get { return database[index].Fine; }
        }
        public int SumToPay(params string[] p)
        {
            var s = 0;
            foreach (var x in p)
                if (database.ContainsKey(x))
                    s += database[x].Fine;
            return s;
        }
    }
}
