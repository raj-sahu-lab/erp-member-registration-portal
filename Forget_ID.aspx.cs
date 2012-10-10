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

public partial class Forget_ID : System.Web.UI.Page
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
            cmd.CommandText = "Select Upliner_ID, Name from MLMRegistration where Contact_No='" + TextBox3.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = "Your ID is : " + dr[0].ToString();
                Label16.Text = dr[1].ToString();
            }
            else
            {
                Label1.Text = "This is not valid mobile no., Please enter valid Mobile No.";
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
    }
}