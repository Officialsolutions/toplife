using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_inventory : System.Web.UI.Page
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
        dt = objsql.GetTable("select * from inventoryproduct p Left Join inventorystock s ON p.code=s.code ");
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        Response.Redirect("add-inventry.aspx?id=" + id);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("inventory-stock.aspx?id=" + id);
    }


    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbldate = (Label)e.Row.FindControl("lbldate");
            if (lbldate.Text != null && lbldate.Text != "")
            {
                lbldate.Text = Convert.ToDateTime(lbldate.Text).ToString("dd/MM/yyyy");
            }
        }
    }
}