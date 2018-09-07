using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Client_punjdirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Tree(Convert.ToString(Session["id"]));
        }
    }
    public void Tree(string Sr)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select row_number() over (order by date_entry) as 'S.No',ID as 'UserId',convert(varchar,Date_entry,106) as 'DOJ',NAME ,Rel,father,MOBILE as 'Mobile No.',MOBILE2,ADDRESS,paddress,pname,pfather,pcity,(select count(*) from installment where id=m.id) as INS,(select count(*) from installment where id=m.id and month(date_entry)=month(dateadd(mm,-1,getdate()))) as PREV,(select count(*) from installment where id=m.id and month(date_entry)=month(getdate())) as CUR from member_creation m where spon=@ID order by date_entry";
            //  cmd.CommandText = "select row_number() over (order by date_entry) as 'S.No',ID as 'UserId',convert(varchar,Date_entry,106) as 'DOJ',NAME + ' ' + isnull(rel,'') + ' ' + father as NAME,MOBILE as 'Mobile No.',MOBILE2,ADDRESS,(select count(*) from installment where id=m.id) as INS,(select count(*) from installment where id=m.id and month(date_entry)=month(dateadd(mm,-1,getdate()))) as PREV,(select count(*) from installment where id=m.id and month(date_entry)=month(getdate())) as CUR from member_creation m where spon=@ID order by date_entry";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        con.Dispose();
    }
}