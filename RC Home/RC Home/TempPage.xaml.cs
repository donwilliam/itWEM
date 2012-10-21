using System;
using System.IO;
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
    public partial class TempPage : PhoneApplicationPage
    {
        public TempPage()
        {
            InitializeComponent();
            checkTemps();
        }

        public class TmpDataSet
        {
            public DateTime time { get; set; }
            public string tmp { get; set; }
        }

        /*
         * method that returns the latest 50 records gathered from the fez board
         */
        public void checkTemps()
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
                List<TmpDataSet> list = new List<TmpDataSet>();
                string[] words = e.Result.Split(';');
                foreach (string str in words)
                {
                    string[] strDateTmp = str.Split(',');
                    TmpDataSet foo = new TmpDataSet();
                    foo.time = new DateTime(Convert.ToInt64(strDateTmp[0]));
                    foo.tmp = strDateTmp[1];
                    list.Add(foo);
                }
                tempLogList1.ItemsSource = list;
            }
            else
            {
                tempLogList1.ItemsSource = e.Error.Message;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lowered temperatures");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Raised temperature");
        }
    }
}