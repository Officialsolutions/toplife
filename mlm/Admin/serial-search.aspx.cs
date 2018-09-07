using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_serial_search : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtsearch_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select ss.regno,ss.date,ss.Serial,ip.name,ip.image,m.NAME as mname,m.MOBILE from tblSingle ss Inner join inventoryproduct ip on ip.id=ss.item join MEMBER_CREATION m on m.ID=ss.regno and ss.Serial='" + txtsearch.Text + "'");
        if(dt.Rows.Count>0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This serial number Does not exist')", true);
        }
        txtsearch.Text = "";
    }
}