using System;
using System.Collections.ObjectModel;

namespace MapOfEnglishWords.Model
{
    public class Word:BaseModel
    {
        public int IdWord { get; set; }
        private string name;
        public string Name 
        {
            get => name;
            set => Set(ref name, value);
        }
        private string translation;
        public string Translation
        {
            get => translation;
            set => Set(ref translation, value);
        }
        private string example;
        public string Example
        {
            get => example;
            set => Set(ref example, value);
        }

        private int countRepeat;

        public int CountRepeat
        {
            get => countRepeat;
            set => Set(ref countRepeat, value);
        }

        private DateTime lastRepeatDate;

        public DateTime LastRepeatDate
        {
            get => lastRepeatDate;
            set => Set(ref lastRepeatDate, value);
        }

        public ObservableCollection<Word> Children { get; set; } = new ObservableCollection<Word>();
        public ObservableCollection<Word> Parents { get; set; } = new ObservableCollection<Word>();
    }
}
