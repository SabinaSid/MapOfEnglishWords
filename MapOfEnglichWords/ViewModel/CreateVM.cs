using MapOfEnglichWords.DAL;
using MapOfEnglichWords.DAL.Rep;
using MapOfEnglichWords.Model;
using MapOfEnglichWords.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MapOfEnglichWords.ViewModel
{
    public class CreateVM : ViewModelBase
    {
       
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
        
        public CreateVM(IView view)
            :base(view)
        {
            manager = new  UnitOfWork(LocalStorageCode.Instance);
            View.ShowDialog();
        }
        
    }
}
