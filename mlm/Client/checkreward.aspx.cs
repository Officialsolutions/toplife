using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_checkreward : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int cl = 0, cr = 0, Cl = 0, Cr = 0, Activeid = 0, se = 0, ActiveidL = 0, c = 0, leftthismont = 0, thismonthinst = 0, thismonthinstleft=0;
    public string left, right;
    public string totalinst = "0", getid = "0", count, aco, sub = "", last = "";
    public string[] arr = new string[200];
    public static string from, to, thismonthlogid,id="";
    public DataTable dt3 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            genratetable();
            date();
            bind();
            se = Convert.ToInt32(id);
            // Tree(Convert.ToString(Session["id"]));
            check(id);


            //     ActiveidL = ActiveidL - 1;


            if (Activeid < ActiveidL)
            {
                aco = Activeid.ToString();
            }
            else
            {
                aco = ActiveidL.ToString();
            }

        }
    }
    protected void date()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblsetting");
        if (dt.Rows.Count > 0)
        {

            from = dt.Rows[0]["fromdate"].ToString();
            to = dt.Rows[0]["todate"].ToString();
        }

    }

    protected void check(string id)
    {
        DataTable dtt = new DataTable();
        dtt = objsql.GetTable("select * from member_creation where upleg='" + id + "' and Side='Left'");
        if (dtt.Rows.Count > 0)
        {
            foreach (DataRow dd in dtt.Rows)
            {
                string side = dd["side"].ToString();
                if (side == "Left")
                {
                    cl += 1;
                    string id2 = dd["id"].ToString();

                    DataTable d1 = new DataTable();
                    xx:;
                    d1 = objsql.GetTable("select * from member_creation where upleg='" + id2 + "'");
                    if (d1.Rows.Count > 0)
                    {
                        string count = objsql.GetSingleValue("select count(id) from member_creation where upleg='" + id2 + "'").ToString();

                        cl += Convert.ToInt32(count);

                        // if count >2



                        // left = objsql.GetSingleValue("select id from member_creation where upleg='" + id2 + "' and Side='Left'").ToString();
                        // right = objsql.GetSingleValue("select id from member_creation where upleg='" + id2 + "' and Side='Left'").ToString();
                        if (left != null)
                        {

                        }
                        foreach (DataRow d in d1.Rows)
                        {
                            id2 = d["id"].ToString();
                            goto xx;
                        }
                    }


                }
                else
                {
                    cl += 1;
                }

            }
        }

    }
    private void pNodeR(string node, string place)
    {
        string sql = "select * from member_creation where upleg='" + node + "' and side='" + place + "'";

        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            Active(node);
            Cr = Cr + 1;
            pNodeRR(dt.Rows[0]["id"].ToString(), "");

        }
        else if (dt.Rows.Count > 0)
        {
            Active(node);
            Cr = Cr + 2;
            pNodeR(dt.Select("side='Left'")[0].ItemArray[0].ToString(), "LEFT");
            pNodeR(dt.Select("side='Right'")[0].ItemArray[0].ToString(), "RIGHT");
            // Active(node);
        }
        if (dt.Rows.Count == 0)
        {
            Active(node);
        }
    }
    private void pNodeRR(string node, string place)
    {
        string sql = "select * from member_creation where upleg='" + node + "'";

        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            Active(node);
            Cr = Cr + 1;
            pNodeRR(dt.Rows[0]["id"].ToString(), "");

        }
        else if (dt.Rows.Count >= 2)
        {

            Active(node);
            Cr = Cr + 2;

            pNodeRR(dt.Select("side='Left'")[0].ItemArray[0].ToString(), "LEFT");
            // Active(node);
            pNodeRR(dt.Select("side='Right'")[0].ItemArray[0].ToString(), "RIGHT");
            // Active(node);

        }
        if (dt.Rows.Count == 0)
        {
            Active(node);
        }
    }

    private void pNodeL(string node, string place)
    {
        string sql = "select * from member_creation where upleg='" + node + "' and side='" + place + "'";


        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            ActiveL(node);
            Cl = Cl + 1;
            pNodeLL(dt.Rows[0]["id"].ToString(), "");

        }
        else if (dt.Rows.Count > 1)
        {
            ActiveL(node);
            Cl = Cl + 2;

            pNodeLL(dt.Select("side='Left'")[0].ItemArray[0].ToString(), "LEFT");
            pNodeLL(dt.Select("side='Right'")[0].ItemArray[0].ToString(), "RIGHT");

        }
        if (dt.Rows.Count == 0)
        {
            ActiveL(node);
        }
    }
    // Calculate after 1 count left
    private void pNodeLL(string node, string place)
    {
        string sql = "select * from member_creation where upleg='" + node + "' ";
        DataTable dt = new DataTable();
        dt = objsql.GetTable(sql);

        if (dt.Rows.Count == 1)
        {
            ActiveL(node);
            Cl = Cl + 1;

            pNodeLL(dt.Rows[0]["id"].ToString(), "");
        }
        else if (dt.Rows.Count > 1 || dt.Rows.Count < 0)
        {
            ActiveL(node);
            Cl = Cl + 2;
            pNodeLL(dt.Select("side='Left'")[0].ItemArray[0].ToString(), "LEFT");

            pNodeLL(dt.Select("side='Right'")[0].ItemArray[0].ToString(), "RIGHT");
            //  ActiveL(node);


        }
        if (dt.Rows.Count == 0)
        {
            ActiveL(node);
        }

    }


    protected void Active(string id)
    {


        if (se != Convert.ToInt32(id))
        {



            totalinst = Common.Get(objsql.GetSingleValue("select count(sr) from installment where id='" + id + "' and date_entry<='" + from + "'"));
            if (Convert.ToInt32(totalinst) >= 6)
            {


                Activeid += 1; // then active

            }
            else
            {
                getid = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
                if (getid != "")
                {
                    int totaldep = (Convert.ToInt32(totalinst) + Convert.ToInt32(getid));
                    if (totaldep >= 2)
                    {
                        if (Convert.ToInt32(getid) > 0)
                        {
                            Activeid += 1; // active

                        }
                    }
                    if (totaldep >= 6)
                    {
                        //  Activeid += 1;
                    }

                }
            }


            #region check this month joining and last month active
            string thismonthjoin = Common.Get(objsql.GetSingleValue("select date_entry from member_creation where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
            if (thismonthjoin != "")
            {

                string getid1 = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
                if (getid1 != "")
                {
                    if (Convert.ToInt32(getid1) > 0)
                    {

                        thismonthinst += 1;
                    }
                }

            }

            #endregion

        }
    }
    protected void ActiveL(string id)
    {
        //count = id;
        if (se != Convert.ToInt32(id))
        {



            totalinst = Common.Get(objsql.GetSingleValue("select count(sr) from installment where id='" + id + "' and date_entry<='" + from + "'"));
            if (Convert.ToInt32(totalinst) >= 6)
            {
                count = count + "," + id;
                ActiveidL += 1; // then active
            }
            else
            {
                getid = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
                if (getid != "")
                {
                    int totaldep = (Convert.ToInt32(totalinst) + Convert.ToInt32(getid));
                    if (totaldep >= 2)
                    {
                        if (Convert.ToInt32(getid) > 0)
                        {
                            ActiveidL += 1; // active
                        }
                    }
                    if (totaldep >= 6)
                    {
                        // ActiveidL += 1;
                    }

                }
            }
            #region check this month joining and last month active
            string thismonthjoin = Common.Get(objsql.GetSingleValue("select date_entry from member_creation where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
            if (thismonthjoin != "")
            {

                string getid1 = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '" + from + "' and '" + to + "' and id='" + id + "'"));
                if (getid1 != "")
                {
                    if (Convert.ToInt32(getid1) > 0)
                    {

                        thismonthinstleft += 1;
                    }
                }

            }

            #endregion
        }
    }

    protected void bind()
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from member_creation where id='1611'");
        if (dt2.Rows.Count > 0)
        {
            id = dt2.Rows[0]["id"].ToString();
            //foreach (DataRow dr in dt2.Rows)
            //{
            //    id = dr["id"].ToString();
            //     pNodeL(id, "Left");
            //    thismonthinstleft = 0;
            //    pNodeR(id, "Right");
               
            //    thismonthinst = 0;
            //    addrows(thismonthinst, id,thismonthinstleft);
            //}

        }
        GridView1.DataSource = dt3;
        GridView1.DataBind();
    }
    protected void genratetable()
    {
     
        dt3.Columns.Add("UserId", typeof(Int32));
        dt3.Columns.Add("PID", typeof(string));
        dt3.Columns.Add("Active", typeof(string));
        dt3.Columns.Add("ActiveLeft", typeof(string));

    }
    protected void addrows(int data,string pid,int leftactive)
    {
        DataRow dtrow = dt3.NewRow();    // Create New Row
        dtrow["UserId"] = 1;            //Bind Data to Columns
        dtrow["PID"] = pid;           //Bind Data to Columns
        dtrow["Active"] = data.ToString();
        dtrow["ActiveLeft"] = leftactive.ToString();

        dt3.Rows.Add(dtrow);
    }
  
}