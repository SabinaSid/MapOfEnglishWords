using MapOfEnglichWords.DAL.LocalStorage;
using MapOfEnglishWords.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.DAL.Rep
{
    public class WordsRepository : IRepository<Word>
    {
        private IStorage context;
        
        public void Add(Word value)
        {
            if (value.Parent!=null)
            {
                value.Parent.Childs.Add(value);
            }
            else
            {
                context.Words.Add(value);
            }

        }

        public ObservableCollection<Word> Get()
        {
            return context.GetMainWords();
        }

        public void Remove(Word value)
        {
            if (value.Parent != null)
            {
                value.Parent.Childs.Remove(value);
            }
            else
            {
                context.Words.Remove(value);
            }
            
        }

        public void Update(ref Word oldValue, Word newValue)
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
