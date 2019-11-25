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
        private LocalStorage localStorage=LocalStorage.Instance;
        
        public void Add(Word value)
        {
           
        }

        public IEnumerable<Word> Get()
        {
            throw new NotImplementedException();
        }

        public void Remove(Word value)
        {
            throw new NotImplementedException();
        }

        public void Update(Word oldValue, Word newValue)
        {
            throw new NotImplementedException();
        }
    }
}
