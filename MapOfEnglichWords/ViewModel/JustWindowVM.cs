using MapOfEnglichWords.Controllers;
using MapOfEnglichWords.DAL.LocalStorage;
using MapOfEnglishWords.DAL.Rep;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.ViewModel
{
    class JustWindowVM:ViewModelBase
    {
        public string Title { get; set; }
        private Word parantWord;
        public Word ParentWord
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
            ParentWord = selectWord;
            Title = ParentWord.Name;
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
                        new CreateVM(new CreateWordWindow(),ParentWord);
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
                        new JustWindowVM(new MainWindow(), SelectedWord);
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
        private Command openDelQuestion;
        public Command OpenDelQuestion
        {
            get
            {
                return openDelQuestion ??
                    (openDelQuestion = new Command(obj =>
                    {
                        new DelVM(new DelQuestion(), SelectedWord);
                    }));
            }
        }
        private Command printExcel;
        public Command PrintExcel
        {
            get
            {
                return printExcel ??
                    (printExcel = new Command(obj =>
                    {
                        if (Words != null)
                        {
                            ReportController.ExportToExel(Words);
                        }
                    }));
            }
        }
        private Command printWord;
        public Command PrintWord
        {
            get
            {
                return printWord ??
                    (printWord = new Command(obj =>
                    {
                        if (Words != null)
                        {
                            ReportController.ExportToWord(Words);
                        }
                    }));
            }
        }


    }
}
