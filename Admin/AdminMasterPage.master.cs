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

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {        
        //if (Session["Login_ID"].ToString() == null)
        //{
        //    Response.Redirect("../Default.aspx");
        //}
        //else
        //{
        //    lb_Welcome.Text = "Welcome :";
        //    lb_UserID.Text = Session["Login_ID"].ToString();
        //    lnk_Logout.Text = "Logout";
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        //        con.Open();
        //        cmd.CommandText = "Select Name from MLMRegistration where Upliner_ID='" + lb_UserID.Text + "'";
        //        cmd.Connection = con;
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //           lb_uname.Text=", Name : " + dr[0].ToString();             
        //        }    
        //        dr.Close();
        //        con.Close();
        //    }            
        }   
   
    protected void lnk_btn_Click(object sender, EventArgs e)
    {     
        Response.Redirect("../Default.aspx");
    }
}
