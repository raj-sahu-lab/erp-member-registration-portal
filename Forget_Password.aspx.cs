using System;
using System.IO;
using System.Net;
using System.Text;
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
using System.Net.Mail;
using System.Net.NetworkInformation;

public partial class Forget_Password : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();        
            cmd.CommandText = "Select Password from Login where Login_ID='" + TextBox3.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["PWD"] = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            dr.Close();
            Label1.Text = ex.Message;
            con.Close();
        }
        SendMsg();
    }
    void SendMsg()
    {
        string u_iid = "";
        u_iid = Session["PWD"].ToString();
        string U_EMAIL = "";
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Email from MLMRegistration where Upliner_ID='" + TextBox3.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                U_EMAIL = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            dr.Close();
            Label1.Text = ex.Message;
            con.Close();
        }
        MailMessage mailMsg = new MailMessage();
        mailMsg.From = new MailAddress("admin@[your-website.com]");
        mailMsg.To.Add(U_EMAIL);
        mailMsg.Subject = "Joining Message :";
        mailMsg.Body = "Your ID is :" + TextBox3.Text + "and Your Password is :" + u_iid;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "[SMTP_HOST]";
        smtp.EnableSsl = false;
        smtp.Port = 25;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("admin@[your-website.com]", "[SMTP_PASSWORD]");
        try
        {           
            smtp.Send(mailMsg);
            Label1.Text = "Password has been sent in your Email ID!!!";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;            
        }
    }
}