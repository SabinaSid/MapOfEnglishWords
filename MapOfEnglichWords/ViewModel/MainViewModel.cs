using System.Collections.ObjectModel;
using System.Linq;
using MapOfEnglishWords.View;
using System.Windows.Input;
using MapOfEnglishWords.Controllers;
using MapOfEnglishWords.Help;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords.ViewModel
{
    public class MainViewModel :ViewModelBase
    {
        public MainViewModel(IView view)
            :base(view)
        {
            Words = new WordService().GetInitialize().Select(x=>x.ToWord()).ToObservableCollectionWords();
            Title = "Все категории";
            View.Show();
        }
        public string Title { get; set; }
        protected Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set => Set(ref selectedWord, value);
        }

        protected ObservableCollection<Word> words;
        public ObservableCollection<Word> Words
        {
            get => words;
            set => Set(ref words, value);
        }
        protected ICommand openEditWindow;
        public ICommand OpenEditWindow
        {
            get
            {
                return openEditWindow ??
                    (openEditWindow = new Command(obj =>
                    {
                        new EditVM(new EditWordWindow(), SelectedWord);
                        Refresh.Execute(openEditWindow);
                    }));
            }
        }
        public ICommand Refresh => new Command(obj =>
        {
            Words = new WordService().GetInitialize().Select(x => x.ToWord()).ToObservableCollectionWords();
        });
        protected ICommand openJustWindow;
        public ICommand OpenJustWindow
        {
            get
            {
                return openJustWindow ??
                    (openJustWindow = new Command(obj =>
                    {
                        new MyWindowVM(new MyWindow(), SelectedWord.IdWord);
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
                        new DelVM(new DelQuestion(), SelectedWord,null);
                        Refresh.Execute(openDelQuestion);
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
        private ICommand openCreateWordWindow;
        public ICommand OpenCreateWordWindow
        {
            get
            {
                return openCreateWordWindow ??
                    (openCreateWordWindow = new Command(obj =>
                    {
                        new CreateVM(new CreateWordWindow(), null);
                        Refresh.Execute(openCreateWordWindow);
                    }));
            }
        }
    }
}
