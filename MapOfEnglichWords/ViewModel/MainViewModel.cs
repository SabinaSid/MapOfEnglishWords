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
        public MainViewModel(IView view)
            :base(view)
        {
            View.Show();
        }
         ObservableCollection<Word> words;
        public ObservableCollection<Word> Words {
            get => words;
            set => Set(ref words, value);
        }
    }
}
