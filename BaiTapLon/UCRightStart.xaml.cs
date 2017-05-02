using BaiTapLon.classes;
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
    /// Interaction logic for UCRightStart.xaml
    /// </summary>
    public partial class UCRightStart : UserControl
    {
        public UCRightStart()
        {
            
            InitializeComponent();

            if(Global.GExpert!=null)
            {
                Prolog.Instance.Load_file(Global.GExpert.Path);
                Load();
            }else
            {
                //cho cái nút ẩn đi
            }
            
        }
        List<Option> list = new List<Option>();

        public void Load()
        {
            stpl.Children.Clear();
            
            LoadQuestion(Global.GViTriCau);

            if (tblQuestion.Text == "")
            {
                txbQuestionId.Text = "Lời khuyên từ chuyên gia:";
                LoadAnswers();
                btnNext.Content = "Kết thúc";
            } 
            else
            {
                txbQuestionId.Text = "Câu hỏi số " + Global.GViTriCau;
                LoadOptions(Global.GViTriCau);
            }

        }

        public void LoadAnswers()
        {
            string query = string.Format("answer([{0}],X).", Global.GAnswer);
            List<string> list = Prolog.Instance.GetAnswers(query);
            list = list.Distinct().Where(x=>x!="").ToList();


            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i];
                TextBlock txb = new TextBlock() { Margin = new Thickness(5, 10, 0, 0), Padding=new Thickness(10,0,0,0), Text = s, Foreground = Brushes.Black, FontSize = 20 , Background=Brushes.White};
                txb.MouseDown += Txb_MouseDown;
                stpl.Children.Add(txb);
            }
        }

        private void Txb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow((sender as TextBlock).Text);
            infoWindow.ShowDialog();
        }

        public void LoadQuestion(int viTriCau)
        {
            string query = string.Format("question({0},X).", viTriCau);
            tblQuestion.Text = Prolog.Instance.GetQuestion(query);
        }
        public void LoadOptions(int viTriCau)
        {
            string query = string.Format("option({0},Index,Content).", viTriCau);
            list = Prolog.Instance.GetOptions(query);

            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i].Content;
                TextBlock txb = new TextBlock() { Margin = new Thickness(5, -7, 0, 0), Text = s, Foreground = Brushes.White, FontSize = 20 };
                CheckBox b = new CheckBox() { Content = txb, Margin=new Thickness(0,10,0,0)};
                stpl.Children.Add(b);
            }
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if((string)btnNext.Content == "Kết thúc")
            {
                Global.Reset();
                Load();
                btnNext.Content = "Next>>";
                return;
            }
            int i = 0;
            foreach (CheckBox item in stpl.Children)
            {
                if((bool)item.IsChecked)
                {
                    TextBlock txb = item.Content as TextBlock;
                    if(Global.GAnswer == "") Global.GAnswer = list[i].Index;
                    else Global.GAnswer +="," + list[i].Index;
                }
                i++;
            }
            Global.GViTriCau++;
            Load();
        }
    }
}
