using MapOfEnglishWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.View
{
    public interface IView
    {
        IViewModel GetViewModel();
        void SetViewModel(IViewModel value);
        void Show();
        void Close();
        bool? ShowDialog();

    }
}
