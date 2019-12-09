using MapOfEnglichWords.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapOfEnglichWords.View
{
    /// <summary>
    /// Логика взаимодействия для JustWindow.xaml
    /// </summary>
    public partial class JustWindow : Window, IView
    {
        public JustWindow()
        {
            InitializeComponent();
        }
        public IViewModel GetViewModel()
        {
            return DataContext as IViewModel;

        }

        public void SetViewModel(IViewModel value)
        {
            DataContext = value;

        }
    }
}
