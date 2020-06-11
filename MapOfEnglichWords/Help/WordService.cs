using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MapOfEnglishWords.db;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords.Help
{
    public class WordService : IWordService
    {
        public WordDto[] GetAll()
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Include(x=>x.Parents)
                    .Include(x=>x.Childrens)
                    .ToArray();
            }
        }

        public WordDto GetById(int Id)
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Include(x => x.Parents)
                    .Include(x => x.Childrens)
                    .First(x=>x.Id == Id);
            }
        }

        public WordDto[] GetInitialize()
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Where(x => x.Parents.Count == 0)
                    .Include(x => x.Parents)
                    .Include(x => x.Childrens)
                    .ToArray();
            }
        }

        public WordDto[] GetParent(int id)
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Include(x => x.Parents)
                    .First(x => x.Id == id)
                    .Parents.ToArray();
            }
        }

        public WordDto[] GetChildren(int id)
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Include(x => x.Childrens)
                    .First(x => x.Id == id)
                    .Childrens.ToArray();
            }
        }

        public void Add(WordDto wordDto)
        {
            using (var context = new UserContext())
            {
                context.Words.Attach(wordDto);
                context.Words.Add(wordDto);
                context.SaveChanges();
            }
        }

        public void Update(WordDto wordDto)
        {
            using (var context = new UserContext())
            {
               var newWordDto= context.Words.FirstOrDefault(x => x.Id == wordDto.Id);
               newWordDto.Name = wordDto.Name;
               newWordDto.Translation = wordDto.Translation;
               newWordDto.Example = wordDto.Example;
               context.SaveChanges();
            }
        }

        public void Delete(WordDto wordDto)
        {
            using (var context=new UserContext())
            {
                context.Words.Attach(wordDto);
                context.Words.Remove(wordDto);
                context.SaveChanges();
            }
        }


        public void DeleteAllById(int wordId)
        {
            using (var context = new UserContext())
            {
                var word = context.Words.First(x => x.Id == wordId);
                context.Words.Remove(word);
                context.SaveChanges();
            }
        }

        public void DeleteById(int wordId)
        {
            using (var context = new UserContext())
            {
                //context.Words.Attach(wordDto);
                //context.Words.Remove(wordDto);
                //context.SaveChanges();
            }
        }
    }
}