using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for TreeClass
/// </summary>
public class TreeClass
{
    public TreeClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string getconString()
    {
        return ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
    }
    public static SqlConnection con;
    public static SqlConnection getCon()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        return con;
    }
    public static DataSet getDS(string s)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        SqlDataAdapter sda = new SqlDataAdapter(s, con);
        DataSet sds = new DataSet();
        sda.Fill(sds, "abc");
        return sds;
    }
    public static SqlDataReader getReader(string Query)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        SqlCommand scmd = new SqlCommand(Query, con);
        con.Open();
        return scmd.ExecuteReader();

    }
    public static int setData(string Sqry)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        SqlCommand scmd = new SqlCommand(Sqry, con);
        con.Open();
        int count = scmd.ExecuteNonQuery();
        con.Close();
        return count;
    }
    public static void Closecon()
    {
        con.Close();
    }
}
