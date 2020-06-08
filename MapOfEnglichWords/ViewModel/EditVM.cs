﻿using MapOfEnglishWords.DAL.LocalStorage;
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
using System.Windows.Input;

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
                            manager.Words.Update(word, newWord);
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
            newWord = new Word();
            newWord.Name = word.Name;
            newWord.Translation = word.Translation;
            newWord.Example = word.Example;
            View.ShowDialog();
        }
    }
}
