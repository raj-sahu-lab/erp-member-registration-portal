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

public partial class Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList1.Items.Add("--Select--");
            DropDownList1.Items.Add("Admin");
            DropDownList1.Items.Add("User");
        }
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "-Select-")
        {
            string jv = "<script>alert('Please select valid Login Mode');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            DropDownList1.Focus();
            return;
        }
        string CL_MODE = "";

            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Mode from LevelMaster Where ID=@loginId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@loginId", TextBox1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                CL_MODE = dr[0].ToString();
            }
            dr.Close();
            // Fetch stored password hash for verification
            string storedPassword = null;
            string loginType = null;
            cmd.CommandText = "Select Login_Type, Password from Login where Login_ID=@loginId2";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@loginId2", TextBox1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                loginType = dr[0].ToString();
                storedPassword = dr[1].ToString();
            }
            dr.Close();
            if (loginType != null && PasswordHelper.VerifyPassword(TextBox2.Text, storedPassword))
            {
                if (DropDownList1.Text != "User")
                {
                    if (loginType == "Admin")
                    {
                        if (DropDownList1.Text != "Admin")
                        {
                            string jv = "<script>alert('Please select valid Login Mode');</script>";
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                            DropDownList1.Focus();
                            con.Close();
                            return;
                        }
                        con.Close();
                        Session["Login_ID"] = TextBox1.Text;
                        Response.Redirect("Admin/AdminHome.aspx");
                    }
                    if (loginType == "User")
                    {
                        if (DropDownList1.Text != "User")
                        {
                            string jv = "<script>alert('Please select valid Login Mode');</script>";
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                            DropDownList1.Focus();
                            con.Close();
                            return;
                        }
                        con.Close();
                        Session["Login_ID"] = TextBox1.Text;
                        Response.Redirect("User/UserHome.aspx");
                    }
                    if (loginType == "Head")
                    {
                        if ((DropDownList1.Text == "STATE HEAD") || (DropDownList1.Text == "DISTRICT HEAD") || (DropDownList1.Text == "INDIA HEAD"))
                        {
                            con.Close();
                            Session["Login_ID"] = TextBox1.Text;
                            Response.Redirect("Head/HeadHome.aspx");
                        }
                        else
                        {
                            string jv = "<script>alert('Please select valid Login Mode');</script>";
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                            DropDownList1.Focus();
                            con.Close();
                            return;
                        }                        
                    }                   
                }
                else
                {
                    con.Close();
                    Session["Login_ID"] = TextBox1.Text;
                    Response.Redirect("User/UserHome.aspx");
                }
            }
            else
            {
                string jv = "<script>alert('Please enter correct login ID and password!!!');</script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox1.Focus();
                return;
            }
            con.Close();
       
       try
        {  } catch (Exception ex)
        {
            //string jv = "<script>alert('" +ex.Message.Replace("'","")+ "');</script>";
            //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            con.Close();
        }
    }            
}