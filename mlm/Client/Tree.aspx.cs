using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label17.Visible = false;
        Label18.Visible = false;
        Label19.Visible = false;
        Label20.Visible = false;
        Label21.Visible = false;
        Label22.Visible = false;
        if (Page.IsPostBack == false)
        {
            Tree(Convert.ToString(Session["id"]));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "VAL_DOWNLINE";
        cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        cmd.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(txtname.Text.ToUpper());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()) == Convert.ToString(txtname.Text.ToUpper()))
        {
            Tree(Convert.ToString(txtname.Text.ToUpper()));
        }
        con.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton1.Text));
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton3.Text));
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton2.Text));
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton4.Text));
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton5.Text));
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton6.Text));
    }
    public void Tree(string Sr)
    {
        Image3.ImageUrl = "../imges/user_black.png";
        Image6.ImageUrl = "../imges/user_black.png";
        Image9.ImageUrl = "../imges/user_black.png";
        Image12.ImageUrl = "../imges/user_black.png";
        Image15.ImageUrl = "../imges/user_black.png";
        Image18.ImageUrl = "../imges/user_black.png";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        #region Check Left Active Pair
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt from cnt_down(@ID)";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label23.Text = "Left IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select active from cnt_down(@ID)";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    // Label23.Text =Label23.Text + "<br>Active IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt_new from cnt_down1(@ID,'Left','01/01/1900','01/01/2020')";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Sr);
                    cmd1.Connection = con;
                    Label23.Text = Label23.Text + "<br>New IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
            }
            else
            {
                Label23.Text = "Left IDs : 0<br>Active IDs : 0<br>";
            }
        }
        #endregion
        #region check right active pair
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt from cnt_down(@ID)";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label25.Text = "Right IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select active from cnt_down(@ID)";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    //   Label25.Text = Label25.Text + "<br>Active IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt_new from cnt_down1(@ID,'Right','01/01/1900','01/01/2020')";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Sr);
                    cmd1.Connection = con;
                    Label25.Text = Label25.Text + "<br>New IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
            }
            else
            {
                Label25.Text = "Right IDs : 0<br>Active IDs : 0<br>New IDs : 0";
            }
        } 
        #endregion
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Label8.Text + "<br>" + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton1.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label10.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select spon from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                if (Convert.ToString(cmd.ExecuteScalar()) != "")
                {
                    Label17.Visible = true;
                    Label17.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select name from member_creation where id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label17.Text = Label17.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                }
                else
                {
                    Image3.ImageUrl = "../imges/tree1.png";
                }
            }
        }
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton4.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label11.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select spon from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                if (Convert.ToString(cmd.ExecuteScalar()) != "")
                {
                    Label18.Visible = true;
                    Label18.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select name from member_creation where id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label18.Text = Label18.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                }
                else
                {
                    Image6.ImageUrl = "../imges/tree1.png";
                }
            }
        }
        {
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton2.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label12.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label19.Visible = true;
                        Label19.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label19.Text = Label19.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image9.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton3.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label13.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label20.Visible = true;
                        Label20.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label20.Text = Label20.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image12.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
        }
        {
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton5.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label14.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label21.Visible = true;
                        Label21.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label21.Text = Label21.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image15.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton6.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label15.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label22.Visible = true;
                        Label22.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label22.Text = Label22.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image18.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
        }
        Image3.ImageUrl = "../img/user_black.png";
        Image6.ImageUrl = "../img/user_black.png";
        Image9.ImageUrl = "../img/user_black.png";
        Image12.ImageUrl = "../img/user_black.png";
        Image15.ImageUrl = "../img/user_black.png";
        Image18.ImageUrl = "../img/user_black.png";
        con.Dispose();
    }
}
