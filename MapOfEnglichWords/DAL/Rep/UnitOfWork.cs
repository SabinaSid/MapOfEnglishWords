using MapOfEnglichWords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.DAL.Rep
{
    public class UnitOfWork
    {
        IStorage context;

        public IRepository<Word> Words;
        public UnitOfWork(IStorage context)
        {
            this.context = context;
            Words = new WordsRepository(context);
        }
    }
}
