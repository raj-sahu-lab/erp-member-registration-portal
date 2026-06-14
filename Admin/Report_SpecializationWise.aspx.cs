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

public partial class Admin_Report_SpecializationWise : System.Web.UI.Page
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
            ddl_zone.Items.Clear();
            ddl_zone.Items.Add("--Select--");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Specialization_Name from SpecializationMaster Order By Specialization_Name";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_zone.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            Upliner_Details();
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
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
        string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    protected void ddl_option_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_option.Text == "Personal Details")
        {
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
            GV_personal_details.DataSource = null;
            GV_personal_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_personal_details.DataSource = dtcourse;
                GV_personal_details.DataBind();
            }
        }
        if (ddl_option.Text == "Communication Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = true;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_communication_details.DataSource = null;
            GV_communication_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_communication_details.DataSource = dtcourse;
                GV_communication_details.DataBind();
            }
        }
        if (ddl_option.Text == "Qualification Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = true;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Qulification_Details.DataSource = null;
            GV_Qulification_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Qulification_Details.DataSource = dtcourse;
                GV_Qulification_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Employment Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = true;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Employment_Details.DataSource = null;
            GV_Employment_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Employment_Details.DataSource = dtcourse;
                GV_Employment_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Extra Activity Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = true;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Extra_Activity_Details.DataSource = null;
            GV_Extra_Activity_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Extra_Activity_Details.DataSource = dtcourse;
                GV_Extra_Activity_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Meeting Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = true;
            GV_SanghPariwar_details.Visible = false;

            GV_Meeting_Details.DataSource = null;
            GV_Meeting_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Meeting_Details.DataSource = dtcourse;
                GV_Meeting_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Sangh Pariwar Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = true;

            GV_SanghPariwar_details.DataSource = null;
            GV_SanghPariwar_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details From RSS_SanghPariwar Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_SanghPariwar_details.DataSource = dtcourse;
                GV_SanghPariwar_details.DataBind();
            }
        }
    }
    void GV_Details_CountryWise()
    {
        if (ddl_option.Text == "Personal Details")
        {
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
            GV_personal_details.DataSource = null;
            GV_personal_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_personal_details.DataSource = dtcourse;
                GV_personal_details.DataBind();
            }
        }
        if (ddl_option.Text == "Communication Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = true;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_communication_details.DataSource = null;
            GV_communication_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_communication_details.DataSource = dtcourse;
                GV_communication_details.DataBind();
            }
        }
        if (ddl_option.Text == "Qualification Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = true;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Qulification_Details.DataSource = null;
            GV_Qulification_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Qulification_Details.DataSource = dtcourse;
                GV_Qulification_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Employment Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = true;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Employment_Details.DataSource = null;
            GV_Employment_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Employment_Details.DataSource = dtcourse;
                GV_Employment_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Extra Activity Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = true;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Extra_Activity_Details.DataSource = null;
            GV_Extra_Activity_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Extra_Activity_Details.DataSource = dtcourse;
                GV_Extra_Activity_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Meeting Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = true;
            GV_SanghPariwar_details.Visible = false;

            GV_Meeting_Details.DataSource = null;
            GV_Meeting_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Meeting_Details.DataSource = dtcourse;
                GV_Meeting_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Sangh Pariwar Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = true;

            GV_SanghPariwar_details.DataSource = null;
            GV_SanghPariwar_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details From RSS_SanghPariwar Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_SanghPariwar_details.DataSource = dtcourse;
                GV_SanghPariwar_details.DataBind();
            }
        }
    }
    void GV_Details_StateWise()
    {
        if (ddl_option.Text == "Personal Details")
        {
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
            GV_personal_details.DataSource = null;
            GV_personal_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_personal_details.DataSource = dtcourse;
                GV_personal_details.DataBind();
            }
        }
        if (ddl_option.Text == "Communication Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = true;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_communication_details.DataSource = null;
            GV_communication_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_communication_details.DataSource = dtcourse;
                GV_communication_details.DataBind();
            }
        }
        if (ddl_option.Text == "Qualification Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = true;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Qulification_Details.DataSource = null;
            GV_Qulification_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Qulification_Details.DataSource = dtcourse;
                GV_Qulification_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Employment Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = true;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Employment_Details.DataSource = null;
            GV_Employment_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Employment_Details.DataSource = dtcourse;
                GV_Employment_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Extra Activity Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = true;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Extra_Activity_Details.DataSource = null;
            GV_Extra_Activity_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Extra_Activity_Details.DataSource = dtcourse;
                GV_Extra_Activity_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Meeting Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = true;
            GV_SanghPariwar_details.Visible = false;

            GV_Meeting_Details.DataSource = null;
            GV_Meeting_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Meeting_Details.DataSource = dtcourse;
                GV_Meeting_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Sangh Pariwar Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = true;

            GV_SanghPariwar_details.DataSource = null;
            GV_SanghPariwar_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details From RSS_SanghPariwar Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_SanghPariwar_details.DataSource = dtcourse;
                GV_SanghPariwar_details.DataBind();
            }
        }
    }
    void GV_Details_DistrictWise()
    {
        if (ddl_option.Text == "Personal Details")
        {
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
            GV_personal_details.DataSource = null;
            GV_personal_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_personal_details.DataSource = dtcourse;
                GV_personal_details.DataBind();
            }
        }
        if (ddl_option.Text == "Communication Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = true;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_communication_details.DataSource = null;
            GV_communication_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_communication_details.DataSource = dtcourse;
                GV_communication_details.DataBind();
            }
        }
        if (ddl_option.Text == "Qualification Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = true;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Qulification_Details.DataSource = null;
            GV_Qulification_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Qulification_Details.DataSource = dtcourse;
                GV_Qulification_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Employment Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = true;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Employment_Details.DataSource = null;
            GV_Employment_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Employment_Details.DataSource = dtcourse;
                GV_Employment_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Extra Activity Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = true;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Extra_Activity_Details.DataSource = null;
            GV_Extra_Activity_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Extra_Activity_Details.DataSource = dtcourse;
                GV_Extra_Activity_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Meeting Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = true;
            GV_SanghPariwar_details.Visible = false;

            GV_Meeting_Details.DataSource = null;
            GV_Meeting_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Meeting_Details.DataSource = dtcourse;
                GV_Meeting_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Sangh Pariwar Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = true;

            GV_SanghPariwar_details.DataSource = null;
            GV_SanghPariwar_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details From RSS_SanghPariwar Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_SanghPariwar_details.DataSource = dtcourse;
                GV_SanghPariwar_details.DataBind();
            }
        }       
    }
    void GV_Details_CityWise()
    {       
        if (ddl_option.Text == "Personal Details")
        {
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
            GV_personal_details.DataSource = null;
            GV_personal_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND City='" + ddl_city.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_personal_details.DataSource = dtcourse;
                GV_personal_details.DataBind();
            }
        }
        if (ddl_option.Text == "Communication Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = true;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_communication_details.DataSource = null;
            GV_communication_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND City='" + ddl_city.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_communication_details.DataSource = dtcourse;
                GV_communication_details.DataBind();
            }
        }
        if (ddl_option.Text == "Qualification Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = true;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Qulification_Details.DataSource = null;
            GV_Qulification_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND City='" + ddl_city.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Qulification_Details.DataSource = dtcourse;
                GV_Qulification_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Employment Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = true;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Employment_Details.DataSource = null;
            GV_Employment_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND City='" + ddl_city.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Employment_Details.DataSource = dtcourse;
                GV_Employment_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Extra Activity Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = true;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Extra_Activity_Details.DataSource = null;
            GV_Extra_Activity_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND City='" + ddl_city.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Extra_Activity_Details.DataSource = dtcourse;
                GV_Extra_Activity_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Meeting Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = true;
            GV_SanghPariwar_details.Visible = false;

            GV_Meeting_Details.DataSource = null;
            GV_Meeting_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where Country='" + ddl_country.Text.Replace("'", "''") + "' AND State='" + ddl_state.Text.Replace("'", "''") + "' AND District='" + ddl_district.Text.Replace("'", "''") + "' AND City='" + ddl_city.Text.Replace("'", "''") + "' AND QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Meeting_Details.DataSource = dtcourse;
                GV_Meeting_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Sangh Pariwar Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = true;

            GV_SanghPariwar_details.DataSource = null;
            GV_SanghPariwar_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details From RSS_SanghPariwar Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_SanghPariwar_details.DataSource = dtcourse;
                GV_SanghPariwar_details.DataBind();
            }
        }
    }
    void GV_Details_ZoneWise()
    {
        if (ddl_option.Text == "Personal Details")
        {
            GV_personal_details.Visible = true;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;
            GV_personal_details.DataSource = null;
            GV_personal_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_personal_details.DataSource = dtcourse;
                GV_personal_details.DataBind();
            }
        }
        if (ddl_option.Text == "Communication Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = true;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_communication_details.DataSource = null;
            GV_communication_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_communication_details.DataSource = dtcourse;
                GV_communication_details.DataBind();
            }
        }
        if (ddl_option.Text == "Qualification Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = true;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Qulification_Details.DataSource = null;
            GV_Qulification_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Qulification_Details.DataSource = dtcourse;
                GV_Qulification_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Employment Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = true;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Employment_Details.DataSource = null;
            GV_Employment_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Employment_Details.DataSource = dtcourse;
                GV_Employment_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Extra Activity Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = true;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = false;

            GV_Extra_Activity_Details.DataSource = null;
            GV_Extra_Activity_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Extra_Activity_Details.DataSource = dtcourse;
                GV_Extra_Activity_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Meeting Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = true;
            GV_SanghPariwar_details.Visible = false;
            GV_Meeting_Details.DataSource = null;
            GV_Meeting_Details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose From RSS_Registration Where QSpecialization='" + ddl_zone.Text.Replace("'", "''") + "' Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_Meeting_Details.DataSource = dtcourse;
                GV_Meeting_Details.DataBind();
            }
        }
        if (ddl_option.Text == "Sangh Pariwar Details")
        {
            GV_personal_details.Visible = false;
            GV_communication_details.Visible = false;
            GV_Qulification_Details.Visible = false;
            GV_Employment_Details.Visible = false;
            GV_Extra_Activity_Details.Visible = false;
            GV_Meeting_Details.Visible = false;
            GV_SanghPariwar_details.Visible = true;

            GV_SanghPariwar_details.DataSource = null;
            GV_SanghPariwar_details.DataBind();
            string qry = "select Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details From RSS_SanghPariwar Order By Reg_ID";
            DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry);
            if (dtcourse.Rows.Count > 0)
            {
                GV_SanghPariwar_details.DataSource = dtcourse;
                GV_SanghPariwar_details.DataBind();
            }
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
            cmd.CommandText = @"Select Distinct City from CityMaster Where Country='India' AND State_Name='@state' AND District='@district' Order By City";
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
        GV_Details_CityWise();
    }
    protected void ddl_zone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_Details_CityWise();
    }
}