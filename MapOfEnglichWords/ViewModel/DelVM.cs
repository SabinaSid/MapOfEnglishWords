using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.ViewModel;
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
        private ICommand removeWordWithSave;
        public ICommand RemoveWordWithSave
        {
            get
            {
                return removeWordWithSave ??
                    (removeWordWithSave = new Command(obj =>
                    {
                        if (word.Parent != null)
                        {
                            foreach (var item in word.Childs)
                            {
                                item.Parent = word.Parent;
                                manager.Words.Add(item);
                            }
                            
                        }
                        else
                        {
                            foreach (var item in word.Childs)
                            {
                                item.Parent = null;
                                manager.Words.Add(item);

                            }
                           
                        }

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
            try
            {
                if (selectWord == null) throw new Exception("Сначала выберите слово");
                word = selectWord;
                if (word.Childs.Count > 0)
                {
                    Text = $"Вы действительно хотите удалить слово {word.Name}? Сохранить вложенные слова?";
                }
                else Text = $"Вы действительно хотите удалить слово {word.Name}?";
                View.ShowDialog();
            }
            catch(Exception ex)
            {
                new MessageWinVM(new MessageWin(), ex.Message);
            }
            
        }
    }
}
