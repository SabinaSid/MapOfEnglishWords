using MapOfEnglichWords.DAL.LocalStorage;
using MapOfEnglishWords.DAL.Rep;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapOfEnglishWords.ViewModel
{
    public class DelVM: ViewModelBase
    {
        Word word;
        private ICommand removeWord;
        public ICommand RemoveWord
        {
            get
            {
                return removeWord ??
                    (removeWord = new Command(obj =>
                    {
                        manager.Words.Remove(word);
                        View.Close();
                    }));
            }
        }
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                return cancel ??
                    (cancel = new Command(obj =>
                    {
                        View.Close();
                    }));
            }
        }
        public string Text { get; set; }

        public DelVM(IView view, Word selectWord)
            : base(view)
        {
            word = selectWord;
            if (word.Childs.Count>0)
            {
                Text = $"Вы действительно хотите удалить слово {word.Name}? Оно имеет связи";
            }
            else Text = $"Вы действительно хотите удалить слово {word.Name}?";
            View.ShowDialog();
        }
    }
}
