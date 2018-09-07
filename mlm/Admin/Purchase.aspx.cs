using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Purchase : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public DataTable MyDT = new DataTable();
    DataRow MyRow;
    string constring = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    int id = 0, total = 0,qty2=0,bvpr=0;
    public static string invoice = "",check="", code="", qnnty="0";
    public static int cnt = 0;
    Common cm = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (cnt == 0)
            {
                Session["DataTable"] = "";
                invoice = cm.Generatepass();
            }
            else
            {

            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        code = Common.Get(objsql.GetSingleValue("select code from tblproduct where name='" + txtname.Text + "'"));
        if (code == "")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please enter valid Product');", true);
            txtname.Text = "";
            txtqty.Text = "";
        }
        else
        {
            check = Common.Get(objsql.GetSingleValue("select stock from tblstock where code='" + code + "'"));
            if (cnt != 0)
            {
                DataTable MyTABLE = new DataTable();
                MyTABLE = (DataTable)Session["DataTable"];

                foreach (DataRow dtrow in MyTABLE.Rows)
                {
                    if (code == dtrow["Code"].ToString())
                    {
                        qnnty = ((Convert.ToInt32(dtrow["Quantity"].ToString())) + (Convert.ToInt32(txtqty.Text))).ToString();
                    }
                }
            }
            else
            {
                qnnty = txtqty.Text;
            }
            if (Convert.ToInt32(check) < Convert.ToInt32(txtqty.Text))
            {
                txtqty.Text = "";
                qnnty = "0";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + check + " stock is left')", true);
            }
            else
            {
                //if (Convert.ToInt32(check) >= Convert.ToInt32(txtqty.Text))
                //{
                //if (Session["DataTable"].ToString() == "")
                //{
                if (cnt == 0)
                {
                    MyDT.Columns.Add("id", System.Type.GetType("System.Int32"));

                    MyDT.Columns.Add("Name");

                    MyDT.Columns.Add("Quantity");
                    MyDT.Columns.Add("Price");
                    MyDT.Columns.Add("BV");
                    MyDT.Columns.Add("Total");
                    MyDT.Columns.Add("BVTotal");
                    MyDT.Columns.Add("pid");
                    MyDT.Columns.Add("Code");
                    MyDT.Columns.Add("Serial");
                    MyDT.Columns.Add();

                    MyRow = MyDT.NewRow();

                    MyRow[0] = MyDT.Rows.Count + 1;

                    MyRow[1] = txtname.Text;

                    MyRow[2] = txtqty.Text;
                    MyRow[3] = Common.Get(objsql.GetSingleValue("select mrp from tblproduct where name='" + txtname.Text + "'"));
                    MyRow[4] = Common.Get(objsql.GetSingleValue("select bv from tblproduct where name='" + txtname.Text + "'"));
                    MyRow[5] = (Convert.ToInt32(MyRow[3]) * Convert.ToInt32(MyRow[2]));
                    MyRow[6] = (Convert.ToInt32(MyRow[4]) * Convert.ToInt32(MyRow[2]));
                    MyRow[7] = Common.Get(objsql.GetSingleValue("select id from tblproduct where name='" + txtname.Text + "'"));
                    MyRow[8] = Common.Get(objsql.GetSingleValue("select code from tblproduct where name='" + txtname.Text + "'"));
                    MyRow[9] = Common.Get(objsql.GetSingleValue("select serial from tblproduct where name='" + txtname.Text + "'"));
                    MyDT.Rows.Add(MyRow);


                    Session["DataTable"] = MyDT;

                    cnt += 1;
                }
                else
                {
                    MyDT = (DataTable)Session["DataTable"];
                    string pccode = null;
                    foreach (DataRow dtr in MyDT.Rows)
                    {
                        if (code == dtr["Code"].ToString())
                        {
                            pccode = "already";
                            int qt = (Convert.ToInt32(MyDT.Rows[0][2].ToString()) + Convert.ToInt32(txtqty.Text));

                            DataRow dr = dtr;
                            dr["Quantity"] = qt.ToString();
                            dr["Price"] = Common.Get(objsql.GetSingleValue("select mrp from tblproduct where code='" + code + "'"));
                            dr["BV"] = Common.Get(objsql.GetSingleValue("select bv from tblproduct where code='" + code + "'"));
                            dr["Total"] = (Convert.ToInt32(dr["Price"].ToString()) * Convert.ToInt32(qt));
                            dr["BVTotal"] = (Convert.ToInt32(dr["BV"].ToString()) * Convert.ToInt32(qt));
                            MyDT.AcceptChanges();
                        }
                    }

                    if (pccode != null)
                    {


                    }
                    else
                    {
                       // MyDT = (DataTable)Session["DataTable"];
                        MyRow = MyDT.NewRow();

                        MyRow[0] = MyDT.Rows.Count + 1;

                        MyRow[1] = txtname.Text;

                        MyRow[2] = txtqty.Text;
                        MyRow[3] = Common.Get(objsql.GetSingleValue("select mrp from tblproduct where name='" + txtname.Text + "'"));
                        MyRow[4] = Common.Get(objsql.GetSingleValue("select bv from tblproduct where name='" + txtname.Text + "'"));
                        MyRow[5] = (Convert.ToInt32(MyRow[3]) * Convert.ToInt32(MyRow[2]));
                        MyRow[6] = (Convert.ToInt32(MyRow[4]) * Convert.ToInt32(MyRow[2]));
                        MyRow[7] = Common.Get(objsql.GetSingleValue("select id from tblproduct where name='" + txtname.Text + "'"));
                        MyRow[8] = code;
                        MyRow[9] = Common.Get(objsql.GetSingleValue("select serial from tblproduct where name='" + txtname.Text + "'"));
                        MyDT.Rows.Add(MyRow);
                    }

                    Session["DataTable"] = MyDT;
                }


                GridView1.DataSource = MyDT;
                GridView1.DataBind();
                btnsubmit.Visible = true;
                bindtotal();
                Button1.Visible = true;
                txtname.Text = "";
                txtqty.Text = "";
                qnnty = "0";
                //}
            }
        }
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only "+check+" stock is left')", true);
        //}
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["cn"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select name from tblproduct where " +
                "name like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
    protected void bindtotal()
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label tot = (Label)gr.FindControl("total");
            total += Convert.ToInt32(tot.Text);
            lbltotal.Text = total.ToString();

            Label bvtot = (Label)gr.FindControl("bvtotal");
            bvpr+= Convert.ToInt32(bvtot.Text);
            lblbvtotal.Text = bvpr.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
            objsql.ExecuteNonQuery("insert into tblmasterorder(purchaseid,regno,amount,status) values('" + invoice + "','" + txtregno.Text + "','" + lbltotal.Text + "','1')");

            foreach (GridViewRow gr in GridView1.Rows)
            {
                HiddenField item = (HiddenField)gr.FindControl("hfid");
                HiddenField qty = (HiddenField)gr.FindControl("qty");

                objsql.ExecuteNonQuery("insert into singleorder(purchaseid,date,regno,item,qty) values('" + invoice + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "','" +txtregno.Text + "','" + item.Value + "','" + qty.Value + "')");
            
                  string stock = Common.Get(objsql.GetSingleValue("select stock from tblstock where code ='" + code + "'"));
                  string dedqty = ((Convert.ToInt32(stock)) - (Convert.ToInt32(qty.Value))).ToString();
                  objsql.ExecuteNonQuery("update tblstock set stock='" + dedqty + "' where code ='" + code + "'");

            }
            DataTable dtr = new DataTable();
            dtr = objsql.GetTable("select bv,self,side,upleg from member_creation where id='" + txtregno.Text + "'");
            string bv= dtr.Rows[0]["bv"].ToString();
            string self = dtr.Rows[0]["self"].ToString();
            string side= dtr.Rows[0]["side"].ToString();
            string upleg = dtr.Rows[0]["upleg"].ToString();
            int selftotal = (Convert.ToInt32(self) + Convert.ToInt32(lblbvtotal.Text));
            objsql.ExecuteNonQuery("update member_creation set self='" + selftotal.ToString() + "' where id='" + txtregno.Text + "'");
            using (SqlConnection con = new SqlConnection(constring))
            {

                using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtregno.Text);           // sponser id
                    cmd.Parameters.AddWithValue("@node", side);                            // node
                    cmd.Parameters.AddWithValue("@checkid", txtregno.Text);
                    cmd.Parameters.AddWithValue("@bvp", lblbvtotal.Text);
                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
        cnt = 0;
        Session["success"] = "true";
        Response.Redirect("managesale.aspx");

    }

    protected void txtregno_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select name from member_creation where id='" + txtregno.Text + "'"));
        if (lblname.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please enter valid ID');", true);
            txtregno.Text = "";
        }
        else
        {
            cnt = 0;
        }
    }
}