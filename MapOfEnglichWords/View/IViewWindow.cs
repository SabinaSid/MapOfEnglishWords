using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.View
{
    public interface IViewWindow:IView
    {
        event Action Active;
    }
}
