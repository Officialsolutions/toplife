using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddfreeIns : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    public string sponser = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
        txtdate1.Attributes.Add("readonly", "readonly");
        txtdate2.Attributes.Add("readonly", "readonly");
    }
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    public void BindGrid()
    {
        DataTable dtg = new DataTable();
        dtg = objsql.GetTable("select m.Id,m.name,m.spon,m.date_entry,e.name as Sponsname,e.date_entry as spondate,m.spon, (select count(*) from installment where id = m.id) as cnt from member_creation m Inner Join member_creation e On  m.id like '" + txtquery.Text + "%' and m.Date_entry Between   '" + txtdate1.Text + "' and '" + txtdate2.Text + "' and m.Spon = e.id order by cnt desc");
        if (dtg.Rows.Count > 0)
        {
            GridView1.DataSource = dtg;
            GridView1.DataBind();
        }
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        string id = (sender as LinkButton).CommandArgument;
        string dtym = "";
        //sponser = dr["id"].ToString();
        // xx:;
        // string spon = Common.Get(objsql.GetSingleValue("select spon from member_creation where id='" + sponser + "'"));
        int count = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + id + "'")));



        if (count >= 8)
        {
            DataTable dtn = new DataTable();
            dtn = objsql.GetTable("select top 8* from installment where id='" + id + "' Order By DATE_ENTRY  desc");

            dtym = dtn.Rows[7][1].ToString();
            string spon = Common.Get(objsql.GetSingleValue("select spon from member_creation where id='" + id + "'"));
            if (spon != "")
            {
                DataTable dtnew = new DataTable();
                dtnew = objsql.GetTable("select * from installment where id='" + spon + "' and sr='" + id + "'");
                if (dtnew.Rows.Count >= 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Free installment is already paid')", true);
                }
                else
                { 
                SqlCommand cmd23 = new SqlCommand();
                cmd23.CommandText = "insert into installment values(@SR,@DATE_ENTRY,@ID,(select isnull(max(sno),0)+1 from installment),@bookid,@adminid,@status,@paid)";
                cmd23.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = Convert.ToDateTime(dtym);
                cmd23.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(spon.ToUpper());
                cmd23.Parameters.Add("@SR", SqlDbType.VarChar).Value = Convert.ToString(id.ToUpper());
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
        BindGrid();

    }
}