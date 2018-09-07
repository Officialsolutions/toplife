using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_gallery : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["view"]!=null)
            {
                bind(Convert.ToInt32(Request.QueryString["view"]));
            }

            

        }
    }
    protected void bind(int id)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblgallery where code='"+id+"'");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }

    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        Response.Redirect("add-gallery.aspx?id=" + id);
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
      
        objsql.ExecuteNonQuery("delete from tblgallery where id='" + id + "'");
        bind(id);
    }

    

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-gallery.aspx?add="+Request.QueryString["view"]);
    }
}