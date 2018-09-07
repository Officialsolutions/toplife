using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_PunjDefault : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        f1();
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DDOWNLINE";
        cmd.Parameters.Add("@DATE_FROM", SqlDbType.DateTime).Value = Convert.ToDateTime("1/1/1900");
        cmd.Parameters.Add("@DATE_TO", SqlDbType.DateTime).Value = Convert.ToDateTime("1/1/2020");
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
}