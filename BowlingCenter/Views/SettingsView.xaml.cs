using System;
using System.Collections.Generic;
using System.Data;
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

namespace BowlingCenter.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            FillResolutionsDataGrid();
        }
        private void FillResolutionsDataGrid()
        {
            List<string> resolutions = new List<string>
            {
            "1400x700",
            "1000x500",
            "1200x600",
            "1600x800",
            "1680x1080",
            "1920x1080",
            };
            resolutionsDataGrid.ItemsSource = resolutions;
        }
        private Window GetParentWindow(DependencyObject reference)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(reference);
            while (parent != null && !(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as Window;
        }

        private void changeResolution(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = (DataGrid)sender;
            Window parentWindow = GetParentWindow(dataGrid);

            if (parentWindow != null)
            {
                var resolution = (String)dataGrid.SelectedItem;

                int width, height;

                switch (resolution)
                {
                    case "1400x700":
                        width = 1400;
                        height = 700;
                        break;
                    case "1000x500":
                        width = 1000;
                        height = 500;
                        break;
                    case "1200x600":
                        width = 1200;
                        height = 600;
                        break;
                    case "1600x800":
                        width = 1600;
                        height = 800;
                        break;
                    case "1680x1080":
                        width = 1680;
                        height = 1080;
                        break;
                    case "1920x1080":
                        width = 1920;
                        height = 1080;
                        break;
                    default:
                        width = 800;
                        height = 600;
                        break;
                }

                parentWindow.Width = width;
                parentWindow.Height = height;
            }
        }
    }
}
