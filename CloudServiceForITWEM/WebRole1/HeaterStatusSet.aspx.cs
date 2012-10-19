using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebRole1 {
    public partial class HeaterStatusSet : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String connectionString = "Server=tcp:dq8781598d.database.windows.net,1433;Database=tmp;User ID=itwemadmin@dq8781598d;Password=1de8c2ed85,;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            string setMax = Request.Params["setMax"];

            string hardOff = Request.Params["hardOff"];
            SqlCommand command;
            if (setMax != null) {
                String sqlSetMax = "update heaterstatus set state=" + setMax + "where id=2";
                command = new SqlCommand(sqlSetMax, con);
                command.ExecuteNonQuery();
            }
            if (hardOff != null) {
                String sqlSetMax = "update heaterstatus set state=" + hardOff + "where id=3";
                command = new SqlCommand(sqlSetMax, con);
                command.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}