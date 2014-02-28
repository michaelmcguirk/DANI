using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chatbot3
{
    public class Word
    {

        string aWord;
        public string AWord
        {
            get { return aWord; }
            set { aWord = value; }
        }


        public List<int> count = new List<int>();


        public Word()
        {
            this.aWord = aWord;

        }



        public override string ToString()
        {

            return aWord;
            
        }

    }
}
