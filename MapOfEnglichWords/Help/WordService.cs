using System.Linq;
using MapOfEnglishWords.db;

namespace MapOfEnglishWords.Help
{
    public class WordService : IWordService
    {
        public WordDto[] GetAll()
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .ToArray();
            }
        }

        public WordDto[] GetInitialize()
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Where(x => x.Parents.Count == 0)
                    .ToArray();
            }
        }

        public WordDto[] GetParent(int id)
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .First(x => x.Id == id)
                    .Parents.ToArray();
            }
        }

        public WordDto[] GetChildren(int id)
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .First(x => x.Id == id)
                    .Childrens.ToArray();
            }
        }
    }
}