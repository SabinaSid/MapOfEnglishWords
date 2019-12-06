using MapOfEnglichWords.DAL.Help;
using MapOfEnglichWords.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.DAL.Rep
{
    public class WordsRepository : IRepository<Word>
    {
        private IStorage context;
        
        public void Add(Word value)
        {
            context.Words.Add(value);
            
        }

        public ObservableCollection<Word> Get()
        {
            return context.GetMainWords();
        }

        public void Remove(Word value)
        {
            context.Words.Remove(value);
        }

        public void Update(Word oldValue, Word newValue)
        {
            oldValue.Name = newValue.Name;
            oldValue.Translation = newValue.Translation;
            oldValue.Example = newValue.Example;
        }
        public WordsRepository(IStorage db)
        {
            context = db;
        }
    }
}
