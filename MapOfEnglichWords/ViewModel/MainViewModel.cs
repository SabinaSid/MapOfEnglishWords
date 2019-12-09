using MapOfEnglichWords.DAL;
using MapOfEnglichWords.DAL.Help;
using MapOfEnglichWords.DAL.Rep;
using MapOfEnglichWords.Model;
using MapOfEnglichWords.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapOfEnglichWords.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        UnitOfWork manager;
        private Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set
            {
                if (Set(ref selectedWord, value))
                {
                    new JustWindowVM(new JustWindow(), SelectedWord);
                    //new EditVM(new EditWordWindow(), SelectedWord);
                }
            }

        }
        //private event EventHandler active;
        //public event EventHandler Active
        //{
        //    add
        //    {
        //        Set(ref active, value);
        //        active += value;
        //    }
        //    remove
        //    {
        //        active -= value;
        //    }
            
        //}
        public event MouseButtonEventHandler doubleclick;
        public MainViewModel(IView view)
            :base(view)
        {
            manager = new UnitOfWork(LocalStorageCode.Instance);
            Words = manager.Words.Get();
            //selectedWord = Words[0];
            //doubleclick += MainViewModel_doubleclick;
            //Active += (s,e) => Words = manager.Words.Get();
            View.Show();
        }

        private void MainViewModel_doubleclick(object sender, MouseButtonEventArgs e)
        {
            //
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
                        new EditVM(new EditWordWindow(), selectedWord);
                    }));
            }
        }

    }
}
