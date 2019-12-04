using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapOfEnglichWords.Model;

namespace MapOfEnglichWords.DAL
{
    public class LocalStorageCode : IStorage
    {
        static LocalStorageCode instance;
        public static LocalStorageCode Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalStorageCode();
                }
                return instance;
            }

        }
        public List<Word> Words { get; set; }
        private LocalStorageCode()
        {
            Words = new List<Word>
            {
                new Word("Animal","Животное"),
                new Word("House","Дом"),
                new Word("Family","Семья"),
                new Word("Person","Персона")
            };
        }
        public List<Word> GetMainWords()
        {
            return Words;
        }

        public void SaveMainWords()
        {
            
        }

    }
}
