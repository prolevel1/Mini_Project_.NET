using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.conn);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
           
            string sql = "Insert into [Table](Name,Email,Password)values ('" + txtname.Text + "','"

                        + txtemail.Text + "','" + txtpassword.Text + "' ) ";

           SqlCommand command = new SqlCommand(sql, sqlConnection);


            command.ExecuteNonQuery();
            Response.Write("<script>alert(' Succesfully.');</script>");
            Response.Redirect("~/Login.aspx");
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";





        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}