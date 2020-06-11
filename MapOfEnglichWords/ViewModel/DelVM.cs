using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MapOfEnglishWords.Help;

namespace MapOfEnglishWords.ViewModel
{
    public class DelVM: ViewModelBase
    {
        private Word word;
        private Word parentWord;
        private ICommand remove;
        public ICommand Remove
        {
            get
            {
                return remove ??
                       (remove = new Command(obj =>
                       {
                           new WordService().DeleteById(word.IdWord);
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
                Text = $"Вы действительно хотите удалить «{word.Name}»?";
                View.ShowDialog();
            }
            catch(Exception ex)
            {
                new MessageWinVM(new MessageWin(), ex.Message);
            }
            
        }
    }
}
