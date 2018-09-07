using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;

public partial class Default2 : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string logid = "", datejoin = "",type="";
   static DateTime dtime = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            txtfather0.Text=Request.QueryString["Pin"].ToString();
            f1();
            setting();
            Label5.Text = logid;
        }
    }
    protected void setting()
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from tblsetting");
        if (dt2.Rows.Count > 0)
        {
            logid = dt2.Rows[0]["loginid"].ToString();
            type = dt2.Rows[0]["type"].ToString();
            datejoin = dt2.Rows[0]["date"].ToString();
            if (type == "Manual")
            {
               // DateTime myDateTime = new DateTime();
                dtime = DateTime.ParseExact(datejoin, "dd/MM/yyyy", null);
            }
            else
            {
                dtime = DateTime.Now.AddHours(12).AddMinutes(30);
            }

        }
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select ID,NAME from states order by name";
        cmd.Connection = con;
        DropDownList3.DataSource = cmd.ExecuteReader();
        DropDownList3.DataTextField = "NAME";
        DropDownList3.DataValueField = "ID";
        DropDownList3.DataBind();
        con.Dispose();
        DropDownList3.SelectedValue = "1";
        //DropDownList3.Items.Insert(0, new ListItem("Add New", "")); 
        f2();
    }
    public void f2()
    {
        if (DropDownList3.Items.Count > 0)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select ID,NAME from dist where state_id=@STATE order by name";
            cmd.Parameters.Add("@STATE", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList3.SelectedValue);
            cmd.Connection = con;
            DropDownList2.DataSource = cmd.ExecuteReader();
            DropDownList2.DataTextField = "NAME";
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataBind();
            con.Dispose();
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        f2();
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
  
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt64(txtmobile.Text.Length) < 5)
        {
            Label1.Visible = true;
            Label1.Text = "Mobile must be 10 Digits!";
        }
        else
        {
            if (Convert.ToInt64(txtid.Text.Length) < 5)
            {
                Label1.Visible = true;
                Label1.Text = "ID must be 5 Digits!";
            }
            else
            {
                if (Convert.ToString(txtpassword.Text) != Convert.ToString(TextBox11.Text))
                {
                    Label1.Visible = true;
                    Label1.Text = "Passwords are not matched!";
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select pin from user_pin where pin=@PIN and (not pin in(select pin from member_creation))";
                    cmd1.Parameters.Add("@PIN", SqlDbType.VarChar).Value = Convert.ToString(txtfather0.Text.ToUpper().TrimStart().TrimEnd().Trim());
                    cmd1.Connection = con;
                    if (Convert.ToString(cmd1.ExecuteScalar()).ToUpper() != Convert.ToString(txtfather0.Text.ToUpper().TrimStart().TrimEnd().Trim()))
                    {
                        Label1.Visible = true;
                        Label1.Text = "Pin not Exist!";
                    }
                    else
                    {
                        SqlCommand cmd11 = new SqlCommand();
                        cmd11.CommandText = "select id from member_creation where id=@ID";
                        cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim());
                        cmd11.Connection = con;
                        if (Convert.ToString(cmd11.ExecuteScalar()).ToUpper() != Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim()))
                        {
                            Label1.Visible = true;
                            Label1.Text = "Proposer not Exist!";
                        }
                        else
                        {
                            SqlCommand cmd111 = new SqlCommand();
                            cmd111.CommandText = "select id from member_creation where id=@ID";
                            cmd111.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim());
                            cmd111.Connection = con;
                            if (Convert.ToString(cmd111.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim()))
                            {
                                Label1.Visible = true;
                                Label1.Text = "Sponser not Exist!";
                            }
                            else
                            {
                                SqlCommand cmd12 = new SqlCommand();
                                cmd12.CommandText = "select id from member_creation where id=@ID";
                                cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = logid + Convert.ToString(txtid.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                cmd12.Connection = con;
                                if (Convert.ToString(cmd12.ExecuteScalar()).ToUpper() == logid + Convert.ToString(txtid.Text.ToUpper().TrimStart().TrimEnd().Trim()))
                                {
                                    Label1.Visible = true;
                                    Label1.Text = "ID Already Exist!";
                                }
                                else
                                {
                                    SqlCommand cmd115 = new SqlCommand();
                                    cmd115.CommandText = "VAL_DOWNLINE";
                                    cmd115.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper());
                                    cmd115.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper());
                                    cmd115.CommandType = CommandType.StoredProcedure;
                                    cmd115.Connection = con;
                                    if (Convert.ToString(cmd115.ExecuteScalar()) != Convert.ToString(TextBox12.Text.ToUpper()))
                                    {
                                        Label1.Visible = true;
                                        Label1.Text = "ID not in Downline!";
                                    }
                                    else
                                    {
                                        string side = "";
                                        string upleg = Convert.ToString(TextBox12.Text.ToUpper());
                                        SqlCommand cmd117 = new SqlCommand();
                                        cmd117.CommandText = "select count(*) from member_creation where upleg=@upleg";
                                        cmd117.Parameters.Add("@UPLEG", SqlDbType.VarChar).Value = Convert.ToString(upleg);
                                        cmd117.Connection = con;
                                        if (Convert.ToInt64(cmd117.ExecuteScalar()) == 2)
                                        {
                                            Label1.Visible = true;
                                            Label1.Text = "Sponser already have ID in both sides!";
                                        }
                                        else
                                        {
                                            SqlCommand cmd118 = new SqlCommand();
                                            cmd118.CommandText = "select count(*) from member_creation where upleg=@upleg and side='Left'";
                                            cmd118.Parameters.Add("@UPLEG", SqlDbType.VarChar).Value = Convert.ToString(upleg);
                                            cmd118.Connection = con;
                                            if (Convert.ToInt64(cmd118.ExecuteScalar()) == 0)
                                            {
                                                side = "Left";
                                            }
                                            else
                                            {
                                                side = "Right";
                                            }
                                            {
                                                {
                                                    SqlCommand cmd = new SqlCommand();
                                                    cmd.CommandText = "insert into member_creation(id,pass,pin,name,mobile,email,pan,bank,acno,ifsc,branch,nominee,relation,address,dob,date_entry,side,spon,upleg,father,tehsil,dist,city,mobile2,pincode,rel,bv,self) values(@ID,@PASS,@PIN,@NAME,@MOBILE,@EMAIL,@PAN,@BANK,@ACNO,@IFSC,@BRANCH,@NOMINEE,@RELATION,@ADDRESS,@DOB,@DATE_ENTRY,@SIDE,@SPON,@UPLEG,@FATHER,@TEHSIL,@DIST,@CITY,@MOBILE2,@PINCODE,@REL,@bv,@self)";
                                                    cmd.Connection = con;
                                                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = logid+ Convert.ToString(txtid.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                                    cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = Convert.ToString(txtpassword.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@PIN", SqlDbType.VarChar).Value = Convert.ToString(txtfather0.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                                    cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = Convert.ToString(txtname.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@MOBILE", SqlDbType.VarChar).Value = Convert.ToString(txtmobile.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Convert.ToString(txtemail.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@PAN", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@BANK", SqlDbType.VarChar).Value = Convert.ToString(DropDownList1.SelectedValue).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@ACNO", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@IFSC", SqlDbType.VarChar).Value = Convert.ToString(TextBox5.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@BRANCH", SqlDbType.VarChar).Value = Convert.ToString(TextBox4.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@NOMINEE", SqlDbType.VarChar).Value = Convert.ToString(TextBox7.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@RELATION", SqlDbType.VarChar).Value = Convert.ToString(DropDownList4.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = Convert.ToString(TextBox6.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdob.Text);
                                                    cmd.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = dtime;
                                                    cmd.Parameters.Add("@SIDE", SqlDbType.VarChar).Value = Convert.ToString(side);
                                                    cmd.Parameters.Add("@SPON", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                                    
                                                   
                                                    cmd.Parameters.Add("@UPLEG", SqlDbType.VarChar).Value = Convert.ToString(upleg);
                                                    cmd.Parameters.Add("@FATHER", SqlDbType.VarChar).Value = Convert.ToString(TextBox2.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@TEHSIL", SqlDbType.VarChar).Value = Convert.ToString(TextBox9.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@DIST", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList2.SelectedValue);
                                                    cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = Convert.ToString(TextBox10.Text).ToUpper().TrimStart().TrimEnd().Trim();
                                                    cmd.Parameters.Add("@MOBILE2", SqlDbType.VarChar).Value = Convert.ToString(TextBox13.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                                    cmd.Parameters.Add("@PINCODE", SqlDbType.VarChar).Value = Convert.ToString(TextBox14.Text.ToUpper().TrimStart().TrimEnd().Trim());
                                                    cmd.Parameters.Add("@REL", SqlDbType.VarChar).Value = Convert.ToString(DropDownList5.SelectedValue);
                                                    cmd.Parameters.Add("@bv", SqlDbType.VarChar).Value = "0";
                                                    cmd.Parameters.Add("@self", SqlDbType.VarChar).Value ="0";

                                                    cmd.ExecuteNonQuery();
                                                    objsql.ExecuteNonQuery("insert into tblcallstatus(leaderid,month,year,memberid,status) values('" + txtgid.Text + "','Nov','2018','" + logid + Convert.ToString(txtid.Text.ToUpper().TrimStart().TrimEnd().Trim()) + "','Pending')");
                                                }
                                                {
                                                    {
                                                        string mobile = Convert.ToString(txtmobile.Text);
                                                        string msg = "Dear " + Convert.ToString(txtname.Text.ToUpper()) + ". Welcome to Top Life Business. Your User Id is  " + Convert.ToString(DateTime.Now.Year).Substring(2, 2) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(txtid.Text.ToUpper().TrimStart().TrimEnd().Trim()) + "  and Password is  " + Convert.ToString(txtpassword.Text.ToUpper()) + " . Kindly visit www.TopLifeBusiness.com.";
                                                        string result = apicall("http://www.zewaa.biz/sms.aspx?SENDER=TopLif&MOBILE=" + mobile + "&MSG=" + msg);
                                                    }
                                                    string msg1 = "Your ID is : " + Convert.ToString(DateTime.Now.Year).Substring(2, 2) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(txtid.Text.ToUpper().TrimStart().TrimEnd().Trim()) + " (" + Convert.ToString(txtname.Text).ToUpper().TrimStart().TrimEnd().Trim() + ")";
                                                    Response.Write("<script>alert('" + msg1 + "');window.location='r-s.html';</script>");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    con.Dispose();
                }
            }
        }
    }
    protected void txtsponsor_TextChanged(object sender, EventArgs e)
    {
        Label2.Text = "";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandText = "select id from member_creation where id=@ID";
        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim());
        cmd1.Connection = con;
        if (Convert.ToString(cmd1.ExecuteScalar()) == Convert.ToString(txtsponsor.Text.ToUpper()))
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim());
                cmd.Connection = con;
                Label2.Text = "Proposer Detail : " + " (" + txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim() + ")" + Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select father from member_creation where id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim());
                cmd.Connection = con;
                Label2.Text = Label2.Text + " S/O " + Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select address from member_creation where id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper().TrimStart().TrimEnd().Trim());
                cmd.Connection = con;
                Label2.Text = Label2.Text + " , " + Convert.ToString(cmd.ExecuteScalar());
            }
        }
        con.Dispose();
    }
    protected void txtupleg_TextChanged(object sender, EventArgs e)
    {
        Label3.Text = "";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd115 = new SqlCommand();
        cmd115.CommandText = "VAL_DOWNLINE";
        cmd115.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtsponsor.Text.ToUpper());
        cmd115.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper());
        cmd115.CommandType = CommandType.StoredProcedure;
        cmd115.Connection = con;
        if (Convert.ToString(cmd115.ExecuteScalar()) != Convert.ToString(TextBox12.Text.ToUpper()))
        {
            Label3.Text = "ID not in Downline!";
        }
        else
        {
            string side = "";
            string upleg = Convert.ToString(TextBox12.Text.ToUpper());
            SqlCommand cmd117 = new SqlCommand();
            cmd117.CommandText = "select count(*) from member_creation where upleg=@upleg";
            cmd117.Parameters.Add("@UPLEG", SqlDbType.VarChar).Value = Convert.ToString(upleg);
            cmd117.Connection = con;
            if (Convert.ToInt64(cmd117.ExecuteScalar()) == 2)
            {
                Label3.Text = "Sponser already have ID in both sides!";
            }
            else
            {
                if (Convert.ToInt64(cmd117.ExecuteScalar()) == 0)
                {
                    side = "Left";
                }
                else
                {
                    side = "Right";
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select id from member_creation where id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim());
                    cmd1.Connection = con;
                    if (Convert.ToString(cmd1.ExecuteScalar()) == Convert.ToString(TextBox12.Text.ToUpper()))
                    {
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "select name from member_creation where id=@ID";
                            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim());
                            cmd.Connection = con;
                            Label3.Text = "Sponser Detail : " + " (" + TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim() + ")" + Convert.ToString(cmd.ExecuteScalar());
                        }
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "select father from member_creation where id=@ID";
                            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim());
                            cmd.Connection = con;
                            Label3.Text = Label3.Text + " S/O " + Convert.ToString(cmd.ExecuteScalar());
                        }
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "select address from member_creation where id=@ID";
                            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox12.Text.ToUpper().TrimStart().TrimEnd().Trim());
                            cmd.Connection = con;
                            Label3.Text = Label3.Text + " , " + Convert.ToString(cmd.ExecuteScalar());
                        }
                    }
                }
            }
        }
        con.Dispose();
    }



    protected void txtgid_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblleader where leaderid='" + txtgid.Text + "'");
        if (dt.Rows.Count > 0)
        {
            lblgname.Text = dt.Rows[0]["Name"].ToString();
            Button1.Enabled = true;
        }
        else
        {
            Button1.Enabled = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Found')", true);


        }
    }
}
