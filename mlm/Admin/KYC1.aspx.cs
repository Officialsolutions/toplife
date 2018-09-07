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
            f1();
        }
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Sr = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Response.Redirect("KYC.aspx");
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
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        string a = " order by m.kyc desc";
        if (Convert.ToString(TextBox1.Text) != "")
        {
        }
        if (RadioButton1.Checked == true)
        {
            a = " order by m.id";
        }
        if (RadioButton3.Checked == true)
        {
            a = " order by m.name";
        }
        if (RadioButton4.Checked == true)
        {
            a = " order by m.date_entry";
        }
        string b = "where 1=1 ";
        if (Convert.ToString(TextBox1.Text) != "")
        {
            b = b + " and date_entry>='" + Convert.ToDateTime(TextBox1.Text) + "'";
        }
        if (Convert.ToString(TextBox2.Text) != "")
        {
            b = b + " and date_entry<='" + Convert.ToDateTime(TextBox2.Text).AddDays(1) + "'";
        }
        if (Convert.ToString(TextBox3.Text) != "")
        {
            b = b + " and m.name like'%" + Convert.ToString(TextBox3.Text) + "%'";
        }
        if (Convert.ToString(TextBox4.Text) != "")
        {
            b = b + " and m.id like'%" + Convert.ToString(TextBox4.Text) + "%'";
        }
        if (Convert.ToString(TextBox5.Text) != "")
        {
            b = b + " and m.mobile like'%" + Convert.ToString(TextBox5.Text) + "%'";
        }
        if (Convert.ToString(TextBox6.Text) != "")
        {
            b = b + " and (select u.id from user_pin u where u.pin=m.pin)='" + Convert.ToString(TextBox6.Text) + "'";
        }
        b = b + " and kyc>0";
        SqlDataAdapter sd = new SqlDataAdapter("select KYC,m.ID,m.NAME + ' ' + isnull(m.rel,'') + ' ' + m.father + ' ' + m.address as NAME,m.MOBILE,(select convert(varchar,u.id) + ' ' + m1.name + ' ' + isnull(m1.rel,'') + ' ' + m1.father from user_pin u,member_creation m1 where u.pin=m.pin and u.id=m1.id) as LEADER,convert(varchar,m.DATE_ENTRY,6) as DOJ from member_creation m " + b + a, con);
        DataSet ds = new DataSet();
        sd.Fill(ds);
        if (ds != null)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
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
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
}