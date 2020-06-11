using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Windows.Input;
using MapOfEnglishWords.Help;

namespace MapOfEnglishWords.ViewModel
{
    public class CreateVM : ViewModelBase
    {
        Word ParentWord;
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

                            if (ParentWord != null)
                            {
                                Word.Parents.Add(ParentWord);
                            }
                                
                            new WordService().AddOrUpdate(word.ToWordDto());
                            
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
            ParentWord = selectWord;
            View.ShowDialog();
        }
        
    }
}
