using MapOfEnglishWords.ViewModel;
using System.Windows;
using MapOfEnglishWords.db;
using MapOfEnglishWords.Help;
using MapOfEnglishWords.View;

namespace MapOfEnglishWords
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.Register<IWordService>(new WordService());
            new MainViewModel(new MainWindow());
            new TrainerVM(new Trainer());
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
}

