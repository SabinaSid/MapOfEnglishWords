using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Windows.Input;
using MapOfEnglishWords.Help;

namespace MapOfEnglishWords.ViewModel
{
    public class DelVM: ViewModelBase
    {
        private Word word;
        private Word parentWord;
        private ICommand removeWord;
        public ICommand RemoveWord
        {
            get
            {
                return removeWord ??
                    (removeWord = new Command(obj =>
                    {
                        new WordService().DeleteAllById(word.IdWord);
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
                        if (word.Parents.Count != 0)
                        {
                            foreach (var item in word.Children)
                            {
                                item.Parents.Remove(word);
                                item.Parents.Add(parentWord);
                                new WordService().Update(item.ToWordDto());
                            }
                            
                        }
                        new WordService().DeleteById(word.IdWord);
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

        public DelVM(IView view, Word selectWord, Word parentWord)
            : base(view)    
        {
            try
            {
                word = selectWord ?? throw new Exception("Сначала выберите слово");
                this.parentWord = parentWord;
                if (word.Children.Count > 0)
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
