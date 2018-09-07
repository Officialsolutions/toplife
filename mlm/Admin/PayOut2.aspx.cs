using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Admin_Default2 : System.Web.UI.Page
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

        string b = "where r.id=m.id ";
        if (Convert.ToString(TextBox1.Text) != "")
        {
            b = b + "and r.date_entry>='" + Convert.ToDateTime(TextBox1.Text) + "'";
        }
        if (Convert.ToString(TextBox2.Text) != "")
        {
            b = b + "and r.date_entry<='" + Convert.ToDateTime(TextBox2.Text).AddDays(1) + "'";
        }
        if (Convert.ToString(TextBox3.Text) != "")
        {
            b = b + "and m.name like'%" + Convert.ToString(TextBox3.Text) + "%'";
        }
        if (Convert.ToString(TextBox4.Text) != "")
        {
            b = b + "and m.id like'%" + Convert.ToString(TextBox4.Text) + "%'";
        }
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select r.ID,m.NAME,m.FATHER,m.ADDRESS,m.MOBILE,convert(varchar,r.date_entry,6) as DATE,r.REWARD,r.CHEQUE from rewards r,member_creation m " + b + " order by r.date_entry";
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
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
