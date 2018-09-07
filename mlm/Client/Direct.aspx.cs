using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Client_Default2 : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string from = "", to = "", session = "";
    public static int lastyear;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Tree(Convert.ToString(Session["id"]));
        }
    }
    public void Tree(string Sr)
    {
        previous();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            // corrwect   cmd.CommandText = "select row_number() over (order by date_entry) as 'S.No',ID as 'UserId',convert(varchar,Date_entry,106) as 'DOJ',NAME ,Rel,father,MOBILE as 'Mobile No.',MOBILE2,ADDRESS,paddress,pname,pfather,pcity,(select count(*) from installment where id=m.id) as INS,(select count(*) from installment where id=m.id and month(date_entry)=month(dateadd(mm,-1,getdate()))) as PREV,(select count(*) from installment where id=m.id and month(date_entry)=month(getdate())) as CUR from member_creation m where spon=@ID order by date_entry";
            //  cmd.CommandText = "select row_number() over (order by date_entry) as 'S.No',ID as 'UserId',convert(varchar,Date_entry,106) as 'DOJ',NAME + ' ' + isnull(rel,'') + ' ' + father as NAME,MOBILE as 'Mobile No.',MOBILE2,ADDRESS,(select count(*) from installment where id=m.id) as INS,(select count(*) from installment where id=m.id and month(date_entry)=month(dateadd(mm,-1,getdate()))) as PREV,(select count(*) from installment where id=m.id and month(date_entry)=month(getdate())) as CUR from member_creation m where spon=@ID order by date_entry";
            cmd.CommandText = "select row_number() over (order by date_entry) as 'S.No',ID as 'UserId',convert(varchar,Date_entry,106) as 'DOJ',NAME ,Rel,father,MOBILE as 'Mobile No.',MOBILE2,ADDRESS,paddress,pname,pfather,pcity,(select count(*) from installment where id=m.id and paid='0') as INS,(select count(*) from installment where id=m.id and Date_entry Between '" + from+"' And '"+to+ "' and paid='0' ) as PREV,(select count(*) from installment where id=m.id and Date_entry > '" + to+ "' and paid='0') as CUR from member_creation m where spon=@ID order by date_entry";

            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        con.Dispose();
    }
    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        string ID = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Tree(ID);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Panel p1 = (Panel)e.Row.FindControl("pneng");
            Panel p2 = (Panel)e.Row.FindControl("pnp");
            Panel pnea = (Panel)e.Row.FindControl("pnea"); // eng
            Panel pnpa = (Panel)e.Row.FindControl("pnpa"); // pun
            HiddenField reg = (HiddenField)e.Row.FindControl("hfreg");
            HiddenField ins = (HiddenField)e.Row.FindControl("hfin");
            if (Convert.ToInt32(ins.Value) >= 8)
            {
                string test = Common.Get(objsql.GetSingleValue("select regno from tblmaster where regno='" + reg.Value + "'"));
                if (test != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }

            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (ddlview.SelectedItem.Text == "English")
            {
                p1.Visible = true;

                p2.Visible = false;
                pnea.Visible = true;
                pnpa.Visible = false;
            }
            else
            {
                p1.Visible = false;
                p2.Visible = true;
                pnea.Visible = false;
                pnpa.Visible = true;
            }
        }
    }

    
    protected void ddlview_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Tree(Convert.ToString(Session["id"]));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location='punjdirect.aspx','_blank';</script>");
    }
    protected void previous()
    {
        int month = System.DateTime.Now.Month;
        if(month==1)
        {
            month = 12;
            int year = System.DateTime.Now.Year;
            lastyear = year - 1;
            
            
        }
        DataTable dm = new DataTable();
        dm = objsql.GetTable("select * from tbllead where month='" + month + "' and session='"+lastyear+"'");
        if (dm.Rows.Count > 0)
        {
            from = dm.Rows[0]["fromdate"].ToString();
            to = dm.Rows[0]["todate"].ToString();
        }


    }
}
