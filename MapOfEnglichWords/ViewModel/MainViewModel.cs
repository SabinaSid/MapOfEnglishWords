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

namespace MapOfEnglichWords.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IViewWindow view)
            :base(view)
        {
            var manager = new UnitOfWork(LocalStorageCode.Instance);
            Words = manager.Words.Get().ToObservable();
            View.Show();
            view.Active += () => Words = manager.Words.Get().ToObservable();
        }
        ObservableCollection<Word> words;
        public ObservableCollection<Word> Words
        {
            get => words;
            set => Set(ref words, value);
        }
        //List<Word> words;
        //public List<Word> Words {
        //    get => words;
        //    set => Set(ref words, value);
        //}
    }
}
