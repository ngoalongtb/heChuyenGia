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

namespace BaiTapLon
{
    /// <summary>
    /// Interaction logic for UCRightTheme.xaml
    /// </summary>
    public partial class UCRightTheme : UserControl
    {
        public UCRightTheme()
        {
            InitializeComponent();
        }

        private void btnLight_Click(object sender, RoutedEventArgs e)
        {
            Global.theme.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            Global.theme.ForegroundActive = Brushes.Black;
            Global.theme.ForegroundTheme = Global.theme.ForegroundActive;
        }

        private void btnDark_Click(object sender, RoutedEventArgs e)
        {
            Global.theme.BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0d0d0d"));
            Global.theme.ForegroundActive = Brushes.White;
            Global.theme.ForegroundTheme = Global.theme.ForegroundActive;
        }
    }
}
