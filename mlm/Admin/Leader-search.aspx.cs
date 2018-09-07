using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Leader_search : System.Web.UI.Page
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

        dt = objsql.GetTable("SELECT c.id,c.name,Member = (SELECT o.name FROM member_creation O WHERE O.id = s.memberid),s.memberid as memberid,c.mobile FROM member_creation C, tblcallstatus s where c.id = s.leaderid ");
        ListView1.DataSource = dt;
        ListView1.DataBind();
    }
}