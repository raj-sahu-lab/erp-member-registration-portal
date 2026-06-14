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

public partial class Admin_Report_Qualification : System.Web.UI.Page
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
            string regDate1 = Convert.ToString(DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year);
            txtfrom_date.Text = regDate1.ToString();
            txtto_date.Text = regDate1.ToString();
            //if (Session["Login_ID"].ToString() == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            ddl_specialization.Items.Add("-Select-");
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct Specialization_Name from SpecializationMaster Order By Specialization_Name";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_specialization.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
            Upliner_Details();
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
    protected void Paging_UplinerDetails(object sender, GridViewPageEventArgs e)
    {
        GV_personal_details.PageIndex = e.NewPageIndex;
        Upliner_Details();
    }
    void Upliner_Details()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_CountryWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND Country='" + ddl_country.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_StateWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' AND QSpecialization2='" + ddl_subsubspecialization.Text.Replace("'", "''") + "' AND Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_DistrictWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' AND QSpecialization2='" + ddl_subsubspecialization.Text.Replace("'", "''") + "' AND Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_CityWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' AND QSpecialization2='" + ddl_subsubspecialization.Text.Replace("'", "''") + "' AND Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND Vidhansabha='" + ddl_city.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_VillageWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "Select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' AND QSpecialization2='" + ddl_subsubspecialization.Text.Replace("'", "''") + "' AND Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND Vidhansabha='" + ddl_city.Text.Replace("'", "''") + "' AND Village='" + ddl_village.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_NameWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "Select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' AND QSpecialization2='" + ddl_subsubspecialization.Text.Replace("'", "''") + "' AND Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND Vidhansabha='" + ddl_city.Text.Replace("'", "''") + "' AND Village='" + ddl_village.Text.Replace("'", "''") + "' AND Name='" + txtsearch.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_QualificationWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "Select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_SpecializationWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "Select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_SubSpecializationWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "Select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    void GV_Details_SubSubSpecializationWise()
    {
        GV_personal_details.DataSource = null;
        GV_personal_details.DataBind();
        string qry = "Select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Qualification='" + ddl_qualification.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_specialization.Text.Replace("'", "''") + "' AND QSpecialization1='" + ddl_subspecialization.Text.Replace("'", "''") + "' AND QSpecialization2='" + ddl_subsubspecialization.Text.Replace("'", "''") + "' Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
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
        GV_Details_CountryWise();
    }
    protected void ddl_qualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_Details_QualificationWise();
    }
    protected void ddl_specialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_subspecialization.Items.Clear();
        ddl_subspecialization.Items.Add("-Select-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Sub_Specialization from SubSpeclMaster Where Specialization_Name='@specialization' Order By Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@specialization", ddl_specialization.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_subspecialization.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        GV_Details_SpecializationWise();
    }
    protected void ddl_subspecialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_subsubspecialization.Items.Clear();
        ddl_subsubspecialization.Items.Add("-Select-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Sub_Sub_Specialization from Sub_SubSpeclMaster Where Specialization_Name='@specialization' AND Sub_Specialization='@subspecialization' Order By Sub_Sub_Specialization";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@specialization", ddl_specialization.Text);
            cmd.Parameters.AddWithValue("@subspecialization", ddl_subspecialization.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_subsubspecialization.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        GV_Details_SubSpecializationWise();
    }
    protected void ddl_subsubspecialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_Details_SubSubSpecializationWise();
    }
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_district.Items.Clear();
        ddl_district.Items.Add("--Select State--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct District from DistrictMaster Where Country='India' AND State_Name='@state' Order By District";
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
            con.Close();
        }
        GV_Details_StateWise();
    }
    protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_city.Items.Clear();
        ddl_city.Items.Add("--Select State--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Vidhansabha from CityMaster Where Country='India' AND State_Name='@state' AND District='@district' Order By Vidhansabha";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@state", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_city.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        GV_Details_DistrictWise();
    }
    protected void ddl_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_village.Items.Clear();
        ddl_village.Items.Add("--Select State--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = @"Select Distinct Village from VillageMaster Where Country='India' AND State_Name='@state' AND District='@district' AND Vidhansabha='@city' Order By Village";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@state", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Parameters.AddWithValue("@city", ddl_city.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_village.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        GV_Details_CityWise();
    }
    protected void ddl_village_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_Details_VillageWise();
    }
    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        GV_Details_NameWise();
    }
}