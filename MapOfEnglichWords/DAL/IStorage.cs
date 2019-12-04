using MapOfEnglichWords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.DAL
{
    public interface IStorage
    {
        List<Word> GetMainWords();
        void SaveMainWords();
        List<Word> Words { get; set; }
    }
}
