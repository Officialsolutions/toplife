using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Leader : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public string imagename, img;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Convert.ToInt32(Request.QueryString["id"]));
            }
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblleader set name='" + txtname.Text + "',fathername='" + txtfname.Text + "',address='"+txtadd.Text+"',phone1='"+txtp1.Text+"',phone2='"+txtp2.Text+"',leaderid='"+txtleader.Text+"' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblleader(name,fathername,address,phone1,phone2,leaderid) values ('" + txtname.Text + "','" + txtfname.Text + "','"+txtadd.Text+"','"+txtp1.Text+"','"+txtp2.Text+"','"+txtleader.Text+"')");

        }
        Response.Redirect("view-leader.aspx");
    }
    protected void bind(int id)
    {
        DataTable dt1 = new DataTable();
        dt1 = objsql.GetTable("select * from tblleader where id='" + id + "'");
        if (dt1.Rows.Count > 0)
        {
            txtname.Text = dt1.Rows[0]["name"].ToString();
            txtfname.Text = dt1.Rows[0]["fathername"].ToString();
            txtadd.Text= dt1.Rows[0]["address"].ToString();
            txtp1.Text= dt1.Rows[0]["phone1"].ToString();
            txtp2.Text= dt1.Rows[0]["phone2"].ToString();
            txtleader.Text = dt1.Rows[0]["leaderid"].ToString();
        }
    }
}