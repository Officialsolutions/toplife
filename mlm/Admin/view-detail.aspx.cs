using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_detail : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  string a = Session["client"].ToString();
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select c.id,m.name,m.father,m.mobile,c.status  from member_creation m , tblcallstatus c where m.id=c.memberid ");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        objsql.ExecuteNonQuery("delete from tblcallstatus where id='" + id + "'");
        bind();
    }
}