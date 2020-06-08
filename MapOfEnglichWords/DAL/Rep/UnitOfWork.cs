using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.DAL.Rep
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
