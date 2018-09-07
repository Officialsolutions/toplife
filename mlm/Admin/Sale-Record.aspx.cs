using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Sale_Record : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if(Session["success"]=="true")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Success');", true);
            }
            else
            {

            }
            bind();
        }
        //else
        //{
        //    if (Request.QueryString["Success"] == "true")
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Success');", true);
        //        // Response.Redirect("Sale-Record.aspx");
        //    }
        //}
       
    }
    protected void bind()
    {
        dt = objsql.GetTable("select mast.purchaseid,mast.regno,mast.amount,m.NAME,m.FATHER,m.ADDRESS,m.MOBILE,s.date from tblMaster mast join MEMBER_CREATION m on m.ID=mast.regno join tblSingle s on s.purchaseid=mast.purchaseid");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }
        Session["success"] = "false";
    }

    protected void lnkedit_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("History-Record.aspx?id=" + id);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        objsql.ExecuteNonQuery("delete from tblMaster where purchaseid=" + id);

        objsql.ExecuteNonQuery("update INSTALLMENT set paid='0',purchaseid='' where purchaseid=" + id);
        DataTable dtm = new DataTable();
        dtm= objsql.GetTable("select * from tblSingle where purchaseid=" + id);

        foreach (DataRow dtr in dtm.Rows)
        {
            string code = Common.Get(objsql.GetSingleValue("select code from inventoryproduct where id ='" + dtr["item"] + "'"));
            string stock = Common.Get(objsql.GetSingleValue("select stock from inventorystock where code ='" + code + "'"));
            string dedqty = ((Convert.ToInt32(stock)) + (Convert.ToInt32(dtr["qty"]))).ToString();
            objsql.ExecuteNonQuery("update inventorystock set stock='" + dedqty + "' where code ='" + code + "'");
        }
       
        objsql.ExecuteNonQuery("delete from tblSingle where purchaseid=" + id);
        bind();
    }


}