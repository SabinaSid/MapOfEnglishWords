using MapOfEnglichWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.View
{
    public interface IView
    {
        IViewModel GetViewModel();
        void SetViewModel(IViewModel value);
        void Show();
        void Close();
        
    }
}
