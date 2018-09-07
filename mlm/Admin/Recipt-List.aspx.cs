using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Recipt_List : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public  string pendingbill = "",showpending="",start="",end="";
    public int R = 0, count = 0;
    public int Finaltotal = 0;
    public int countdata = 0,balance=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                start = Common.Get(objsql.GetSingleValue("select rstart from tblreciptdetails where billbook='" + Request.QueryString["id"] + "'"));
                end = Common.Get(objsql.GetSingleValue("select rend from tblreciptdetails where billbook='" + Request.QueryString["id"] + "'"));
                bind(Request.QueryString["id"].ToString());
                showpending = pending(Request.QueryString["id"].ToString());
                balance = Finaltotal - countdata;
            }

        }
    }
    protected void bind(string id)
    {
        //   dt = objsql.GetTable("select * from installment where bookid='" + id + "'");

        dt = objsql.GetTable("select i.id,i.sr,i.DATE_ENTRY,m.name,m.father,m.address,m.mobile from member_creation m , installment i where i.sr between '"+start+"' and '"+end+ "' and i.sno!='' and i.bookid!='' and i.id=m.id  order by sr asc");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField id = (HiddenField)e.Row.FindControl("hfid");
            Label total = (Label)e.Row.FindControl("lbltotal");
            Label price = (Label)e.Row.FindControl("lblprice");
            string date = Common.Get(objsql.GetSingleValue("select DATE_ENTRY from member_creation where id='" + id.Value + "'"));
            DateTime check = new DateTime();
            check = Convert.ToDateTime("2017-05-01");
            DateTime before = Convert.ToDateTime("2018-03-06");
            if (Convert.ToDateTime(date) < check)
            {
                total.Text = "1000";
                Finaltotal += Convert.ToInt32(total.Text);
            }
            else
            {
                total.Text = "1100";
                Finaltotal += Convert.ToInt32(total.Text);
            }
            if (Convert.ToDateTime(date) < before)
            {
                string count = Common.Get(objsql.GetSingleValue("select count(sr) from INSTALLMENT where id='" + id.Value + "'"));
                if (Convert.ToInt32(count) <= 6)
                {
                    price.Text = "50";
                    countdata += Convert.ToInt32(price.Text);
                }
                else
                {
                    price.Text = "0";
                    countdata += Convert.ToInt32(price.Text);
                }
            }
            else
            {
                string count = Common.Get(objsql.GetSingleValue("select count(sr) from INSTALLMENT where id='" + id.Value + "'"));
                if (Convert.ToInt32(count) >= 2 && Convert.ToInt32(count)<=6 )
                {
                    price.Text = "100";
                    countdata += Convert.ToInt32(price.Text);
                }
                else
                {
                    price.Text = "0";
                    countdata += Convert.ToInt32(price.Text);
                }
            }
        }
    }
    protected string pending(string id)
    {
        DataTable d1 = new DataTable();
        d1 =objsql.GetTable("select * from tblreciptdetails where billbook='" + id + "'");
        if (d1.Rows.Count > 0)
        {
            int end =Convert.ToInt32(d1.Rows[0]["rend"]);
            int start = Convert.ToInt32(d1.Rows[0]["Rstart"]);
            for(int i=start;i <= end;i++)
            {

                string check = Common.Get(objsql.GetSingleValue("select sr from installment where sr='" + i + "'"));
                if (check == "")
                {
                    chkp.Items.Add(i.ToString());
                   
                    if (i <= end)
                    {
                        if (i == end)
                        {
                            goto xx;
                        }
                        else
                        {
                            int inc = i + 1;
                            string check2 = Common.Get(objsql.GetSingleValue("select sr from installment where sr='" + inc + "'"));
                            if (check2 != "")
                            {
                                chkp.Items.FindByValue(i.ToString()).Enabled = false;
                            }
                        }
                    }
                  //  pendingbill += i + ",";
                }
            }
            return pendingbill;
        xx:;
        }
        return "";
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in chkp.Items)
        {
            if (item.Selected)
            {
                count += 1;
                
            }

        }
        string end = Common.Get(objsql.GetSingleValue("select rend from tblreciptdetails where billbook='" + Request.QueryString["id"] + "'"));
        if (end != "")
        {
            string pending = (Convert.ToInt32(end) - Convert.ToInt32(count)).ToString();
            objsql.ExecuteNonQuery("update tblreciptdetails set rend='" + pending + "' where billbook='" + Request.QueryString["id"] + "'");

        }
        bind(Request.QueryString["id"].ToString());
        Response.Redirect("recipt-list.aspx?id=" + Request.QueryString["id"]);
    }
}