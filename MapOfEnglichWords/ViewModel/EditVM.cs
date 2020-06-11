using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Windows.Input;
using MapOfEnglishWords.Help;

namespace MapOfEnglishWords.ViewModel
{
    public class EditVM:ViewModelBase
    {
        Word word;
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
                            new WordService().Update(newWord.ToWordDto());
                            View.Close();
                        }
                        catch (Exception ex)
                        {
                            new MessageWinVM(new MessageWin(), ex.Message);
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
            this.word = word;
            newWord = new Word {Name = word.Name, Translation = word.Translation, Example = word.Example, IdWord = word.IdWord};
            View.ShowDialog();
        }
    }
}
