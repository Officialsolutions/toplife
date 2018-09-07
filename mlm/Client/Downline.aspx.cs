using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Client_Default2 : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string from = "", to = "", session = "";
    public static int lastyear;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            previous();
            f1();
        }
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DOWNLINE";
        if (RadioButton1.Checked == true)
        {
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        }
        if (RadioButton2.Checked == true)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select id from member_creation where upleg=@ID1 and side='Left'";
            cmd1.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd1.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd1.ExecuteScalar());
        }
        if (RadioButton3.Checked == true)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select id from member_creation where upleg=@ID1 and side='Right'";
            cmd1.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd1.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd1.ExecuteScalar());
        }
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        f1();
    }

    protected void ddlview_SelectedIndexChanged(object sender, EventArgs e)
    {
        f1();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Panel p1 = (Panel)e.Row.FindControl("pneng");
            Panel p2 = (Panel)e.Row.FindControl("pnp");
            Panel p1p = (Panel)e.Row.FindControl("pnengp");
            Panel p2p = (Panel)e.Row.FindControl("pnpp");
            Panel pnea = (Panel)e.Row.FindControl("pnea");
            Panel pnpa = (Panel)e.Row.FindControl("pnpa");
            HiddenField mid = (HiddenField)e.Row.FindControl("hfid");
            Label ins = (Label)e.Row.FindControl("lblins");
            Label pre = (Label)e.Row.FindControl("lblpre");
            Label cur = (Label)e.Row.FindControl("lblcur");
            if (ddlview.SelectedItem.Text == "English")
            {
                p1.Visible = true;
                p1p.Visible = true;
                p2.Visible = false;
                p2p.Visible = false;
                pnea.Visible = true;
                pnpa.Visible = false;
            }
            else
            {
                p1.Visible = false;
                p1p.Visible = false;
                p2.Visible = true;
                p2p.Visible = true;
                pnea.Visible = false;
                pnpa.Visible = true;
            }
  
            ins.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + mid.Value + "' and paid='0'"));
            pre.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id='" + mid.Value + "' and Date_entry Between '" + from + "' And '" + to + "' and paid='0'"));
            cur.Text = Common.Get(objsql.GetSingleValue("select count(*) from installment where id=" + mid.Value + " and Date_entry > '" + to + "' and paid='0'"));

            if (Convert.ToInt32(ins.Text) >= 8)
            {
                string test = Common.Get(objsql.GetSingleValue("select regno from tblmaster where regno='" + mid.Value + "'"));
                if (test != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }

            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }


        }
    }

    protected void ddlview_SelectedIndexChanged1(object sender, EventArgs e)
    {
        f1();
    }
    protected void previous()
    {
        //string month1 = "";
        //int month = System.DateTime.Now.Month;

        //month1 = (Convert.ToInt32(month) - Convert.ToInt32(1)).ToString();
        //if ( Convert.ToInt32(month1) < 9)
        //{
        //    month1 = "0" + month1.ToString();
        //  }
        int year = System.DateTime.Now.Year;
        string month1 = Common.Get(objsql.GetSingleValue("select top(1) Month from tbllead where session='" + year + "' order by month desc"));





        DataTable dm = new DataTable();
        dm = objsql.GetTable("select * from tbllead where month='" + month1 + "' and session='" + year + "'");
        if (dm.Rows.Count > 0)
        {
            from = dm.Rows[0]["fromdate"].ToString();
            to = dm.Rows[0]["todate"].ToString();
        }


    }
}
