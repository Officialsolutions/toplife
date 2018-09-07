using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            Session["client"] = null;
        }
    }
    public string apicall(string url)
    {
        string results = "";
        try
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
            StreamReader sr = new StreamReader(httpres.GetResponseStream());
            results = sr.ReadToEnd();
            sr.Close();
        }
        catch { }
        return results;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd.Connection = con;
                if (Convert.ToString(cmd.ExecuteScalar()) != Convert.ToString(TextBox1.Text.ToUpper()))
                {
                    Label1.Visible = true;
                    Label1.Text = "ID not Exist!";
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select pass from member_creation where id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                    cmd1.Connection = con;
                    if (Convert.ToString(cmd1.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox2.Text.ToUpper()))
                    {
                        Label1.Visible = true;
                        Label1.Text = "Password not Matched!";
                    }
                    else
                    {
                        Session["id"] = Convert.ToString(TextBox1.Text.ToUpper());
                        {
                            SqlCommand cmd11 = new SqlCommand();
                            cmd11.CommandText = "update member_creation set last_login=cur_login where id=@ID";
                            cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                            cmd11.Connection = con;
                            cmd11.ExecuteNonQuery();
                        }
                        {
                            SqlCommand cmd11 = new SqlCommand();
                            cmd11.CommandText = "update member_creation set cur_login=@DATE where id=@ID";
                            cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                            cmd11.Parameters.Add("@DATE",SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.AddHours(12).AddMinutes(30));
                            cmd11.Connection = con;
                            cmd11.ExecuteNonQuery();
                        }
                        Response.Redirect("client");
                    }
                }
            }
        }
        con.Dispose();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        if (Convert.ToInt64(TextBox1.Text.Length) == 0)
        {
            Label1.Visible = true;
            Label1.Text = "Please Fill Your ID First!";
        }
        else
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != Convert.ToString(TextBox1.Text.ToUpper()))
            {
                Label1.Visible = true;
                Label1.Text = "ID not Exist!";
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select mobile from member_creation where id=@ID";
                cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd1.Connection = con;
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "select name from member_creation where id=@ID";
                cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd2.Connection = con;
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = "select pass from member_creation where id=@ID";
                cmd3.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd3.Connection = con;
                string mobile = Convert.ToString(cmd1.ExecuteScalar());
                string msg = "Dear " + Convert.ToString(cmd2.ExecuteScalar()) + " (" + Convert.ToString(TextBox1.Text.ToUpper()) + "). Your Password is (" + Convert.ToString(cmd3.ExecuteScalar()) + "). Please LogOn to www.SanjeevaniHerbs.com.";
                //string result = apicall("http://login.smsmedia.org/api/mt/SendSMS?user=sherbs&password=sherbs@123&senderid=SHerbs&channel=Trans&DCS=0&flashsms=0&number=91" + mobile + "&text=" + msg + "&route=1");
                Label1.Visible = true;
                Label1.Text = "Your Password is sent to Your Mobile!";
            }
        }
    }
}