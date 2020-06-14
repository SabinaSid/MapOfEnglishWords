using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Linq.Expressions;
using System.Windows.Input;
using MapOfEnglishWords.Help;

namespace MapOfEnglishWords.ViewModel
{
    public class CreateVM : ViewModelBase
    {
        private IWordService wordService = ServiceLocator.GetService<IWordService>();
        private Word parentWord;
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
                           
                                throw new Exception("Заполните поля иностранное и родное слово");
                            
                            if (parentWord != null) Word.Parents.Add(parentWord);

                            wordService.Add(word.ToWordDto());
                            
                            View.Close();
                        }
                        catch(Exception ex)
                        {
                            if (ex.HResult==-2146233087)
                            {
                                try
                                {
                                    CreateExistent();
                                }
                                catch (Exception e)
                                {
                                    new MessageWinVM(new MessageWin(), e.Message);
                                }
                            }
                            else new MessageWinVM(new MessageWin(), ex.Message);
                            
                        }
                        
                    }));
            }
        }

        private void CreateExistent()
        {
            var existentWord = wordService.GetByName(word.Name).ToWord();
            if (CanCreateExistent(existentWord))
            {
                Word.Translation += (Word.Translation == existentWord.Translation)
                    ? ""
                    : $", {existentWord.Translation}";
                Word.Example += (Word.Example == existentWord.Example)
                    ? ""
                    : (string.IsNullOrEmpty(Word.Example))? $"{existentWord.Example}" :
                    $@"
{existentWord.Example}";
                Word.IdWord = existentWord.IdWord;
                wordService.AddRelation(existentWord.IdWord, parentWord.IdWord);
               View.Close();
               new EditVM(new EditWordWindow(), Word);
            }
            else throw new Exception($"Вы уже учили «{word.Name}».");
        }
        private bool CanCreateExistent(Word existentWord)
        {
            var canCreate = false;
            
            if (parentWord != null)
            {
                if (parentWord.IdWord == existentWord.IdWord) return false;
                
                foreach (var parent in existentWord.Parents)
                {
                    if (parentWord.IdWord == parent.IdWord) return false;
                    
                }

                foreach (var child in existentWord.Children)
                {
                    if (parentWord.IdWord == child.IdWord) return false;

                }

                canCreate = true;
            }
            return canCreate;
        }



        public CreateVM(IView view,Word selectWord)
            :base(view)
        {
            parentWord = selectWord;
            View.ShowDialog();
        }
        
    }
}
