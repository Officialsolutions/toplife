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
            Label1.Visible = false;
            f1();
        }
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Reward";
        if (RadioButton1.Checked == true)
        {
            cmd.Parameters.Add("@STAT", SqlDbType.VarChar).Value = "ID";
        }
        if (RadioButton2.Checked == true)
        {
            cmd.Parameters.Add("@STAT", SqlDbType.VarChar).Value = "IBO";
        }
        if (RadioButton3.Checked == true)
        {
            cmd.Parameters.Add("@STAT", SqlDbType.VarChar).Value = "NAME";
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
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Sr = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Session["id"] = Sr;
        Response.Redirect("~/Client/");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select id from member_creation where id=@sr";
        cmd.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text);
        cmd.Connection = con;
        string aa = Convert.ToString(cmd.ExecuteScalar());
        if (aa != Convert.ToString(TextBox1.Text))
        {
            Label1.Visible = true;
            Label1.Text = "ID not Exist!";
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "insert into rewards values(@sr,@date1,@amount,@cheque)";
            cmd1.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text);
            cmd1.Parameters.Add("@date1", SqlDbType.DateTime).Value = Convert.ToDateTime(TextBox4.Text);
            cmd1.Parameters.Add("@amount", SqlDbType.BigInt).Value = Convert.ToInt64(TextBox2.Text);
            cmd1.Parameters.Add("@cheque", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text);
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            Response.Redirect("reward.aspx");
        }
        con.Dispose();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select name from member_creation where id=@sr";
        cmd.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text);
        cmd.Connection = con;
        Label2.Text = Convert.ToString(cmd.ExecuteScalar());
        con.Dispose();
    }
}