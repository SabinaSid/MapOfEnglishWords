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
using MapOfEnglishWords.ViewModel;

namespace MapOfEnglishWords.View
{
    /// <summary>
    /// Логика взаимодействия для DelQuestion.xaml
    /// </summary>
    public partial class DelQuestion : Window, IView
    {
        public DelQuestion()
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
