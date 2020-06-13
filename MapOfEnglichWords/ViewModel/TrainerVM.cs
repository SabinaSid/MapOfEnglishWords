using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapOfEnglishWords.View;

namespace MapOfEnglishWords.ViewModel
{
    class TrainerVM : ViewModelBase
    {
        public TrainerVM(IView view)
            : base(view)
        {
            View.Show();
        }
    }
}
