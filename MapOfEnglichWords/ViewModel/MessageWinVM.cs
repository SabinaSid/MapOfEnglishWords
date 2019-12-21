using MapOfEnglishWords.View;
using MapOfEnglishWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapOfEnglichWords.ViewModel
{
    class MessageWinVM : ViewModelBase
    {
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                return cancel ??
                    (cancel = new Command(obj =>
                    {
                        View.Close();
                    }));
            }
        }
        public string Text { get; set; }

        public MessageWinVM(IView view, string Text)
            : base(view)
        {
            this.Text = Text;
            View.ShowDialog();
        }
    
    }
}
