using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Windows.Input;
using MapOfEnglishWords.Help;

namespace MapOfEnglishWords.ViewModel
{
    public class EditVM:ViewModelBase
    {
        private IWordService wordService = ServiceLocator.GetService<IWordService>();
        Word newWord;
        private ICommand editWord;
        public ICommand EditWord
        {
            get
            {
                return editWord ??
                    (editWord = new Command(obj =>
                    {
                        try
                        {
                            if (NewWord.Name == "" || NewWord.Translation == "")
                            {
                                throw new Exception("Заполните поля иностранное и родное слово");
                            }
                            wordService.Update(newWord.ToWordDto());
                            View.Close();
                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult== -2146233087)
                            {
                                new MessageWinVM(new MessageWin(), $"Вы уже учили «{newWord.Name}».");
                            }
                            else new MessageWinVM(new MessageWin(), ex.Message);
                        }
                        
                    }));
            }
        }
        public Word NewWord
        {
            get => newWord;
            set => Set(ref newWord, value);
        }

        public EditVM(IView view, Word word)
            :base(view)
        {
            newWord = new Word {Name = word.Name, Translation = word.Translation, Example = word.Example, IdWord = word.IdWord};
            View.ShowDialog();
        }
    }
}
