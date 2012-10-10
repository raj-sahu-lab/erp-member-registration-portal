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

public partial class Admin_masterfilter : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    string qry = @"select distinct Reg_ID, convert(char(10), Reg_Date, 103) as Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality,
Marriage_Date, Anniversary_Date, No_of_Family_Member,aadhar,Presentorganization,
Address,Address1,Address2,rastra1,kshetraorg1,kshetrarss1,prantrss1,prantorg1,prantgovt1,loksabha1,district1,vidhansabha1,tehsil1,nagar1,upnagar1,pincode1,fax1,landno11,landno12,rastra2,kshetraorg2,kshetrarss2,prantrss2,prantorg2,prantgovt2,loksabha2,district2,vidhansabha2,tehsil2,nagar2,upnagar2,pincode2,fax2,landno21,landno22,rastra3,kshetraorg3,kshetrarss3,prantrss3,prantorg3,prantgovt3,loksabha3,district3,vidhansabha3,tehsil3,nagar3,upnagar3,pincode3,fax3,landno31,landno32,
Email_ID1, Email_ID2,Email_ID3,Email_ID4,
Contact_No1, Contact_No2, Contact_No3, Contact_No4,bloglink,fblink,website,twitter,linkedIn,   
Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, 
Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, 
Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2,
Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, 
Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4,
ASr_No1, Hobbies1, Extra_Activities1, 
ASr_No2, Hobbies2,Extra_Activities2,
ASr_No3, Hobbies3, Extra_Activities3,
ASr_No4, Hobbies4, Extra_Activities4,
ASr_No5, Hobbies5, Extra_Activities5,Achievements, Future_Ambition, 
Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose,
 Memo_Discription,rastra4 ,kshetraorg4,kshetrarss4,prantrss4,prantorg4,prantgovt4,loksabha4,district4,vidhansabha4,
tehsil4,nagar4,upnagar4,pincode4,Sr_No, Organization, RSSDesignation,From_Date, To_Date,Achievement_During_Work,
Additional_Remark,present_past,sanghsiksha,level,vicharpariwar,familymembername,rss_member_id From RSS_Registration";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
            ddlrssdesignation.Items.Clear();

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "select distinct Designation_Name from DesignationMaster";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlrssdesignation.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddlrssdesignation.Items.Insert(0, "---select---");
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

            ddl_qualification.Items.Clear();

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Qualification_Name from QualificationMaster";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_qualification.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                con.Close();
            }
            ddl_qualification.Items.Insert(0, "---select---");
            ddl_organization1.Items.Clear();

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Organization_Name from OrganizationMaster Order By Organization_Name";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_organization1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddl_organization1.Items.Insert(0, "---select---");
            //
            ddloccupation.Items.Clear();

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Occupation_Name from OccupationMaster Order By Occupation_Name";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddloccupation.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddloccupation.Items.Insert(0, "---select---");
            ddl_rsslevel.Items.Clear();

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Level_Name from RSSLevelMaster Order By Level_Name";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_rsslevel.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddl_rsslevel.Items.Insert(0, "---select---");
            try
            {
                HiddenField1.Value = "";
                HiddenField1.Value = HiddenField1.Value + " where rastra1='" + ddl_country.SelectedItem.Text + "'";
                Upliner_Details();
            }
            catch
            {
                HiddenField1.Value = "";
                Upliner_Details();
            }

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
            ddl_organization_training.Items.Clear();
            ddl_organization_training.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "select varsh_name from VarshMaster";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_organization_training.Items.Add(dr[0].ToString());
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


    //protected void ddl_kshetraorg_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_kshetrarss.Items.Clear();
    //    ddl_kshetrarss.Items.Add("--Select--");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    //        cmd.CommandText = "select rsswisekshetra from StateMaster where Country='" + ddl_country.SelectedItem.Text + "' and orgwisekshetra='" + ddl_kshetraorg.SelectedItem.Text + "'";
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_kshetrarss.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //    HiddenField1.Value = HiddenField1.Value + " and kshetraorg1='" + ddl_kshetraorg.SelectedItem.Text + "'";
    //    Upliner_Details();
    //}

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
        HiddenField1.Value = HiddenField1.Value + " and kshetraorg1='" + ddl_kshetraorg.SelectedItem.Text + "'";
        Upliner_Details();
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
        HiddenField1.Value = HiddenField1.Value + " and kshetrarss1='" + ddl_kshetrarss.SelectedItem.Text + "'";
        Upliner_Details();
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
        HiddenField1.Value = HiddenField1.Value + " and prantorg1='" + ddl_prant_org.SelectedItem.Text + "'";
        Upliner_Details();

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
        HiddenField1.Value = HiddenField1.Value + " and prantrss1='" + ddl_prant_rss.SelectedItem.Text + "'";
        Upliner_Details();

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
        HiddenField1.Value = HiddenField1.Value + " and prantgovt1='" + ddl_prant_govt.SelectedItem.Text + "'";
        Upliner_Details();

    }
    protected void ddl_lokshabhaname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_distr.Items.Clear();
        ddl_distr.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select District from DistrictMaster where Country='" + ddl_country.SelectedItem.Text + "' and kshetraorg='" + ddl_kshetraorg.SelectedItem.Text + "' and kshetrarss='" + ddl_kshetrarss.SelectedItem.Text + "' and prantrss='" + ddl_prant_rss.SelectedItem.Text + "' and prantorg='" + ddl_prant_org.SelectedItem.Text + "' and prantgovt='" + ddl_prant_govt.SelectedItem.Text + "' and loksabha='" + ddl_lokshabhaname.SelectedItem.Text + "' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_distr.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        HiddenField1.Value = HiddenField1.Value + " and loksabha1='" + ddl_lokshabhaname.SelectedItem.Text + "'";
        Upliner_Details();

    }
    protected void ddl_distr_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_vidhansabha.Items.Clear();
        ddl_vidhansabha.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Vidhansabha from CityMaster where Country='" + ddl_country.SelectedItem.Text + "' and kshetraorg='" + ddl_kshetraorg.SelectedItem.Text + "' and kshetrarss='" + ddl_kshetrarss.SelectedItem.Text + "' and prantrss='" + ddl_prant_rss.SelectedItem.Text + "' and prantorg='" + ddl_prant_org.SelectedItem.Text + "' and prantgovt='" + ddl_prant_govt.SelectedItem.Text + "' and loksabha='" + ddl_lokshabhaname.SelectedItem.Text + "' and District='" + ddl_distr.SelectedItem.Text + "' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_vidhansabha.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        HiddenField1.Value = HiddenField1.Value + " and district1='" + ddl_distr.SelectedItem.Text + "'";
        Upliner_Details();

    }
    protected void ddl_vidhansabha_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_tehsil.Items.Clear();
        ddl_tehsil.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Tehsil from TehsilMaster where Country='" + ddl_country.SelectedItem.Text + "' and kshetraorg='" + ddl_kshetraorg.SelectedItem.Text + "' and kshetrarss='" + ddl_kshetrarss.SelectedItem.Text + "' and prantrss='" + ddl_prant_rss.SelectedItem.Text + "' and prantorg='" + ddl_prant_org.SelectedItem.Text + "' and prantgovt='" + ddl_prant_govt.SelectedItem.Text + "' and loksabha='" + ddl_lokshabhaname.SelectedItem.Text + "' and District='" + ddl_distr.SelectedItem.Text + "' and vidhansabha='" + ddl_vidhansabha.SelectedItem.Text + "' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_tehsil.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        HiddenField1.Value = HiddenField1.Value + " and vidhansabha1='" + ddl_vidhansabha.SelectedItem.Text + "'";
        Upliner_Details();
    }
    protected void ddl_tehsil_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_nagar.Items.Clear();
        ddl_nagar.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Nagar from NagarMaster where Country='" + ddl_country.SelectedItem.Text + "' and kshetraorg='" + ddl_kshetraorg.SelectedItem.Text + "' and kshetrarss='" + ddl_kshetrarss.SelectedItem.Text + "' and prantrss='" + ddl_prant_rss.SelectedItem.Text + "' and prantorg='" + ddl_prant_org.SelectedItem.Text + "' and prantgovt='" + ddl_prant_govt.SelectedItem.Text + "' and loksabha='" + ddl_lokshabhaname.SelectedItem.Text + "' and District='" + ddl_distr.SelectedItem.Text + "' and vidhansabha='" + ddl_vidhansabha.SelectedItem.Text + "' and tehsil='" + ddl_tehsil.SelectedItem.Text + "' ";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_nagar.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        HiddenField1.Value = HiddenField1.Value + " and tehsil1='" + ddl_tehsil.SelectedItem.Text + "'";
        Upliner_Details();
        //   ddl_tehsil.Enabled = false;

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

        try
        {
            HiddenField1.Value = "";
            HiddenField1.Value = HiddenField1.Value + " where rastra1='" + ddl_country.SelectedItem.Text + "'";
            Upliner_Details();

        }
        catch
        {
            HiddenField1.Value = "";
            Upliner_Details();
        }


    }

    void Upliner_Details()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();


        //string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age,Email_ID3,Email_ID4, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Order By Reg_ID";

        qry = qry + HiddenField1.Value.ToString();
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }


    public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();
        SqlCommand cmd = new SqlCommand(commandText);
        cmd.CommandType = commandType;
        cmd.CommandTimeout = 500;
        cmd.Connection = cn;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Parameters.Clear();
        foreach (SqlParameter PR in commandParameters)
        {
            cmd.Parameters.Add(PR);
        }

        da.SelectCommand = cmd;
        da.Fill(ds);
        cn.Close();
        cn.Dispose();
        da.Dispose();
        return ds.Tables[0];
    }

    public void show()
    {

        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        qry = @"select distinct Reg_ID, convert(char(10), Reg_Date, 103) as Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality,
Marriage_Date, Anniversary_Date, No_of_Family_Member,aadhar,Presentorganization,
Address,Address1,Address2,rastra1,kshetraorg1,kshetrarss1,prantrss1,prantorg1,prantgovt1,loksabha1,district1,vidhansabha1,tehsil1,nagar1,upnagar1,pincode1,fax1,landno11,landno12,rastra2,kshetraorg2,kshetrarss2,prantrss2,prantorg2,prantgovt2,loksabha2,district2,vidhansabha2,tehsil2,nagar2,upnagar2,pincode2,fax2,landno21,landno22,rastra3,kshetraorg3,kshetrarss3,prantrss3,prantorg3,prantgovt3,loksabha3,district3,vidhansabha3,tehsil3,nagar3,upnagar3,pincode3,fax3,landno31,landno32,
Email_ID1, Email_ID2,Email_ID3,Email_ID4,
Contact_No1, Contact_No2, Contact_No3, Contact_No4,bloglink,fblink,website,twitter,linkedIn,   
Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, 
Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, 
Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2,
Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, 
Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4,
ASr_No1, Hobbies1, Extra_Activities1, 
ASr_No2, Hobbies2,Extra_Activities2,
ASr_No3, Hobbies3, Extra_Activities3,
ASr_No4, Hobbies4, Extra_Activities4,
ASr_No5, Hobbies5, Extra_Activities5,Achievements, Future_Ambition, 
Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose,
 Memo_Discription,rastra4 ,kshetraorg4,kshetrarss4,prantrss4,prantorg4,prantgovt4,loksabha4,district4,vidhansabha4,
tehsil4,nagar4,upnagar4,pincode4,Sr_No, Organization, RSSDesignation,From_Date, To_Date,Achievement_During_Work,
Additional_Remark,present_past,sanghsiksha,level,vicharpariwar,familymembername,rss_member_id From RSS_Registration";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }

    protected void ddl_nagar_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_upnagar.Items.Clear();
        ddl_upnagar.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select upnagar from Upnagarmaster where Nagar='" + ddl_nagar.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_upnagar.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        HiddenField1.Value = HiddenField1.Value + " and nagar1='" + ddl_nagar.SelectedItem.Text + "'";
        Upliner_Details();
        //   ddl_nagar.Enabled = false;
    }
    protected void ddl_upnagar_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenField1.Value = HiddenField1.Value + " and upnagar1='" + ddl_upnagar.SelectedItem.Text + "'";
        Upliner_Details();
        ddl_upnagar.Enabled = false;
    }
    protected void Paging_UplinerDetails(object sender, GridViewPageEventArgs e)
    {
        GV_personal_details.PageIndex = e.NewPageIndex;
        Upliner_Details();
    }
    protected void ddl_ocass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlrssdesignation.SelectedItem.Text == "---select---")
        //{
        //}
        //else
        //{
        //    HiddenField1.Value = HiddenField1.Value + " and RSSDesignation='" + ddlrssdesignation.SelectedItem.Text + "'";
        //    Upliner_Details();
        //    ddlrssdesignation.Enabled = false;
        //}
    }
    protected void ddlsex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsex.SelectedItem.Text == "--Select--")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and Sex='" + ddlsex.SelectedItem.Text + "'";
            Upliner_Details();
            ddlsex.Enabled = false;
        }
    }
    protected void ddl_age_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_age.SelectedItem.Text == "--Select--")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and Age>='" + ddl_age.SelectedItem.Text + "' and Age<='" + ddl_toage.SelectedItem.Text + "'";
            Upliner_Details();
            ddl_age.Enabled = false;
        }
    }
    protected void ddl_organization1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Select Distinct Organization_Name from OrganizationMaster Order By Organization_Name
        if (ddl_organization1.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and Presentorganization='" + ddl_organization1.SelectedItem.Text + "'";
            Upliner_Details();
            ddl_organization1.Enabled = false;
        }

    }
    protected void ddl_rsslevel_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddl_rsslevel.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and level='" + ddl_rsslevel.SelectedItem.Text + "'";
            Upliner_Details();
            ddl_rsslevel.Enabled = false;
        }
        ddl_org_desig.Items.Clear();
        ddl_org_desig.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select designation_name from RSSDesignationMaster where level_name='" + ddl_rsslevel.SelectedItem.Text + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_org_desig.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddloccupation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Select Distinct Occupation_Name from OccupationMaster Order By Occupation_Name
        if (ddloccupation.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and Occupation='" + ddloccupation.SelectedItem.Text + "'";
            Upliner_Details();
            ddloccupation.Enabled = false;
        }
    }
    protected void ddl_qualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_qualification.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and Qualification='" + ddl_qualification.SelectedItem.Text + "'";
            Upliner_Details();
            ddl_qualification.Enabled = false;
        }
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {

    }
    protected void ddl_ocass1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrssdesignation.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and RSSDesignation='" + ddlrssdesignation.SelectedItem.Text + "'";
            Upliner_Details();
            ddlrssdesignation.Enabled = false;
        }
    }
    protected void ddl_organization_training_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_organization_training.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and sanghsiksha='" + ddl_organization_training.SelectedItem.Text + "'";
            Upliner_Details();
            ddl_organization_training.Enabled = false;
        }
    }


    protected void ddl_org_desig_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_org_desig.SelectedItem.Text == "---select---")
        {
        }
        else
        {
            HiddenField1.Value = HiddenField1.Value + " and sanghsiksha='" + ddl_org_desig.SelectedItem.Text + "'";
            Upliner_Details();
            ddl_org_desig.Enabled = false;
        }
    }
}