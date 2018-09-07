using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Receipt : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            data(",","");
            if (Request.QueryString["id"] != null)
            {

                bind();
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string montlyid = Common.Get(objsql.GetSingleValue("select id from tbllead where month='" + rdochk.SelectedItem.Value + "' and session='" + ddlsession.SelectedItem.Text + "'"));

        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblreciptdetails set date='" + txtdate.Text + "',rstart='" + txtstart.Text + "',rend='" + txtend.Text + "',adminid='" + txtname.Text + "',month='"+rdochk.SelectedItem.Text+"' , year='"+ddlsession.SelectedItem.Text+"' where id='" + Request.QueryString["id"] + "'");
            Response.Redirect("receipt.aspx");
        }
        else
        {
            string check = Common.Get(objsql.GetSingleValue("select * from tblreciptdetails where rstart<='"+txtstart.Text+"' and rend>='"+txtend.Text+"'"));
            if (check == "")
            {
                string bid = Guid.NewGuid().ToString().Substring(0, 4);
                objsql.ExecuteNonQuery("insert into tblreciptdetails(date,rstart,rend,adminid,billbook,month,year) values('" + txtdate.Text + "','" + txtstart.Text + "','" + txtend.Text + "','" + txtname.Text + "','" + bid + "','" + rdochk.SelectedItem.Text + "','"+ddlsession.SelectedItem.Text+"')");
                Response.Redirect("receipt.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry Already Exist')", true);
            }
        }
       

    }

    protected void txtname_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select name from member_creation where id='" + txtname.Text + "'"));
    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblreciptdetails where id='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            txtdate.Text = dt.Rows[0]["date"].ToString();
            txtend.Text = dt.Rows[0]["rend"].ToString();
            txtname.Text = dt.Rows[0]["adminid"].ToString();
            txtstart.Text = dt.Rows[0]["rstart"].ToString();
           

        }
    }
    protected void data(string month,string year)
    {
        DataTable dt2 = new DataTable();
        if (month == "" && year=="")
        {
            dt2 = objsql.GetTable("select DISTINCT m.name,r.adminid from member_creation m , tblreciptdetails r where r.adminid=m.id");
        }
        else
        {
            dt2 = objsql.GetTable("select DISTINCT m.name,r.adminid from member_creation m , tblreciptdetails r where r.adminid=m.id and r.month='"+month+"' and r.year='"+year+"'");
        }
        
        
        if (dt2.Rows.Count > 0)
        {
            GridView1.DataSource = dt2;
            GridView1.DataBind();
        }
    }

    protected void lnkcheck_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        Response.Redirect("book-detail.aspx?id=" + id + "&month=" + ddlmonth.SelectedItem.Text + "&year=" + yearfilter.SelectedItem.Text);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        Response.Redirect("Receipt.aspx?id=" + id);
    }

    protected void btnfilter_Click(object sender, EventArgs e)
    {
       // string sessionid = Common.Get(objsql.GetSingleValue("select id from tbllead where month='" + ddlmonth.SelectedItem.Value + "' and session='" + yearfilter.SelectedItem.Text + "'"));
        data(ddlmonth.SelectedItem.Text,yearfilter.SelectedItem.Text);
        Panel1.Visible = true;
        Panel2.Visible = false;
        
    }

    protected void txtrecp_TextChanged(object sender, EventArgs e)
    {
        if(txtrecp.Text!="")
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            BindSearch();
        }
    }
    public void BindSearch()
    {
        string bookno = Common.Get(objsql.GetSingleValue("select bookid from INSTALLMENT where sr ='"+ txtrecp.Text+"'"));

       DataTable dts = new DataTable();
        dts = objsql.GetTable("select ins.adminid,ins.ID,ins.DATE_ENTRY,ins.status,(select name from MEMBER_CREATION where ins.adminid=ID) as adminname,mm.NAME from INSTALLMENT ins join MEMBER_CREATION mm on mm.ID=ins.ID and ins.bookid='"+ bookno + "' and ins.SR='"+ txtrecp.Text + "'");
        if(dts.Rows.Count>0)
        {
            GridView2.DataSource = dts;
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = dts;
            GridView2.DataBind();
        }
    }
}