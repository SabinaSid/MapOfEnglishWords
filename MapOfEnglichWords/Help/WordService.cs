using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
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
                    .Include(x => x.Parents)
                    .Include(x => x.Childrens)
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
                    .First(x => x.Id == Id);
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

        public WordDto[] GetForRepeat()
        {
            WordDto[] returnWords = new WordDto[3];

            var allWords = GetAll();
            var repeatsWord = allWords
                .Where(x => x.CountRepeat < 6 && x.LastRepeatDate < DateTime.Today)
                .ToArray();
            if (repeatsWord.Length == 0)
                throw new WordException("На сегодня слова закончились. Приходите завтра");
            var selectedIndex = new Random().Next(0, repeatsWord.Length);
            returnWords[0] = repeatsWord[selectedIndex];
            var allWordsWithoutSelected = allWords.Where(x => x.Id != returnWords[0].Id).ToArray();
            returnWords[1] = allWordsWithoutSelected[new Random().Next(0, allWordsWithoutSelected.Length)];
            allWordsWithoutSelected = allWordsWithoutSelected.Where(x => x.Id != returnWords[1].Id).ToArray();
            Thread.Sleep(50);
            returnWords[2] = allWordsWithoutSelected[new Random().Next(0, allWordsWithoutSelected.Length)];
            return returnWords;
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

        public void AddRelation(int wordId, int parentId)
        {
            using (var context = new UserContext())
            {
                context.Database.ExecuteSqlCommand(
                    $"insert into ParentChild(ParentId,ChildId) values ({parentId}, {wordId}) ");
            }
        }

        public void Add(WordDto wordDto)
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
                var newWordDto = context.Words.FirstOrDefault(x => x.Id == wordDto.Id);
                newWordDto.Name = wordDto.Name;
                newWordDto.Translation = wordDto.Translation;
                newWordDto.Example = wordDto.Example;
                context.SaveChanges();
            }
        }

        public void UpdateForTrainer(int wordId)
        {
            using (var context = new UserContext())
            {
                var newWordDto = context.Words.FirstOrDefault(x => x.Id == wordId);
                newWordDto.CountRepeat = newWordDto.CountRepeat+1;
                newWordDto.LastRepeatDate = DateTime.Today;
                context.SaveChanges();
            }
        }

        public void DeleteRelation(int wordId, int parentId)
        {
            using (var context = new UserContext())
            {
                context.Database.ExecuteSqlCommand(
                    $"DELETE FROM ParentChild WHERE ParentId = {parentId} AND ChildId = {wordId}");
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
                        context.Database.ExecuteSqlCommand(
                            $"insert into ParentChild(ParentId,ChildId) values ({parent.Id}, {child.Id}) ");
                    }
                }

                context.Words.Remove(word);
                context.SaveChanges();
            }
        }

        public WordDto GetByName(string wordName)
        {
            using (var context = new UserContext())
            {
                return context.Words
                    .Include(x => x.Parents)
                    .Include(x => x.Childrens)
                    .First(x => x.Name == wordName);
            }
        }
    }
}