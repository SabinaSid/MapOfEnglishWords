using MapOfEnglichWords.DAL.LocalStorage;
using MapOfEnglishWords.DAL.Rep;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.ViewModel
{
    public class EditVM:ViewModelBase
    {
        Word word;
        Word newWord;
        private Command editWord;
        public Command EditWord
        {
            get
            {
                return editWord ??
                    (editWord = new Command(obj =>
                    {
                        manager.Words.Update(ref word,newWord);
                        View.Close();
                    }));
            }
        }
        public Word NewWord
        {
            get => newWord;
            set => Set(ref newWord, value);
        }

        public EditVM(IView view, Word word)
            :base(view)
        {
            this.word = word;
            newWord = new Word();
            newWord.Name = word.Name;
            newWord.Translation = word.Translation;
            newWord.Example = word.Example;
            View.ShowDialog();
        }
    }
}
