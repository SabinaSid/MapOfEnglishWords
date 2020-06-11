using System.Windows;
using MapOfEnglishWords.ViewModel;

namespace MapOfEnglishWords.View
{
    /// <summary>
    /// Логика взаимодействия для CreateWordWindow.xaml
    /// </summary>
    public partial class CreateWordWindow : Window, IView
    {
        public CreateWordWindow()
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
