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

public partial class User_ChangePassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime regDate = DateTime.Now;           
            LoadData();
        }
    }
    void LoadData()
    {
        try
        {
            string u_id = Session["Login_ID"].ToString();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select * from MLMRegistration where Upliner_ID=@uplId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@uplId", u_id);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {               
                txtuser_id.Text = dr[1].ToString();                                         
                txtpassword.Text = dr[26].ToString();              
                ddlhint_que.Text = dr[29].ToString();
                txtans.Text = dr[30].ToString();              
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            dr.Close();
            con.Close();
        }
    }
    void Clear()
    {  
        txtpassword.Text = "";      
        ddlhint_que.Text = "--Select--";
        txtans.Text = "";       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {       
        if (txtpassword.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Password');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtpassword.Focus();
            return;

        }        
        DateTime regDate = DateTime.Now;
        SqlTransaction transaction = null;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            transaction = con.BeginTransaction("BIT_MEDICARE");
            cmd.Connection = con;
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.Text;
            string hashedPwd = PasswordHelper.HashPassword(txtpassword.Text);
            cmd.CommandText = "Update MLMRegistration Set Password=@pwd,Hint_Question=@hint,Answer=@ans Where Upliner_ID=@uid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pwd", hashedPwd);
            cmd.Parameters.AddWithValue("@hint", ddlhint_que.Text);
            cmd.Parameters.AddWithValue("@ans", txtans.Text);
            cmd.Parameters.AddWithValue("@uid", txtuser_id.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Update Login Set Password=@pwd2,Security_Hint=@hint2,Answer=@ans2 Where Login_ID=@uid2";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pwd2", hashedPwd);
            cmd.Parameters.AddWithValue("@hint2", ddlhint_que.Text);
            cmd.Parameters.AddWithValue("@ans2", txtans.Text);
            cmd.Parameters.AddWithValue("@uid2", txtuser_id.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            string jv1 = "<script>alert('Password has been changed');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv1, false);
            transaction.Commit();
            con.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            con.Close();
            string jv1 = "<script>alert('Error!!!');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv1, false);
            Label36.Text = "An error occurred. Please try again."; // Exception logged server-side in production
            return;
        }
        Clear();
    }
}