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

public partial class Admin_StateMaster : System.Web.UI.Page
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

               ddl_ORGzone.Items.Clear();
               ddl_ORGzone.Items.Add("-Select-");
               try
               {
                   con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                   con.Open();
                   cmd.CommandText = "Select Distinct orgwise from KshetraMaster where Country='Bharat' Order By orgwise";
                   cmd.Connection = con;
                   dr = cmd.ExecuteReader();
                   while (dr.Read())
                   {
                       ddl_ORGzone.Items.Add(dr[0].ToString());
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
        max_ssr_no = 0;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select MAX(Sr_No) from StateMaster";
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
            string jv = "<script>alert('Please enter State ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcomm_id.Focus();
            return;

        }
        if (txtrss_prant_name.Text.Trim() == "")
        {
            string jv = "<script>alert('RSS Wise Prant Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtrss_prant_name.Focus();
            return;
        }
        if (txtorg_prant_name.Text.Trim() == "")
        {
            string jv = "<script>alert('RSS Wise Prant Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtorg_prant_name.Focus();
            return;
        }
        if (txtgovt_prant_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Govt Wise Prant Name can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtgovt_prant_name.Focus();
            return;
        }
        if (txtcode.Text.Trim() == "")
        {
            string jv = "<script>alert('State Code can not be left blank');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcode.Focus();
            return;
        }     
        DateTime regDate = DateTime.Now;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "insert into StateMaster (Sr_No,Country,orgwisekshetra,rsswisekshetra,rsswiseprant,orgwiseprant,govtwiseprant,State_Code) values (@srNo,@country,@orgKsh,@rssKsh,@rssPrant,@orgPrant,@govtPrant,@stateCode)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@srNo", txtcomm_id.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
            cmd.Parameters.AddWithValue("@orgKsh", ddl_ORGzone.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssKsh", ddl_RSSzone.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@rssPrant", txtrss_prant_name.Text);
            cmd.Parameters.AddWithValue("@orgPrant", txtorg_prant_name.Text);
            cmd.Parameters.AddWithValue("@govtPrant", txtgovt_prant_name.Text);
            cmd.Parameters.AddWithValue("@stateCode", txtcode.Text);
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
        txtgovt_prant_name.Text = "";
        txtorg_prant_name.Text = "";
        txtrss_prant_name.Text = "";
       

        Auto_Gen_ID();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_ORGzone.Items.Clear();
        ddl_ORGzone.Items.Add("-Select-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct orgwise from KshetraMaster where Country=@country Order By orgwise";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_ORGzone.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_ORGzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_RSSzone.Items.Clear();
        ddl_RSSzone.Items.Add("-Select-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct rsswise from KshetraMaster where Country=@country and orgwise=@orgwise Order By rsswise";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@orgwise", ddl_ORGzone.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_RSSzone.Items.Add(dr[0].ToString());
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
