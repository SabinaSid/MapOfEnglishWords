using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.ViewModel;
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
        public Word Word
        {
            get => word;
            set => Set(ref word, value);
        }
        private ICommand addNewWord;
        public ICommand AddNewWord
        {
            get
            {
                return addNewWord ??
                    (addNewWord = new Command(obj =>
                    {
                        try
                        {
                            if (Word.Name == null || Word.Translation == null || Word.Name == "" || Word.Translation == "")
                            {
                                throw new Exception("Заполните поля иностранное и родное слово");
                            }
                            Word.Parent = ParantWord;
                            manager.Words.Add(Word);
                            View.Close();
                        }
                        catch(Exception ex)
                        {
                            new MessageWinVM(new MessageWin(), ex.Message);
                        }
                        
                    }));
            }
        }
  
       
        
        public CreateVM(IView view,Word selectWord)
            :base(view)
        {
            ParantWord = selectWord;
            View.ShowDialog();
        }
        
    }
}
