using MapOfEnglishWords.View;
using MapOfEnglishWords.ViewModel;
using System.Windows;

namespace MapOfEnglishWords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
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
