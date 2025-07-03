using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
/// <summary>
/// Summary description for cls_connection
/// </summary>
public class cls_connection
{
    public System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
    public System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter();
    public System.Data.SqlClient.SqlCommandBuilder cb;
    public System.Data.SqlClient.SqlCommand cmd;
    public System.Data.SqlClient.SqlTransaction trans;
    public cls_connection()
    {
        cb = new System.Data.SqlClient.SqlCommandBuilder(adp);
        adp.SelectCommand = new System.Data.SqlClient.SqlCommand(" ", con);
        adp.InsertCommand = new System.Data.SqlClient.SqlCommand(" ", con);
        adp.UpdateCommand = new System.Data.SqlClient.SqlCommand(" ", con);
        cmd = new System.Data.SqlClient.SqlCommand("", con);
        con.ConnectionString = ConfigurationManager.ConnectionStrings["CISCon"].ToString();
    }
    public void open()
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
    }
    public void close()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
    
}