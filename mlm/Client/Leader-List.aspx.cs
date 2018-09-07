using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Leader_List : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string from = "", to = "", session = "";
    public static int lastyear;
    public int pres = 0, curnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  string a = Session["client"].ToString();
          
        previous();
            bind();
            foreach (GridViewRow gr in gvdata.Rows)
            {
                LinkButton delete = (LinkButton)gr.FindControl("lnkdelete");
                if (Session["admin"] != null)
                {
                    delete.Visible = true;
                }
                else
                {
                    delete.Visible = false;
                }

            }
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select c.id,m.name,m.father,m.mobile,m.mobile2,m.address,c.status,c.memberid,m.pname,m.pfather,m.paddress,m.rel  from member_creation m , tblcallstatus c where m.id=c.memberid and c.leaderid='" + Session["id"] + "' order by m.date_entry asc");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }
    }



    protected void gvdata_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvdata.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void gvdata_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvdata.EditIndex = -1;
        bind();
    }



    protected void gvdata_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //string userid = ((HiddenField)gvdata.Rows[e.RowIndex].FindControl("hfid")).Value;
        GridViewRow row = (GridViewRow)gvdata.Rows[e.RowIndex];
        HiddenField id = (HiddenField)row.FindControl("hfid");
        TextBox lblID = (TextBox)row.FindControl("txtst");
        objsql.ExecuteNonQuery("update tblcallstatus set status='" + lblID.Text + "' where id='" + id.Value + "'");
        gvdata.EditIndex = -1;
        bind();
    }



    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        objsql.ExecuteNonQuery("delete from tblcallstatus where id='" + id + "'");
        bind();
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Panel p1 = (Panel)e.Row.FindControl("pneng");
            Panel p2 = (Panel)e.Row.FindControl("pnp");
           
            Panel pnea = (Panel)e.Row.FindControl("pnea");
            Panel pnpa = (Panel)e.Row.FindControl("pnpa");
            HiddenField mid = (HiddenField)e.Row.FindControl("mid");
            Label ins = (Label)e.Row.FindControl("lblins");
            Label pre = (Label)e.Row.FindControl("lblpre");
            Label cur = (Label)e.Row.FindControl("lblcur");
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
     
            ins.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id='"+mid.Value+"' and paid='0'"));
            pre.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id='"+mid.Value+"' and Date_entry Between '" + from + "' And '" + to + "' and paid='0'"));
            cur.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id="+mid.Value+" and Date_entry > '" + to + "' and paid='0'"));
            curnt += Convert.ToInt32(cur.Text);
            pres += Convert.ToInt32(pre.Text);
            if (Convert.ToInt32(ins.Text) >= 8)
            {
                e.Row.BackColor = System.Drawing.Color.Yellow;

            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void ddlview_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }

    protected void previous()
    {
        //string month1 = "";
        //int month = System.DateTime.Now.Month;

        //month1 = (Convert.ToInt32(month) - Convert.ToInt32(1)).ToString();
        //if ( Convert.ToInt32(month1) < 9)
        //{
        //    month1 = "0" + month1.ToString();
        //  }
        int year = System.DateTime.Now.Year;
        string month1 = Common.Get(objsql.GetSingleValue("select top(1) Month from tbllead where session='" + year + "' order by month desc"));

            


        
        DataTable dm = new DataTable();
        dm = objsql.GetTable("select * from tbllead where month='" + month1 + "' and session='" + year + "'");
        if (dm.Rows.Count > 0)
        {
            from = dm.Rows[0]["fromdate"].ToString();
            to = dm.Rows[0]["todate"].ToString();
        }


    }

}