using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Leader_Punj : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string from = "", to = "", session = "";
    public static int lastyear;
    public int pres = 0, curnt= 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        dt = objsql.GetTable("select c.id,m.name,m.father,m.mobile,m.mobile2,m.address,c.status,c.memberid,m.pname,m.pfather,m.paddress,m.rel  from member_creation m , tblcallstatus c where m.id=c.memberid and c.leaderid='" + Session["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        previous();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField mid = (HiddenField)e.Row.FindControl("mid");
            Label ins = (Label)e.Row.FindControl("lblins");
            Label pre = (Label)e.Row.FindControl("lblpre");
            Label cur = (Label)e.Row.FindControl("lblcur");

            ins.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + mid.Value + "'"));
            pre.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + mid.Value + "' and Date_entry Between '" + from + "' And '" + to + "'"));
            cur.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id=" + mid.Value + " and Date_entry > '" + to + "'"));
            curnt += Convert.ToInt32(cur.Text);
            pres += Convert.ToInt32(pre.Text);

        }
    }
    protected void previous()
    {
        string month1 = "";
        int month = System.DateTime.Now.Month;

        month1 = (Convert.ToInt32(month) - Convert.ToInt32(1)).ToString();
        if (Convert.ToInt32(month1) < 9)
        {
            month1 = "0" + month1.ToString();
        }
        int year = System.DateTime.Now.Year;

        DataTable dm = new DataTable();
        dm = objsql.GetTable("select * from tbllead where month='" + month1 + "' and session='" + year + "'");
        if (dm.Rows.Count > 0)
        {
            from = dm.Rows[0]["fromdate"].ToString();
            to = dm.Rows[0]["todate"].ToString();
        }


    }
}
