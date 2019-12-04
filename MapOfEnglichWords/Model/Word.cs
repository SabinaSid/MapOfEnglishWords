using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.Model
{
    public class Word
    {
        public string Name { get; set; }

        public string Translation { get; set; }

        public string Example { get; set; }

        public List<Word> Childs { get; set; }

        public Word(string Name, string Translation)
        {
            this.Name = Name;
            this.Translation = Translation;
        }
        public Word()
        {

        }
    }
}
