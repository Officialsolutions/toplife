using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Montly_Pair : System.Web.UI.Page
{ SQLHelper objsql = new SQLHelper();
    public int cl = 0, cr = 0, Cl=0, Cr=0,Activeid=0,se=0,ActiveidL=0,c=0,leftthismont=0,thismonthinst=0, thismonthinstleft = 0;
    public string left, right;
    public string totalinst = "0", getid = "0", count,aco,sub="",last="";
    public string[] arr = new string[200];
    public static string from, to, thismonthlogid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label17.Visible = false;
        Label18.Visible = false;
        Label19.Visible = false;
        Label20.Visible = false;
        Label21.Visible = false;
        Label22.Visible = false;
        string[] Month = new string[12];
        Month[0] = "Jan";Month[1] ="Feb";Month[2] = "Mar"; Month[3]="Apr";
        Month[4] = "May"; Month[5] = "Jun"; Month[6] = "Jul"; Month[7] = "Aug";
        Month[8] = "Sep"; Month[9] = "Oct"; Month[10] = "Nov"; Month[11] = "Dec";
        if (Page.IsPostBack == false)
        {

            DateTime last2 = System.DateTime.Now.AddMonths(-2);
            DateTime last = System.DateTime.Now.AddMonths(-1);
            int l = last.Month-1;
            
            int l2 = last2.Month-1;
            lnklast2.CommandArgument = l2.ToString();
            lnklast.CommandArgument = l.ToString();
            lnklast.Text = Month[l].ToString();

            lnklast2.Text = Month[l2].ToString();

            date();
            se = Convert.ToInt32(Session["id"]);
            Tree(Convert.ToString(Session["id"]));
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
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "VAL_DOWNLINE";
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        cmd.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(txtname.Text.ToUpper());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()) == Convert.ToString(txtname.Text.ToUpper()))
        {
            Tree(Convert.ToString(txtname.Text.ToUpper()));
        }
        con.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton1.Text));
        pNodeR(Convert.ToString(LinkButton1.Text), "Right");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton3.Text));
        pNodeR(Convert.ToString(LinkButton3.Text), "Right");

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton2.Text));
        pNodeR(Convert.ToString(LinkButton2.Text), "Right");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton4.Text));
        pNodeR(Convert.ToString(LinkButton4.Text), "Right");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton5.Text));
        pNodeR(Convert.ToString(LinkButton5.Text), "Right");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton6.Text));
        pNodeR(Convert.ToString(LinkButton6.Text), "Right");
    }
    public void Tree(string Sr)
    {
        Image3.ImageUrl = "../imges/user_black.png";
        Image6.ImageUrl = "../imges/user_black.png";
        Image9.ImageUrl = "../imges/user_black.png";
        Image12.ImageUrl = "../imges/user_black.png";
        Image15.ImageUrl = "../imges/user_black.png";
        Image18.ImageUrl = "../imges/user_black.png";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt from CNT_DOWNdemo(@ID)";
                    //cmd1.Parameters.Add("@From", SqlDbType.VarChar).Value = from;
                    //cmd1.Parameters.Add("@To", SqlDbType.VarChar).Value = to;
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label23.Text = "Left IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select active from CNT_DOWNdemo(@ID)";
                   // cmd1.Parameters.Add("@From", SqlDbType.VarChar).Value = from;
                   //cmd1.Parameters.Add("@To", SqlDbType.VarChar).Value = to;
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label23.Text = Label23.Text + "<br>Active IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt_new from cnt_down1(@ID,'Left','01/01/1900','01/01/2020')";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Sr);
                    cmd1.Connection = con;
                    Label23.Text = Label23.Text + "<br>New IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
            }
            else
            {
                Label23.Text = "Left IDs : 0<br>Active IDs : 0<br>New IDs : 0";
            }
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
            {
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt from cnt_down(@ID)";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label25.Text = "Right IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select active from cnt_down(@ID)";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label25.Text = Label25.Text + "<br>Active IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select cnt_new from cnt_down1(@ID,'Right','01/01/1900','01/01/2020')";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Sr);
                    cmd1.Connection = con;
                    Label25.Text = Label25.Text + "<br>New IDs : " + Convert.ToInt64(cmd1.ExecuteScalar());
                }
            }
            else
            {
                Label25.Text = "Right IDs : 0<br>Active IDs : 0<br>New IDs : 0";
            }
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Label8.Text + "<br>" + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton1.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label10.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select spon from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                if (Convert.ToString(cmd.ExecuteScalar()) != "")
                {
                    Label17.Visible = true;
                    Label17.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select name from member_creation where id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label17.Text = Label17.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                }
                else
                {
                    Image3.ImageUrl = "../imges/tree1.png";
                }
            }
        }
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton4.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label11.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select spon from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                if (Convert.ToString(cmd.ExecuteScalar()) != "")
                {
                    Label18.Visible = true;
                    Label18.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select name from member_creation where id=@ID";
                    cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                    cmd1.Connection = con;
                    Label18.Text = Label18.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                }
                else
                {
                    Image6.ImageUrl = "../imges/tree1.png";
                }
            }
        }
        {
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton2.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label12.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label19.Visible = true;
                        Label19.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label19.Text = Label19.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image9.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton3.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label13.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label20.Visible = true;
                        Label20.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label20.Text = Label20.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image12.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
        }
        {
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton5.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label14.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label21.Visible = true;
                        Label21.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label21.Text = Label21.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image15.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton6.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label15.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select spon from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    if (Convert.ToString(cmd.ExecuteScalar()) != "")
                    {
                        Label22.Visible = true;
                        Label22.Text = "Proposer ID : " + Convert.ToString(cmd.ExecuteScalar());
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select name from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd.ExecuteScalar());
                        cmd1.Connection = con;
                        Label22.Text = Label22.Text + "(" + Convert.ToString(cmd1.ExecuteScalar()) + ")";
                    }
                    else
                    {
                        Image18.ImageUrl = "../imges/tree1.png";
                    }
                }
            }
        }
        Image3.ImageUrl = "../img/user_black.png";
        Image6.ImageUrl = "../img/user_black.png";
        Image9.ImageUrl = "../img/user_black.png";
        Image12.ImageUrl = "../img/user_black.png";
        Image15.ImageUrl = "../img/user_black.png";
        Image18.ImageUrl = "../img/user_black.png";
        con.Dispose();
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

                        cl +=Convert.ToInt32(count);

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
        if(dt.Rows.Count==0)
        {
            ActiveL(node);
        }

    }
   

    protected void Active(string id)
    {
        

        if (se != Convert.ToInt32(id))
        {
            


            totalinst = Common.Get(objsql.GetSingleValue("select count(sr) from installment where id='" + id + "' and date_entry<='"+from+"'"));
            if (Convert.ToInt32(totalinst) >= 6)
            {
                

                Activeid += 1; // then active
             
            }
            else
            {
                getid = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '"+from+"' and '"+to+"' and id='" + id + "'"));
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

            

            totalinst = Common.Get(objsql.GetSingleValue("select count(sr) from installment where id='" + id + "' and date_entry<='"+from+"'"));
            if (Convert.ToInt32(totalinst) >= 6)
            {
                count = count + "," + id;
                ActiveidL += 1; // then active
            }
            else
            {
                getid = Common.Get(objsql.GetSingleValue("select count(sr) from installment where date_entry between '"+from+"' and '"+to+"' and id='" + id + "'"));
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
    protected void date()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblsetting");
        if (dt.Rows.Count > 0)
        {
            
            from = dt.Rows[0]["fromdate"].ToString();
            to = dt.Rows[0]["todate"].ToString();
            thismonthlogid =dt.Rows[0]["loginid"].ToString();
        }

    }
    protected void lead(int month)
    {
        DataTable dtm = new DataTable();
        dtm = objsql.GetTable("select * from tbllead where month='" + month + "'");
        if (dtm.Rows.Count > 0)
        {
            from = dtm.Rows[0]["fromdate"].ToString();
            to = dtm.Rows[0]["todate"].ToString();
        }
        
        pNodeL(Convert.ToString(Session["id"]), "Left");
        pNodeR(Convert.ToString(Session["id"]), "Right");
    }

    protected void lnklast2_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        lead(id);

    }
}