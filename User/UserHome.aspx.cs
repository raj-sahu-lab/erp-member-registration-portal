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

public partial class User_UserHome : System.Web.UI.Page
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
            if (Session["Login_ID"].ToString() == null)
            {
                Response.Redirect("Default.aspx");
            }
            Load_AllData();
            Auto_Balance();
        }
    }
    void Auto_Balance()
    {
        ArrayList u_id = new ArrayList();
        ArrayList u_id1 = new ArrayList();
        string tbs_id = Session["Login_ID"].ToString();
        string self_pt = "0";
        string self_pt1 = "0";
        string tot_amount = "0";
        u_id.Clear();
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            //cmd.CommandText = "select Upliner_ID from MLMRegistration Order By Upliner_ID";
            //cmd.Connection = con;
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    u_id.Add(dr[0].ToString());
            //}
            //dr.Close();
            cmd.CommandText = "select User_ID from Point_Details Order By User_ID";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                u_id.Add(dr[0].ToString());
            }
            dr.Close();
            int i = 0;
            int i1 = 0;
            while (i < u_id.Count)
            {
                cmd.CommandText = "select Self_Point from Point_Details Where User_ID='" + u_id[i].ToString() + "'";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    self_pt = dr[0].ToString();
                }
                dr.Close();
                cmd.CommandText = "select Upliner_ID from Level_Tree Where Spil_Sponsor_ID='" + u_id[i].ToString() + "' AND Upliner_Level='FIRST LEVEL'";
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    u_id1.Add(dr[0].ToString());
                }
                dr.Close();
                while (i1 < u_id1.Count)
                {
                    cmd.CommandText = "select Self_Point from Level_Tree Where Upliner_ID='" + u_id1[i1].ToString() + "' AND Spil_Sponsor_ID='" + u_id[i].ToString() + "' AND Upliner_Level='FIRST LEVEL'";
                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        self_pt1 = dr[0].ToString();
                    }
                    dr.Close();
                    if (Convert.ToDouble(self_pt) <= Convert.ToDouble(self_pt1))
                    {
                        tot_amount = Convert.ToString(Math.Round(((Convert.ToDouble(self_pt) * 10) / 100), 2));
                        tot_amount = Convert.ToString(Convert.ToDouble(tot_amount) + (Math.Round(((Convert.ToDouble(self_pt1) * 10) / 100), 2)));
                    }
                    else
                    {
                        tot_amount = Convert.ToString(Math.Round(((Convert.ToDouble(self_pt1) * 10) / 100), 2));
                        tot_amount = Convert.ToString(Convert.ToDouble(tot_amount) + (Math.Round(((Convert.ToDouble(self_pt1) * 10) / 100), 2)));
                    }
                    cmd.CommandText = "Update Level_Tree Set Total_Point='" + tot_amount + "' Where Upliner_ID='" + u_id1[i1].ToString() + "' AND Spil_Sponsor_ID='" + u_id[i].ToString() + "' AND Upliner_Level='FIRST LEVEL'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    i1 = i1 + 1;
                }
                i1 = 0;
                u_id1.Clear();
                i = i + 1;
            }
            i = 0;
            i1 = 0;
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }

    }
    void Load_AllData()
    {
        try
        {
            double F_LEVEL = 0;
            double S_LEVEL = 0;
            double T_LEVEL = 0;
            double LEVEL4 = 0;
            double LEVEL5 = 0;
            double LEVEL6 = 0;
            double LEVEL7 = 0;
            double LEVEL8 = 0;
            double LEVEL9 = 0;
            double LEVEL10 = 0;
            double LEVEL11 = 0;
            double LEVEL12 = 0;
            double LEVEL13 = 0;
            double LEVEL14 = 0;
            double LEVEL15 = 0;
            double LEVEL16 = 0;
            double LEVEL17 = 0;
            double LEVEL18 = 0;
            double LEVEL19 = 0;
            double LEVEL20 = 0;
            string tbs_id = Session["Login_ID"].ToString();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select Self_Point from Point_Details Where User_ID='" + tbs_id + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lb_self_bonus.Text = dr[0].ToString();
            }
            dr.Close();
            cmd.CommandText = "select tds, pc, Other from TaxMaster";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lb_tds.Text = dr[0].ToString();
                lb_pc.Text = dr[1].ToString();
                lb_other.Text = dr[2].ToString();
            }
            dr.Close();
            cmd.CommandText = "select Matching_Point from Matching_Bonus Where Sponsor_ID='" + tbs_id + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lb_matching_bonus.Text = dr[0].ToString();
                lb_matching_bonus.Text = Convert.ToString(Math.Round(((Convert.ToDouble(lb_matching_bonus.Text) * 10) / 100), 2));
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='FIRST LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                F_LEVEL = Convert.ToDouble(dr[0]) + F_LEVEL;
            }
            lb_first_level.Text = Convert.ToString(F_LEVEL);
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='SECOND LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                S_LEVEL = Convert.ToDouble(dr[0]) + S_LEVEL;
            }
            lb_second_level.Text = Convert.ToString(S_LEVEL);
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='THIRD LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                T_LEVEL = Convert.ToDouble(dr[0]) + T_LEVEL;
            }
            lb_third_level.Text = Convert.ToString(T_LEVEL);
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='FOURTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL4 = Convert.ToDouble(dr[0]) + LEVEL4;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='FIFTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL5 = Convert.ToDouble(dr[0]) + LEVEL5;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='SIXTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL6 = Convert.ToDouble(dr[0]) + LEVEL6;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='SEVENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL7 = Convert.ToDouble(dr[0]) + LEVEL7;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='EIGHT LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL8 = Convert.ToDouble(dr[0]) + LEVEL8;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='NINE LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL9 = Convert.ToDouble(dr[0]) + LEVEL9;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='TENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL10 = Convert.ToDouble(dr[0]) + LEVEL10;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='ELEVENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL11 = Convert.ToDouble(dr[0]) + LEVEL11;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='TWELVETH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL12 = Convert.ToDouble(dr[0]) + LEVEL12;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='THIRTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL13 = Convert.ToDouble(dr[0]) + LEVEL13;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='FOURTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL14 = Convert.ToDouble(dr[0]) + LEVEL14;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='FIFTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL15 = Convert.ToDouble(dr[0]) + LEVEL15;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='SIXTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL16 = Convert.ToDouble(dr[0]) + LEVEL16;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='SEVENTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL17 = Convert.ToDouble(dr[0]) + LEVEL17;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='EIGHTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL18 = Convert.ToDouble(dr[0]) + LEVEL18;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='NINTEENTH LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL19 = Convert.ToDouble(dr[0]) + LEVEL19;
            }
            dr.Close();
            cmd.CommandText = "select Total_Point from Level_Tree Where Sponsor_ID='" + tbs_id + "' AND Upliner_Level='TWENTY LEVEL'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LEVEL20 = Convert.ToDouble(dr[0]) + LEVEL20;
            }
            dr.Close();
            lb_fourth_level.Text = Convert.ToString(Math.Round(LEVEL4 + LEVEL5 + LEVEL6 + LEVEL7 + LEVEL8 + LEVEL9 + LEVEL10 + LEVEL11 + LEVEL12 + LEVEL13 + LEVEL14 + LEVEL15 + LEVEL16 + LEVEL17 + LEVEL18 + LEVEL19 + LEVEL20, 2));
            con.Close();
            lb_total.Text = Convert.ToString(Math.Round(Convert.ToDouble(lb_matching_bonus.Text) + Convert.ToDouble(lb_self_bonus.Text) + Convert.ToDouble(lb_first_level.Text) + Convert.ToDouble(lb_second_level.Text) + Convert.ToDouble(lb_third_level.Text) + Convert.ToDouble(lb_fourth_level.Text), 2));
            lb_ded_tds.Text = Convert.ToString(Math.Round(((Convert.ToDouble(lb_total.Text) * Convert.ToDouble(lb_tds.Text)) / 100), 2));
            lb_ded_pc.Text = Convert.ToString(Math.Round(((Convert.ToDouble(lb_total.Text) * Convert.ToDouble(lb_pc.Text)) / 100), 2));
            lb_ded_other.Text = Convert.ToString(Math.Round(((Convert.ToDouble(lb_total.Text) * Convert.ToDouble(lb_other.Text)) / 100), 2));
            lb_grand_total.Text = Convert.ToString(Math.Round(Convert.ToDouble(lb_total.Text) - (Convert.ToDouble(lb_ded_tds.Text) + Convert.ToDouble(lb_ded_pc.Text) + Convert.ToDouble(lb_ded_other.Text)), 2));
        }
        catch (Exception ex)
        {
            con.Close();
            lb_message.Text = ex.Message;
        }
    }
}