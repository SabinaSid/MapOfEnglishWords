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
                new Word("Animal","Животное"),
                new Word("House","Дом"),
                new Word("Family","Семья"),
                new Word("Person","Персона")

            };

            Words[0].Childs = new ObservableCollection<Word> { new Word("Dog", "Пес"),new Word("Duck", "Утка"), new Word("Cat", "Кошка") };
            Words[0].Childs[0].Childs.Add(new Word("small", "маденькая"));
            Words[0].Childs[0].Childs.Add(new Word("big", "большая"));
            Words[0].Childs[1].Childs.Add(new Word("Fly", "летать"));
            Words[0].Childs[1].Childs[0].Childs.Add(new Word("West", "Запад"));
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
