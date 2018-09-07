using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //f1();
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select m.ID,m.name + ' ' + isnull(m.rel,'') + ' ' + m.father as NAME,(select count(*) from member_creation m1 where spon=m.id and(select count(*) from installment where id=m1.id and date_entry>=@DATE_FROM and date_entry<=@DATE_TO)>=15) as COUNT from member_creation m where (select count(*) from member_creation m1 where spon=m.id and(select count(*) from installment where id=m1.id and date_entry>=@DATE_FROM and date_entry<=@DATE_TO)>=15)>0 order by m.ID";
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
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Sr = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select ID from member_creation m where spon=@ID and (select count(*) from installment where date_entry>=@DATE_FROM and date_entry<=@DATE_TO and id=m.id)>=1 order by m.ID";
        cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = Sr;
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
        cmd.Connection = con;
        GridView2.DataSource = cmd.ExecuteReader();
        GridView2.DataBind();
        con.Dispose();
    }
}
