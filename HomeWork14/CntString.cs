using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HomeWork14
{
    public class CntString
    {
        public string word { get; }
        public int count { get; set; }
        public CntString(string Word,int Count)
        {
            Debug.Assert(Word !="" && Word!=null);
            Debug.Assert(Count>0);
            word = Word;
            count = Count;
        }
    }
}
