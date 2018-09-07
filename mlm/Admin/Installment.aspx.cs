using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI;

public partial class Admin_Default : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string adminid, bookid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            string date = System.DateTime.Today.Date.ToString("dd");
            string month = System.DateTime.Today.Month.ToString();
            string year = System.DateTime.Today.Year.ToString();
            string month23 = DateTime.Now.Month.ToString();
            if (Convert.ToInt32(month23) <= 9)
            {
                string mm = "0" + month23;
                ddlmonth.Items.FindByText(mm).Selected = true;
            }
            else
            {
                ddlmonth.Items.FindByText(month23).Selected = true;
            }

            ddldate.Items.FindByText(date).Selected = true;
           
            ddlyear.Items.FindByText(year).Selected = true;

            TextBox4.Focus();
            f1();
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
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        string b = "where i.id=m.id ";
        string order = "";
        string row = "";
        if (Convert.ToString(TextBox7.Text) != "")
        {
            b = b + "and i.date_entry>='" + Convert.ToDateTime(TextBox7.Text) + "'";
        }
        if (Convert.ToString(TextBox8.Text) != "")
        {
            b = b + "and i.date_entry<='" + Convert.ToDateTime(TextBox8.Text).AddDays(1) + "'";
        }
        if (Convert.ToString(TextBox6.Text) != "")
        {
            b = b + "and m.name like'%" + Convert.ToString(TextBox6.Text) + "%'";
        }
        if (Convert.ToString(TextBox5.Text) != "")
        {
            b = b + "and m.id like'%" + Convert.ToString(TextBox5.Text) + "%'";
        }
        if (Convert.ToString(TextBox3.Text) != "")
        {
            b = b + "and (select count(*) from installment where date_entry<=i.date_entry and id=i.id)=" + Convert.ToInt64(TextBox3.Text);
        }
        if (Convert.ToString(TextBox9.Text) != "")
        {
            b = b + "and i.sr like'%" + Convert.ToString(TextBox9.Text) + "%'";
        }
        if (Convert.ToString(TextBox10.Text) != "")
        {
            b = b + "and convert(int,i.sr)>=" + Convert.ToInt64(TextBox10.Text);
        }
        if (Convert.ToString(TextBox11.Text) != "")
        {
            b = b + "and convert(int,i.sr)<=" + Convert.ToString(TextBox11.Text);
        }
        if (Convert.ToString(TextBox9.Text) == "" && Convert.ToString(TextBox8.Text) == "" && Convert.ToString(TextBox7.Text) == "" && Convert.ToString(TextBox6.Text) == "" && Convert.ToString(TextBox5.Text) == "" && Convert.ToString(TextBox3.Text) == "" && Convert.ToString(TextBox10.Text) == "" && Convert.ToString(TextBox11.Text) == "")
        {
            order = "i.sno desc";
            row = "top 3 ";
        }
        else
        {
            order = "convert(int,i.sr)";
            row = "";
        }
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select " + row + " row_number() over (order by " + order + ") as 'NO.',i.SR as RN,convert(varchar,i.DATE_ENTRY,106) as DATE,i.ID,m.NAME + ' ' + isnull(m.rel,'') + ' ' + m.father as NAME,(select count(*) from installment where date_entry<=i.date_entry and id=i.id) as 'INS-NO.' from installment i,member_creation m " + b + " and i.Paid='0' order by " + order;
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox2.Text = ddlmonth.SelectedItem.Text +"/" +ddldate.SelectedItem.Text +"/"+ ddlyear.SelectedItem.Text;


        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();

        detail();
        if (adminid != "")
        {


            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "select sr from installment where sr=@ID";
            cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox4.Text.ToUpper());
            cmd2.Connection = con;
            if (Convert.ToString(cmd2.ExecuteScalar()).ToUpper() == Convert.ToString(TextBox4.Text.ToUpper()))
            {
                Label1.Text = "Receipt already Exist!";
            }
            else
            {
           
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd.Connection = con;
                if (Convert.ToString(cmd.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox1.Text.ToUpper()))
                {
                    Label1.Text = "ID is not Correct!";
                }
                else
                {
                    {
                        string srno = Common.Get(objsql.GetSingleValue("select isnull(max(sno),0)+1 from installment"));
                        //SqlCommand cmd1 = new SqlCommand();
                        //cmd1.CommandText = "insert into installment values(@DATE_ENTRY,@ID,@SNO,@SR,@bookid,@adminid,@status,@paid,@purchaseid)";
                        //cmd1.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = TextBox2.Text;
                        //cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                        //cmd1.Parameters.Add("@SNO", SqlDbType.VarChar).Value =srno;
                        //cmd1.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(TextBox4.Text.ToUpper());
                        //cmd1.Parameters.Add("@bookid", SqlDbType.VarChar).Value = bookid;
                        //cmd1.Parameters.Add("@adminid", SqlDbType.VarChar).Value = adminid;
                        //cmd1.Parameters.Add("@status", SqlDbType.VarChar).Value = "Free";
                        //cmd1.Parameters.Add("@paid", SqlDbType.Bit).Value = true;
                        //cmd1.Parameters.Add("@purchaseid", SqlDbType.VarChar).Value = "";
                        //cmd1.Connection = con;

                        //cmd1.ExecuteNonQuery();
                        objsql.ExecuteNonQuery("insert into installment(DATE_ENTRY,ID,SNO,SR,bookid,adminid,status,paid) Values('" + TextBox2.Text + "','" + TextBox1.Text.ToUpper() + "','" + srno + "','" + TextBox4.Text.ToUpper() + "','" + bookid + "','" + adminid + "','Free','0')");
                        xx:;
                        int count =Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + txtid.Value + "'")));
                        if (count == 8)
                        {
                            string spon = Common.Get(objsql.GetSingleValue("select spon from member_creation where id='" + txtid.Value + "'"));
                            if (spon != "")
                            {
                                //SqlCommand cmd23 = new SqlCommand();
                                //cmd23.CommandText = "insert into installment values(@SR,@DATE_ENTRY,@ID,(select isnull(max(sno),0)+1 from installment),@bookid,@adminid,@status,@paid)";
                                //cmd23.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = Convert.ToDateTime(TextBox2.Text);
                                //cmd23.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(spon.ToUpper());
                                //cmd23.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(txtid.Value.ToUpper());
                                //cmd23.Parameters.Add("@bookid", SqlDbType.VarChar).Value = "";
                                //cmd23.Parameters.Add("@adminid", SqlDbType.VarChar).Value = "";
                                //cmd23.Parameters.Add("@status", SqlDbType.VarChar).Value = "Free";
                                //cmd23.Parameters.Add("@paid", SqlDbType.Bit).Value = "0";
                                //cmd23.Connection = con;
                                //cmd23.ExecuteNonQuery();
                                objsql.ExecuteNonQuery("insert into installment(DATE_ENTRY,ID,SNO,SR,bookid,adminid,status,paid) Values('" + TextBox2.Text + "','" + spon.ToUpper() + "','" + srno + "','" + txtid.Value.ToUpper() + "','','','Free','0')");
                                txtid.Value = spon;
                                goto xx;
                            }
                        }
                    }
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select mobile from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                        cmd1.Connection = con;
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.CommandText = "select name from member_creation where id=@ID";
                        cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                        cmd5.Connection = con;
                        string mobile = Convert.ToString(cmd1.ExecuteScalar());
                        string msg = "Dear " + Convert.ToString(cmd5.ExecuteScalar()) + " (" + Convert.ToString(TextBox1.Text.ToUpper()) + "). Your Installment is Received on " + Convert.ToDateTime(TextBox2.Text).Day + "-" + Convert.ToDateTime(TextBox2.Text).Month + "-" + Convert.ToDateTime(TextBox2.Text).Year + ". Kindly visit www.TopLifeBusiness.com.";
                        string result = apicall("http://www.zewaa.biz/sms.aspx?SENDER=TOPLIF&MOBILE=" + mobile + "&MSG=" + msg);
                    }
                    Response.Redirect("Installment.aspx");
                }
            }

        }
        else if (adminid == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Receipt Not Found')", true);

        }
       
        con.Dispose();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        txtid.Value = TextBox1.Text;
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper().TrimStart().TrimEnd().Trim());
            cmd.Connection = con;
            Label2.Text = Convert.ToString(cmd.ExecuteScalar()) + " (" + TextBox1.Text.ToUpper().TrimStart().TrimEnd().Trim() + ")"; ;
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select father from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper().TrimStart().TrimEnd().Trim());
            cmd.Connection = con;
            Label2.Text = Label2.Text + " S/O " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select address from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper().TrimStart().TrimEnd().Trim());
            cmd.Connection = con;
            Label2.Text = Label2.Text + " , " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select mobile from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper().TrimStart().TrimEnd().Trim());
            cmd.Connection = con;
            Label2.Text = Label2.Text + " ( " + Convert.ToString(cmd.ExecuteScalar()) + ")";
        }
        con.Dispose();
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void detail()
    {
        DataTable dd = new DataTable();
        dd =objsql.GetTable("select * from tblreciptdetails where rend>='" + TextBox4.Text + "' and rstart<='"+TextBox4.Text+"'");
        if (dd.Rows.Count>0)
        {
            adminid = dd.Rows[0]["adminid"].ToString();
            bookid = dd.Rows[0]["billbook"].ToString();
        }
        
        
    }
}