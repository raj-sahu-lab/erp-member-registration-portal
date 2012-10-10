using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class classDB
{

    // so that u dont have to 

    public static string qryStr = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.ToString();
   
    public SqlConnection scon = new SqlConnection(qryStr);
    public SqlCommand scom = new SqlCommand();
    public classDB()
    {

    }
    public void conOpen()
    {

        if (scon.State.Equals(System.Data.ConnectionState.Closed))
        {

            scon.Open();
        }        
    }
    public int com_conOpen()
    {
        if (scon.State.Equals(System.Data.ConnectionState.Closed))
        {

            try
            {


                scon.Open();
            }
            catch
            {
                return 1;
            }
        }      
        scom.Connection = scon;
        scom.CommandType = CommandType.Text;
        scom.CommandType = CommandType.Text;
        return 0;
    }

}
