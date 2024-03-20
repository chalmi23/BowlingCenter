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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BowlingCenter.Views
{
    /// <summary>
    /// Logika interakcji dla klasy BilliardsView.xaml
    /// </summary>
    public partial class BilliardsView : UserControl
    {
        public BilliardsView()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            Window parentWindow = GetParentWindow(textBox);
            if (parentWindow != null)
            {
                parentWindow.Width = int.Parse(textBox.Text); // Przykładowa zmiana szerokości okna nadrzędnego
            }
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
    }
}
