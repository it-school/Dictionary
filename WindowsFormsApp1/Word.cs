using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Parts : int { существительное = 1, прилагательное = 2, глагол = 3, союз = 4, местоимение = 5, междометие = 6, предлог = 7, наречие = 8};

namespace WindowsFormsApp1
{
    [Serializable]
    class Words
    {
        String word;
        Parts part;


        public Words()
        {

        }

        public Words(String word, Parts part)
        {
            this.Word = word;
            this.Part = part;
        }

        public string Word { get => word; set => word = value; }
        public Parts Part { get => part; set => part = value; } 

        override public String ToString()
        {
            return this.Word + " (" + Part +")";
        }
    }
}
