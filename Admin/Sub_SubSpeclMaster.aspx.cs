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

public partial class Admin_Sub_SubSpeclMaster : System.Web.UI.Page
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
            ddl_country.Items.Clear();
            ddl_country.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Specialization_Name from SpecializationMaster Order By Specialization_Name";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_country.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
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
            cmd.CommandText = "select MAX(Sr_No) from Sub_SubSpeclMaster";
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
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_state.Items.Clear();
        ddl_state.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct Sub_Specialization from SubSpeclMaster Where Specialization_Name=@specName Order By Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@specName", ddl_country.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_state.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtcomm_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Sub Sub Specialization ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcomm_id.Focus();
            return;

        }
        if (ddl_country.Text.Trim() == "")
        {
            string jv = "<script>alert('Specialization can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_state.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Sub Specialization can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }    
        if (txtlabel_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Sub Sub Specialization can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }      
         
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Insert into Sub_SubSpeclMaster(Sr_No, Specialization_Name, Sub_Specialization, Sub_Sub_Specialization) values(@srNo,@specName,@subSpec,@subSubSpec)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@srNo", txtcomm_id.Text);
            cmd.Parameters.AddWithValue("@specName", ddl_country.Text);
            cmd.Parameters.AddWithValue("@subSpec", ddl_state.Text);
            cmd.Parameters.AddWithValue("@subSubSpec", txtlabel_name.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            string jv = "<script>alert('Record has been saved!!!');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            con.Close();
            GridView1.DataBind();
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
        txtlabel_name.Text = "";
        txtlabel_name.Focus();
        Auto_Gen_ID();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
