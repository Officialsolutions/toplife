using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Client_transfer : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
 //   Session["ID"].ToString()
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (lblname.Text == "")
        {

        }
        else
        {
            objsql.ExecuteNonQuery("update INSTALLMENT set id='" + txtto.Text + "' where id='" + Session["ID"].ToString() + "' and sr='" + Request.QueryString["sr"] + "'");
            objsql.ExecuteNonQuery("insert into tbltransfer(tfrom,tto,date,status,reason)values('" + Session["ID"].ToString() + "','" + txtto.Text + "','" + System.DateTime.Now + "','1','" + txtreason.Text + "')");
            Response.Redirect("transfer-report.aspx");
        }
    }

    protected void txtto_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from MEMBER_CREATION where id='" + txtto.Text + "'");
        if(dt.Rows.Count>0)
        {
            lblname.Text = dt.Rows[0]["name"].ToString();
        }
    }
}