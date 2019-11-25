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
        public List<Word> GetMainWords()
        {
            //путь к файлу
            var path = "./Content/daily_utf8.xml";
            return Xml.LoadObjectFromFile<List<Word>>(path);
        }
    }
}
