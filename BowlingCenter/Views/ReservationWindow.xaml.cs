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

namespace BowlingCenter.Views
{
    public partial class ReservationWindow : Window
    {
        public ReservationWindow()
        {
            InitializeComponent();
        }

        private void ReserveButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CloseAddingWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinimizeAddingWindow(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
    }
}
