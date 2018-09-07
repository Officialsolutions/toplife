using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin1_Settings : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            bind();
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
        }

    }
}