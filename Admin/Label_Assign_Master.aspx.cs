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

public partial class Admin_Label_Assign_Master : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Auto_Gen_ID();           
        }     
    }
    void Auto_Gen_ID()
    {
        int ssr_no;
        string sr_ssno;
        ssr_no = 1;
        sr_ssno = "";
        int max_ssr_no;
        string MAX_SRNO = "";
        max_ssr_no = 0;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select MAX(Assign_ID) from Level_AssignMaster";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MAX_SRNO = dr[0].ToString();
            }
            dr.Close();
            if (MAX_SRNO == "")
            {
                max_ssr_no = 0;               
            }
            else
            {
                max_ssr_no = Convert.ToInt32(MAX_SRNO);               
            }
          
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("-Select-");
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("-Select-");
            cmd.CommandText = "select DISTINCT Label_Name from LabelMaster";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cmd.CommandText = "select DISTINCT Upliner_ID from MLMRegistration";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lb_Message.Text = ex.Message;
            con.Close();
        }
        ssr_no = max_ssr_no + 1;
        sr_ssno = ssr_no.ToString();
        txtcomm_id.Text = sr_ssno;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtcomm_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Label ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcomm_id.Focus();
            return;

        }
        if (txtname.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter name');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtname.Focus();
            return;

        }
       
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Insert into Level_AssignMaster(Assign_ID, Level_Name, ID, Name, Mode) values(@assignId,@levelName,@id,@name,'ACTIVE')";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@assignId", txtcomm_id.Text);
            cmd.Parameters.AddWithValue("@levelName", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@id", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            if (DropDownList1.Text == "CLIENT")
            {
                cmd.CommandText = "Update Login Set Login_Type='Clients' Where Login_ID=@loginId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@loginId", DropDownList2.Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = "Update Login Set Login_Type='Head' Where Login_ID=@loginId2";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@loginId2", DropDownList2.Text);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }           
            string jv = "<script>alert('Record has been saved!!!');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
            lb_Message.Text = ex.Message;
        }
        Clear();
    }   
    void Clear()
    {       
        txtcomm_id.Text = "";
        DropDownList1.Text = "-Select-";
        DropDownList2.Text = "-Select-";
        txtname.Text = "";
        DropDownList1.Focus();
        Auto_Gen_ID();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Name from MLMRegistration Where Upliner_ID=@uplId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@uplId", DropDownList2.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtname.Text = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lb_Message.Text = ex.Message;
            con.Close();
        }
    }
}
