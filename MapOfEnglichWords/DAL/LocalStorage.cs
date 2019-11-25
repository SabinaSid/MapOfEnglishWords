using MapOfEnglichWords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.DAL
{
    public class LocalStorage : IStorage
    {
        private LocalStorage()
        {
            Words = GetMainWords();
        }
        static LocalStorage instance;
        public static LocalStorage Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new LocalStorage();
                }
                return instance;
            }
            
        }
        public List<Word> Words { get; set; }
        public List<Word> GetMainWords()
        {
            //путь к файлу
            var path = "ads.xml";
            return Xml.LoadObjectFromFile<List<Word>>(path);
        }
        public void Save()
        {
            var x = Xml.Serelialize(Words);
            x.Save("ads.xml");

        }
    }
}
