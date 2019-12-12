using MapOfEnglichWords.Controllers;
using MapOfEnglichWords.DAL.LocalStorage;
using MapOfEnglishWords.DAL.Rep;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapOfEnglishWords.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        UnitOfWork manager;
        public string Title { get; set; }
        private Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set
            {
                Set(ref selectedWord, value);
            }

        }
        
        public MainViewModel(IView view)
            :base(view)
        {
            manager = new UnitOfWork(LocalStorageCode.Instance);
            Words = manager.Words.Get();
            Title = "Все категории";
            View.Show();
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
                        new CreateVM(new CreateWordWindow(),null);
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

    }
}
