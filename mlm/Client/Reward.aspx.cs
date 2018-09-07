using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public int cl = 0, cr = 0, Cl = 0, Cr = 0, Activeid = 0, se = 0, ActiveidL = 0, c = 0,rl=0,rr=0;
    public string left, right;
    public string totalinst = "0", getid = "0", count, aco;
    public string[] arr = new string[200];
    public static string from, to;
    protected void Page_Load(object sender, EventArgs e)
    {
        date();
        se = Convert.ToInt32(Session["id"]);
       // Tree(Convert.ToString(Session["id"]));
        check(Convert.ToString(Session["id"]));
        pNodeL(Convert.ToString(Session["id"]), "Left");
        pNodeR(Convert.ToString(Session["id"]), "Right");
        //     ActiveidL = ActiveidL - 1;
       

        if (Activeid < ActiveidL)
        {
            aco = Activeid.ToString();
        }
        else
        {
            aco = ActiveidL.ToString();
        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        Int64 lbus = 0;
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select active from cnt_down(@ID)";
                cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                cmd1.Connection = con;
                Label33.Text = Convert.ToString(cmd1.ExecuteScalar());
                lbus = Convert.ToInt64(cmd1.ExecuteScalar());
            }
            else
            {
                Label33.Text = "0";
            }
        }
        Int64 rbus = 0;
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select active from cnt_down(@ID)";
                cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                cmd1.Connection = con;
                Label34.Text = Convert.ToString(cmd1.ExecuteScalar());
                rbus = Convert.ToInt64(cmd1.ExecuteScalar());
            }
            else
            {
                Label34.Text = "0";
            }
        }
        {
            SqlCommand cmd11 = new SqlCommand();
            cmd11.CommandText = "select count(*) from member_creation where spon=@ID";
            cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd11.Connection = con;
            if (Convert.ToInt64(cmd11.ExecuteScalar())>=4)
            {
                Label9.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=1 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label10.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=1 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label3.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 30 && rbus >= 30)
            {
                Label11.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=2 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label12.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=2 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label4.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 125 && rbus >= 125)
            {
                Label13.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=3 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label14.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=3 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label5.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 500 && rbus >= 500)
            {
                Label15.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=4 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label16.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=4 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label6.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 1000 && rbus >= 1000)
            {
                Label17.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=5 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label18.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=5 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label7.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 2050 && rbus >= 2050)
            {
                Label19.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=6 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label20.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=6 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label8.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 3200 && rbus >= 3200)
            {
                Label21.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=7 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label22.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=7 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label25.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 10000 && rbus >= 10000)
            {
                Label23.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=8 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label24.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=8 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label26.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        {
            if (lbus >= 25000 && rbus >= 25000)
            {
                Label1.Text = "Yes";
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from rewards where reward=9 and id=@ID";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                if (Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
                {
                    Label2.Text = "Yes";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select convert(varchar,date_entry,106) from rewards where reward=9 and id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                    cmd1.Connection = con;
                    Label27.Text = Convert.ToString(cmd1.ExecuteScalar());
                }
            }
        }
        con.Dispose();
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
                    if (totaldep >= 1)
                    {
                        rr += 1;

                    }
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
                    if (totaldep >= 1)
                    {
                        rl += 1;

                    }
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
        }
    }
    protected void reward()
    {

    }

}
