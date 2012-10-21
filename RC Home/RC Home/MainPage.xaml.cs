using System;
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

namespace RC_Home
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            checkTempAndLight();
        }

        /*
         * method that returns the latest 50 records gathered from the fez board
         */
        public void checkTempAndLight()
        {
            string url = "http://itwem.azurewebsites.net/GetTempStatus.ashx";
            Uri serviceUri = new Uri(url, UriKind.Absolute);

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(serviceUri);
        }

        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] tmps = e.Result.Split(';');
                string recentTmp = tmps[tmps.Length - 1];     
                string[] strDateTmp = recentTmp.Split(',');
                string tmp = strDateTmp[1];
                temperatureBlock.Text = tmp;

                Random random = new Random();
                int lightWatt = random.Next(10) + random.Next(10);
                lightBlock.Text = lightWatt.ToString();
            }
            else
            {
                temperatureBlock.Text = "EE";
            }
        }

        private void tempImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void lightImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void lightImage_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/lightPage.xaml", UriKind.Relative));
        }

        private void tempImage_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/tempPage.xaml", UriKind.Relative));
        }

        private void tempLoaded(object sender, RoutedEventArgs e)
        {
            checkTempAndLight();
        }
    }
}