using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BaiTapLon.classes
{
    public class Theme: INotifyPropertyChanged
    {
        public Theme()
        {
            ForegroundExpert = Brushes.White;
            ForegroundStart = Brushes.Gray;
            ForegroundTheme = Brushes.Gray;

            ForegroundActive = Brushes.White;

            backgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0d0d0d"));
        }

        public SolidColorBrush ForegroundActive;
        private SolidColorBrush backgroundColor;
        public SolidColorBrush BackgroundColor
        {
            get
            {
                return backgroundColor;
            }

            set
            {
                backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }

        public SolidColorBrush ForegroundExpert
        {
            get
            {
                return foregroundExpert;
            }

            set
            {
                foregroundExpert = value;
                OnPropertyChanged("ForegroundExpert");
            }
        }

        private SolidColorBrush foregroundExpert;

        public SolidColorBrush ForegroundStart
        {
            get
            {
                return foregroundStart;
            }

            set
            {
                foregroundStart = value;
                OnPropertyChanged("ForegroundStart");
            }
        }

        private SolidColorBrush foregroundStart;

        private SolidColorBrush foregroundTheme;
        public SolidColorBrush ForegroundTheme
        {
            get
            {
                return foregroundTheme;
            }

            set
            {
                foregroundTheme = value;
                OnPropertyChanged("ForegroundTheme");
            }
        }

        




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string s)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
}
}
