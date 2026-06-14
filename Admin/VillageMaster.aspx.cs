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

public partial class Admin_VillageMaster : System.Web.UI.Page
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
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_state.Items.Clear();
        ddl_state.Items.Add("--Select State--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct State_Name from StateMaster Where Country='@country' Order By State_Name";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
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
            cmd.CommandText = "select MAX(Sr_No) from VillageMaster";
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
        if (ddl_state.Text.Trim() == "--Select State--")
        {
            string jv = "<script>alert('State Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_district.Text.Trim() == "-Select-")
        {
            string jv = "<script>alert('District Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (ddl_Vidhansabha.Text.Trim() == "-Select-")
        {
            string jv = "<script>alert('Vidhansabha Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }
        if (txtlabel_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Village Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtlabel_name.Focus();
            return;
        }          
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Insert into VillageMaster(Sr_No, Country, State_Name, District, Vidhansabha, Village) values('@commid','@country','@state','@district','@Vidhansabha','@labelname')";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@commid", txtcomm_id.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
            cmd.Parameters.AddWithValue("@state", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Parameters.AddWithValue("@Vidhansabha", ddl_Vidhansabha.Text);
            cmd.Parameters.AddWithValue("@labelname", txtlabel_name.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
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
        txtlabel_name.Text = "";
        txtlabel_name.Focus();
        Auto_Gen_ID();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
        //ddl_city
    }
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_district.Items.Clear();
            ddl_district.Items.Add("-Select-");           
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Distinct District from DistrictMaster Where State_Name='@state' Order By District";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@state", ddl_state.Text);
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
            lb_Message.Text = ex.Message;
            con.Close();
        }
    }
    protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_Vidhansabha.Items.Clear();
            ddl_Vidhansabha.Items.Add("-Select-");
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Distinct Vidhansabha from CityMaster Where State_Name='@state' AND District='@district' Order By Vidhansabha";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@state", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_Vidhansabha.Items.Add(dr[0].ToString());
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
