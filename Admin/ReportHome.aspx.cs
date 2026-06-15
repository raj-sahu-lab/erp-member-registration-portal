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

public partial class Admin_ReportHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime curr_date = DateTime.Now;
            if (Session["Login_ID"] == null || Session["Login_ID"].ToString() == "")
            {
                Response.Redirect("../Default.aspx");
            }
            ddl_regid.Items.Clear();
            ddl_regid.Items.Add("-Select ID-");
            ddl_name.Items.Clear();
            ddl_name.Items.Add("-Select Name-");
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
                con.Open();
                cmd.CommandText = "Select Distinct Reg_ID from RSS_Registration Order By Reg_ID";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_regid.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cmd.CommandText = "Select Distinct Name from RSS_Registration Order By Name";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddl_name.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
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
       
        
        //string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age,Email_ID3,Email_ID4, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Order By Reg_ID";
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
Additional_Remark,present_past,sanghsiksha,level,vicharpariwar,familymembername,rss_member_id From RSS_Registration Order By Reg_ID";
        
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
        //string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Reg_Date>='" + Convert.ToDateTime(txtfrom_date.Text) + "' AND Reg_Date<='" + Convert.ToDateTime(txtto_date.Text) + "' AND Reg_ID='" + ddl_regid.Text + "' Order By Reg_ID";
       
        
        //string qry = "select distinct Reg_ID, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Reg_ID='" + ddl_regid.Text + "' Order By Reg_ID";

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
Additional_Remark,present_past,sanghsiksha,level,vicharpariwar,familymembername,rss_member_id From RSS_Registration
Where Reg_ID=@regId Order By Reg_ID";
        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry, new SqlParameter("@regId", ddl_regid.Text));
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
        //string qry = "select Reg_ID, convert(char(10), Reg_Date, 103) as Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Reg_Date>='" + Convert.ToDateTime(txtfrom_date.Text) + "' AND Reg_Date<='" + Convert.ToDateTime(txtto_date.Text) + "' AND Name='" + ddl_name.Text + "' Order By Reg_ID";
      //  string qry = "select distinct Reg_ID, convert(char(10), Reg_Date, 103) as Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription From RSS_Registration Where Name='" + ddl_name.Text + "' Order By Reg_ID";
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
Additional_Remark,present_past,sanghsiksha,level,vicharpariwar,familymembername,rss_member_id From RSS_Registration
Where Name=@name Order By Reg_ID";

        DataTable dtcourse = ExecuteDataTable(classDB.qryStr, CommandType.Text, qry, new SqlParameter("@name", ddl_name.Text));
        if (dtcourse.Rows.Count > 0)
        {
            GV_personal_details.DataSource = dtcourse;
            GV_personal_details.DataBind();
        }
    }
    protected void ddl_regid_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_Details_CountryWise();
    }
    protected void ddl_name_SelectedIndexChanged(object sender, EventArgs e)
    {        
        GV_Details_StateWise();
    }
}
