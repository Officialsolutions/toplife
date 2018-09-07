using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from tblslider");
            if (dt.Rows.Count > 0)
            {
                lvslider.DataSource = dt;
                lvslider.DataBind();
            }
        }
    }
}