using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Redirect("../Client.aspx");
        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@EMP_ID";
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
            cmd.Connection = con;
            Label2.Text = Convert.ToString(cmd.ExecuteScalar()) + " (" + Convert.ToString(Session["id"]) + ")";
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select last_login from member_creation where id=@EMP_ID";
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
            cmd.Connection = con;
            Label1.Text = " Last Login : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cur_login from member_creation where id=@EMP_ID";
            cmd.Parameters.Add("@EMP_ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
            cmd.Connection = con;
            Label3.Text = " Current Login : " + Convert.ToString(cmd.ExecuteScalar());
        }
        con.Dispose();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../ client.aspx");
    }
}
