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
using System.IO;
public partial class Admin_Registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    string userId;
    string familyname = "";
    string memberid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillddl();
            DateTime regDate = DateTime.Now;
            string regDate1 = Convert.ToString(DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year);
            txtdate.Text = regDate1.ToString();
            //if (Session["Login_ID"].ToString() == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}  
            AutoLoadData();
            regid();
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
                    ddl_country1.Items.Add(dr[0].ToString());
                    ddl_country2.Items.Add(dr[0].ToString());
                    ddl_country3.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddl_country.SelectedItem.Text = "Bharat";
            ddl_country1.SelectedItem.Text = "Bharat";
            ddl_country2.SelectedItem.Text = "Bharat";
            ddl_country3.SelectedItem.Text = "Bharat";
            ddl_kshetraorg.Items.Clear();
            ddl_kshetraorg.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country'";
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
            ddl_kshetraorg1.Items.Clear();
            ddl_kshetraorg1.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country1'";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@country1", ddl_country1.Text);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_kshetraorg1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddl_kshetraorg2.Items.Clear();
            ddl_kshetraorg2.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country2'";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_kshetraorg2.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddl_kshetraorg3.Items.Clear();
            ddl_kshetraorg3.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country3'";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_kshetraorg3.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            ddl_sanghsiksha.Items.Clear();
             ddl_sanghsiksha.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "select distinct Varsh_Name from VarshMaster";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_sanghsiksha.Items.Add(dr[0].ToString());
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
    public void clearr()
    {
        ddl_country1.Items.Clear();
        ddl_kshetraorg1.Items.Clear();
        ddl_kshetrarss1.Items.Clear();
        ddl_prant_rss1.Items.Clear();
        ddl_prant_org1.Items.Clear();
        ddl_prant_govt1.Items.Clear();
        ddl_lokshabhaname1.Items.Clear();
        ddl_distr1.Items.Clear();
        ddl_vidhansabha1.Items.Clear();
        ddl_tehsil1.Items.Clear();
        ddl_nagar1.Items.Clear();
        ddl_upnagar1.Items.Clear();
        ddl_country2.Items.Clear();
        ddl_kshetraorg2.Items.Clear();
        ddl_kshetrarss2.Items.Clear();
        ddl_prant_rss2.Items.Clear();
        ddl_prant_org2.Items.Clear();
        ddl_prant_govt2.Items.Clear();
        ddl_lokshabhaname2.Items.Clear();
        ddl_distr2.Items.Clear();
        ddl_vidhansabha2.Items.Clear();
        ddl_tehsil2.Items.Clear();
        ddl_nagar2.Items.Clear();
        ddl_upnagar2.Items.Clear();
        ddl_country.Items.Clear();
        ddl_kshetraorg.Items.Clear();
        ddl_kshetrarss.Items.Clear();
        ddl_prant_rss.Items.Clear();
        ddl_prant_org.Items.Clear();
        ddl_prant_govt.Items.Clear();
        ddl_lokshabhaname.Items.Clear();
        ddl_distr.Items.Clear();
        ddl_vidhansabha.Items.Clear();
        ddl_tehsil.Items.Clear();
        ddl_nagar.Items.Clear();
        ddl_upnagar.Items.Clear();
        ddlspecialization.Items.Clear();
        ddlspecialization1.Items.Clear();
        ddlspelization2.Items.Clear();
        ddlspecialization4.Items.Clear();
        ddlspecialization5.Items.Clear();
        ddlspecialization6.Items.Clear();
        ddl_country3.Items.Clear();
        ddl_kshetraorg3.Items.Clear();
        ddl_kshetrarss3.Items.Clear();
        ddl_prant_rss3.Items.Clear();
        ddl_prant_org3.Items.Clear();
        ddl_prant_govt3.Items.Clear();
        ddl_lokshabhaname3.Items.Clear();
        ddl_distr3.Items.Clear();
        ddl_vidhansabha3.Items.Clear();
        ddl_tehsil3.Items.Clear();
        ddl_nagar3.Items.Clear();
        ddl_upnagar3.Items.Clear();
    }
    public void fillddl()
    {
        ddl_country1.Items.Clear();
        ddl_country1.Items.Insert(0, "---select---");
        ddl_kshetraorg1.Items.Insert(0, "---select---");
        ddl_kshetrarss1.Items.Insert(0, "---select---");
        ddl_prant_rss1.Items.Insert(0, "---select---");
        ddl_prant_org1.Items.Insert(0, "---select---");
        ddl_prant_govt1.Items.Insert(0, "---select---");
        ddl_lokshabhaname1.Items.Insert(0, "---select---");
        ddl_distr1.Items.Insert(0, "---select---");
        ddl_vidhansabha1.Items.Insert(0, "---select---");
        ddl_tehsil1.Items.Insert(0, "---select---");
        ddl_nagar1.Items.Insert(0, "---select---");
        ddl_upnagar1.Items.Insert(0, "---select---");
        ddl_country2.Items.Insert(0, "---select---");
        ddl_kshetraorg2.Items.Insert(0, "---select---");
        ddl_kshetrarss2.Items.Insert(0, "---select---");
        ddl_prant_rss2.Items.Insert(0, "---select---");
        ddl_prant_org2.Items.Insert(0, "---select---");
        ddl_prant_govt2.Items.Insert(0, "---select---");
        ddl_lokshabhaname2.Items.Insert(0, "---select---");
        ddl_distr2.Items.Insert(0, "---select---");
        ddl_vidhansabha2.Items.Insert(0, "---select---");
        ddl_tehsil2.Items.Insert(0, "---select---");
        ddl_nagar2.Items.Insert(0, "---select---");
        ddl_upnagar2.Items.Insert(0, "---select---");
        ddl_country.Items.Insert(0, "---select---");
        ddl_kshetraorg.Items.Insert(0, "---select---");
        ddl_kshetrarss.Items.Insert(0, "---select---");
        ddl_prant_rss.Items.Insert(0, "---select---");
        ddl_prant_org.Items.Insert(0, "---select---");
        ddl_prant_govt.Items.Insert(0, "---select---");
        ddl_lokshabhaname.Items.Insert(0, "---select---");
        ddl_distr.Items.Insert(0, "---select---");
        ddl_vidhansabha.Items.Insert(0, "---select---");
        ddl_tehsil.Items.Insert(0, "---select---");
        ddl_nagar.Items.Insert(0, "---select---");
        ddl_upnagar.Items.Insert(0, "---select---");
        ddlspecialization.Items.Insert(0, "---select---");
        ddlspecialization1.Items.Insert(0, "---select---");
        ddlspelization2.Items.Insert(0, "---select---");
        ddlspecialization4.Items.Insert(0, "---select---");
        ddlspecialization5.Items.Insert(0, "---select---");
        ddlspecialization6.Items.Insert(0, "---select---");
        ddl_country3.Items.Insert(0, "---select---");
        ddl_kshetraorg3.Items.Insert(0, "---select---");
        ddl_kshetrarss3.Items.Insert(0, "---select---");
        ddl_prant_rss3.Items.Insert(0, "---select---");
        ddl_prant_org3.Items.Insert(0, "---select---");
        ddl_prant_govt3.Items.Insert(0, "---select---");
        ddl_lokshabhaname3.Items.Insert(0, "---select---");
        ddl_distr3.Items.Insert(0, "---select---");
        ddl_vidhansabha3.Items.Insert(0, "---select---");
        ddl_tehsil3.Items.Insert(0, "---select---");
        ddl_nagar3.Items.Insert(0, "---select---");
        ddl_upnagar3.Items.Insert(0, "---select---");

    }
    void AutoLoadData()
    {
        ddlorganization_serving.Items.Clear();
        //  ddl_zone.Items.Clear();
        //     ddl_zone1.Items.Clear();
        //  ddl_zone2.Items.Clear();
        ddlarea_of_work.Items.Clear();
        //ddlplace_of_work.Items.Clear();
        ddlvarsh_attended.Items.Clear();
        ddlspecialization.Items.Clear();
        ddlspecialization4.Items.Clear();
        ddloccupation.Items.Clear();
        ddlassign_work.Items.Clear();
        ddlrssdesignation.Items.Clear();
        ddl_organization1.Items.Clear();
        ddl_occasion.Items.Clear();
        ddl_sanghsiksha.Items.Clear();
        ddl_rsslevel.Items.Clear();
        ddlorganization_serving.Items.Add("--Select Organization--");
        ddlarea_of_work.Items.Add("--Select Work Area--");
        //   ddlplace_of_work.Items.Add("--Select Work Place--");
        ddlvarsh_attended.Items.Add("--Select Varsh--");
        ddlspecialization.Items.Add("--Select Specialization--");
        ddlspecialization4.Items.Add("--Select Specialization--");
        ddloccupation.Items.Add("--Select Occupation--");
        ddlassign_work.Items.Add("--Select Assign Work--");
        ddlrssdesignation.Items.Add("-Select Designation-");
        ddl_organization1.Items.Add("--Select Organization--");
        ddl_occasion.Items.Add("--Select Occasion--");
        ddl_sanghsiksha.Items.Add("--Select--");
        ddl_rsslevel.Items.Add("--Select Level--");
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        con.Open();
        cmd.CommandText = "Select Distinct SanghShiksha_Name from SanghShikshaMaster Order By SanghShiksha_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl_sanghsiksha.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Level_Name from RSSLevelMaster Order By Level_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl_rsslevel.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Designation_Name from RSSDesignationMaster Order By Designation_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlrssdesignation.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Occasion_Name from OccasionMaster Order By Occasion_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl_occasion.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct WorkArea_Name from WorkAreaMaster Order By WorkArea_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlarea_of_work.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct District from DistrictMaster Order By District";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            //        ddlplace_of_work.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Varsh_Name, Sr_No from VarshMaster Order By Sr_No";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlvarsh_attended.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Specialization_Name from SpecializationMaster Order By Specialization_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlspecialization.Items.Add(dr[0].ToString());
            ddlspecialization4.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Organization_Name from OrganizationMaster Order By Organization_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlorganization_serving.Items.Add(dr[0].ToString());
            ddl_organization1.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Occupation_Name from OccupationMaster Order By Occupation_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddloccupation.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct WorkAssign from WorkAssignMaster Order By WorkAssign";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlassign_work.Items.Add(dr[0].ToString());
        }
        dr.Close();
        con.Close();
    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_kshetraorg.Items.Clear();
        ddl_kshetraorg.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
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
    //}
    // protected void ddl_country1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_state1.Items.Clear();
    //    ddl_state1.Items.Add("-Select State-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    cmd.CommandText = @"Select Distinct State_Name from StateMaster Where Country='@country1' Order By State_Name";
    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@country1", ddl_country1.Text);
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_state1.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
    //protected void ddl_state1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_district1.Items.Clear();
    //    ddl_district1.Items.Add("-Select District-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    cmd.CommandText = @"Select Distinct District from DistrictMaster Where Country='India' AND State_Name='@state1' Order By District";
    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@state1", ddl_state1.Text);
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_district1.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
    //protected void ddl_district1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_city1.Items.Clear();
    //    ddl_city1.Items.Add("-Select Vidhansabha-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    cmd.CommandText = @"Select Distinct Vidhansabha from CityMaster Where Country='India' AND State_Name='@state1' AND District='@district1' Order By Vidhansabha";
    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@state1", ddl_state1.Text);
    cmd.Parameters.AddWithValue("@district1", ddl_district1.Text);
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_city1.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
    //protected void ddl_city1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_zone1.Items.Clear();
    //    ddl_zone1.Items.Add("-Select Village-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    cmd.CommandText = @"Select Distinct Village from VillageMaster Where Country='India' AND State_Name='@state1' AND District='@district1' AND Vidhansabha='@city1' Order By Village";
    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@state1", ddl_state1.Text);
    cmd.Parameters.AddWithValue("@district1", ddl_district1.Text);
    cmd.Parameters.AddWithValue("@city1", ddl_city1.Text);
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_zone1.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
    //protected void ddl_city2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddl_zone2.Items.Clear();
    //    ddl_zone2.Items.Add("-Select Village-");
    //    try
    //    {
    //        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    //        con.Open();
    cmd.CommandText = @"Select Distinct Village from VillageMaster Where Country='India' AND State_Name='@state2' AND District='@district2' AND Vidhansabha='@city2' Order By Village";
    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@state2", ddl_state2.Text);
    cmd.Parameters.AddWithValue("@district2", ddl_district2.Text);
    cmd.Parameters.AddWithValue("@city2", ddl_city2.Text);
    //        cmd.Connection = con;
    //        dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            ddl_zone2.Items.Add(dr[0].ToString());
    //        }
    //        dr.Close();
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //    }
    //}
    protected void ddlspecialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspecialization1.Items.Clear();
        ddlspecialization1.Items.Add("--Select Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Sub_Specialization from SubSpeclMaster Where Specialization_Name='@ddlspecialization' Order By Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddlspecialization", ddlspecialization.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspecialization1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspelization2.Items.Clear();
        ddlspelization2.Items.Add("--Select Sub-Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Sub_Sub_Specialization from Sub_SubSpeclMaster Where Specialization_Name='@ddlspecialization' AND Sub_Specialization='@ddlspecialization1' Order By Sub_Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddlspecialization", ddlspecialization.Text);
            cmd.Parameters.AddWithValue("@ddlspecialization1", ddlspecialization1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspelization2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization4_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspecialization5.Items.Clear();
        ddlspecialization5.Items.Add("--Select Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Sub_Specialization from SubSpeclMaster Where Specialization_Name='@ddlspecialization4' Order By Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddlspecialization4", ddlspecialization4.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspecialization5.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization5_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspecialization6.Items.Clear();
        ddlspecialization6.Items.Add("--Select Sub-Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Sub_Sub_Specialization from Sub_SubSpeclMaster Where Specialization_Name='@ddlspecialization4' AND Sub_Specialization='@ddlspecialization5' Order By Sub_Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddlspecialization4", ddlspecialization4.Text);
            cmd.Parameters.AddWithValue("@ddlspecialization5", ddlspecialization5.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspecialization6.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void btnfileupload_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please select Reg ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }

        if (fileImage.HasFile == true)
        {
            string ext = System.IO.Path.GetExtension(this.fileImage.PostedFile.FileName);
            if (ext != ".jpg" && ext != ".JPG" && ext != ".jpeg")
            {

                string jv = "<script>alert('Please upload jpg/jpeg only');</script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                return;
            }
            if (Directory.Exists(Server.MapPath("~/Img_Member/")) == false)
            {
                Directory.CreateDirectory(Server.MapPath("~/Img_Member/"));
            }
            string file_name = "~/Img_Member/" + (txtname.Text + DateTime.Now.ToString()).Replace("&", "").Replace("/", "").Replace("'", "").Replace(" ", "").Replace("AM", "").Replace("PM", "").Replace(":", "") + Path.GetExtension(fileImage.FileName);
            fileImage.SaveAs(Server.MapPath(file_name));
            hidden_img.Value = file_name;
            Image3.ImageUrl = file_name;
        }

    }
    protected void btnmemoupload_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please select Reg ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
        if (FileUpload1.HasFile == true)
        {
            string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
            //if (ext != ".jpg" )
            //{
            //    d.messagebox("Please upload jpg only", this);
            //    return;
            //}
            if (Directory.Exists(Server.MapPath("~/Memo_Photo/")) == false)
            {
                Directory.CreateDirectory(Server.MapPath("~/Memo_Photo/"));
            }
            string file_name = "~/Memo_Photo/" + (txtname.Text + DateTime.Now.ToString()).Replace("&", "").Replace("/", "").Replace("'", "").Replace(" ", "").Replace("AM", "").Replace("PM", "").Replace(":", "") + Path.GetExtension(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath(file_name));
            hidden_memo.Value = file_name;
            Image1.ImageUrl = file_name;
        }


    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Add(ddlorganization_serving.SelectedItem.ToString());
        ListBox10.Items.Add(ddlrssdesignation.SelectedItem.ToString());
        ListBox2.Items.Add(txtorg_date_from.Text);
        ListBox3.Items.Add(txtorg_date_to.Text);
        ListBox4.Items.Add(ddlarea_of_work.SelectedItem.ToString());
        ListBox5.Items.Add(ddl_present_past.SelectedItem.Text);
        ListBox6.Items.Add(txtachievement_work.Text);
        ListBox7.Items.Add(txtadditional_remarks.Text);
        ListBox8.Items.Add(ddl_distr3.SelectedItem.Text.ToString());
        ListBox9.Items.Add(ddl_nagar3.SelectedItem.Text.ToString());
        ListBoxcountry.Items.Add(ddl_country3.SelectedItem.Text.ToString());
        ListBoxkshetraorg.Items.Add(ddl_kshetraorg3.SelectedItem.Text.ToString());
        ListBoxkshetrarss.Items.Add(ddl_kshetrarss3.SelectedItem.Text.ToString());
        ListBoxprant_rss.Items.Add(ddl_prant_rss3.SelectedItem.Text.ToString());
        ListBoxprant_org.Items.Add(ddl_prant_org3.SelectedItem.Text.ToString());
        ListBoxprant_govt.Items.Add(ddl_prant_govt3.SelectedItem.Text.ToString());
        ListBoxlokshabhaname.Items.Add(ddl_lokshabhaname3.SelectedItem.Text.ToString());
        ListBoxvidhansabha.Items.Add(ddl_vidhansabha3.SelectedItem.Text.ToString());
        ListBoxtehsil.Items.Add(ddl_tehsil3.SelectedItem.Text.ToString());
        ListBoxupnagar.Items.Add(ddl_upnagar3.SelectedItem.Text.ToString());
        ListBoxpincode.Items.Add(txtpincode3.Text);
        ListBoxsanghsiksha.Items.Add(ddl_sanghsiksha.SelectedItem.Text.ToString());
        ListBoxrsslevel.Items.Add(ddl_rsslevel.SelectedItem.Text.ToString());
    }
    protected void btnbtnreset_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        ListBox2.Items.Clear();
        ListBox3.Items.Clear();
        ListBox4.Items.Clear();
        ListBox5.Items.Clear();
        ListBox6.Items.Clear();
        ListBox7.Items.Clear();
        ListBox8.Items.Clear();
        ListBox9.Items.Clear();
        ListBox10.Items.Clear();
        ListBoxcountry.Items.Clear();
        ListBoxkshetraorg.Items.Clear();
        ListBoxkshetrarss.Items.Clear();
        ListBoxprant_rss.Items.Clear();
        ListBoxprant_org.Items.Clear();
        ListBoxprant_govt.Items.Clear();
        ListBoxlokshabhaname.Items.Clear();
        ListBoxvidhansabha.Items.Clear();
        ListBoxtehsil.Items.Clear();
        ListBoxupnagar.Items.Clear();
        ListBoxpincode.Items.Clear();
        ListBoxsanghsiksha.Items.Clear();
        ListBoxrsslevel.Items.Clear();

    }
    protected void btnadd_p_Click(object sender, EventArgs e)
    {
        if (txtmember_rss.Text.Trim() == "")
        {
            txtmember_rss.Text = txtreg_id.Text;
        }
        //   lb_p_org.Items.Add(ddl_organization1.SelectedItem.ToString());
        lb_p_membername.Items.Add(txtname_familymember.Text);
        lb_p_memberid.Items.Add(txtmember_rss.Text);
    }
    protected void btnreset_p_Click(object sender, EventArgs e)
    {
        // lb_p_org.Items.Clear();
        lb_p_membername.Items.Clear();
        lb_p_memberid.Items.Clear();
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        //if (ListBox1.Items.Count == 0)
        //{
        //    string jv = "<script>alert('Please Add Information to sangh Pariwar');</script>";
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
        // //   txtdate.Focus();
        //    return;

        //}
        if (txtdate.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Date');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtdate.Focus();
            return;

        }
        if (txtage.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Age');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtage.Focus();
            return;

        }
        if (ddlsex.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Sex');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddlsex.Focus();
            return;
        }
        if (ddl_country.SelectedItem.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Country');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_country.Focus();
            return;
        }

        if (ddl_country.SelectedItem.Text.Trim() == "-Select Country-")
        {
            string jv = "<script>alert('Please Select Country');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_country.Focus();
            return;
        }

        string st_code = "";
        string vdh_code = "";
        //  try
        //  {
        //      con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        //      con.Open();
        cmd.CommandText = @"Select Distinct State_Code from StateMaster Where Country='India' AND State_Name='@state' Order By State_Code";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@state", ddl_state.Text);
        //      cmd.Connection = con;
        //      dr = cmd.ExecuteReader();
        //      if (dr.Read())
        //      {
        //          st_code = dr[0].ToString();
        //      }
        //      dr.Close();
        cmd.CommandText = @"Select Distinct Vidhansabha_Code from CityMaster Where Country='India' AND State_Name='@state' AND District='@district' AND Vidhansabha='@city' Order By Vidhansabha_Code";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@state", ddl_state.Text);
        cmd.Parameters.AddWithValue("@district", ddl_district.Text);
        cmd.Parameters.AddWithValue("@city", ddl_city.Text);
        //      cmd.Connection = con;
        //      dr = cmd.ExecuteReader();
        //      if (dr.Read())
        //      {
        //          vdh_code = dr[0].ToString();
        //      }
        //      dr.Close();
        //      con.Close();
        //  }
        //  catch (Exception ex)
        //  {
        //      con.Close();
        //  }
        DateTime RegDate = DateTime.Now;
        SqlTransaction transaction = null;
        int Increment;
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            SqlCommand cmd = new SqlCommand("GET_Upliner_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            {
                cmd.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.Int)).Direction = ParameterDirection.Output;
            }
            con.Open();
            transaction = con.BeginTransaction("BIT_SKNRSS");
            cmd.Connection = con;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            Increment = Convert.ToInt32(cmd.Parameters["@ID"].Value);
            int icr;
            string RecNo = "";
            icr = Increment + 1;
            //if (Increment < 9)
            //{
            //    //RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "000000" + icr;
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "000000" + icr;
            //}
            //else if (Increment < 99)
            //{
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "00000" + icr;
            //}
            //else if (Increment < 999)
            //{
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "0000" + icr;
            //}
            //else if (Increment < 9999)
            //{
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "000" + icr;
            //}
            //else if (Increment < 99999)
            //{
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "00" + icr;
            //}
            //else if (Increment < 99999)
            //{
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "0" + icr;
            //}
            //else if (Increment < 99999)
            //{
            //    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + icr;
            //}
            // txtreg_id.Text = RecNo;
            if (txtreg_id.Text.Trim() == "")
            {
                string jv = "<script>alert('Please enter User ID');</script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                txtreg_id.Focus();
                return;
            }
            if (txtmember_rss.Text.Trim() == "")
            {
                txtmember_rss.Text = txtreg_id.Text;
            }
            for (int k = 0; k < lb_p_membername.Items.Count; k++)
            {
                if (k == 0)
                {
                    familyname = familyname + lb_p_membername.Items[k].ToString();
                }
                else
                {
                    familyname = familyname + "," + lb_p_membername.Items[k].ToString();
                }
            }

            for (int l = 0; l < lb_p_memberid.Items.Count; l++)
            {
                if (l == 0)
                {
                    memberid = memberid + lb_p_memberid.Items[l].ToString();
                }
                else
                {
                    memberid = memberid + "," + lb_p_memberid.Items[l].ToString();
                }
            }
            int i = 0;
            int j = 0;
            int isrno = 1;
            i = ListBox1.Items.Count;
            if (j == i)
            {

                cmd.CommandType = CommandType.Text;

                string qwe = "Insert into RSS_Registration(Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member,aadhar,Presentorganization,Address,Address1,Address2,rastra1,kshetraorg1,kshetrarss1,prantrss1,prantorg1,prantgovt1,loksabha1,district1,vidhansabha1,tehsil1,nagar1,upnagar1,pincode1,fax1,landno11,landno12,rastra2,kshetraorg2,kshetrarss2,prantrss2,prantorg2,prantgovt2,loksabha2,district2,vidhansabha2,tehsil2,nagar2,upnagar2,pincode2,fax2,landno21,landno22,rastra3,kshetraorg3,kshetrarss3,prantrss3,prantorg3,prantgovt3,loksabha3,district3,vidhansabha3,tehsil3,nagar3,upnagar3,pincode3,fax3,landno31,landno32,      Email_ID1, Email_ID2,Email_ID3,Email_ID4,                               Contact_No1, Contact_No2, Contact_No3, Contact_No4,bloglink,fblink,website,twitter,linkedIn,Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails,  Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1,        Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2,   Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3,             Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4,     ASr_No1, Hobbies1, Extra_Activities1,                                    ASr_No2, Hobbies2,Extra_Activities2,     ASr_No3, Hobbies3, Extra_Activities3,           ASr_No4, Hobbies4, Extra_Activities4,     ASr_No5, Hobbies5, Extra_Activities5,Achievements, Future_Ambition,         Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose,Sr_No, Memo_Discription,familymembername,rss_member_id ) values ('" + txtreg_id.Text + "','" + RegDate + "','" + txtname.Text + "','" + txtnickname.Text + "','" + ddlsex.SelectedItem.Text + "','" + txtdob.Text + "','" + txtage.Text + "','" + ddlnationality.SelectedItem.Text + "','" + txtmarriage_date.Text + "','" + ddl_occasion.SelectedItem.Text + "','" + txtfamily_member.Text + "','" + txtaadhar.Text + "','" + ddl_organization1.SelectedItem.Text + "','" + txtpermanent_addr.Text + "', '" + txtcurr_addr.Text + "', '" + txtoffice_addr.Text + "','" + ddl_country.SelectedItem.Text + "', '" + ddl_kshetraorg.SelectedItem.Text + "', '" + ddl_kshetrarss.SelectedItem.Text + "', '" + ddl_prant_rss.SelectedItem.Text + "', '" + ddl_prant_org.SelectedItem.Text + "', '" + ddl_prant_govt.SelectedItem.Text + "', '" + ddl_lokshabhaname.SelectedItem.Text + "', '" + ddl_distr.SelectedItem.Text + "', '" + ddl_vidhansabha.SelectedItem.Text + "', '" + ddl_tehsil.SelectedItem.Text + "', '" + ddl_nagar.SelectedItem.Text + "', '" + ddl_upnagar.SelectedItem.Text + "', '" + txtpincode.Text + "', '" + txtfax.Text + "','" + txtlandline11.Text + "','" + txtlandline12.Text + "','" + ddl_country1.SelectedItem.Text + "','" + ddl_kshetraorg1.SelectedItem.Text + "','" + ddl_kshetrarss1.SelectedItem.Text + "','" + ddl_prant_rss1.SelectedItem.Text + "','" + ddl_prant_org1.SelectedItem.Text + "','" + ddl_prant_govt1.SelectedItem.Text + "','" + ddl_lokshabhaname1.SelectedItem.Text + "','" + ddl_distr1.SelectedItem.Text + "','" + ddl_vidhansabha1.SelectedItem.Text + "','" + ddl_tehsil1.SelectedItem.Text + "','" + ddl_nagar1.SelectedItem.Text + "','" + ddl_upnagar1.SelectedItem.Text + "','" + txtpincode1.Text + "','" + txtfax1.Text + "','" + txtlandline21.Text + "','" + txtlandline22.Text + "','" + ddl_country2.SelectedItem.Text + "','" + ddl_kshetraorg2.SelectedItem.Text + "','" + ddl_kshetrarss2.SelectedItem.Text + "','" + ddl_prant_rss2.SelectedItem.Text + "','" + ddl_prant_org2.SelectedItem.Text + "','" + ddl_prant_govt2.SelectedItem.Text + "','" + ddl_lokshabhaname2.SelectedItem.Text + "','" + ddl_distr2.SelectedItem.Text + "','" + ddl_vidhansabha2.SelectedItem.Text + "','" + ddl_tehsil2.SelectedItem.Text + "','" + ddl_nagar2.SelectedItem.Text + "','" + ddl_upnagar2.SelectedItem.Text + "','" + txtpincode2.Text + "','" + txtfax2.Text + "','" + txtlandline31.Text + "','" + txtlandline32.Text + "','" + txtemail_id1.Text + "','" + txtemail_id2.Text + "','" + txtemail_id3.Text + "','" + txtemail_id4.Text + "','" + txtcontact_no1.Text + "','" + txtcontact_no2.Text + "','" + txtcontact_no3.Text + "','" + txtcontact_no4.Text + "','" + txtblog_link.Text + "','" + txtfb_link.Text + "','" + txtweb_link.Text + "','" + txttwitter_link.Text + "','" + txtlinkedin_link.Text + "','" + ddl_qualification.SelectedItem.Text + "','" + ddlspecialization.SelectedItem.Text + "','" + ddlspecialization1.SelectedItem.Text + "','" + ddlspelization2.SelectedItem.Text + "','" + txtcourse1.Text + "','" + ddloccupation.SelectedItem.Text + "','" + ddlspecialization4.SelectedItem.Text + "','" + ddlspecialization5.SelectedItem.Text + "','" + ddlspecialization6.SelectedItem.Text + "','1','" + txtorg1.Text + "','" + txtorg1_fromdate.Text + "','" + txtorg1_todate.Text + "','" + txtorg1_achievement.Text + "','" + txtorg1_remark.Text + "','2','" + txtorg2.Text + "','" + txtorg2_fromdate.Text + "','" + txtorg2_todate.Text + "','" + txtorg2_achievement.Text + "','" + txtorg2_remark.Text + "','3','" + txtorg3.Text + "','" + txtorg3_fromdate.Text + "','" + txtorg3_todate.Text + "','" + txtorg3_achievement.Text + "','" + txtorg3_remark.Text + "','4','" + txtorg4.Text + "','" + txtorg4_fromdate.Text + "','" + txtorg4_todate.Text + "','" + txtorg4_achievement.Text + "','" + txtorg4_remark.Text + "','1','" + txthobbies1.Text + "','" + txtextra_act1.Text + "','2','" + txthobbies2.Text + "','" + txtextra_act2.Text + "','3','" + txthobbies3.Text + "','" + txtextra_act3.Text + "','4','" + txthobbies4.Text + "','" + txtextra_act4.Text + "','5','" + txthobbies5.Text + "','" + txtextra_act5.Text + "','" + txtachievements.Text + "','" + txtfuture_ambition.Text + "','" + txtmeeting_reason.Text + "','" + txtmeeting_place.Text + "','" + txtmeeting_date.Text + "','" + ddlassign_work.SelectedItem.Text + "','" + txtany_purpose.Text + "','1', '" + txtmemo.Text + "','" + familyname + "','" + memberid + "')";

              //  Response.Write(qwe);
              //  Response.Write(qwe1); Response.Write(qwe3); Response.Write(qwe4); Response.Write(qwe5); Response.Write(qwe6);
                cmd.CommandText = qwe;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            while (j < i)
            {
                //  cmd = new SqlCommand();
                //rastra4 ,kshetraorg4,kshetrarss4,prantrss4,prantorg4,prantgovt4,loksabha4,district4,vidhansabha4,tehsil4,nagar4,upnagar4,pincode4
                cmd.CommandType = CommandType.Text;
                //               cmd.CommandText = @"Insert into RSS_Registration(Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date,
                //                No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1,
                //                Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, 
                //                QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, 
                //                Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, 
                //                Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1,
                //                Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, 
                //                Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, 
                //                Sr_No, Organization, RSSDesignation,From_Date, To_Date, 
                //Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, 
                //                Additional_Details, Memo_Discription) values('" + txtreg_id.Text + "','" + RegDate + "','" + txtname.Text + "','" + txtnickname.Text + "','" + ddlsex.Text + "','" + txtdob.Text + "','" + txtage.Text + "','" + ddlnationality.Text + "','" + txtmarriage_date.Text + "','" + ddl_occasion.Text + "','" + txtfamily_member.Text + "','" + txtmember_rss.Text + "','" + txtpermanent_addr.Text + "','" + ddl_country.Text + "','" + ddl_state.Text + "','" + ddl_district.Text + "','" + ddl_city.Text + "','" + ddl_zone.Text + "','" + txtcurr_addr.Text + "','" + ddl_country1.Text + "','" + ddl_state1.Text + "','" + ddl_district1.Text + "','" + ddl_city1.Text + "','" + ddl_zone1.Text + "','" + txtoffice_addr.Text + "','" + ddl_country2.Text + "','" + ddl_state2.Text + "','" + ddl_district2.Text + "','" + ddl_city2.Text + "','" + ddl_zone2.Text + "','" + txtemail_id1.Text + "','" + txtemail_id2.Text + "','" + txtcontact_no1.Text + "','" + txtcontact_no2.Text + "','" + txtcontact_no3.Text + "','" + txtcontact_no4.Text + "','" + ddl_qualification.Text + "','" + ddlspecialization.Text + "','" + ddlspecialization1.Text + "','" + ddlspelization2.Text + "','" + txtcourse1.Text + "','" + ddloccupation.Text + "','" + ddlspecialization4.Text + "','" + ddlspecialization5.Text + "','" + ddlspecialization6.Text + "','1','" + txtorg1.Text + "','" + txtorg1_fromdate.Text + "','" + txtorg1_todate.Text + "','" + txtorg1_achievement.Text + "','" + txtorg1_remark.Text + "','2','" + txtorg2.Text + "','" + txtorg2_fromdate.Text + "','" + txtorg2_todate.Text + "','" + txtorg2_achievement.Text + "','" + txtorg2_remark.Text + "','3','" + txtorg3.Text + "','" + txtorg3_fromdate.Text + "','" + txtorg3_todate.Text + "','" + txtorg3_achievement.Text + "','" + txtorg3_remark.Text + "','4','" + txtorg4.Text + "','" + txtorg4_fromdate.Text + "','" + txtorg4_todate.Text + "','" + txtorg4_achievement.Text + "','" + txtorg4_remark.Text + "','1','" + txthobbies1.Text + "','" + txtextra_act1.Text + "','2','" + txthobbies2.Text + "','" + txtextra_act2.Text + "','3','" + txthobbies3.Text + "','" + txtextra_act3.Text + "','4','" + txthobbies4.Text + "','" + txtextra_act4.Text + "','5','" + txthobbies5.Text + "','" + txtextra_act5.Text + "','" + txtachievements.Text + "','" + txtbehavior_analysis.Text + "','" + txtfuture_ambition.Text + "','" + txtmeeting_reason.Text + "','" + txtmeeting_place.Text + "','" + txtmeeting_date.Text + "','" + ddlassign_work.Text + "','" + txtany_purpose.Text + "','" + isrno + "','" + ListBox1.Items[j].ToString() + "','" + ListBox10.Items[j].ToString() + "','" + ListBox2.Items[j].ToString() + "','" + ListBox3.Items[j].ToString() + "','" + ListBox4.Items[j].ToString() + "','" + ListBox5.Items[j].ToString() + "','" + ListBox6.Items[j].ToString() + "','" + ListBox7.Items[j].ToString() + "','" + ListBox8.Items[j].ToString() + "','" + ListBox9.Items[j].ToString() + "', '" + txtmemo.Text + "')";
                cmd.CommandText = @"Insert into RSS_Registration(Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality,
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
Additional_Remark,present_past,sanghsiksha,level,vicharpariwar,familymembername,rss_member_id) 
values('" + txtreg_id.Text + "','" + RegDate + "','" + txtname.Text + "','" + txtnickname.Text + "','" + ddlsex.Text + "','" + txtdob.Text + "','" + txtage.Text + "','" + ddlnationality.SelectedItem.Text.ToString() + "','" + txtmarriage_date.Text + "','" + ddl_occasion.SelectedItem.Text + "','" + txtfamily_member.Text + "','" + txtaadhar.Text + "','" + ddl_organization1.SelectedItem.Text.ToString() + "','" + txtpermanent_addr.Text + "', '" + txtcurr_addr.Text + "', '" + txtoffice_addr.Text + "','" + ddl_country.SelectedItem.Text.ToString() + "', '" + ddl_kshetraorg.SelectedItem.Text.ToString() + "', '" + ddl_kshetrarss.SelectedItem.Text.ToString() + "', '" + ddl_prant_rss.SelectedItem.Text.ToString() + "', '" + ddl_prant_org.SelectedItem.Text.ToString() + "', '" + ddl_prant_govt.SelectedItem.Text.ToString() + "', '" + ddl_lokshabhaname.SelectedItem.Text.ToString() + "', '" + ddl_distr.SelectedItem.Text.ToString() + "', '" + ddl_vidhansabha.SelectedItem.Text.ToString() + "', '" + ddl_tehsil.SelectedItem.Text.ToString() + "', '" + ddl_nagar.SelectedItem.Text.ToString() + "', '" + ddl_upnagar.SelectedItem.Text.ToString() + "', '" + txtpincode.Text + "', '" + txtfax.Text + "','" + txtlandline11.Text + "','" + txtlandline12.Text + "','" + ddl_country1.SelectedItem.Text.ToString() + "','" + ddl_kshetraorg1.SelectedItem.Text.ToString() + "','" + ddl_kshetrarss1.SelectedItem.Text.ToString() + "','" + ddl_prant_rss1.SelectedItem.Text.ToString() + "','" + ddl_prant_org1.SelectedItem.Text.ToString() + "','" + ddl_prant_govt1.SelectedItem.Text.ToString() + "','" + ddl_lokshabhaname1.SelectedItem.Text.ToString() + "','" + ddl_distr1.SelectedItem.Text.ToString() + "','" + ddl_vidhansabha1.SelectedItem.Text.ToString() + "','" + ddl_tehsil1.SelectedItem.Text.ToString() + "','" + ddl_nagar1.SelectedItem.Text.ToString() + "','" + ddl_upnagar1.SelectedItem.Text.ToString() + "','" + txtpincode1.Text + "','" + txtfax1.Text + "','" + txtlandline21.Text + "','" + txtlandline22.Text + "','" + ddl_country2.SelectedItem.Text.ToString() + "','" + ddl_kshetraorg2.SelectedItem.Text.ToString() + "','" + ddl_kshetrarss2.SelectedItem.Text.ToString() + "','" + ddl_prant_rss2.SelectedItem.Text.ToString() + "','" + ddl_prant_org2.SelectedItem.Text.ToString() + "','" + ddl_prant_govt2.SelectedItem.Text.ToString() + "','" + ddl_lokshabhaname2.SelectedItem.Text.ToString() + "','" + ddl_distr2.SelectedItem.Text.ToString() + "','" + ddl_vidhansabha2.SelectedItem.Text.ToString() + "','" + ddl_tehsil2.SelectedItem.Text.ToString() + "','" + ddl_nagar2.SelectedItem.Text.ToString() + "','" + ddl_upnagar2.SelectedItem.Text.ToString() + "','" + txtpincode2.Text + "','" + txtfax2.Text + "','" + txtlandline31.Text + "','" + txtlandline32.Text + "','" + txtemail_id1.Text + "','" + txtemail_id2.Text + "','" + txtemail_id3.Text + "','" + txtemail_id4.Text + "','" + txtcontact_no1.Text + "','" + txtcontact_no2.Text + "','" + txtcontact_no3.Text + "','" + txtcontact_no4.Text + "','" + txtblog_link.Text + "','" + txtfb_link.Text + "','" + txtweb_link.Text + "','" + txttwitter_link.Text + "','" + txtlinkedin_link.Text + "','" + ddl_qualification.SelectedItem.Text.ToString() + "','" + ddlspecialization.SelectedItem.Text.ToString() + "','" + ddlspecialization1.SelectedItem.Text.ToString() + "','" + ddlspelization2.SelectedItem.Text.ToString() + "','" + txtcourse1.Text + "','" + ddloccupation.SelectedItem.Text.ToString() + "','" + ddlspecialization4.SelectedItem.Text.ToString() + "','" + ddlspecialization5.SelectedItem.Text.ToString() + "','" + ddlspecialization6.SelectedItem.Text.ToString() + "','1','" + txtorg1.Text + "','" + txtorg1_fromdate.Text + "','" + txtorg1_todate.Text + "','" + txtorg1_achievement.Text + "','" + txtorg1_remark.Text + "','2','" + txtorg2.Text + "','" + txtorg2_fromdate.Text + "','" + txtorg2_todate.Text + "','" + txtorg2_achievement.Text + "','" + txtorg2_remark.Text + "','3','" + txtorg3.Text + "','" + txtorg3_fromdate.Text + "','" + txtorg3_todate.Text + "','" + txtorg3_achievement.Text + "','" + txtorg3_remark.Text + "','4','" + txtorg4.Text + "','" + txtorg4_fromdate.Text + "','" + txtorg4_todate.Text + "','" + txtorg4_achievement.Text + "','" + txtorg4_remark.Text + "','1','" + txthobbies1.Text + "','" + txtextra_act1.Text + "','2','" + txthobbies2.Text + "','" + txtextra_act2.Text + "','3','" + txthobbies3.Text + "','" + txtextra_act3.Text + "','4','" + txthobbies4.Text + "','" + txtextra_act4.Text + "','5','" + txthobbies5.Text + "','" + txtextra_act5.Text + "','" + txtachievements.Text + "','" + txtfuture_ambition.Text + "','" + txtmeeting_reason.Text + "','" + txtmeeting_place.Text + "','" + txtmeeting_date.Text + "','" + ddlassign_work.SelectedItem.Text + "','" + txtany_purpose.Text + "', '" + txtmemo.Text + "','" + ListBoxcountry.Items[j].ToString() + "','" + ListBoxkshetraorg.Items[j].ToString() + "','" + ListBoxkshetrarss.Items[j].ToString() + "','" + ListBoxprant_rss.Items[j].ToString() + "','" + ListBoxprant_org.Items[j].ToString() + "','" + ListBoxprant_govt.Items[j].ToString() + "','" + ListBoxlokshabhaname.Items[j].ToString() + "','" + ListBox8.Items[j].ToString() + "','" + ListBoxvidhansabha.Items[j].ToString() + "','" + ListBoxtehsil.Items[j].ToString() + "','" + ListBox9.Items[j].ToString() + "','" + ListBoxupnagar.Items[j].ToString() + "','" + ListBoxpincode.Items[j].ToString() + "','" + isrno + "','" + ListBox1.Items[j].ToString() + "','" + ListBox10.Items[j].ToString() + "','" + ListBox2.Items[j].ToString() + "','" + ListBox3.Items[j].ToString() + "','" + ListBox6.Items[j].ToString() + "','" + ListBox7.Items[j].ToString() + "','" + ListBox5.Items[j].ToString() + "','" + ListBoxsanghsiksha.Items[j].ToString() + "','" + ListBoxrsslevel.Items[j].ToString() + "','" + ListBox4.Items[j].ToString() + "','" + familyname + "','" + memberid + "')";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                j = j + 1;
                isrno = isrno + 1;
            }
            if (hidden_img.Value.ToString() != "")
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into profile_img(userid,url,status,type) values('@regid','@hidimgValue','true','profile_pic')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
                cmd.Parameters.AddWithValue("@hidimgValue", hidden_img.Value.ToString());
                cmd.ExecuteNonQuery();
            }
            if (hidden_memo.Value.ToString() != "")
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into profile_img(userid,url,status,type,description) values('@regid','@hidmemoValue','true','memo','@memo')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
                cmd.Parameters.AddWithValue("@hidmemoValue", hidden_memo.Value.ToString());
                cmd.Parameters.AddWithValue("@memo", txtmemo.Text);
                cmd.ExecuteNonQuery();
            }
            if (hidden_resume.Value.ToString() != "")
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into profile_img(userid,url,status,type) values('@regid','@hidresumeValue','true','resume')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
                cmd.Parameters.AddWithValue("@hidresumeValue", hidden_resume.Value.ToString());
                cmd.ExecuteNonQuery();
            }
            string jv1 = "<script>alert('Record has been saved, and your Registration No. is :" + txtreg_id.Text + ". Your ID and Password has been sent in your email id');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv1, false);
            transaction.Commit();
            con.Close();

            fillddl();
            clearr();
            Clear();

            regid();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            con.Close();
            string jv1 = "<script>alert('Please select fields!!!');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv1, false);
            Label36.Text = ex.Message;
            //  Response.Write(ex.Message);
            return;
        }
        //Send_msg();       
        //Clear();
    }
    void Send_msg()
    {
        MailMessage mailMsg = new MailMessage();
        mailMsg.From = new MailAddress("admin@[your-website.com]");
        mailMsg.To.Add(txtemail_id1.Text);
        mailMsg.Subject = "Joining Message :";
        mailMsg.Body = "Congratulation " + txtname.Text + ", Your Registration No is :" + txtreg_id.Text;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "[SMTP_HOST]";
        smtp.EnableSsl = false;
        smtp.Port = 25;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("admin@[your-website.com]", "[SMTP_PASSWORD]");
        try
        {
            smtp.Send(mailMsg);
            Label36.Text = "Confirmation email has been sent in your Email ID!!!";
        }
        catch (Exception ex)
        {
            Label36.Text = ex.Message;
        }
    }
    void Clear()
    {
        txtachievement_work.Text = "";
        txtachievements.Text = "";
        txtadditional_details.Text = "";
        txtadditional_remarks.Text = "";
        txtage.Text = "";
        //  ddl_occasion.Text = "";
        txtany_purpose.Text = "";
        txtbehavior_analysis.Text = "";
        txtcontact_no1.Text = "";
        txtcontact_no2.Text = "";
        txtcontact_no3.Text = "";
        txtcontact_no4.Text = "";
        txtcourse1.Text = "";
        txtcurr_addr.Text = "";
        txtdate.Text = "";
        txtdob.Text = "";
        txtemail_id1.Text = "";
        txtemail_id2.Text = "";
        txtextra_act1.Text = "";
        txtextra_act2.Text = "";
        txtextra_act3.Text = "";
        txtextra_act4.Text = "";
        txtextra_act5.Text = "";
        txtfamily_member.Text = "";
        txtfuture_ambition.Text = "";
        txthobbies1.Text = "";
        txthobbies2.Text = "";
        txthobbies3.Text = "";
        txthobbies4.Text = "";
        txthobbies5.Text = "";
        txtmarriage_date.Text = "";
        txtmeeting_date.Text = "";
        txtmeeting_place.Text = "";
        txtmeeting_reason.Text = "";
        txtmember_rss.Text = "";
        txtname.Text = "";
        txtnickname.Text = "";
        txtoffice_addr.Text = "";
        txtorg_date_from.Text = "";
        txtorg_date_to.Text = "";
        txtorg1.Text = "";
        txtorg1_achievement.Text = "";
        txtorg1_fromdate.Text = "";
        txtorg1_remark.Text = "";
        txtorg1_todate.Text = "";
        txtorg2.Text = "";
        txtorg2_achievement.Text = "";
        txtorg2_fromdate.Text = "";
        txtorg2_remark.Text = "";
        txtorg2_todate.Text = "";
        txtorg3.Text = "";
        txtorg3_achievement.Text = "";
        txtorg3_fromdate.Text = "";
        txtorg3_remark.Text = "";
        txtorg3_todate.Text = "";
        txtorg3.Text = "";
        txtorg4_achievement.Text = "";
        txtorg4_fromdate.Text = "";
        txtorg4_remark.Text = "";
        txtorg4_todate.Text = "";
        txtpermanent_addr.Text = "";
        txtreg_id.Text = "";
        ListBox1.Items.Clear();
        ListBox2.Items.Clear();
        ListBox3.Items.Clear();
        ListBox4.Items.Clear();
        ListBox5.Items.Clear();
        ListBox6.Items.Clear();
        ListBox7.Items.Clear();
        ListBox8.Items.Clear();
        ListBox9.Items.Clear();
        ListBox10.Items.Clear();
        ListBoxcountry.Items.Clear();
        ListBoxkshetraorg.Items.Clear();
        ListBoxkshetrarss.Items.Clear();
        ListBoxprant_rss.Items.Clear();
        ListBoxprant_org.Items.Clear();
        ListBoxprant_govt.Items.Clear();
        ListBoxlokshabhaname.Items.Clear();
        ListBoxvidhansabha.Items.Clear();
        ListBoxtehsil.Items.Clear();
        ListBoxupnagar.Items.Clear();
        ListBoxpincode.Items.Clear();
        ListBoxsanghsiksha.Items.Clear();
        ListBoxrsslevel.Items.Clear();
        Image1.ImageUrl = "";
        Image3.ImageUrl = "";
        lblress.Text = "";
        txtaadhar.Text = "";
        txtmemo.Text = "";

        AutoLoadData();

    }
    protected void btn_open_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select * from RSS_Registration Where Reg_ID='@regid'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtreg_id.Text = dr[0].ToString();
                txtdate.Text = dr[1].ToString();
                txtname.Text = dr[2].ToString();
                txtnickname.Text = dr[3].ToString();
                ddlsex.Text = dr[4].ToString();
                txtdob.Text = dr[5].ToString();
                txtage.Text = dr[6].ToString();
                ddlnationality.Text = dr[7].ToString();
                txtmarriage_date.Text = dr[8].ToString();
                ddl_occasion.SelectedItem.Text = dr[9].ToString();
                txtfamily_member.Text = dr[10].ToString();
                txtmember_rss.Text = dr[11].ToString();
                txtpermanent_addr.Text = dr[12].ToString();
                ddl_country.SelectedItem.Text = dr[13].ToString();
                //       ddl_state.Text = dr[14].ToString();
                //        ddl_district.Text = dr[15].ToString();
                //        ddl_city.Text = dr[16].ToString();
                //        ddl_zone.Text = dr[17].ToString();
                txtcurr_addr.Text = dr[18].ToString();
                ddl_country1.SelectedItem.Text = dr[19].ToString();
                //ddl_state1.Text = dr[20].ToString();
                //ddl_district1.Text = dr[21].ToString();
                //ddl_city1.Text = dr[22].ToString();
                //ddl_zone1.Text = dr[23].ToString();
                txtoffice_addr.Text = dr[24].ToString();
                ddl_country2.SelectedItem.Text = dr[25].ToString();
                //ddl_state2.Text = dr[26].ToString();
                //ddl_district2.Text = dr[27].ToString();
                //ddl_city2.Text = dr[28].ToString();
                //ddl_zone2.Text = dr[29].ToString();
                txtemail_id1.Text = dr[30].ToString();
                txtemail_id2.Text = dr[31].ToString();
                txtcontact_no1.Text = dr[32].ToString();
                txtcontact_no2.Text = dr[33].ToString();
                txtcontact_no3.Text = dr[34].ToString();
                txtcontact_no4.Text = dr[35].ToString();
                ddl_qualification.SelectedItem.Text = dr[36].ToString();
                ddlspecialization.Text = dr[37].ToString();
                ddlspecialization1.Text = dr[38].ToString();
                ddlspelization2.Text = dr[39].ToString();
                txtcourse1.Text = dr[40].ToString();
                ddloccupation.Text = dr[41].ToString();
                ddlspecialization4.Text = dr[42].ToString();
                ddlspecialization5.Text = dr[43].ToString();
                ddlspecialization6.Text = dr[44].ToString();
                txtorg1.Text = dr[46].ToString();
                txtorg1_fromdate.Text = dr[47].ToString();
                txtorg1_todate.Text = dr[48].ToString();
                txtorg1_achievement.Text = dr[49].ToString();
                txtorg1_remark.Text = dr[50].ToString();
                txtorg2.Text = dr[52].ToString();
                txtorg2_fromdate.Text = dr[53].ToString();
                txtorg2_todate.Text = dr[54].ToString();
                txtorg2_achievement.Text = dr[55].ToString();
                txtorg2_remark.Text = dr[56].ToString();
                txtorg3.Text = dr[58].ToString();
                txtorg3_fromdate.Text = dr[59].ToString();
                txtorg3_todate.Text = dr[60].ToString();
                txtorg3_achievement.Text = dr[61].ToString();
                txtorg3_remark.Text = dr[62].ToString();
                txtorg4.Text = dr[64].ToString();
                txtorg4_fromdate.Text = dr[65].ToString();
                txtorg4_todate.Text = dr[66].ToString();
                txtorg4_achievement.Text = dr[67].ToString();
                txtorg4_remark.Text = dr[68].ToString();
                txthobbies1.Text = dr[70].ToString();
                txtextra_act1.Text = dr[71].ToString();
                txthobbies2.Text = dr[73].ToString();
                txtextra_act2.Text = dr[74].ToString();
                txthobbies3.Text = dr[76].ToString();
                txtextra_act3.Text = dr[77].ToString();
                txthobbies4.Text = dr[79].ToString();
                txtextra_act4.Text = dr[80].ToString();
                txthobbies5.Text = dr[82].ToString();
                txtextra_act5.Text = dr[83].ToString();
                txtachievements.Text = dr[84].ToString();
                txtbehavior_analysis.Text = dr[85].ToString();
                txtfuture_ambition.Text = dr[86].ToString();
                txtmeeting_reason.Text = dr[87].ToString();
                txtmeeting_place.Text = dr[88].ToString();
                txtmeeting_date.Text = dr[89].ToString();
                ddlassign_work.Text = dr[90].ToString();
                txtany_purpose.Text = dr[91].ToString();
                txtmemo.Text = dr[103].ToString();
            }
            dr.Close();
            cmd.CommandText = @"select * from RSS_Registration Where Reg_ID='@regid'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListBox1.Items.Add(dr[93].ToString());
                ListBox10.Items.Add(dr[94].ToString());
                ListBox2.Items.Add(dr[95].ToString());
                ListBox3.Items.Add(dr[96].ToString());
                ListBox4.Items.Add(dr[97].ToString());
                ListBox5.Items.Add(dr[98].ToString());
                ListBox6.Items.Add(dr[99].ToString());
                ListBox7.Items.Add(dr[100].ToString());
                ListBox8.Items.Add(dr[101].ToString());
                ListBox9.Items.Add(dr[102].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            //lb_Message.Text = ex.Message;
            con.Close();
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Delete from RSS_Registration Where Reg_ID='@regid'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"Delete from RSS_SanghPariwar Where Reg_ID='@regid'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@regid", txtreg_id.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            string jv = "<script>alert('Record has been Deleted!!!');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {

    }
    protected void txtdob_TextChanged(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();

        con.Open();
        cmd.CommandText = @"select DATEDIFF(DD,'@dob',GETDATE())/365";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@dob", txtdob.Text);
        cmd.Connection = con;
        txtage.Text = cmd.ExecuteScalar().ToString();
        con.Close();
    }

    public void regid()
    {

        //string str = (Convert.ToInt32(DateTime.Now.Millisecond.ToString()) + Convert.ToInt32(DateTime.Now.Second.ToString()) + 32145).ToString();
        //str = (str.Trim() + DateTime.Now.Date.ToString().Replace("/", string.Empty)).ToString();
        //if (str.Contains(":"))
        //{
        //    str = str.Replace(":", string.Empty);
        //}

        //if (str.Contains("AM"))
        //{
        //    str = str.Replace("AM", string.Empty);

        //}
        //else
        //{
        //    str = str.Replace("PM", string.Empty);

        //}
        //if (str.Length >= 8)
        //{
        //    str = str.Substring(1, 8);
        //}
        //else
        //{
        //    str = str.Substring(1, 7);
        //}
        //txtreg_id.Text = str;

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
            cmd.CommandText = "select MAX(Reg_ID) from RSS_Registration";
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

            con.Close();
        }
        ssr_no = max_ssr_no + 1;
        sr_ssno = ssr_no.ToString();
        txtreg_id.Text = sr_ssno;

    }


    ////////////////////////////////////////////////////////////////////////////////
    protected void ddl_kshetraorg_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_kshetrarss.Items.Clear();
        ddl_kshetrarss.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswisekshetra from StateMaster where Country='@country' and orgwisekshetra='@kshetraorg'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
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
            cmd.CommandText = @"select rsswiseprant from StateMaster where Country='@country' and orgwisekshetra='@kshetraorg' and rsswisekshetra='@kshetrarss'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
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
            cmd.CommandText = @"select govtwiseprant from StateMaster where Country='@country' and orgwisekshetra='@kshetraorg' and rsswisekshetra='@kshetrarss' and rsswiseprant='@prantrss'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
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
            cmd.CommandText = @"select orgwiseprant from StateMaster where Country='@country' and orgwisekshetra='@kshetraorg' and rsswisekshetra='@kshetrarss'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
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
            cmd.CommandText = @"select Loksabha from LoksabhaMaster where Country='@country' and kshetraorg='@kshetraorg' and kshetrarss='@kshetrarss' and prantrss='@prantrss' and prantorg='@prantorg' and prantgovt='@prantgovt'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
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
    protected void ddl_lokshabhaname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_distr.Items.Clear();
        ddl_distr.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select District from DistrictMaster where Country='@country' and kshetraorg='@kshetraorg' and kshetrarss='@kshetrarss' and prantrss='@prantrss' and prantorg='@prantorg' and prantgovt='@prantgovt' and loksabha='@lokshabhaname' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname", ddl_lokshabhaname.SelectedItem.Text);
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
    }
    protected void ddl_distr_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_vidhansabha.Items.Clear();
        ddl_vidhansabha.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Vidhansabha from CityMaster where Country='@country' and kshetraorg='@kshetraorg' and kshetrarss='@kshetrarss' and prantrss='@prantrss' and prantorg='@prantorg' and prantgovt='@prantgovt' and loksabha='@lokshabhaname' and District='@distr' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname", ddl_lokshabhaname.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr", ddl_distr.SelectedItem.Text);
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
    }
    protected void ddl_vidhansabha_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_tehsil.Items.Clear();
        ddl_tehsil.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Tehsil from TehsilMaster where Country='@country' and kshetraorg='@kshetraorg' and kshetrarss='@kshetrarss' and prantrss='@prantrss' and prantorg='@prantorg' and prantgovt='@prantgovt' and loksabha='@lokshabhaname' and District='@distr' and vidhansabha='@vidhansabha' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname", ddl_lokshabhaname.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr", ddl_distr.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha", ddl_vidhansabha.SelectedItem.Text);
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
    }
    protected void ddl_tehsil_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_nagar.Items.Clear();
        ddl_nagar.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Nagar from NagarMaster where Country='@country' and kshetraorg='@kshetraorg' and kshetrarss='@kshetrarss' and prantrss='@prantrss' and prantorg='@prantorg' and prantgovt='@prantgovt' and loksabha='@lokshabhaname' and District='@distr' and vidhansabha='@vidhansabha' and tehsil='@tehsil' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname", ddl_lokshabhaname.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr", ddl_distr.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha", ddl_vidhansabha.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil", ddl_tehsil.SelectedItem.Text);
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
    }
    protected void ddl_nagar_SelectedIndexChanged(object sender, EventArgs e)
    {
        //
        ddl_upnagar.Items.Clear();
        ddl_upnagar.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select upNagar from UpNagarMaster where Country='@country' and kshetraorg='@kshetraorg' and kshetrarss='@kshetrarss' and prantrss='@prantrss' and prantorg='@prantorg' and prantgovt='@prantgovt' and loksabha='@lokshabhaname' and District='@distr' and vidhansabha='@vidhansabha' and tehsil='@tehsil' and nagar='@nagar' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country", ddl_country.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg", ddl_kshetraorg.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss", ddl_kshetrarss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss", ddl_prant_rss.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg", ddl_prant_org.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt", ddl_prant_govt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname", ddl_lokshabhaname.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr", ddl_distr.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha", ddl_vidhansabha.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil", ddl_tehsil.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@nagar", ddl_nagar.SelectedItem.Text);
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
    }

    /////2///////
    protected void ddl_kshetraorg_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_kshetrarss1.Items.Clear();
        ddl_kshetrarss1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswisekshetra from StateMaster where Country='@country1' and orgwisekshetra='@kshetraorg1'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetrarss1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_kshetrarss_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_prant_rss1.Items.Clear();
        ddl_prant_rss1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswiseprant from StateMaster where Country='@country1' and orgwisekshetra='@kshetraorg1' and rsswisekshetra='@kshetrarss1'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_rss1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_org_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_prant_govt1.Items.Clear();
        ddl_prant_govt1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select govtwiseprant from StateMaster where Country='@country1' and orgwisekshetra='@kshetraorg1' and rsswisekshetra='@kshetrarss1' and rsswiseprant='@prantrss1'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_govt1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_rss_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_prant_org1.Items.Clear();
        ddl_prant_org1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwiseprant from StateMaster where Country='@country1' and orgwisekshetra='@kshetraorg1' and rsswisekshetra='@kshetrarss1'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_org1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_govt_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_lokshabhaname1.Items.Clear();
        ddl_lokshabhaname1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();

            // 
            cmd.CommandText = @"select Loksabha from LoksabhaMaster where Country='@country1' and kshetraorg='@kshetraorg1' and kshetrarss='@kshetrarss1' and prantrss='@prantrss1' and prantorg='@prantorg1' and prantgovt='@prantgovt1'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg1", ddl_prant_org1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt1", ddl_prant_govt1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_lokshabhaname1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_lokshabhaname_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_distr1.Items.Clear();
        ddl_distr1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select District from DistrictMaster where Country='@country1' and kshetraorg='@kshetraorg1' and kshetrarss='@kshetrarss1' and prantrss='@prantrss1' and prantorg='@prantorg1' and prantgovt='@prantgovt1' and loksabha='@lokshabhaname1' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg1", ddl_prant_org1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt1", ddl_prant_govt1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname1", ddl_lokshabhaname1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_distr1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_distr_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_vidhansabha1.Items.Clear();
        ddl_vidhansabha1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Vidhansabha from CityMaster where Country='@country1' and kshetraorg='@kshetraorg1' and kshetrarss='@kshetrarss1' and prantrss='@prantrss1' and prantorg='@prantorg1' and prantgovt='@prantgovt1' and loksabha='@lokshabhaname1' and District='@distr1' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg1", ddl_prant_org1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt1", ddl_prant_govt1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname1", ddl_lokshabhaname1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr1", ddl_distr1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_vidhansabha1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_vidhansabha_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_tehsil1.Items.Clear();
        ddl_tehsil1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Tehsil from TehsilMaster where Country='@country1' and kshetraorg='@kshetraorg1' and kshetrarss='@kshetrarss1' and prantrss='@prantrss1' and prantorg='@prantorg1' and prantgovt='@prantgovt1' and loksabha='@lokshabhaname1' and District='@distr1' and vidhansabha='@vidhansabha1' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg1", ddl_prant_org1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt1", ddl_prant_govt1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname1", ddl_lokshabhaname1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr1", ddl_distr1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha1", ddl_vidhansabha1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_tehsil1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_tehsil_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_nagar1.Items.Clear();
        ddl_nagar1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Nagar from NagarMaster where Country='@country1' and kshetraorg='@kshetraorg1' and kshetrarss='@kshetrarss1' and prantrss='@prantrss1' and prantorg='@prantorg1' and prantgovt='@prantgovt1' and loksabha='@lokshabhaname1' and District='@distr1' and vidhansabha='@vidhansabha1' and tehsil='@tehsil1' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg1", ddl_prant_org1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt1", ddl_prant_govt1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname1", ddl_lokshabhaname1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr1", ddl_distr1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha1", ddl_vidhansabha1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil1", ddl_tehsil1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_nagar1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_nagar_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //
        ddl_upnagar1.Items.Clear();
        ddl_upnagar1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select upNagar from UpNagarMaster where Country='@country1' and kshetraorg='@kshetraorg1' and kshetrarss='@kshetrarss1' and prantrss='@prantrss1' and prantorg='@prantorg1' and prantgovt='@prantgovt1' and loksabha='@lokshabhaname1' and District='@distr1' and vidhansabha='@vidhansabha1' and tehsil='@tehsil1' and nagar='@nagar1' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg1", ddl_kshetraorg1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss1", ddl_kshetrarss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss1", ddl_prant_rss1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg1", ddl_prant_org1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt1", ddl_prant_govt1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname1", ddl_lokshabhaname1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr1", ddl_distr1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha1", ddl_vidhansabha1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil1", ddl_tehsil1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@nagar1", ddl_nagar1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_upnagar1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_country_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_kshetraorg1.Items.Clear();
        ddl_kshetraorg1.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country1'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country1", ddl_country1.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetraorg1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }

    ////3////
    protected void ddl_kshetraorg_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_kshetrarss2.Items.Clear();
        ddl_kshetrarss2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswisekshetra from StateMaster where Country='@country2' and orgwisekshetra='@kshetraorg2'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetrarss2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_kshetrarss_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_prant_rss2.Items.Clear();
        ddl_prant_rss2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswiseprant from StateMaster where Country='@country2' and orgwisekshetra='@kshetraorg2' and rsswisekshetra='@kshetrarss2'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_rss2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_org_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_prant_govt2.Items.Clear();
        ddl_prant_govt2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select govtwiseprant from StateMaster where Country='@country2' and orgwisekshetra='@kshetraorg2' and rsswisekshetra='@kshetrarss2' and rsswiseprant='@prantrss2'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_govt2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_rss_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_prant_org2.Items.Clear();
        ddl_prant_org2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwiseprant from StateMaster where Country='@country2' and orgwisekshetra='@kshetraorg2' and rsswisekshetra='@kshetrarss2'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_org2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_govt_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_lokshabhaname2.Items.Clear();
        ddl_lokshabhaname2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();

            // 
            cmd.CommandText = @"select Loksabha from LoksabhaMaster where Country='@country2' and kshetraorg='@kshetraorg2' and kshetrarss='@kshetrarss2' and prantrss='@prantrss2' and prantorg='@prantorg2' and prantgovt='@prantgovt2'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg2", ddl_prant_org2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt2", ddl_prant_govt2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_lokshabhaname2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_lokshabhaname_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_distr2.Items.Clear();
        ddl_distr2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select District from DistrictMaster where Country='@country2' and kshetraorg='@kshetraorg2' and kshetrarss='@kshetrarss2' and prantrss='@prantrss2' and prantorg='@prantorg2' and prantgovt='@prantgovt2' and loksabha='@lokshabhaname2' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg2", ddl_prant_org2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt2", ddl_prant_govt2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname2", ddl_lokshabhaname2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_distr2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_distr_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_vidhansabha2.Items.Clear();
        ddl_vidhansabha2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Vidhansabha from CityMaster where Country='@country2' and kshetraorg='@kshetraorg2' and kshetrarss='@kshetrarss2' and prantrss='@prantrss2' and prantorg='@prantorg2' and prantgovt='@prantgovt2' and loksabha='@lokshabhaname2' and District='@distr2' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg2", ddl_prant_org2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt2", ddl_prant_govt2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname2", ddl_lokshabhaname2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr2", ddl_distr2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_vidhansabha2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_vidhansabha_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_tehsil2.Items.Clear();
        ddl_tehsil2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Tehsil from TehsilMaster where Country='@country2' and kshetraorg='@kshetraorg2' and kshetrarss='@kshetrarss2' and prantrss='@prantrss2' and prantorg='@prantorg2' and prantgovt='@prantgovt2' and loksabha='@lokshabhaname2' and District='@distr2' and vidhansabha='@vidhansabha2' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg2", ddl_prant_org2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt2", ddl_prant_govt2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname2", ddl_lokshabhaname2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr2", ddl_distr2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha2", ddl_vidhansabha2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_tehsil2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_tehsil_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_nagar2.Items.Clear();
        ddl_nagar2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Nagar from NagarMaster where Country='@country2' and kshetraorg='@kshetraorg2' and kshetrarss='@kshetrarss2' and prantrss='@prantrss2' and prantorg='@prantorg2' and prantgovt='@prantgovt2' and loksabha='@lokshabhaname2' and District='@distr2' and vidhansabha='@vidhansabha2' and tehsil='@tehsil2' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg2", ddl_prant_org2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt2", ddl_prant_govt2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname2", ddl_lokshabhaname2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr2", ddl_distr2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha2", ddl_vidhansabha2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil2", ddl_tehsil2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_nagar2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_nagar_SelectedIndexChanged2(object sender, EventArgs e)
    {
        //
        ddl_upnagar2.Items.Clear();
        ddl_upnagar2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select upNagar from UpNagarMaster where Country='@country2' and kshetraorg='@kshetraorg2' and kshetrarss='@kshetrarss2' and prantrss='@prantrss2' and prantorg='@prantorg2' and prantgovt='@prantgovt2' and loksabha='@lokshabhaname2' and District='@distr2' and vidhansabha='@vidhansabha2' and tehsil='@tehsil2' and nagar='@nagar2' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg2", ddl_kshetraorg2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss2", ddl_kshetrarss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss2", ddl_prant_rss2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg2", ddl_prant_org2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt2", ddl_prant_govt2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname2", ddl_lokshabhaname2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr2", ddl_distr2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha2", ddl_vidhansabha2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil2", ddl_tehsil2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@nagar2", ddl_nagar2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_upnagar2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_country_SelectedIndexChanged2(object sender, EventArgs e)
    {
        ddl_kshetraorg2.Items.Clear();
        ddl_kshetraorg2.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country2'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country2", ddl_country2.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetraorg2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////3///////////////////////////////////////////////////////////////////////////
    protected void ddl_kshetraorg_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_kshetrarss3.Items.Clear();
        ddl_kshetrarss3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswisekshetra from StateMaster where Country='@country3' and orgwisekshetra='@kshetraorg3'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetrarss3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_kshetrarss_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_prant_rss3.Items.Clear();
        ddl_prant_rss3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select rsswiseprant from StateMaster where Country='@country3' and orgwisekshetra='@kshetraorg3' and rsswisekshetra='@kshetrarss3'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_rss3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_org_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_prant_govt3.Items.Clear();
        ddl_prant_govt3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select govtwiseprant from StateMaster where Country='@country3' and orgwisekshetra='@kshetraorg3' and rsswisekshetra='@kshetrarss3' and rsswiseprant='@prantrss3'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_govt3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_rss_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_prant_org3.Items.Clear();
        ddl_prant_org3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwiseprant from StateMaster where Country='@country3' and orgwisekshetra='@kshetraorg3' and rsswisekshetra='@kshetrarss3'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_prant_org3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_prant_govt_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_lokshabhaname3.Items.Clear();
        ddl_lokshabhaname3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();

            // 
            cmd.CommandText = @"select Loksabha from LoksabhaMaster where Country='@country3' and kshetraorg='@kshetraorg3' and kshetrarss='@kshetrarss3' and prantrss='@prantrss3' and prantorg='@prantorg3' and prantgovt='@prantgovt3'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg3", ddl_prant_org3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt3", ddl_prant_govt3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_lokshabhaname3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_lokshabhaname_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_distr3.Items.Clear();
        ddl_distr3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select District from DistrictMaster where Country='@country3' and kshetraorg='@kshetraorg3' and kshetrarss='@kshetrarss3' and prantrss='@prantrss3' and prantorg='@prantorg3' and prantgovt='@prantgovt3' and loksabha='@lokshabhaname3' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg3", ddl_prant_org3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt3", ddl_prant_govt3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname3", ddl_lokshabhaname3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_distr3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_distr_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_vidhansabha3.Items.Clear();
        ddl_vidhansabha3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Vidhansabha from CityMaster where Country='@country3' and kshetraorg='@kshetraorg3' and kshetrarss='@kshetrarss3' and prantrss='@prantrss3' and prantorg='@prantorg3' and prantgovt='@prantgovt3' and loksabha='@lokshabhaname3' and District='@distr3' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg3", ddl_prant_org3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt3", ddl_prant_govt3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname3", ddl_lokshabhaname3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr3", ddl_distr3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_vidhansabha3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_vidhansabha_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_tehsil3.Items.Clear();
        ddl_tehsil3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Tehsil from TehsilMaster where Country='@country3' and kshetraorg='@kshetraorg3' and kshetrarss='@kshetrarss3' and prantrss='@prantrss3' and prantorg='@prantorg3' and prantgovt='@prantgovt3' and loksabha='@lokshabhaname3' and District='@distr3' and vidhansabha='@vidhansabha3' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg3", ddl_prant_org3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt3", ddl_prant_govt3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname3", ddl_lokshabhaname3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr3", ddl_distr3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha3", ddl_vidhansabha3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_tehsil3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_tehsil_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_nagar3.Items.Clear();
        ddl_nagar3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select Nagar from NagarMaster where Country='@country3' and kshetraorg='@kshetraorg3' and kshetrarss='@kshetrarss3' and prantrss='@prantrss3' and prantorg='@prantorg3' and prantgovt='@prantgovt3' and loksabha='@lokshabhaname3' and District='@distr3' and vidhansabha='@vidhansabha3' and tehsil='@tehsil3' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg3", ddl_prant_org3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt3", ddl_prant_govt3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname3", ddl_lokshabhaname3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr3", ddl_distr3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha3", ddl_vidhansabha3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil3", ddl_tehsil3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_nagar3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_nagar_SelectedIndexChanged3(object sender, EventArgs e)
    {
        //
        ddl_upnagar3.Items.Clear();
        ddl_upnagar3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select upNagar from UpNagarMaster where Country='@country3' and kshetraorg='@kshetraorg3' and kshetrarss='@kshetrarss3' and prantrss='@prantrss3' and prantorg='@prantorg3' and prantgovt='@prantgovt3' and loksabha='@lokshabhaname3' and District='@distr3' and vidhansabha='@vidhansabha3' and tehsil='@tehsil3' and nagar='@nagar3' ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetraorg3", ddl_kshetraorg3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@kshetrarss3", ddl_kshetrarss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantrss3", ddl_prant_rss3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantorg3", ddl_prant_org3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@prantgovt3", ddl_prant_govt3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@lokshabhaname3", ddl_lokshabhaname3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@distr3", ddl_distr3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@vidhansabha3", ddl_vidhansabha3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@tehsil3", ddl_tehsil3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@nagar3", ddl_nagar3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_upnagar3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_country_SelectedIndexChanged3(object sender, EventArgs e)
    {
        ddl_kshetraorg3.Items.Clear();
        ddl_kshetraorg3.Items.Add("--Select--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"select orgwisekshetra from StateMaster where Country='@country3'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@country3", ddl_country3.SelectedItem.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_kshetraorg3.Items.Add(dr[0].ToString());
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
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please select Reg ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }

        if (FileUpload2.HasFile == true)
        {
            string ext = System.IO.Path.GetExtension(this.FileUpload2.PostedFile.FileName);
            //if (ext != ".pdf" )
            //{
            //    d.messagebox("Please upload jpg only", this);
            //    return;
            //}
            if (Directory.Exists(Server.MapPath("~/resume/")) == false)
            {
                Directory.CreateDirectory(Server.MapPath("~/resume/"));
            }
            string file_name = "~/resume/" + (txtname.Text + DateTime.Now.ToString()).Replace("&", "").Replace("/", "").Replace("'", "").Replace(" ", "").Replace("AM", "").Replace("PM", "").Replace(":", "") + Path.GetExtension(FileUpload2.FileName);
            FileUpload2.SaveAs(Server.MapPath(file_name));
            hidden_resume.Value = file_name;
            lblress.Text = "Resume Uploaded Sucessfully";
        }
    }
}
