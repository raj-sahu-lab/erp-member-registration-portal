using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TreeShow
/// </summary>
public class TreeShow
{

    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlDataReader dr;
    DataSet ds;
    DataTable dt;
    string sql;
    int status;
    string msg;

    public void find(string apid, out string Left, out string Right)
    {
        Left = "";
        Right = "";
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "select lleg,rleg from User_Detail where userid='" + apid + "'";
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    Left = dr[0].ToString();
                }
                if (dr[1].ToString() != "")
                {

                    Right = dr[1].ToString();
                }
            }
            con.Close();
        }
        catch (Exception ex)
        {
            //Label3.Text= ex.Message();
            con.Close();
        }
    }

    public DataTable fillUserDetail(string apid)
    {
        //DataTable ufill = new DataTable();
        //TreeClass.getCon();        
        //da = new SqlDataAdapter("select name,ljoining,rjoining,pair,jointype from User_Detail where userid='" + apid + "'", con);
        //da.Fill(ufill);
        //TreeClass.Closecon();
        //return ufill;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        con.Open();
        string s = "select name,ljoining,rjoining,pair,jointype from User_Detail where userid='" + apid + "'";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataTable ufill = new DataTable();
        da.Fill(ufill);
        con.Close();
        return ufill;

    }

}