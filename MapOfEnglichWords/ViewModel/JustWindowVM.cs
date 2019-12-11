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

namespace MapOfEnglichWords.ViewModel
{
    class JustWindowVM:ViewModelBase
    {
        UnitOfWork manager;
        private Word parantWord;
        public Word ParantWord
        {
            get => parantWord;
            set => Set(ref parantWord, value);
        }
        private Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set
            {
                Set(ref selectedWord, value);
            }

        }
        public JustWindowVM(IView view,Word selectWord)
            :base(view)
        {
            manager = new UnitOfWork(LocalStorageCode.Instance);
            ParantWord = selectWord;
            Words = selectWord.Childs;
            View.ShowDialog();
        }

        ObservableCollection<Word> words;
        public ObservableCollection<Word> Words
        {
            get => words;
            set => Set(ref words, value);
        }
        private Command openCreateWordWindow;
        public Command OpenCreateWordWindow
        {
            get
            {
                return openCreateWordWindow ??
                    (openCreateWordWindow = new Command(obj =>
                    {
                        new CreateVM(new CreateWordWindow(),ParantWord);
                    }));
            }
        }
        private Command openJustWindow;
        public Command OpenJustWindow
        {
            get
            {
                return openJustWindow ??
                    (openJustWindow = new Command(obj =>
                    {
                        new JustWindowVM(new JustWindow(), SelectedWord);
                    }));
            }
        }
        private Command openEditWindow;
        public Command OpenEditWindow
        {
            get
            {
                return openEditWindow ??
                    (openEditWindow = new Command(obj =>
                    {
                        new EditVM(new EditWordWindow(), SelectedWord);
                    }));
            }
        }

    }
}
