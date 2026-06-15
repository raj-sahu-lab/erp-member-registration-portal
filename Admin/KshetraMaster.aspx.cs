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

public partial class Admin_KshetraMaster : System.Web.UI.Page
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
        }     
    }
    void Auto_Gen_ID()
    {
        int ssr_no;
        string sr_ssno;
        ssr_no = 1;
        sr_ssno = "";
        int max_ssr_no;
        max_ssr_no = 0;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select MAX(Sr_No) from KshetraMaster";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                max_ssr_no = Convert.ToInt32(dr[0]);
            }
            else
            {
                max_ssr_no = 0;
                con.Close();
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            lb_Message.Text = "An error occurred. Please try again."; // Exception logged server-side in production
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
            string jv = "<script>alert('Please enter Kshetra ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcomm_id.Focus();
            return;

        }
        if (txtorgwise.Text.Trim() == "")
        {
            string jv = "<script>alert('Organization Wise Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtorgwise.Focus();
            return;
        }
        if (txtrsswise.Text.Trim() == "")
        {
            string jv = "<script>alert('RSS Wise Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtrsswise.Focus();
            return;
        }
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Insert into KshetraMaster(Sr_No, Country, orgwise, rsswise) values(@srNo,@country,@orgwise,@rsswise)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@srNo", txtcomm_id.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
            cmd.Parameters.AddWithValue("@orgwise", txtorgwise.Text);
            cmd.Parameters.AddWithValue("@rsswise", txtrsswise.Text);
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
            lb_Message.Text = "An error occurred. Please try again."; // Exception logged server-side in production
        }
        Clear();
    }   
    void Clear()
    {       
        txtcomm_id.Text = "";
        txtrsswise.Text = "";
        txtorgwise.Focus();
        Auto_Gen_ID();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    //protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_zone.Items.Clear();
    //    ddl_zone.Items.Add("-Select Zone-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    //        cmd.CommandText = "Select Distinct Zone_Name from ZoneMaster Where Country='" + ddl_country.Text + "' Order By Zone_Name";
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_zone.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
    //protected void ddl_zone_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_prant.Items.Clear();
    //    ddl_prant.Items.Add("-Select Prant-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    //        cmd.CommandText = "Select Distinct State_Name from StateMaster Where Country='" + ddl_country.Text + "' AND Zone='" + ddl_zone.Text + "' Order By State_Name";
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_prant.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
}
