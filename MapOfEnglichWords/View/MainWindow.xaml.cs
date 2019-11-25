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
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Open;
            //commandBinding.Executed += CommandBinding_Executed;
            commandBinding.Executed += (s, e) => new CreateWordWindow().Show();
            bOpenCreateWordWindow.CommandBindings.Add(commandBinding);
        }

        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    new CreateWordWindow().Show();
        //}

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
