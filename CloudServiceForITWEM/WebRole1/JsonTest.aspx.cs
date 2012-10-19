using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace WebRole1 {
    public partial class JsonTest : System.Web.UI.Page {

        /*
         *  small class that represents the data gathered from the fez board.
         */
        public class TmpDataSet {
            public DateTime date { get; set; }
            public double tmp { get; set; }
        }


        /*
         * methode that returns the latest 50 records from the fez board
         */
        public static List<TmpDataSet> ParseDateTmpResponse() {
            string url = "http://itwem.azurewebsites.net/GetTempStatus.ashx";

            Uri serviceUri = new Uri(url, UriKind.Absolute);


            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(serviceUri);


            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string jsonResponse = string.Empty;
            StreamReader sr = new StreamReader(response.GetResponseStream());

            jsonResponse = sr.ReadToEnd();


            List<TmpDataSet> list = new List<TmpDataSet>();
            string[] words = jsonResponse.Split(';');
            foreach (string str in words) {
                string[] strDateTmp = str.Split(',');
                TmpDataSet foo = new TmpDataSet();
                foo.date = new DateTime(Convert.ToInt64(strDateTmp[0]));
                foo.tmp = Convert.ToDouble(strDateTmp[0]);
                list.Add(foo);
            }
            return list;
        }

        protected void Page_Load(object sender, EventArgs e) {

            List<TmpDataSet> list = ParseDateTmpResponse();
                

                webpage.Text = "" + list[0].date + " " + list[0].tmp;



            
                

                

            
             
    }
        
    }
}