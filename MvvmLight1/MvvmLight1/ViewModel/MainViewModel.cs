using GalaSoft.MvvmLight;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MvvmLight1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string ApplicationTitle
        {
            get
            {
                return "RC HOME";
            }
        }

        public string PageName
        {
            get
            {
                return "Room status";
            }
        }

        public string LightTextBlock
        {
            get
            {
                Random random = new Random();
                int lightWatt = random.Next(10) + random.Next(10);
                return lightWatt.ToString();
            }
        }

        public string LightImageSource
        {
            get
            {
                return "/MvvmLight1;component/Images/LightIcon.png";
            }
        }

        public string TempImageSource
        {
            get
            {
                return "/MvvmLight1;component/Images/TemperatureIcon.png";
            }
        }

        public MainViewModel()
        {
        }
    }
}