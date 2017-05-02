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
    /// Interaction logic for UCExpert.xaml
    /// </summary>
    public partial class UCExpert : UserControl
    {
        private bool isActive;
        private Expert expert;

        public UCExpert(Expert expert)
        {
            InitializeComponent();
            txb.Text = expert.Name;
            this.Expert = expert;
            isActive = false;
            grImage.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory()+"\\" + expert.Image))) { Stretch = Stretch.Uniform};
            this.MouseDown += UCExpert_MouseDown;
        }

        private void UCExpert_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsActive = true;
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
                if (isActive) this.Background = Brushes.Purple;
            }
        }

        public Expert Expert
        {
            get
            {
                return expert;
            }

            set
            {
                expert = value;
            }
        }
    }
}
