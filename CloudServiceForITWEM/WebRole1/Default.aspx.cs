using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebRole1 {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String connectionString ="Server=tcp:dq8781598d.database.windows.net,1433;Database=tmp;User ID=itwemadmin@dq8781598d;Password=1de8c2ed85,;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string tmp = Request.Params["Tmp"];
            if (tmp != null) {
                String sqlQuery = "INSERT INTO Tmp VALUES (GetDate()," + tmp + ")";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                int numrow = command.ExecuteNonQuery();
                string url = HttpContext.Current.Request.Url.AbsoluteUri;


                
            }
            con.Close();
            

        }
    }
}
