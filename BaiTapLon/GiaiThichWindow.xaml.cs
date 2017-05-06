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
    /// Interaction logic for GiaiThichWindow.xaml
    /// </summary>
    public partial class GiaiThichWindow : Window
    {
        public GiaiThichWindow()
        {
            InitializeComponent();
        }
        public GiaiThichWindow(string language)
        {
            InitializeComponent();
            txtGiaiThich.Text += language;

            string strLuat = Prolog.Instance.GetQuestion("answer(X,'"+language+"')");
            strLuat = string.Format("answer({0}],'{1}').", strLuat.Split(']')[0],language);
            txtLuat.Text = strLuat;

            string strOptions = Global.GAnswer;
            if (strOptions == "")
            {
                TextBlock tbl = new TextBlock();
                tbl.Foreground = Brushes.Aquamarine;
                tbl.FontSize = 20;
                tbl.Text = "Bạn không chọn lựa chọn nào";
                stpl.Children.Add(tbl);
            }
            else
            {
                foreach (string item in strOptions.Split(','))
                {
                    string query = string.Format("option(_,{0},X)", item);
                    string strOption = Prolog.Instance.GetQuestion(query);

                    TextBlock tbl = new TextBlock();
                    tbl.Foreground = Brushes.Aquamarine;
                    tbl.FontSize = 20;
                    tbl.Text = item + " - " + strOption;
                    stpl.Children.Add(tbl);
                }
            }

            




        }
    }
}
