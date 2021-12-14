using System;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication7
{
    public partial class Customer : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.conn);

        protected void Page_Load(object sender, EventArgs e)
        {
            
            sqlConnection.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand command;

            SqlDataAdapter adapter = new SqlDataAdapter();

            String sql;



            sql = "insert into Customer_Details(Account_No,Name,Address,Phone) values( '" + txtaccount.Text + "','"

+ txtname.Text + "','" + txtaddress.Text + "','" + txtphone.Text + "' ) ";
            command = new SqlCommand(sql, sqlConnection);



            adapter.DeleteCommand = new SqlCommand(sql, sqlConnection);

            adapter.DeleteCommand.ExecuteNonQuery();

            Response.Write("<script>alert('Inserted Succesfully.');</script>");
            txtaccount.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";

            command.Dispose();

            sqlConnection.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            

            command = new SqlCommand("update Customer_Details set Name='" + txtname.Text + "', Address='" + txtaddress.Text + "', Phone='" + txtphone.Text + "' where Account_no='" + txtaccount.Text + "'", sqlConnection);
            command.ExecuteNonQuery();
            // Response.Write("<script>alert('Updated Details');</script>");
            Response.Redirect("~/ Manage.aspx");
            txtaccount.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand command;

            SqlDataAdapter adapter = new SqlDataAdapter();

            String sql = "";



            sql = "Delete Customer_Details where Account_no =" + Convert.ToInt32(txtaccount.Text) + "";
            command = new SqlCommand(sql, sqlConnection);
            command.ExecuteNonQuery();

            Response.Write("<script>alert('Deleted');</script>");
            txtaccount.Text = "";

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            

           // SqlCommand cmd;

            //string query = "select Name,Address,Phone from Customer_Details   ";
            SqlCommand cmd = new SqlCommand("select Name,Address,Phone from Customer_Details where Account_no=" + txtaccount.Text, sqlConnection);
           // cmd = new SqlCommand(query, sqlConnection);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }

            txtaccount.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Transaction.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer.aspx");
        }

        protected void Button8_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Manage.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Transaction.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer.aspx");
        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}