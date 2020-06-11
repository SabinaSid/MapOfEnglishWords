using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
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

        public void AddOrUpdate(WordDto wordDto)
        {
            using (var context = new UserContext())
            {
                context.Words.Attach(wordDto);
                context.Words.AddOrUpdate(wordDto);
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
               newWordDto.Childrens = wordDto.Childrens;
               newWordDto.Parents = wordDto.Parents;
               context.SaveChanges();
            }
        }

        public void DeleteRelation(int wordId,int parentId)
        {
            using (var context = new UserContext())
            {
                context.Database.ExecuteSqlCommand($"DELETE FROM ParentChild WHERE ParentId = {parentId} AND ChildId = {wordId}");
                context.SaveChanges();
            }
        }

        public void DeleteById(int wordId)
        {
            using (var context = new UserContext())
            {
                var word = context.Words.First(x => x.Id == wordId);
                foreach (var child in word.Childrens)
                {
                    foreach (var parent in word.Parents)
                    {
                        context.Database.ExecuteSqlCommand($"insert into ParentChild(ParentId,ChildId) values ({parent.Id}, {child.Id}) ");
                    }
                }
                context.Words.Remove(word);
                context.SaveChanges();
            }
        }
    }
}