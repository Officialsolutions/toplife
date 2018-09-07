using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SaleHistory : System.Web.UI.Page
{

    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind();
            }
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("  select p.name,o.Purchaseid,o.date,o.qty,p.mrp,p.bv,p.serial from tblproduct p , singleorder o where p.id=o.item and o.Purchaseid='" + Request.QueryString["id"] + "'");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
    }

    //protected void lnkedit_Click(object sender, EventArgs e)
    //{
    //    string id = (sender as LinkButton).CommandArgument;
    //    Response.Redirect("product.aspx?id=" + id);
    //}

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    string id = (sender as LinkButton).CommandArgument;
    //    objsql.ExecuteNonQuery("delete from tblproduct where id=" + id);
    //    bind();
    //}
}