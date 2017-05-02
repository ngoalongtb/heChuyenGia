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
using System.Xml;

namespace BaiTapLon
{
    /// <summary>
    /// Interaction logic for UCRightExpert.xaml
    /// </summary>
    public partial class UCRightExpert : UserControl
    {
        public UCRightExpert()
        {
            InitializeComponent();
            LoadExpert();
        }

        public void LoadExpert()
        {
            string file = System.IO.Directory.GetCurrentDirectory()+"\\Expert.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            string image =  doc.GetElementsByTagName("Image")[0].InnerText;
            string name = doc.GetElementsByTagName("Name")[0].InnerText;
            Expert expert = new Expert();

            expert.Name = name;
            expert.Image = image;
            expert.Info = doc.GetElementsByTagName("Info")[0].InnerText;
            expert.CreateBy = doc.GetElementsByTagName("CreateBy")[0].InnerText;
            expert.Path = doc.GetElementsByTagName("Path")[0].InnerText;


            UCExpert ucExpert = new UCExpert(expert);
            wrappl.Children.Add(ucExpert);
        }
        public void ResetActive()
        {
            foreach (UCExpert item in wrappl.Children)
            {
                item.IsActive = false;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            foreach (UCExpert item in wrappl.Children)
            {
                if (item.IsActive)
                {
                    Global.GExpert = item.Expert;
                    this.onLoadLeft(item.Expert, new EventArgs());
                    return;
                }
            }
            MessageBox.Show("Vui lòng chọn một hệ chuyên gia");
        }


        private event EventHandler onLoadLeft;
        public event EventHandler OnLoadLeft
        {
            add
            {
                onLoadLeft += value;
            }
            remove
            {
                onLoadLeft -= value;
            }
        }


    }
}
