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
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  branch ,Bank ,IFSC ,AcNo from member_creation where Id=@ID";
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                DropDownList1.Text = dr["bank"].ToString();
                txtemail.Text = dr["acno"].ToString();
                TextBox1.Text = dr["branch"].ToString();
                TextBox3.Text = dr["ifsc"].ToString();
            }
            con.Dispose();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Member_Creation Set branch=@branch,Bank=@Bank,Ifsc=@Ifsc ,AcNo=@Acno  Where Id= @Id";
            cmd.Connection = con;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = Convert.ToString(DropDownList1.SelectedValue);
            cmd.Parameters.Add("@acno", SqlDbType.VarChar).Value = txtemail.Text.ToUpper();
            cmd.Parameters.Add("@branch", SqlDbType.VarChar).Value = TextBox1.Text.ToUpper();
            cmd.Parameters.Add("@ifsc", SqlDbType.VarChar).Value = TextBox3.Text.ToUpper();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Label1.Visible = true;
            Label1.Text = "Profile Updated Successfully!";
        }
    }
}
