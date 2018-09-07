using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_All_Memeber_List : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from MEMBER_CREATION");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem gr in ListView1.Items)
        {
            HiddenField hid = (HiddenField)gr.FindControl("hfid");
            TextBox lid = (TextBox)gr.FindControl("txtid");
            if (lid.Text != "")
            {
                objsql.ExecuteNonQuery("insert into tblcallstatus(leaderid,month,year,memberid,status) values('" + lid.Text + "','" + ddlmonth.SelectedItem.Text + "','" + ddlyear.SelectedItem.Text + "','" + hid.Value + "','Pending')");
            }
        }

        bind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            HiddenField hid = (HiddenField)e.Item.FindControl("hfid");
            string val = Common.Get(objsql.GetSingleValue("select id from tblcallstatus where memberid='" + hid.Value + "'"));
            if (val != "")
            {
                e.Item.Visible = false;
            }
        }
    }
}