﻿using MapOfEnglishWords.ViewModel;
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

namespace MapOfEnglishWords.View
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
    }
}
