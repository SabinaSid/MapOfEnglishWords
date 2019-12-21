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
        public void RemoveWithSave(Word value)
        {
            if (value.Parent != null)
            {
                foreach (var item in value.Childs)
                {
                    value.Parent.Childs.Add(item);
                }
                value.Parent.Childs.Remove(value);
            }
            else
            {
                foreach (var item in value.Childs)
                {
                    context.Words.Add(item);
                }
                context.Words.Remove(value);
            }

        }

        public void Update(Word oldValue, Word newValue)
        {
            oldValue.Name = newValue.Name;
            oldValue.Translation = newValue.Translation;
            oldValue.Example = newValue.Example;
        }

        public void Save()
        {
            context.SaveMainWords();
        }

        public WordsRepository(IStorage db)
        {
            context = db;
        }
    }
}
