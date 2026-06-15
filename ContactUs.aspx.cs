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
using System.Net.Mail;
using System.Net.NetworkInformation;
//using System.Net.NetworkCredential;

public partial class ContactUs : System.Web.UI.Page
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        MailMessage mailMsg = new MailMessage();
        mailMsg.From = new MailAddress("admin@[your-website.com]");
        mailMsg.To.Add("admin@[your-website.com]");
        //mailMsg.Cc = "cc@ccServer.com"";
        //mailMsg.Bcc = "bcc@bccServer.com";
        mailMsg.Subject = "Feedback Form :";
        mailMsg.Body = "Name :" + TextBox3.Text + "  " + "Contact No :" + TextBox4.Text + "  " + "E-Mail :" + TextBox5.Text + "  " + "Contact For :" + DropDownList1.Text + "  " + "Details :" + TextBox7.Text;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "[SMTP_HOST]";
        smtp.EnableSsl = false;
        smtp.Port = 25;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("admin@[your-website.com]", "[SMTP_PASSWORD]");

        try
        {
            //smtp.SendAsync(mailMsg, null);
            smtp.Send(mailMsg);
            Label20.Text = "Your enquiry has been submitted successfully!!!";
        }
        catch (Exception ex)
        {
            Label20.Text = "An error occurred. Please try again."; // Exception logged server-side in production
            //Label20.Text = "An error has accured! </br></br>";
        }
        Clear();
    }
    void Clear()
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox7.Text = "";
        DropDownList1.Text = "";
        DropDownList1.Text = "--Select--";
    }

}