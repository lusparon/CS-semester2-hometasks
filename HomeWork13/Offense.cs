using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace PDD
{
	public class Offense
	{
		public string article; //статья
        public string description;//описание
        public int fine;//штраф 
		public string Article
		{
			get { return article; }
		}
		public string Description
		{
			get { return description; }
		}
		public int Fine
		{
			get { return fine; }
            set {
                Debug.Assert(value > 0);
                fine = value;
            }
		}

		public Offense(string Article,string Description,int Fine)
		{
			Debug.Assert(Fine>0);
			Debug.Assert(Article!=null && Article!="");
			Debug.Assert(Description != null && Description != "");
			this.article = Article;
			this.description = Description;
			this.fine = Fine;
		}

		public void Println()
		{
			WriteLine($"Название статьи : {this.Article}");
			WriteLine($"Описание правонарушения : {this.Description}");
			WriteLine($"Размер штрафа : {this.Fine} р.");
		}
	}
}
