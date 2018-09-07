using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CLUB";
            cmd.Parameters.Add("@STAT",SqlDbType.VarChar).Value = "D";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Dispose();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "CLUB";
        cmd.Parameters.Add("@STAT", SqlDbType.VarChar).Value = "P";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Dispose();
        Response.Redirect("Closing.aspx");
    }
}