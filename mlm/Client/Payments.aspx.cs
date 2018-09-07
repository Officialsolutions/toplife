using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Client_Default2 : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"].ToString() == null)
        {
            Response.Redirect("../Client.aspx");
        }
        if (Page.IsPostBack == false)
        {
            BindInstall();
            BindProduct();
        }
    }
    public void BindInstall()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select row_number() over (order by sr) as SR,SR as 'Rec',DATE_ENTRY as DATE,ID,paid from installment where id='"+ Session["id"] + "' and paid='0' order by DATE_ENTRY";
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
    public void BindProduct()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblMaster where regno='" + Session["ID"].ToString() + "' ");
        if (dt.Rows.Count > 0)
        {
            //pnlproduct.Visible = true;
          
            DataTable dts = new DataTable();
            dts = objsql.GetTable("select p.name,p.mrp,p.bv,p.image,s.qty,s.date,s.purchaseid from tblproduct p Inner join tblSingle s on s.item = p.id and s.regno = '"+ Session["id"] + "'");
            GridView2.DataSource = dts;
            GridView2.DataBind();

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('')", true);
        }
    }
    protected void GridView2_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty = (Label)e.Row.FindControl("lblqty");
            Label lblmrp = (Label)e.Row.FindControl("lblmrp");
            Label lblbv = (Label)e.Row.FindControl("lblbv");
            Label total = (Label)e.Row.FindControl("total");
            Label bvtotal = (Label)e.Row.FindControl("bvtotal");
            total.Text = ((Convert.ToInt32(lblqty.Text)) * (Convert.ToInt32(lblmrp.Text))).ToString();
            bvtotal.Text = ((Convert.ToInt32(lblqty.Text)) * (Convert.ToInt32(lblbv.Text))).ToString();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName== "transfer")
        {
            Response.Redirect("transfer.aspx?sr="+e.CommandArgument);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblpaid = (Label)e.Row.FindControl("lblpaid");
            //if(lblpaid.Text=="1")
            //{

            //}
        }
    }
}
