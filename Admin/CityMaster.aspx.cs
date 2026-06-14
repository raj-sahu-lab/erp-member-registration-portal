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

public partial class Admin_CityMaster : System.Web.UI.Page
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
                cmd.CommandText = "select orgwisekshetra from StateMaster where Country=@country";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@country", ddl_country.Text);
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
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_kshetraorg.Items.Clear();
        ddl_kshetraorg.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select orgwisekshetra from StateMaster where Country=@country";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
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
            cmd.CommandText = "select MAX(Sr_No) from CityMaster";
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
            string jv = "<script>alert('Vidhansabha Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (txtcode.Text.Trim() == "")
        {
            string jv = "<script>alert('Vidhansabha Code can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcode.Focus();
            return;
        }    
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Insert into CityMaster(Sr_No, Country,kshetraorg,kshetrarss,prantrss,prantorg,prantgovt,Loksabha,Vidhansabha,Vidhansabha_Code,district) values(@srNo,@country,@kshetraorg,@kshetrarss,@prantrss,@prantorg,@prantgovt,@loksabha,@vidhansabha,@vidhCode,@district)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@srNo", txtcomm_id.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@loksabha", ddl_loksabha.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha", txtlabel_name.Text);
            cmd.Parameters.AddWithValue("@vidhCode", txtcode.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.SelectedItem.Text);
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
        txtcode.Text = "";
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
           cmd.CommandText = "select rsswisekshetra from StateMaster where Country=@country and orgwisekshetra=@orgKsh";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_kshetraorg.SelectedItem.Text);
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
            cmd.CommandText = "select rsswiseprant from StateMaster where Country=@country and orgwisekshetra=@orgKsh and rsswisekshetra=@rssKsh";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssKsh", ddl_kshetrarss.SelectedItem.Text);
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
            cmd.CommandText = "select govtwiseprant from StateMaster where Country=@country and orgwisekshetra=@orgKsh and rsswisekshetra=@rssKsh and rsswiseprant=@rssPrant";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssKsh", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssPrant", ddl_prant_rss.SelectedItem.Text);
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
            cmd.CommandText = "select orgwiseprant from StateMaster where Country=@country and orgwisekshetra=@orgKsh and rsswisekshetra=@rssKsh";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssKsh", ddl_kshetrarss.SelectedItem.Text);
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
        //ddl_loksabha
        ddl_loksabha.Items.Clear();
        ddl_loksabha.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Loksabha from LoksabhaMaster where prantgovt=@prantgovt and prantorg=@prantorg and Country=@country and kshetraorg=@orgKsh and kshetrarss=@rssKsh";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssKsh", ddl_kshetrarss.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_loksabha.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_loksabha_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_district.Items.Clear();
        ddl_district.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select District from DistrictMaster where prantgovt=@prantgovt and prantorg=@prantorg and Country=@country and kshetraorg=@orgKsh and kshetrarss=@rssKsh and loksabha=@loksabha";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssKsh", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@loksabha", ddl_loksabha.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_district.Items.Add(dr[0].ToString());
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
