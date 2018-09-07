using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            Session["admin"] = null;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select sr from admin where sr=@ID";
        cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox1.Text.ToUpper()))
        {
            Label1.Visible = true;
            Label1.Text = "ID not Exist!";
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select pass from admin where sr=@ID";
            cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd1.Connection = con;
            if (Convert.ToString(cmd1.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox2.Text.ToUpper()))
            {
                Label1.Visible = true;
                Label1.Text = "Password not Matched!";
            }
            else
            {
                Session["admin"] = Convert.ToString(TextBox1.Text.ToUpper());
                Response.Redirect("admin");
            }
        }
        con.Dispose();
    }
}