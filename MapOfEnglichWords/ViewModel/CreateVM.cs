using MapOfEnglishWords.DAL;
using MapOfEnglishWords.DAL.Rep;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MapOfEnglishWords.ViewModel
{
    public class CreateVM : ViewModelBase
    {
        Word ParantWord;
        Word word=new Word();
        UnitOfWork manager;        
        private Command addNewWord;
        public Command AddNewWord
        {
            get
            {
                return addNewWord ??
                    (addNewWord = new Command(obj =>
                    {
                        Word.Parent = ParantWord;
                        manager.Words.Add(Word);
                        View.Close();
                    }));
            }
        }
  
        public Word Word
        {
            get => word;
            set => Set(ref word, value);
        }
        
        public CreateVM(IView view,Word selectWord)
            :base(view)
        {
            ParantWord = selectWord;
            manager = new  UnitOfWork(LocalStorageCode.Instance);
            View.ShowDialog();
        }
        
    }
}
