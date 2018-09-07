using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["admin"] == null)
            {
                Button1.Visible = false;
                txtproname.Enabled = false;
                txtpspon.Enabled = false;
                txtppf.Enabled = false;
                txtpcity.Enabled = false;
                txtpname.Enabled = false;
                txtpadd.Enabled = false;
            }
            f1();
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select state_id from dist where id=(select dist from member_creation where id=@Id)";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
                cmd.Connection = con;
                DropDownList3.SelectedValue = Convert.ToString(cmd.ExecuteScalar());
                f2();
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  mobile2,rel,id,Name,father,Email,Mobile,pan,address,pname,pfather,paddress,pcity,tehsil,city,convert(varchar,date_entry,106) as doj,convert(varchar,dob,101) as dob,acno,ifsc,bank,branch,nominee,pnomi,relation,spon,(select name from member_creation where id=m.spon) as SPONNAME,(select pname from member_creation where id=m.spon) as PSPONNAME,upleg,(select name from member_creation where id=m.upleg) as UPLEGNAME,(select pname from member_creation where id=m.upleg) as PPUPLEGNAME,dist from member_creation m where Id=@ID";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtname.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["father"].ToString();
                    txtemail.Text = dr["Email"].ToString();
                    txtmobile.Text = dr["Mobile"].ToString();
                    TextBox8.Text = dr["Mobile2"].ToString();
                    TextBox1.Text = dr["pan"].ToString();
                    TextBox6.Text = dr["address"].ToString();
                    TextBox9.Text = dr["tehsil"].ToString();
                    TextBox10.Text = dr["city"].ToString();
                    txtdob.Text = dr["dob"].ToString();
                    TextBox3.Text = dr["acno"].ToString();
                    TextBox4.Text = dr["branch"].ToString();
                    TextBox5.Text = dr["ifsc"].ToString();
                    TextBox7.Text = dr["nominee"].ToString();
                    DropDownList4.Text = dr["relation"].ToString();
                    DropDownList5.Text = dr["rel"].ToString();
                    TextBox11.Text = dr["spon"].ToString();
                    TextBox12.Text = dr["sponname"].ToString();
                    TextBox13.Text = dr["upleg"].ToString();
                    TextBox14.Text = dr["uplegname"].ToString();
                    TextBox15.Text = dr["id"].ToString();
                    TextBox16.Text = dr["doj"].ToString();
                    txtpname.Text = dr["pname"].ToString();
                    txtppf.Text = dr["pfather"].ToString();
                    txtpcity.Text = dr["pcity"].ToString();
                    txtproname.Text = dr["PSPONNAME"].ToString();
                    txtpspon.Text = dr["PPUPLEGNAME"].ToString();
                    txtpadd.Text = dr["paddress"].ToString();
                    txtpnomi.Text = dr["pnomi"].ToString();
                    if (DropDownList3.Items.Count > 0)
                    {
                        DropDownList2.SelectedValue = dr["dist"].ToString();
                    }
                    DropDownList1.SelectedValue = dr["bank"].ToString();
                }
            }
            con.Dispose();
        }
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select ID,NAME from states order by name";
        cmd.Connection = con;
        DropDownList3.DataSource = cmd.ExecuteReader();
        DropDownList3.DataTextField = "NAME";
        DropDownList3.DataValueField = "ID";
        DropDownList3.DataBind();
        con.Dispose();
        //DropDownList3.Items.Insert(0, new ListItem("Add New", "")); 
        f2();
    }
    public void f2()
    {
        if (DropDownList3.Items.Count > 0)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select ID,NAME from dist where state_id=@STATE order by name";
            cmd.Parameters.Add("@STATE", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList3.SelectedValue);
            cmd.Connection = con;
            DropDownList2.DataSource = cmd.ExecuteReader();
            DropDownList2.DataTextField = "NAME";
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataBind();
            con.Dispose();
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        f2();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Member_Creation Set mobile2=@mobile2,rel=@rel,Name =@Name,father=@father,Email=@Email ,Mobile=@Mobile,pan=@PAN,address=@address,tehsil=@tehsil,city=@city,dob=@dob,acno=@acno,branch=@branch,ifsc=@ifsc,nominee=@nominee,relation=@relation,pname=@pname,pfather=@pfather,pcity=@pcity,paddress=@paddress,pnomi=@pnomi  Where Id= @Id";
            cmd.Connection = con;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Convert.ToString(txtname.Text).ToUpper();
            cmd.Parameters.Add("@father", SqlDbType.VarChar).Value = Convert.ToString(TextBox2.Text).ToUpper();
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtemail.Text;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = txtmobile.Text.ToUpper();
            cmd.Parameters.Add("@Mobile2", SqlDbType.VarChar).Value = TextBox8.Text.ToUpper();
            cmd.Parameters.Add("@PAN", SqlDbType.VarChar).Value = TextBox1.Text.ToUpper();
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = TextBox6.Text.ToUpper();
            cmd.Parameters.Add("@dob", SqlDbType.VarChar).Value = txtdob.Text.ToUpper();
            cmd.Parameters.Add("@tehsil", SqlDbType.VarChar).Value = TextBox9.Text.ToUpper();
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = TextBox10.Text.ToUpper();
            cmd.Parameters.Add("@acno", SqlDbType.VarChar).Value = TextBox3.Text.ToUpper();
            cmd.Parameters.Add("@branch", SqlDbType.VarChar).Value = TextBox4.Text.ToUpper();
            cmd.Parameters.Add("@ifsc", SqlDbType.VarChar).Value = TextBox5.Text.ToUpper();
            cmd.Parameters.Add("@nominee", SqlDbType.VarChar).Value = TextBox7.Text.ToUpper();
            cmd.Parameters.Add("@relation", SqlDbType.VarChar).Value = DropDownList4.Text.ToUpper();
            cmd.Parameters.Add("@rel", SqlDbType.VarChar).Value = DropDownList5.Text.ToUpper();
            cmd.Parameters.Add("@pname", SqlDbType.VarChar).Value = txtpname.Text;
            cmd.Parameters.Add("@pfather", SqlDbType.VarChar).Value = txtppf.Text;
            cmd.Parameters.Add("@pcity", SqlDbType.VarChar).Value = txtpcity.Text;
            cmd.Parameters.Add("@paddress", SqlDbType.VarChar).Value = txtpadd.Text;
            cmd.Parameters.Add("@pnomi", SqlDbType.VarChar).Value = txtpnomi.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Label1.Visible = true;
            Label1.Text = "Profile Updated Successfully!";
        }
    }
}
