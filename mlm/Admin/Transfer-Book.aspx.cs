using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Transfer_Book : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void txtname_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select name from member_Creation where id='" + txtname.Text + "'"));
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (lblname.Text != null)
        {
            objsql.ExecuteNonQuery("update tblreciptdetails set adminid='" + txtname.Text + "',month='"+ddlmonth.SelectedItem.Text+"',year='"+yearfilter.SelectedItem.Text+"' where billbook='" + Request.QueryString["id"] + "'");
            objsql.ExecuteNonQuery("update installment set adminid='" + txtname.Text + "' where bookid='" + Request.QueryString["id"] + "'");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
        }
    }
}