using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class Transaction : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.conn);
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();



            string query = "select * from Transactions ";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }

            sqlConnection.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Transaction.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}