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
            //f1();
        }
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Sr = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Session["id"] = Sr;
        Response.Write("<script>window.open('../client/','_blank')</script>");
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
        string a = "order by m.id";
        if (RadioButton1.Checked == true)
        {
            a = "order by m.id";
        }
        if (RadioButton3.Checked == true)
        {
            a = "order by m.name";
        }
        if (RadioButton4.Checked == true)
        {
            a = "order by m.date_entry";
        }
        string b = "where 1=1 ";
        DateTime c = Convert.ToDateTime("1/1/1990");
        DateTime d = Convert.ToDateTime("1/1/2020");
        if (Convert.ToString(TextBox1.Text) != "")
        {
            c = Convert.ToDateTime(TextBox1.Text);
        }
        if (Convert.ToString(TextBox2.Text) != "")
        {
            d = Convert.ToDateTime(TextBox2.Text);
        }
        if (Convert.ToString(TextBox3.Text) != "")
        {
            b = b + "and m.name like'%" + Convert.ToString(TextBox3.Text) + "%'";
        }
        if (Convert.ToString(TextBox4.Text) != "")
        {
            b = b + "and m.id like'%" + Convert.ToString(TextBox4.Text) + "%'";
        }
        SqlDataAdapter sd = new SqlDataAdapter("select row_number() over (" + a + ") as SR,m.ID,m.NAME,(select cnt from cnt_down1(m.id,'A',@DATE_FROM,@DATE_TO)) as TOTAL,(select cnt from cnt_down1(m.id,'Left',@DATE_FROM,@DATE_TO)) as 'LEFT',(select cnt from cnt_down1(m.id,'Right',@DATE_FROM,@DATE_TO)) as 'RIGHT' from member_creation m " + b + a, con);
        sd.SelectCommand.Parameters.Add("@DATE_FROM",SqlDbType.DateTime).Value = c;
        sd.SelectCommand.Parameters.Add("@DATE_TO", SqlDbType.DateTime).Value = d;
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
}