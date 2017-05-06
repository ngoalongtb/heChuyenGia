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

namespace BaiTapLon
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
        }
        private string language;
        public InfoWindow(string language)
        {
            InitializeComponent();
            this.language = language;

            string query = string.Format("info('{0}',X).", language);
            string strInfo = Prolog.Instance.GetQuestion(query);
            txtInfo.Text = strInfo;
        }

        private void btnGiaiThich_Click(object sender, RoutedEventArgs e)
        {
            GiaiThichWindow gtWindow = new GiaiThichWindow(this.language);
            gtWindow.ShowDialog();
        }
    }
}
