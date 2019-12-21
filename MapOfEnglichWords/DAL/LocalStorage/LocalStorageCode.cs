using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapOfEnglishWords.Model;

namespace MapOfEnglichWords.DAL.LocalStorage
{
    public class LocalStorageCode : IStorage
    {
        static LocalStorageCode instance;
        public static LocalStorageCode Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalStorageCode();
                }
                return instance;
            }

        }
        public ObservableCollection<Word> Words { get; set; }
        private LocalStorageCode()
        {
            Words = new ObservableCollection<Word>
            {
                new Word("Animal","Животное","This looks like a plant, but it's actually an animal."),
                new Word("House","Дом","And we walked into a house with a very special home video recording system."),
                new Word("Family","Семья"),
                new Word("Person","Персона")

            };

            Words[0].Childs = new ObservableCollection<Word> { 
                new Word("Dog", "Пес","On the Internet nobody knows you're a dog, right?"),
                new Word("Duck", "Утка", "And chickens and ducks and geese and turkeys are basically as dumb as dumps."),
                new Word("Cat", "Кошка","When the cat's away, the mice will play.") };
            Words[0].Childs[0].Childs.Add(new Word("Breed", "Порода"));
            Words[0].Childs[0].Childs.Add(new Word("Bark", "Лай"));
            Words[0].Childs[1].Childs.Add(new Word("Lake", "Озеро", "This has a diamond-bottomed lake."));
            Words[0].Childs[1].Childs[0].Childs.Add(new Word("Sedge", "Камыш", "The sedge has wither'd from the lake And no birds sing."));
            foreach (var item in Words[0].Childs)
            {
                item.Parent = Words[0];
            }
        }

        public ObservableCollection<Word> GetMainWords()
        {
            return Words;
        }

        public void SaveMainWords()
        {

        }

    }
}
