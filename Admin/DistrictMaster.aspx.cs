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

public partial class Admin_DistrictMaster : System.Web.UI.Page
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

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Country_Name from CountryMaster Order By Country_Name";
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
            ddl_country.SelectedItem.Text = "Bharat";

            ddl_kshetraorg.Items.Clear();
            ddl_kshetraorg.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "select orgwisekshetra from StateMaster where Country='" + ddl_country.Text + "'";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_kshetraorg.Items.Add(dr[0].ToString());
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
            cmd.CommandText = "select MAX(Sr_No) from DistrictMaster";
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
        ddl_kshetraorg.Items.Clear();
        ddl_kshetraorg.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select orgwisekshetra from StateMaster where Country='" + ddl_country.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetraorg.Items.Add(dr[0].ToString());
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
            string jv = "<script>alert('Please enter State ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcomm_id.Focus();
            return;

        }
        if (ddl_country.Text.Trim() == "--Select Country--")
        {
            string jv = "<script>alert('Country Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_kshetraorg.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Oraganization wise Kshetra Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_kshetrarss.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('RSS wise Kshetra Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_prant_govt.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Govt wise Prant Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_prant_org.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Org wise Prant Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_prant_rss.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('RSS wise Prant Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (txtlabel_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Loksabha Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }    
        if (txtlabel_name.Text.Trim() == "")
        {
            string jv = "<script>alert('District Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }        
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Insert into DistrictMaster(Sr_No, Country, kshetraorg,kshetrarss,prantrss,prantorg,prantgovt,loksabha, District) values('" + txtcomm_id.Text + "','" + ddl_country.SelectedItem.Text + "','" + ddl_kshetraorg.SelectedItem.Text + "','" + ddl_kshetrarss.SelectedItem.Text + "','" + ddl_prant_rss.SelectedItem.Text + "','" + ddl_prant_org.SelectedItem.Text + "','" + ddl_prant_govt.SelectedItem.Text + "','" + ddl_lokshabhaname.SelectedItem.Text + "','" + txtlabel_name.Text + "')";
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

    protected void ddl_kshetraorg_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_kshetrarss.Items.Clear();
        ddl_kshetrarss.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select rsswisekshetra from StateMaster where Country='" + ddl_country.SelectedItem.Text + "' and orgwisekshetra='" + ddl_kshetraorg.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetrarss.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_kshetrarss_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_prant_rss.Items.Clear();
        ddl_prant_rss.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select rsswiseprant from StateMaster where Country='" + ddl_country.SelectedItem.Text + "' and orgwisekshetra='" + ddl_kshetraorg.SelectedItem.Text + "' and rsswisekshetra='" + ddl_kshetrarss.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_rss.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_prant_govt.Items.Clear();
        ddl_prant_govt.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select govtwiseprant from StateMaster where Country='" + ddl_country.SelectedItem.Text + "' and orgwisekshetra='" + ddl_kshetraorg.SelectedItem.Text + "' and rsswisekshetra='" + ddl_kshetrarss.SelectedItem.Text + "' and rsswiseprant='" + ddl_prant_rss.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_govt.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_rss_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_prant_org.Items.Clear();
        ddl_prant_org.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select orgwiseprant from StateMaster where Country='" + ddl_country.SelectedItem.Text + "' and orgwisekshetra='" + ddl_kshetraorg.SelectedItem.Text + "' and rsswisekshetra='" + ddl_kshetrarss.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_org.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_govt_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_lokshabhaname.Items.Clear();
        ddl_lokshabhaname.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();

            // 
            cmd.CommandText = "select Loksabha from LoksabhaMaster where Country='" + ddl_country.SelectedItem.Text + "' and kshetraorg='" + ddl_kshetraorg.SelectedItem.Text + "' and kshetrarss='" + ddl_kshetrarss.SelectedItem.Text + "' and prantrss='" + ddl_prant_rss.SelectedItem.Text + "' and prantorg='" + ddl_prant_org.SelectedItem.Text + "' and prantgovt='" + ddl_prant_govt.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_lokshabhaname.Items.Add(dr[0].ToString());
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
