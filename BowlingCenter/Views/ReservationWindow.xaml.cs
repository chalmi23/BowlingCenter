using System.Windows;
using System.Windows.Input;

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
