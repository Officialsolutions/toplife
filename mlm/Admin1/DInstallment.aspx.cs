using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "delete from installment where sr=@SR";
        cmd.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text.ToUpper());
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Dispose();
        Response.Redirect("dInstallment.aspx");
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=(select id from installment where sr=@SR)";
            cmd.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text.ToUpper());
            cmd.Connection = con;
            Label1.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from installment where sr=@SR";
            cmd.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text.ToUpper());
            cmd.Connection = con;
            Label1.Text = Label1.Text + "(" + Convert.ToString(cmd.ExecuteScalar()) + ")";
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select convert(varchar,date_entry,106) from installment where sr=@SR";
            cmd.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text.ToUpper());
            cmd.Connection = con;
            Label1.Text = Label1.Text + " on " + Convert.ToString(cmd.ExecuteScalar());
        }
    }
}