using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Book_Detail : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public string values = "";
    public int Finaltotal = 0,payment2=0,recive=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                lblname.Text = Common.Get(objsql.GetSingleValue("select name from member_creation where id='" + Request.QueryString["id"] + "'"));
                bind(Request.QueryString["id"].ToString());
               
            }

        }
    }
    protected void bind(string id)
    {
        dt = objsql.GetTable("select * from tblreciptdetails where adminid='" + id + "' and month='"+Request.QueryString["month"]+"' and year='"+Request.QueryString["year"]+"'");
        if(dt.Rows.Count>0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label start = (Label)e.Row.FindControl("lblstart");
            Label end = (Label)e.Row.FindControl("lblend");
            HiddenField id = (HiddenField)e.Row.FindControl("hfid");
            Label recived = (Label)e.Row.FindControl("lblrecived");
            Label pending = (Label)e.Row.FindControl("lblpending");
            Label total = (Label)e.Row.FindControl("lbltotal");
            Label payment = (Label)e.Row.FindControl("lbltpayment");
            values = id.Value;
            DataTable dt1 = new DataTable();
            recived.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where sr between '"+start.Text+"' and '"+end.Text+"' and sno!=''"));
            total.Text = ((Convert.ToInt32(end.Text) - Convert.ToInt32(start.Text))+1).ToString();
            pending.Text = (Convert.ToInt32(total.Text) - Convert.ToInt32(recived.Text)).ToString();
            recive += Convert.ToInt32(recived.Text);
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from installment where sr between '" + start.Text + "' and '" + end.Text + "' and sno!=''");
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string date = Common.Get(objsql.GetSingleValue("select DATE_ENTRY from member_creation where id='" + dr["id"] + "'"));
                    DateTime check = new DateTime();
                    check = Convert.ToDateTime("2017-05-01");
                    if (Convert.ToDateTime(date) < check)
                    {
                        payment.Text = "1000";
                        payment.Text = (Convert.ToInt32(recived.Text) * Convert.ToInt32(payment.Text)).ToString();
                       // payment2 += Convert.ToInt32(payment.Text);
                       // Finaltotal += Convert.ToInt32(payment.Text);
                    }
                    else
                    {
                        payment.Text = "1100";
                        payment.Text = (Convert.ToInt32(recived.Text) * Convert.ToInt32(payment.Text)).ToString();
                       // payment2 += Convert.ToInt32(payment.Text);
                       // Finaltotal += Convert.ToInt32(payment.Text);
                    }

                   
                }

            }
            Finaltotal += Convert.ToInt32(payment.Text);
        }       
    }

    protected void lbllist_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("recipt-list.aspx?id=" + id);
    }

    protected void lnktrans_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("transfer-book.aspx?id=" + id);
    }
    
}