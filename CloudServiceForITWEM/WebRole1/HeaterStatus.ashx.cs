using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebRole1 {
    /// <summary>
    /// Summary description for HeaterStatus
    /// </summary>
    public class HeaterStatus : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            String connectionString = "Server=tcp:dq8781598d.database.windows.net,1433;Database=tmp;User ID=itwemadmin@dq8781598d;Password=1de8c2ed85,;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            String sqlQuery = "select state from heaterStatus where ID=2";
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataReader dataReader = command.ExecuteReader();
            int maxTmp = 0;
            while (dataReader.Read()) {
                try {
                    maxTmp = (int)dataReader["state"];
                } catch (InvalidCastException e) {
                    context.Response.Write("maxTmp" + e.StackTrace);
                }
            }
            dataReader.Close();
             sqlQuery = "select state from heaterStatus where ID=3";
            command = new SqlCommand(sqlQuery, con);
            dataReader = command.ExecuteReader();
            int hardOff = 0;
            while (dataReader.Read()) {
                try {
                    hardOff = (int)dataReader["state"];
                } catch (InvalidCastException e) {
                    context.Response.Write("hardOff" + e.StackTrace);
                }
            }
            /*
            SELECT Tmp FROM Tmp WHERE ID = (SELECT MAX(ID)  FROM tmp)
            
              */
            dataReader.Close();
             sqlQuery = "SELECT tmp FROM Tmp WHERE ID = (SELECT MAX(ID)  FROM tmp)";
            command = new SqlCommand(sqlQuery, con);
            dataReader = command.ExecuteReader();
            
            double currentTmp = 0;

            while (dataReader.Read()) {
                try {
                    currentTmp = (double)dataReader["tmp"];
                } catch (InvalidCastException e) {
                    context.Response.Write("currentTmp " + e.ToString());
                }
            }
            dataReader.Close();
            
            int str = 0;
            if (currentTmp < maxTmp) {
                str = 1;
            }
            if (hardOff == 1) {
                str = 0;
            }

            con.Close();
            context.Response.Write("" + str);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}