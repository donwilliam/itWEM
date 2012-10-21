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
    public partial class LightPage : PhoneApplicationPage
    {
        public LightPage()
        {
            InitializeComponent();
            checkWatt();
        }

        public class LightDataSet
        {
            public DateTime time { get; set; }
            public string watt { get; set; }
        }

        /*
         * method that returns the latest 50 records gathered from the fez board
         */
        public void checkWatt()
        {
            List<LightDataSet> list = new List<LightDataSet>();
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                LightDataSet foo = new LightDataSet();
                foo.watt = (random.Next(10) + random.Next(10)).ToString();
                DateTime start = new DateTime(2012, 10, 15);
                int range = ((TimeSpan)(DateTime.Today - start)).Days;
                foo.time = start.AddDays(random.Next(range));
                list.Add(foo);
            }
            lightLogList1.ItemsSource = list;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lowered lights");    
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Raised lights");
        }
    }
}