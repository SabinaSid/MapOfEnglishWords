using MapOfEnglichWords.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.DAL
{
    public interface IStorage
    {
        ObservableCollection<Word> GetMainWords();
        void SaveMainWords();
        ObservableCollection<Word> Words { get; set; }
    }
}
