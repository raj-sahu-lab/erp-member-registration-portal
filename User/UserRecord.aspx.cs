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

public partial class User_UserRecord : System.Web.UI.Page
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
            lb_date.Text = regDate.ToString();
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
            cmd.CommandText = "select * from MLMRegistration where Upliner_ID='" + u_id + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtsponsor_no.Text = dr[0].ToString();
                txtuser_id.Text = dr[1].ToString();
                ddl_binary_side.Text = dr[3].ToString();
                ddl_head1.Text = dr[4].ToString();
                txtuser_name.Text = dr[5].ToString();
                txtuser_dob.Text = dr[6].ToString();
                txtf_h_name.Text = dr[7].ToString();
                txtaddress.Text = dr[8].ToString();
                txtemail.Text = dr[9].ToString();
                txtcity.Text = dr[10].ToString();
                txtstate.Text = dr[11].ToString();
                txtpincode.Text = dr[12].ToString();
                txtmobile_no.Text = dr[13].ToString();
                ddl_sex.Text = dr[14].ToString();
                ddlnationality.Text = dr[15].ToString();
                txtac_holder_name.Text = dr[16].ToString();
                txtacc_no.Text = dr[17].ToString();
                txtbank_name.Text = dr[18].ToString();
                txtifsc_code.Text = dr[19].ToString();
                txtpan_no.Text = dr[20].ToString();
                ddl_head2.Text = dr[21].ToString();
                txtnominee_name.Text = dr[22].ToString();
                txtnominee_dob.Text = dr[23].ToString();
                ddlrelation.Text = dr[24].ToString();
                lb_date.Text = dr[25].ToString();
                ddlid_proof.Text = dr[27].ToString();
                ddladdress_proof.Text = dr[28].ToString();
                txtspil_sponsorname.Text = dr[31].ToString();
                txtspil_sponsorno.Text = dr[32].ToString();
                txtsponsor_name.Text = dr[34].ToString();
                txtbranch_name.Text = dr[35].ToString();
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
        txtsponsor_no.Text = "";
        txtuser_id.Text = "";
        ddl_binary_side.Text = "--Select--";
        ddl_head1.Text = "--Select--";
        txtuser_name.Text = "";
        txtuser_dob.Text = "";
        txtf_h_name.Text = "";
        txtaddress.Text = "";
        txtemail.Text = "";
        txtcity.Text = "";
        txtstate.Text = "--Select--";
        txtpincode.Text = "";
        txtmobile_no.Text = "";
        ddl_sex.Text = "--Select--";
        ddlnationality.Text = "--Select--";
        txtac_holder_name.Text = "";
        txtacc_no.Text = "";
        txtbank_name.Text = "";
        txtifsc_code.Text = "";
        txtpan_no.Text = "";
        ddl_head2.Text = "--Select--";
        txtnominee_name.Text = "";
        txtnominee_dob.Text = "";
        ddlrelation.Text = "--Relationship--";
        lb_date.Text = "";      
        ddlid_proof.Text = "--Select--";
        ddladdress_proof.Text = "--Select--";       
        txtsponsor_name.Text = "";
        txtspil_sponsorno.Text = "";
        txtsponsor_name.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtsponsor_no.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Sponsor ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtsponsor_no.Focus();
            return;

        }       
        if (ddl_binary_side.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Binary Side');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_binary_side.Focus();
            return;

        }
        if (ddl_binary_side.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Please Select Binary Side');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_binary_side.Focus();
            return;

        }
        if (txtuser_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Applicant Name');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtuser_name.Focus();
            return;

        }
        if (txtuser_dob.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Date of Birth/Age');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtuser_dob.Focus();
            return;

        }
        if (txtf_h_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Father Name');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtf_h_name.Focus();
            return;

        }
        if (txtaddress.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Postal Address');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtaddress.Focus();
            return;

        }

        if (txtcity.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter City ');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtcity.Focus();
            return;

        }
        if (txtstate.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Please select State ');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtstate.Focus();
            return;

        }

        if (txtmobile_no.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Contact No');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtmobile_no.Focus();
            return;

        }
        if (ddl_sex.Text.Trim() == "--Select--")
        {
            string jv = "<script>alert('Please select Sex ');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_sex.Focus();
            return;

        }
        if (ddlnationality.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Nationality ');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddlnationality.Focus();
            return;

        }
        if (txtnominee_name.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Nominee Name ');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtnominee_name.Focus();
            return;

        }
        if (txtspil_sponsorname.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Speel Sponsor Name');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtspil_sponsorname.Focus();
            return;

        }
        if (txtspil_sponsorno.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Speel Sponsor No');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtspil_sponsorno.Focus();
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
            cmd.CommandText = "Update MLMRegistration Set Sponsor_ID='" + txtsponsor_no.Text + "',Plan_No='0',Binary_Side='" + ddl_binary_side.Text + "',Name_Title='" + ddl_head1.Text + "',Name='" + txtuser_name.Text + "',DOB='" + txtuser_dob.Text + "',F_H_Name='" + txtf_h_name.Text + "',Postal_Address='" + txtaddress.Text + "',Email='" + txtemail.Text + "',City='" + txtcity.Text + "',State='" + txtstate.Text + "',Pin_Code='" + txtpincode.Text + "',Contact_No='" + txtmobile_no.Text + "',Sex='" + ddl_sex.Text + "',Nationality='" + ddlnationality.Text + "',Nominee_Title='" + ddl_head2.Text + "',Nominee_Name='" + txtnominee_name.Text + "',Nominee_DOB='" + txtnominee_dob.Text + "',Relation='" + ddlrelation.Text + "',Registration_Date='" + regDate + "',Acc_Holder_Name='" + txtac_holder_name.Text + "',Account_No='" + txtacc_no.Text + "',Bank_Branch_Name='" + txtbank_name.Text + "',Bank_IFSC_Code='" + txtifsc_code.Text + "',Pan_No='" + txtpan_no.Text + "',ID_Proof='" + ddlid_proof.Text + "',Address_Proof='" + ddladdress_proof.Text + "',Speel_SponsorName='" + txtspil_sponsorname.Text + "',Speel_SponsorNo='" + txtspil_sponsorno.Text + "',Proposer_Type='NONE',Sponsor_Name='" + txtsponsor_name.Text + "',Branch_Name='" + txtbranch_name.Text + "' Where Upliner_ID='" + txtuser_id.Text + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();           
            string jv1 = "<script>alert('Record has been Updated');</script>";
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
            Label36.Text = ex.Message;
            return;
        }
        Clear();
    }
}