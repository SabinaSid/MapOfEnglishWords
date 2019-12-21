using MapOfEnglichWords.Controllers;
using MapOfEnglishWords;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using MapOfEnglishWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapOfEnglichWords.ViewModel
{
    public class AbstractMainVM:ViewModelBase
    {
        public string Title { get; set; }
        protected Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set
            {
                Set(ref selectedWord, value);
            }

        }

        public AbstractMainVM(IView view)
            : base(view)
        {
      
        }

        protected ObservableCollection<Word> words;
        public ObservableCollection<Word> Words
        {
            get => words;
            set => Set(ref words, value);
        }
        //protected ICommand openCreateWordWindow;
        //public ICommand OpenCreateWordWindow
        //{
        //    get
        //    {
        //        return openCreateWordWindow ??
        //            (openCreateWordWindow = new Command(obj =>
        //            {
        //                new CreateVM(new CreateWordWindow(), null);
        //            }));
        //    }
        //}

        protected ICommand openEditWindow;
        public ICommand OpenEditWindow
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
        protected ICommand openJustWindow;
        public ICommand OpenJustWindow
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
        protected ICommand openDelQuestion;
        public ICommand OpenDelQuestion
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
        protected ICommand printExcel;
        public ICommand PrintExcel
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
        protected ICommand printWord;
        public ICommand PrintWord
        {
            get
            {
                return printWord ??
                    (printWord = new Command(obj =>
                    {
                        if (SelectedWord != null)
                        {
                            ReportController.ExportToWord(SelectedWord);
                        }
                    }));
            }
        }
        protected ICommand save;
        public ICommand Save
        {
            get
            {
                return save ??
                    (save = new Command(obj =>
                    {
                        manager.Words.Save();
                    }));
            }
        }
    }
}
