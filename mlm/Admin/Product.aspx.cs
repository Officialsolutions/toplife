using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string img;
    public string imagename;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Convert.ToInt32(Request.QueryString["id"]));
            }
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (sliderimage.HasFile)
        {
            string sliderpic = sliderimage.FileName;
            imagename = "PH" + "_" + Common.GenerateClassCode2() + "_" + sliderpic;
            string filePath2 = MapPath("../uploadimage/" + imagename);
            Stream Buffer2 = sliderimage.PostedFile.InputStream;
            System.Drawing.Image Image2 = System.Drawing.Image.FromStream(Buffer2);
            Bitmap bmp2 = GetImage.ResizeImage(Image2, Image2.Height, Image2.Width);
            bmp2.Save(filePath2, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else
        {
            imagename = img;
        }
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblproduct set name='" + txtname.Text + "',Mrp='" + txtmrp.Text + "',image='" + imagename + "',bv='"+txtbv.Text+ "',serial='"+txtserial.Text+"' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblproduct(name,code,mrp,image,bv,serial) values('" + txtname.Text + "','" + txtcode.Text + "','" + txtmrp.Text + "','"+imagename+ "','" + txtbv.Text + "','" + txtserial.Text + "')");
        }
        img = "";
        Response.Redirect("view-products.aspx");
    }
    protected void bind(int id)
    {
        DataTable dt1 = new DataTable();
        dt1 = objsql.GetTable("select * from tblproduct where id='" + id + "'");
        if (dt1.Rows.Count > 0)
        {
            txtname.Text = dt1.Rows[0]["name"].ToString();
            txtmrp.Text= dt1.Rows[0]["Mrp"].ToString();
            txtcode.Text= dt1.Rows[0]["code"].ToString();
            img = dt1.Rows[0]["image"].ToString();
            txtbv.Text= dt1.Rows[0]["bv"].ToString();
          txtserial.Text= dt1.Rows[0]["serial"].ToString();
        }
    }
}