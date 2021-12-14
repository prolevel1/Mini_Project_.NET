using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.conn);
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            

           
            string check = "select count(*) from [Table] where Email = '" + txtusr.Text + "' and  Password= '" + txtpass.Text + "' ";
            SqlCommand com = new SqlCommand(check, sqlConnection);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Response.Redirect("~/Manage.aspx");
            }
            else
            {
                lblres.ForeColor = System.Drawing.Color.Red;
                lblres.Text = "Invalid email";
            }

        }

        protected void txtusr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}