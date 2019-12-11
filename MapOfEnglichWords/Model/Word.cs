using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.Model
{
    public class Word:BaseModel
    {
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


        public ObservableCollection<Word> Childs { get; set; } = new ObservableCollection<Word>();
        public Word Parent { get; set; }

        public Word(string Name, string Translation)
        {
            this.Name = Name;
            this.Translation = Translation;
        }
        public Word()
        {

        }
        //public override int GetHashCode()
        //{
        //    int ret = 0;
        //    if (Name !=null)
        //    {
        //        ret += Name.GetHashCode();
        //    }
        //    if (Translation!=null)
        //    {
        //        ret += Translation.GetHashCode();
        //    }
        //    if (Example!=null)
        //    {
        //        ret += Example.GetHashCode();
        //    }
        //    return ret;
        //}

    }
}
