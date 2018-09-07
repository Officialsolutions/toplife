using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    public string sponser = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            check();
        }
        

    }
    protected void bind()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        dt = objsql.GetTable("select distinct id from installment");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                sponser = dr["id"].ToString();

                xx:;

                int count = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + sponser + "'")));
                if (count >= 8)
                {
                    string status = Common.Get(objsql.GetSingleValue("select id from installment where id='" + sponser + "' and status !='free'"));
                    if (status != "Free")
                    {
                        string spon = Common.Get(objsql.GetSingleValue("select spon from member_creation where id='" + sponser + "'"));
                        if (spon != "")
                        {
                            SqlCommand cmd23 = new SqlCommand();
                            cmd23.CommandText = "insert into installment values(@SR,@DATE_ENTRY,@ID,(select isnull(max(sno),0)+1 from installment),@bookid,@adminid,@status,@paid)";
                            cmd23.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd23.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(spon.ToUpper());
                            cmd23.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(sponser);
                            cmd23.Parameters.Add("@bookid", SqlDbType.VarChar).Value = "";
                            cmd23.Parameters.Add("@adminid", SqlDbType.VarChar).Value = "";
                            cmd23.Parameters.Add("@status", SqlDbType.VarChar).Value = "Free";
                            cmd23.Parameters.Add("@paid", SqlDbType.VarChar).Value = "0";
                            cmd23.Connection = con;
                            cmd23.ExecuteNonQuery();
                            sponser = spon;
                            goto xx;
                        }
                    }

                }
            }
        }
    }
    protected void check()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from member_creation where id like '1611%' and Date_entry Between '2016-11-01' and '2017-01-12'");
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                string dtym = "";
                sponser = dr["id"].ToString();
               // xx:;
               // string spon = Common.Get(objsql.GetSingleValue("select spon from member_creation where id='" + sponser + "'"));
                int count = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + sponser + "'")));

              

                if (count >= 8)
                {
                    DataTable dtn = new DataTable();
                    dtn = objsql.GetTable("select top 8* from installment where id='" + sponser + "' Order By DATE_ENTRY  desc");
        
                    dtym = dtn.Rows[7][1].ToString();
                    string spon = Common.Get(objsql.GetSingleValue("select spon from member_creation where id='" + sponser + "'"));
                    if (spon != "")
                    {
                        SqlCommand cmd23 = new SqlCommand();
                        cmd23.CommandText = "insert into installment values(@SR,@DATE_ENTRY,@ID,(select isnull(max(sno),0)+1 from installment),@bookid,@adminid,@status,@paid)";
                        cmd23.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = Convert.ToDateTime(dtym);
                        cmd23.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(spon.ToUpper());
                        cmd23.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(sponser.ToUpper());
                        cmd23.Parameters.Add("@bookid", SqlDbType.VarChar).Value = "";
                        cmd23.Parameters.Add("@adminid", SqlDbType.VarChar).Value = "";
                        cmd23.Parameters.Add("@status", SqlDbType.VarChar).Value = "Free";
                        cmd23.Parameters.Add("@paid", SqlDbType.VarChar).Value = "0";
                        cmd23.Connection = con;
                        cmd23.ExecuteNonQuery();
                       // sponser = spon;
                      //  goto xx;
                    }
                }   
            }
        }
    }
}