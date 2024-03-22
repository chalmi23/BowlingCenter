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
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
            DataContext = new BowlingViewModel();
        }

        private void ChangeDataContext(object sender, RoutedEventArgs e) 
        {
           if(sender.ToString() == "System.Windows.Controls.Button: BOWLING") DataContext = new BowlingViewModel();
           else if(sender.ToString() == "System.Windows.Controls.Button: DARTS") DataContext = new DartsViewModel();
           else if(sender.ToString() == "System.Windows.Controls.Button: BILLIARDS") DataContext = new BilliardsViewModel();
           else if(sender.ToString() == "System.Windows.Controls.Button: SETTINGS") DataContext = new SettingsViewModel();
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void DragMove_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
