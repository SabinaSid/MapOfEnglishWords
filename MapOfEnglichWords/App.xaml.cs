using MapOfEnglishWords.DAL;
using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Entity;
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


            // new MainViewModel(new MainWindow());

        }

        private void InitializeDb()
        {
            var words = new[]
            {
                new WordDto()
                {
                    Name = "Animal", Translation = "Животное",
                    Example = "This looks like a plant, but it's actually an animal."
                },
                new WordDto()
                {
                    Name = "House", Translation = "Дом",
                    Example = "And we walked into a house with a very special home video recording system."
                },
                new WordDto() {Name = "Family", Translation = "Семья"},
                new WordDto() {Name = "Person", Translation = "Персона"}
            };

            words[0].Childrens = new[]
            {
                new WordDto()
                    {Name = "Dog", Translation = "Пес", Example = "On the Internet nobody knows you're a dog, right?"},
                new WordDto()
                {
                    Name = "Duck", Translation = "Утка",
                    Example = "And chickens and ducks and geese and turkeys are basically as dumb as dumps."
                },
                new WordDto() {Name = "Cat", Translation = "Кошка", Example = "When the cat's away, the mice will play."}
            };

            words[0].Parents.Add(new WordDto() {Name = "Life", Translation = "Жизнь"});
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
    [Table("Word")]
    public class WordDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }

        public string Example { get; set; }

        [Column("Parent")]
        public virtual ICollection<WordDto> Parents { get; set; }
        [Column("Child")]
        public virtual ICollection<WordDto> Childrens { get; set; }

        public WordDto()
        {
            Parents = new List<WordDto>();
            Childrens = new List<WordDto>();
        }
    }
}

