using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select PIN,AMOUNT from user_pin where not pin in(select pin from member_creation)";
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Dispose();
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Pin = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Response.Write("<script>window.open('../reg.aspx?pin=" + Pin + "','_blank')</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        String se, aaa;
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            {
                Random r = new Random();
                Int32 w = Convert.ToInt32(TextBox2.Text);
                aaa = "";
                for (int q = 0; q < w; q++)
                {
                    se = "";
                    for (int i = 0; i < 5; i++)
                    {
                        for (int it = 0; it < 5; it++)
                        {
                            int aa = r.Next(65, 90);
                            char c = Convert.ToChar(aa);
                            se = se + c;
                            aaa = se;
                        }
                        if (i < 4)
                        {
                            se = se + "-";
                        }
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select pin from user_pin where pin=@pin";
                    cmd.Connection = con;
                    cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = Convert.ToString(aaa);
                    var k = cmd.ExecuteScalar();
                    var u = aaa;
                    cmd.Dispose();
                    if (k != u)
                    {
                        {
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandText = "insert into user_pin values(@pin,0,@amount)";
                            cmd2.Connection = con;
                            cmd2.Parameters.Add("@pin", SqlDbType.VarChar).Value = Convert.ToString(aaa);
                            cmd2.Parameters.Add("@amount", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList1.SelectedValue);
                            //cmd2.ExecuteNonQuery();
                        }
                    }
                }
                Response.Redirect("PinGen.aspx");
            }
        }
        con.Dispose();
    }
}