using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace WebRole1 {
    /// <summary>
    /// Summary description for GetTempStatus
    /// </summary>
    public class GetTempStatus : IHttpHandler {

        // antal der skal hentes
        private static int count = 50;

        public void ProcessRequest(HttpContext context) {



            context.Response.ContentType = "text/plain";
            String connectionString = "Server=tcp:dq8781598d.database.windows.net,1433;Database=tmp;User ID=itwemadmin@dq8781598d;Password=1de8c2ed85,;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            string sqlQuery = "select * from Tmp where ID not in ( select top ((select count(*) from Tmp) -" + count + ") ID from Tmp)";
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataReader dataReader = command.ExecuteReader();
            /*
             * {
"employees": [
{ "firstName":"John" , "lastName":"Doe" }, 
{ "firstName":"Anna" , "lastName":"Smith" }, 
{ "firstName":"Peter" , "lastName":"Jones" }
]
}
             */
            string str = "";
            if (dataReader.Read()) {
                DateTime date = (DateTime) dataReader["date"];
                str += date.ToBinary()+",";
                str +=  dataReader["tmp"];
            }
            while (dataReader.Read()) {
                DateTime date = (DateTime)dataReader["date"];
                str += ";" + date.ToBinary() + ",";
                str +=  dataReader["tmp"];
            } ;
          
            con.Close();

            context.Response.Write(str);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }

    public class tmpDataSet {

        
        public DateTime date { get; set; }
        public double tmp { get; set; }
    }
}