using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class User_UploadData : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime curr_date = DateTime.Now;
            if (Session["Login_ID"].ToString() == null)
            {
                Response.Redirect("Default.aspx");
            }
            string u_ID = Session["Login_ID"].ToString();
            TextBox1.Text = u_ID;
            Image1.ImageUrl = "~/UserUpload/" + TextBox1.Text + 1 + ".jpg";
            Image2.ImageUrl = "~/UserUpload/" + TextBox1.Text + 2 + ".jpg";
            Image3.ImageUrl = "~/UserUpload/" + TextBox1.Text + 3 + ".jpg";
            Image4.ImageUrl = "~/UserUpload/" + TextBox1.Text + 4 + ".jpg";
        }
    }
    protected void btnfileupload_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            TextBox1.Focus();
            return;
        }        
        string pat = "";
        string ext = "";
        string strFileNameWithPath = "";
        string strFileName = "";
        strFileNameWithPath = fileImage.PostedFile.FileName;
        strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
        ext = System.IO.Path.GetExtension(strFileNameWithPath);
        if (fileImage.HasFile)
        {
            System.IO.Stream fs = fileImage.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytesPhoto = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytesPhoto, 0, bytesPhoto.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
            Image1.Visible = true;
            try
            {
                pat = (TextBox1.Text);
                fileImage.SaveAs(Server.MapPath("~/UserUpload/" + pat + "1" + ext));
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void btnfileupload1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            TextBox1.Focus();
            return;
        }
        string pat = "";
        string ext = "";
        string strFileNameWithPath = "";
        string strFileName = "";
        strFileNameWithPath = fileImage1.PostedFile.FileName;
        strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
        ext = System.IO.Path.GetExtension(strFileNameWithPath);
        if (fileImage1.HasFile)
        {
            System.IO.Stream fs = fileImage1.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytesPhoto = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytesPhoto, 0, bytesPhoto.Length);
            Image2.ImageUrl = "data:image/png;base64," + base64String;
            Image2.Visible = true;
            try
            {
                pat = (TextBox1.Text);
                fileImage1.SaveAs(Server.MapPath("~/UserUpload/" + pat + "2" + ext));
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void btnfileupload2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            TextBox1.Focus();
            return;
        }
        string pat = "";
        string ext = "";
        string strFileNameWithPath = "";
        string strFileName = "";
        strFileNameWithPath = fileImage2.PostedFile.FileName;
        strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
        ext = System.IO.Path.GetExtension(strFileNameWithPath);
        if (fileImage2.HasFile)
        {
            System.IO.Stream fs = fileImage2.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytesPhoto = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytesPhoto, 0, bytesPhoto.Length);
            Image3.ImageUrl = "data:image/png;base64," + base64String;
            Image3.Visible = true;
            try
            {
                pat = (TextBox1.Text);
                fileImage2.SaveAs(Server.MapPath("~/UserUpload/" + pat + "3" + ext));
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            TextBox1.Focus();
            return;
        }
        string pat = "";
        string ext = "";
        string strFileNameWithPath = "";
        string strFileName = "";
        strFileNameWithPath = fileImage3.PostedFile.FileName;
        strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
        ext = System.IO.Path.GetExtension(strFileNameWithPath);
        if (fileImage3.HasFile)
        {
            System.IO.Stream fs = fileImage3.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytesPhoto = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytesPhoto, 0, bytesPhoto.Length);
            Image4.ImageUrl = "data:image/png;base64," + base64String;
            Image4.Visible = true;
            try
            {
                pat = (TextBox1.Text);
                fileImage3.SaveAs(Server.MapPath("~/UserUpload/" + pat + "4" + ext));
            }
            catch (Exception ex)
            {

            }
        }
    }
}