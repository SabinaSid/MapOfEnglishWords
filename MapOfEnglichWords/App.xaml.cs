using MapOfEnglishWords.DAL;
using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MapOfEnglishWords.db;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //  new MainViewModel(new MainWindow());
            InitializeDb();
        }

        private void InitializeDb()
        {
            var words = new[]
            {
                new WordDb()
                {
                    Name = "Animal", Translation = "Животное",
                    Example = "This looks like a plant, but it's actually an animal."
                },
                new WordDb()
                {
                    Name = "House", Translation = "Дом",
                    Example = "And we walked into a house with a very special home video recording system."
                },
                new WordDb() {Name = "Family", Translation = "Семья"},
                new WordDb() {Name = "Person", Translation = "Персона"}
            };

            words[0].Childrens = new[]
            {
                new WordDb()
                    {Name = "Dog", Translation = "Пес", Example = "On the Internet nobody knows you're a dog, right?"},
                new WordDb()
                {
                    Name = "Duck", Translation = "Утка",
                    Example = "And chickens and ducks and geese and turkeys are basically as dumb as dumps."
                },
                new WordDb() {Name = "Cat", Translation = "Кошка", Example = "When the cat's away, the mice will play."}
            };

            words[0].Parents.Add(new WordDb() {Name = "Life", Translation = "Жизнь"});
            foreach (var item in words[0].Childrens)
            {
                item.Parents.Add(words[0]);
            }

            using (UserContext db = new UserContext())
            {
                db.Words.AddRange(words);
                db.SaveChanges();
            }
        }
    }

    public class WordDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }

        public string Example { get; set; }

        public virtual ICollection<WordDb> Parents { get; set; }

        public virtual ICollection<WordDb> Childrens { get; set; }

        public WordDb()
        {
            Parents = new List<WordDb>();
            Childrens = new List<WordDb>();
        }
    }
}

