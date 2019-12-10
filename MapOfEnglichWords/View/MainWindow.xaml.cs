using MapOfEnglichWords.DAL;
using MapOfEnglichWords.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapOfEnglichWords
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

        //CommandBinding commandBinding = new CommandBinding();
        //commandBinding.Command = ApplicationCommands.Open;
        //commandBinding.Executed += (s, e) => new CreateVM(new CreateWordWindow());
        //commandBinding.Executed += (s, e) => LocalStorage.Instance.Save();
        //ToDo:Сериализация в месте закрытия LocalStorage.Instance.Save();
        //bOpenCreateWordWindow.CommandBindings.Add(commandBinding);

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
