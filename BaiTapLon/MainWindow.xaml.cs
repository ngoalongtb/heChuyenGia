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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            UCRightExpert uc = new UCRightExpert();
            grdRight.Children.Add(uc);
            uc.OnLoadLeft += Uc_OnLoadLeft;

            grdLeft.Children.Add(new UCLeftInfo());
        }
        #region sự kiện click trên top
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimum_Click(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }
        private void btnMaximum_Click(object sender, RoutedEventArgs e)
        {
            
            WindowState = (WindowState == System.Windows.WindowState.Maximized) ? System.Windows.WindowState.Normal : WindowState.Maximized;
        }
#endregion
        #region grdTop move
        private int x;
        private int y;
        private bool isMouseDown = false;
        private void grdTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(grdTop);
            x = (int)p.X;
            y = (int)p.Y;
            isMouseDown = true;
        }

        private void grdTop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
        }

        private void grdTop_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDown)
            {
                Point p = Mouse.GetPosition(grdTop);
                window.Left = window.Left - x + p.X;
                window.Top = window.Top - y + p.Y;
            }
        }
        #endregion

        private void ResetDefaultNav()
        {
            tblExpert.Foreground = Brushes.Gray;
            tblStart.Foreground = Brushes.Gray;
            tblTheme.Foreground = Brushes.Gray;

            tblExpert.FontSize = 30;
            tblStart.FontSize = 30;
            tblTheme.FontSize = 30;

        }
        private void tblExpert_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdRight.Children.Clear();
            ResetDefaultNav();
            tblExpert.Foreground = Brushes.White;
            tblExpert.FontSize = 35;

            UCRightExpert uc = new UCRightExpert();
            grdRight.Children.Add(uc);
            uc.OnLoadLeft += Uc_OnLoadLeft;
        }

        private void Uc_OnLoadLeft(object sender, EventArgs e)
        {
            grdLeft.Children.Clear();

            grdLeft.Children.Add(new UCLeftInfo());
            tblStart_MouseDown(sender, null);
        }

        private void tblStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Global.GExpert == null)
            {
                MessageBox.Show("Vui lòng chọn hệ chuyên gia trước khi bắt đầu");
                return;
            }

            grdRight.Children.Clear();
            ResetDefaultNav();
            tblStart.Foreground = Brushes.White;
            tblStart.FontSize = 35;

            grdRight.Children.Add(new UCRightStart());
        }

        private void tblTheme_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdRight.Children.Clear();
            ResetDefaultNav();
            tblTheme.Foreground = Brushes.White;
            tblTheme.FontSize = 35;

            grdRight.Children.Add(new UCRightTheme());
        }

    }
}
