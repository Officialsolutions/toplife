using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //chk();
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select d.ID,d.NAME,s.name as STATE from dist d,states s where d.state_id=s.id order by d.name";
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Dispose();
            f1();
        }
    }
    public void chk()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandText = "select admin_id from admin_rights where admin_id=@ADMIN_ID and page_id=@PAGE_ID";
        cmd1.Parameters.Add("@ADMIN_ID", SqlDbType.VarChar).Value = Convert.ToString(Session["admin"]);
        cmd1.Parameters.Add("@PAGE_ID", SqlDbType.VarChar).Value = Convert.ToString(this.Page.ToString().Substring(10).Substring(0, this.Page.ToString().Substring(10).Length - 5));
        cmd1.Connection = con;
        if (Convert.ToString(cmd1.ExecuteScalar()) != Convert.ToString(Session["admin"]))
        {
            Response.Redirect("Default.aspx");
        }
        con.Dispose();
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select ID,NAME from states order by name";
        cmd.Connection = con;
        DropDownList1.DataSource = cmd.ExecuteReader();
        DropDownList1.DataTextField = "NAME";
        DropDownList1.DataValueField = "ID";
        DropDownList1.DataBind();
        con.Dispose();    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from dist where state_id=@STATE and name=@NAME";
            cmd.Parameters.Add("@STATE", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList1.SelectedValue);
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) == Convert.ToString(TextBox1.Text.ToUpper()))
            {
                Label1.Visible = true;
                Label1.Text = "District Name already Exist!";
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "insert into dist values((select isnull(max(id),0)+1 from dist),@NAME,@STATE)";
                cmd1.Parameters.Add("@NAME", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd1.Parameters.Add("@STATE", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList1.SelectedValue);
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                Response.Redirect("Dist.aspx");
            }
        }
        con.Dispose();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("States.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dist.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("City.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Banks.aspx");
    }
}