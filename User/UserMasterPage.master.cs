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

public partial class User_UserMasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_ID"].ToString() == null)
        {
            Response.Redirect("../Default.aspx");
        }
        else
        {
            lb_Welcome.Text = "Welcome :";
            lb_UserID.Text = Session["Login_ID"].ToString();
            lnk_Logout.Text = "Logout";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Name from MLMRegistration where Upliner_ID='" + lb_UserID.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lb_uname.Text = ", Name : " + dr[0].ToString();
            }
            dr.Close();
            con.Close();
        } 
        Auto_Update_AllUserData();
    }
    ArrayList ar_ls;
    void Auto_Update_AllUserData()
    {
        ArrayList ar_ls = new ArrayList();
        ar_ls.Clear();
        string rleg_id, lleg_id;
        rleg_id = "";
        lleg_id = "";
        int rjoining1, ljoining1, pair1;
        rjoining1 = 0;
        ljoining1 = 0;
        pair1 = 0;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Distinct(userid) from User_Detail";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ar_ls.Add(dr[0]);                
            }            
            dr.Close();           
            con.Close();
        }
        catch (Exception ex)
        {            
            con.Close();
        }
        int ar_count = 0;
        int start_i = 0;
        ar_count = ar_ls.Count;
        while (start_i < ar_count - 1)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "select lleg, rleg, ljoining, rjoining, pair from User_Detail Where userid='" + ar_ls[start_i] + "'";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lleg_id = dr[0].ToString();
                    rleg_id = dr[1].ToString();
                    ljoining1 = Convert.ToInt32(dr[2]);
                    rjoining1 = Convert.ToInt32(dr[3]);
                    pair1 = Convert.ToInt32(dr[4]);
                }
                dr.Close();
                cmd.CommandText = "Update Binary_Detail SET lleg='" + lleg_id + "',rleg='" + rleg_id + "',ljoining='" + ljoining1 + "',rjoining='" + rjoining1 + "',pair='" + pair1 + "' Where userid='" + ar_ls[start_i] + "'";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            start_i = start_i + 1;
        }       
    }
    protected void lnk_Logout_Click(object sender, EventArgs e)
    {
        Session["Login_ID"] = null;
        Response.Redirect("../Default.aspx");
    }
}
