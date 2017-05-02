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
    /// Interaction logic for UCLeftIntro.xaml
    /// </summary>
    public partial class UCLeftInfo : UserControl
    {

        public UCLeftInfo()
        {
            InitializeComponent();
            if(Global.GExpert == null)
            {
                txbInfo.Text = "TẠ MINH LUẬN\r\nNGUYỄN VĂN THẮNG\r\nPHẠM MINH PHƯƠNG\r\nHOÀNG NGHĨA MẠNH\r\nNGUYỄN THÀNH ĐẠT";
            }
            else
            {
                txbName.Text = Global.GExpert.Name;
                txbInfo.Text = string.Format("Tạo bởi: {0}\r\n{1}", Global.GExpert.CreateBy, Global.GExpert.Info);
                grdImage.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\" + Global.GExpert.Image)));
            }
            
        }
    }
}
