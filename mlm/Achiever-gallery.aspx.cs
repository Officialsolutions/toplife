using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Achiever_gallery : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            name = Common.Get(objsql.GetSingleValue("select name from tblalbum where id='" + Request.QueryString["id"] + "'"));
            DataTable dt = new DataTable();
            dt = objsql.GetTable("select * from tblgallery where code='"+Request.QueryString["id"]+"'");
            if (dt.Rows.Count > 0)
            {
                lvgallery.DataSource = dt;
                lvgallery.DataBind();
            }
        }
    }
}