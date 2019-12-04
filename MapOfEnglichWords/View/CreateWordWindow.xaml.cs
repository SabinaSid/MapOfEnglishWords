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
using MapOfEnglichWords.ViewModel;

namespace MapOfEnglichWords.View
{
    /// <summary>
    /// Логика взаимодействия для CreateWordWindow.xaml
    /// </summary>
    public partial class CreateWordWindow : Window, IView
    {
        public CreateWordWindow()
        {
            InitializeComponent();
            //CommandBinding commandBinding = new CommandBinding();
            //commandBinding.Command = ApplicationCommands.New;
            //commandBinding.Executed += CommandBinding_Executed;
            //bNewWord.CommandBindings.Add(commandBinding);
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
