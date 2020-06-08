using MapOfEnglishWords.Controllers;
using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.ViewModel;
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
using System.Windows;
using System.Windows.Input;

namespace MapOfEnglishWords.ViewModel
{
    public class MainViewModel : AbstractMainVM
    {
        public MainViewModel(IView view)
            :base(view)
        {
            Words = manager.Words.Get();
            Title = "Все категории";
            View.Show();
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
                    }));
            }
        }
    }
}
