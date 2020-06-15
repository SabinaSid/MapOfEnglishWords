using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using MapOfEnglishWords.Controllers;
using MapOfEnglishWords.Help;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;

namespace MapOfEnglishWords.ViewModel
{
    class MyWindowVM : ViewModelBase
    {
        private IWordService wordService = ServiceLocator.GetService<IWordService>();
        
        private Brush colorParents;
        public Brush ColorParents
        {
            get => colorParents;
            set => Set(ref colorParents, value);
        }
        private string titleParents;
        public string TitleParents 
        {
            get => titleParents;
            set => Set(ref titleParents, value);
        }
        private string titleChildren;
        public string TitleChildren
        {
            get => titleChildren;
            set => Set(ref titleChildren, value);
        }
        private Word word;
        private Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set => Set(ref selectedWord, value);
        }

        private ObservableCollection<Word> parentsWord;
        public ObservableCollection<Word> ParentsWord
        {
            get => parentsWord;
            set => Set(ref parentsWord, value);
        }

        private ObservableCollection<Word> childrenWord;
        public ObservableCollection<Word> ChildrenWord
        {
            get => childrenWord;
            set => Set(ref childrenWord, value);
        }

        public MyWindowVM(IView view, int id)
            : base(view)
        {
            UpdateWindow(id);
            View.ShowDialog();
        }

        private void UpdateWindow(int id)
        {
            word = wordService.GetById(id).ToWord();

            TitleParents = word.Parents.Count == 0 ? "нет родителей" : "";

            ColorParents = word.Parents.Count == 0 
                ? new SolidColorBrush(Color.FromRgb(55, 135, 82))
                : new SolidColorBrush(Color.FromRgb(227, 241, 226));

            TitleChildren = $"{word.Name}";

            TitleChildren += word.Children.Count == 0 ? " без детей" : "";
            
            ParentsWord = word.Parents;

            ChildrenWord = word.Children;
        }

        private ICommand openEditWindow;
        public ICommand OpenEditWindow=>
            (openEditWindow = new Command(obj =>
            {
                new EditVM(new EditWordWindow(), SelectedWord);
                Refresh.Execute(openEditWindow);
            }));

        private ICommand openJustWindow;
        public ICommand OpenJustWindow => 
            (openJustWindow = new Command(obj =>
            {
                UpdateWindow(selectedWord.IdWord);
            }));

        public ICommand Refresh => new Command(obj =>
            {
                UpdateWindow(word.IdWord);
            });

        private ICommand openDelQuestion;
        public ICommand OpenDelQuestion => 
            (openDelQuestion = new Command(obj =>
            {
                new DelVM(new DelQuestion(), wordService.GetById(SelectedWord.IdWord).ToWord(), word);
                Refresh.Execute(openDelQuestion);
            }));
        
        private ICommand openCreateWordWindow;
        public ICommand OpenCreateWordWindow =>
            (openCreateWordWindow = new Command(obj =>
            {
                new CreateVM(new CreateWordWindow(), word);
                Refresh.Execute(openCreateWordWindow);
            }));
        private ICommand printWord;
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


    }
}
