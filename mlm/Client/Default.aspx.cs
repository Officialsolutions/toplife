using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Client_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = "0";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        Int64 lbus = 0;
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select active from cnt_down(@ID)";
                cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                cmd1.Connection = con;
                lbus = Convert.ToInt64(cmd1.ExecuteScalar());
            }
        }
        Int64 rbus = 0;
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select active from cnt_down(@ID)";
                cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                cmd1.Connection = con;
                rbus = Convert.ToInt64(cmd1.ExecuteScalar());
            }
        }
        {
            SqlCommand cmd11 = new SqlCommand();
            cmd11.CommandText = "select count(*) from member_creation where spon=@ID";
            cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd11.Connection = con;
            if (Convert.ToInt64(cmd11.ExecuteScalar()) >= 4)
            {
                Label2.Text = "Star Distributor";
            }
        }
        {
            if (lbus >= 30 && rbus >= 30)
            {
                Label2.Text = "Silver Distributor";
            }
        }
        {
            if (lbus >= 125 && rbus >= 125)
            {
                Label2.Text = "Gold Distributor";
            }
        }
        {
            if (lbus >= 500 && rbus >= 500)
            {
                Label2.Text = "Star Gold Distributor";
            }
        }
        {
            if (lbus >= 1000 && rbus >= 1000)
            {
                Label2.Text = "Ruby Distributor";
            }
        }
        {
            if (lbus >= 2050 && rbus >= 2050)
            {
                Label2.Text = "Star Ruby Distributor";
            }
        }
        {
            if (lbus >= 3200 && rbus >= 3200)
            {
                Label2.Text = "Diamond Distributor";
            }
        }
        {
            if (lbus >= 10000 && rbus >= 10000)
            {
                Label2.Text = "STar Diamond Distributor";
            }
        }
        {
            if (lbus >= 25000 && rbus >= 25000)
            {
                Label2.Text = "Top Life King Distributor";
            }
        }
        con.Dispose();
    }
}