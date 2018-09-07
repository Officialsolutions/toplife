using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ID"] = "1611";
        f1();
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DDOWNLINE";
        if (Convert.ToString(TextBox1.Text) == "")
        {
            cmd.Parameters.Add("@DATE_FROM", SqlDbType.DateTime).Value = Convert.ToDateTime("1/1/1900");
        }
        else
        {
            cmd.Parameters.Add("@DATE_FROM", SqlDbType.DateTime).Value = Convert.ToDateTime(TextBox1.Text);
        }
        if (Convert.ToString(TextBox2.Text) == "")
        {
            cmd.Parameters.Add("@DATE_TO", SqlDbType.DateTime).Value = Convert.ToDateTime("1/1/2020");
        }
        else
        {
            cmd.Parameters.Add("@DATE_TO", SqlDbType.DateTime).Value = Convert.ToDateTime(TextBox2.Text);
        }
        if (RadioButton1.Checked == true)
        {
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        }
        if (RadioButton2.Checked == true)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select id from member_creation where upleg=@ID1 and side='Left'";
            cmd1.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd1.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd1.ExecuteScalar());
        }
        if (RadioButton3.Checked == true)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select id from member_creation where upleg=@ID1 and side='Right'";
            cmd1.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd1.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd1.ExecuteScalar());
        }
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
}
