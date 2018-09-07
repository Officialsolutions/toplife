using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
        }
    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }
    protected void buttonClick_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select id from member_creation where id=@ID";
        cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()) != Convert.ToString(txtUserId.Text.ToUpper()))
        {
            Label1.Visible = true;
            Label1.Text = "ID is not Correct!";
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select pass from member_creation where id=@ID";
            cmd1.Parameters.Add("@ID",SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
            cmd1.Connection = con;
            if (Convert.ToString(cmd1.ExecuteScalar()) != Convert.ToString(txtpins.Text.ToUpper()))
            {
                Label1.Visible = true;
                Label1.Text = "Password is not Correct!";
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "select count(*) from member_creation where upleg=@ID";
                cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                cmd2.Connection = con;
                if (Convert.ToInt64(cmd2.ExecuteScalar()) >=1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Have Sponser of any ID!";
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandText = "select count(*) from member_creation where spon=@ID";
                    cmd3.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                    cmd3.Connection = con;
                    if (Convert.ToInt64(cmd3.ExecuteScalar()) >= 1)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Have Proposer of any ID!";
                    }
                    else
                    {
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4.CommandText = "select count(*) from installment where id=@ID";
                        cmd4.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                        cmd4.Connection = con;
                        if (Convert.ToInt64(cmd4.ExecuteScalar()) >= 1)
                        {
                            Label1.Visible = true;
                            Label1.Text = "Have Installments!";
                        }
                        else
                        {
                            SqlCommand cmd5 = new SqlCommand();
                            cmd5.CommandText = "delete from member_creation where id=@ID";
                            cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                            cmd5.Connection = con;
                            cmd5.ExecuteNonQuery();
                            Response.Write("<script>alert('ID deleted Successfully!');window.location='deleteid.aspx';</script>");
                        }
                    }
                }
            }
        }
        con.Dispose();
    }
    protected void txtUserId_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
            cmd.Connection = con;
            Label4.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select rel from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
            cmd.Connection = con;
            Label4.Text = Label4.Text + " " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select father from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
            cmd.Connection = con;
            Label4.Text = Label4.Text + " " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select address from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
            cmd.Connection = con;
            Label4.Text = Label4.Text + " " + Convert.ToString(cmd.ExecuteScalar());
        }
        con.Dispose();
    }
}