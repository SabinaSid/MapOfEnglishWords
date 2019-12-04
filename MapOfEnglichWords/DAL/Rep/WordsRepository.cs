using MapOfEnglichWords.Model;
using System;
using System.Collections.Generic;
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

        public List<Word> Get()
        {
            return context.GetMainWords();
        }

        public void Remove(Word value)
        {
            throw new NotImplementedException();
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
