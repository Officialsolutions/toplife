using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Setting : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime dd = System.DateTime.Now;
            string year = dd.Year.ToString();
            ddlsession.Items.FindByText(year).Selected = true;
            bind();
            check();

        }
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Manual")
        {
            txtdate.Enabled = true;
        }
        else
        {
            txtdate.Enabled = false;
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update tblsetting set loginid='" + txtserial.Text + "',type='" + ddltype.SelectedItem.Text + "',date='" + txtdate.Text + "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblsetting");
        if (dt.Rows.Count > 0)
        {
            txtdate.Text = dt.Rows[0]["date"].ToString();
            txtserial.Text = dt.Rows[0]["loginid"].ToString();
            string dd = dt.Rows[0]["type"].ToString();
            ddltype.Items.FindByText(dd).Selected = true;
            txtfrom.Text = dt.Rows[0]["fromdate"].ToString();
            txtto.Text = dt.Rows[0]["todate"].ToString();
        }

    }

    protected void btndate_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update tblsetting set fromdate='" + txtfrom.Text+ "',todate='" +txtto.Text+ "'");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
    }

    protected void btnleads_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("insert into tbllead (fromdate,todate,session,month) values ('" + txtlfrom.Text + "','" + txtlto.Text + "','" + ddlsession.SelectedItem.Text + "','" + rdochk.SelectedItem.Value + "')");
    }
    protected void check()
    {
        DataTable dc = new DataTable();
        dc = objsql.GetTable("select * from tbllead where session='" + ddlsession.SelectedItem.Text + "' order by month");
        if (dc.Rows.Count > 0)
        {
            foreach (DataRow dr in dc.Rows)
            {
                string val = dr["month"].ToString();
                string a = rdochk.Items.FindByValue(val).Value;


                if (val == a)
                {
                    rdochk.Items.FindByValue(val).Enabled = false;
                }
            }
            gvdata.DataSource = dc;
            gvdata.DataBind();
        }
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        objsql.ExecuteNonQuery("delete from tbllead where id='" + id + "'");
        check();
    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        edit(id);
        btnleads.Visible = false;

    }
    protected void edit(int id)
    {
        DataTable ds = new DataTable();
        ds = objsql.GetTable("select * from tbllead where id='" + id + "'");
        if (ds.Rows.Count > 0)
        {
            txtlfrom.Text = ds.Rows[0]["fromdate"].ToString();
            txtlto.Text = ds.Rows[0]["todate"].ToString();
            string val= ds.Rows[0]["month"].ToString();
            rdochk.Items.FindByValue(val).Selected = true;


        }

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

    }

    protected void ddlsession_SelectedIndexChanged(object sender, EventArgs e)
    {
        check();
    }
}