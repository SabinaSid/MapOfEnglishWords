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
        public int ColumnSpan { get; set; }

        private ICommand removeRelation;
        public ICommand RemoveRelation
        {
            get
            {
                return removeRelation ??
                       (removeRelation = new Command(obj =>
                       {
                           new WordService().DeleteRelation(word.IdWord,parentWord.IdWord);
                           View.Close();
                       }));
            }
        }
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
                if (word.Parents.Count<=1)
                {
                    Text = $"Вы действительно хотите удалить «{word.Name}»?";
                    ColumnSpan = 2;
                }
                else Text = $"Вы действительно хотите удалить «{word.Name}»? Или только связь «{word.Name}» - «{parentWord.Name}»?";
                View.ShowDialog();
            }
            catch(Exception ex)
            {
                new MessageWinVM(new MessageWin(), ex.Message);
            }
            
        }
    }
}
