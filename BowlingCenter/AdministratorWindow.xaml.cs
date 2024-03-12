using BowlingCenter.ViewModels;
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

namespace BowlingCenter
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        private void BowlingButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BowlingViewModel();
        }
        private void DartsButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DartsViewModel();
        }
        private void BilliardsButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BilliardsViewModel();
        }
    }
}
