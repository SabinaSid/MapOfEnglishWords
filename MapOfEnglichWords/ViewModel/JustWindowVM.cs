using MapOfEnglishWords.Controllers;
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
using System.Windows.Input;

namespace MapOfEnglishWords.ViewModel
{
    class JustWindowVM: AbstractMainVM
    {
        private Word parantWord;
        public Word ParentWord
        {
            get => parantWord;
            set => Set(ref parantWord, value);
        }
        public JustWindowVM(IView view,Word selectWord)
            :base(view)
        {
            ParentWord = selectWord;
            Title = ParentWord.Name;
            Words = selectWord.Childs;
            View.ShowDialog();
        }
        private ICommand openCreateWordWindow;
        public ICommand OpenCreateWordWindow
        {
            get
            {
                return openCreateWordWindow ??
                    (openCreateWordWindow = new Command(obj =>
                    {
                        new CreateVM(new CreateWordWindow(), ParentWord);
                    }));
            }
        }
    }
}
