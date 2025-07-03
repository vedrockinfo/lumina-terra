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
using System.Collections.Generic;
using System.Xml;
using System.Reflection;

/// <summary>
/// Summary description for commoncode
/// </summary>
public class commoncode
{
    cls_connection Mycon = new cls_connection();
    SqlDataReader dr;
    private SqlConnection con;
    public SqlCommand SqlCmd;
    private SqlCommand cmd;
    private SqlDataAdapter da;
    private DataTable dt;
    private DataSet ds;
    public commoncode()
    {
        ConnectToServer();
        SqlCmd = new SqlCommand();
        SqlCmd.Connection = con;
        cmd = new SqlCommand();
    }
    public enum mode_Type
    {
        NewMode = 0,
        EditMode = 1,
        GenMode = 2
    }
    public static Int16 get_Count(string tableName, string whereclause)
    {
        cls_connection MyCon = new cls_connection();
        DataSet ds = new DataSet();
        MyCon.open();
        if (string.IsNullOrEmpty(whereclause.Trim()))
        {
            MyCon.adp.SelectCommand.CommandText = "select * from " + tableName;
        }
        else
        {
            MyCon.adp.SelectCommand.CommandText = "select * from " + tableName + " Where " + whereclause;
        }
        MyCon.adp.Fill(ds, "RowsCount");
        MyCon.close();
        return (Int16)ds.Tables["RowsCount"].Rows.Count;
    }
    public static void Create_Log(string Userid, string Form_Name, string eventName, string IpAddress, string msg)
    {
        cls_connection MyCon = new cls_connection();
        string date1 = "";
        string time1 = null;
        DataSet ds = new DataSet();
        string id = null;

        //+++++++++++++++++ These Lines For ID
        MyCon.adp.SelectCommand.CommandText = "SELECT dbo.getLogId()";
        //+++++++++++++++++ End Code"
        MyCon.adp.Fill(ds, "stid");
        date1 = DateTime.Now.ToString("dd/MMM/yyyy");
        time1 = DateTime.Now.ToLongTimeString();
        id = ds.Tables["stid"].Rows[ds.Tables["stid"].Rows.Count - 1][0].ToString();
        MyCon.adp.SelectCommand.CommandText = "insert into tbl_eventLog values('" + id + "','" + Userid + "','" + Form_Name + "','" + eventName + "','" + date1 + "','" + time1 + "','" + IpAddress + "','" + msg + "')";
        MyCon.open();
        MyCon.adp.SelectCommand.ExecuteNonQuery();
        MyCon.close();
    }

    //public static void BeginTransaction(ref MyConnection Mycon)
    //{
    //    Mycon.trans = Mycon.con.BeginTransaction();
    //}
    //public static void RollBackTransaction(ref MyConnection Mycon)
    //{
    //    Mycon.trans.Rollback();
    //}
    //public static void CommitTransaction(ref MyConnection Mycon)
    //{
    //    Mycon.trans.Commit();
    //}
    public static void delete_Record(string tableName, string fieldName, string Id)
    {
        cls_connection mycon = new cls_connection();
        mycon.con.Open();
        mycon.adp.SelectCommand.CommandText = "delete from " + tableName + " where " + fieldName + "='" + Id + "' ";
        mycon.adp.SelectCommand.ExecuteNonQuery();
        mycon.con.Close();
    }
    public static void delete_Record(string tableName, string fieldName, string Id, ref cls_connection mycon)
    {
       
        mycon.con.Open();
        mycon.cmd.CommandText = "delete from " + tableName + " where " + fieldName + "='" + Id + "' ";
        mycon.cmd.ExecuteNonQuery();
        mycon.con.Close();
    }
    public string Set_Value(string s)
    {

        s = s.Replace("'", "''");
        //s = s.Replace("-", "''");
        //s = s.Replace("/", "''");
        return s.Trim();
    }
    public string get_Value(string s)
    {

        s = s.Replace("''", "'");
        //s = s.Replace("''", "-");
        //s = s.Replace("''", "/");
        return s.Trim();
    }
    
    //public static string get_Lastid(string tblname, string fieldname)
    //{
    //    DAL_Commoncode obj_DALCommonCode = new DAL_Commoncode();
    //    return (obj_DALCommonCode.GetLastID(tblname, fieldname));

    //}
    //public static System.Data.DataSet display(string tblname, string whereclause, string IdField, string ID)
    //{
    //    DAL_Commoncode obj_DALCommonCode = new DAL_Commoncode();
    //    return (obj_DALCommonCode.Display(tblname, whereclause, IdField, ID));
    //}

    //public static string get_Lastidwithwhere(string tblname, string fieldname, int length, string whereclause)
    //{
    //    DAL_Commoncode obj_DALCommonCode = new DAL_Commoncode();
    //    return (obj_DALCommonCode.GetLastIDWithWhere(tblname, fieldname, length, whereclause));
    //}
    //public void itemproupddl(DropDownList ddl)
    //{

      
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        cls_connection Mycon = new cls_connection();
    //        Mycon.cmd.CommandType = CommandType.StoredProcedure;
    //        Mycon.cmd.CommandText = "usp_M_ItemGroupSelect";

    //        Mycon.open();
    //        Mycon.cmd.Parameters.AddWithValue("@GroupID", DBNull.Value);
    //        SqlDataReader dr;
    //        dr = Mycon.cmd.ExecuteReader();
    //        ddl.DataSource = dr;
    //        ddl.DataTextField = "GroupName";
    //        ddl.DataValueField = "GroupID";

    //        ddl.DataBind();
    //        ddl.Items.Insert(0, "<--Select-->");
    //        ddl.Items[0].Value = "0";
    //        Mycon.close();

    //    }
    //    catch
    //    {

    //    }

    //}
    public static String ConvertToXMLFormat<T>(ref List<T> list)
    {


        XmlDocument doc = new XmlDocument();
        XmlNode node = doc.CreateNode(XmlNodeType.Element, string.Empty, "root", null);

        foreach (T xml in list)
        {
            XmlElement element = doc.CreateElement("data");

            PropertyInfo[] allProperties = xml.GetType().GetProperties();
            foreach (PropertyInfo thisProperty in allProperties)
            {
                object value = thisProperty.GetValue(xml, null);
                XmlElement tmp = doc.CreateElement(thisProperty.Name);
                if (value != null)
                {
                    tmp.InnerXml = value.ToString();
                }
                else
                {
                    tmp.InnerXml = string.Empty;
                }
                element.AppendChild(tmp);
            }
            node.AppendChild(element);
        }
        doc.AppendChild(node);
        return doc.InnerXml;
    }
    public DataView Get_Data(string sql)
    {
        DataView dv = new DataView();
        try
        {
            sql = "set dateformat mdy " + sql;
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            dt = new DataTable("table1");
            da.Fill(dt);
            ds.Tables.Add(dt);
            dv = ds.Tables["table1"].DefaultView;
            return dv;


        }
        catch { return dv; }
        con.Close();
        con.Dispose();
    }
    public DataSet Get_Datadataset(string sql)
    {
        DataSet ds = new DataSet();
        try
        {
            sql = sql;
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            dt = new DataTable("table1");
            da.Fill(ds);
            return ds;


        }
        catch { return ds; }
        con.Close();
        con.Dispose();
    }
    public bool Insert_data(string qry)
    {
        SqlCmd = new SqlCommand();
        SqlCmd.CommandText = qry;
        try
        {
            SqlCmd.Connection = con;
            SqlCmd.ExecuteNonQuery();
            return true;
        }
        catch
        { return false; }
        con.Close();
        con.Dispose();
    }
    public bool Update_data(string qry)
    {
        SqlCmd = new SqlCommand();
        SqlCmd.CommandText = qry;
        try
        {
            SqlCmd.Connection = con;
            SqlCmd.ExecuteNonQuery();
            return true;
        }
        catch
        { return false; }
        con.Close();
        con.Dispose();
    }
    public bool Delete_data(string qry)
    {
        con = new SqlConnection();
        SqlCmd = new SqlCommand();
       
        SqlCmd.CommandText = qry;
        try
        {
           
            SqlCmd.Connection = con;
            SqlCmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        con.Close();
        con.Dispose();

    }
    private Boolean ConnectToServer()
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["CON"].ToString();
        try
        {
            con = new SqlConnection(connection);
            con.Open();
            return true;
        }
        catch (SqlException ex)
        {
            return false;
        }
    }
    public DataView get_data_select(string qry)
    {
        DataView dv = new DataView();
        try
        {
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            dt = new DataTable("table1");
            da.Fill(dt);
            ds.Tables.Add(dt);
            dv = ds.Tables["table1"].DefaultView;
            return dv;
        }
        catch { return dv; }
        con.Close();
        con.Dispose();
    }
    public string GetMax(string str)
    {
        string id;
        da = new SqlDataAdapter(str, con);
        ds = new DataSet();
        dt = new DataTable("table1");
        da.Fill(dt);
        ds.Tables.Add(dt);
        id = ds.Tables["table1"].Rows[0][0].ToString();
        return id;
        con.Close();
        con.Dispose();
    }
       public static void bindemptygrid(ref GridView grd)
    {
        string str = "<html><table border='1' width='99%' border-collapse='collapse' cellspadding='0' cellspacing='0' style='Font-weight:bold;'><tr  bgcolor='#FFFFCC'>";
        string emptyro = "</tr><tr>";
        for (int i = 0; i < grd.Columns.Count; i++)
        {
            str += "<td align='left' Class='header'> " + grd.Columns[i].HeaderText.ToString() + " </td>";
            emptyro += "<td align='left'>&nbsp;</td>";
        }
        emptyro += "</tr></table></html>";
        str += emptyro;
        grd.DataSource = "";
        grd.DataBind();
        GridViewRow gvr;
        Table tbl = (Table)grd.Controls[0];
        gvr = (GridViewRow)tbl.Controls[0];
        TableCell cell = gvr.Cells[0];
        //Literal emptydataheader = (Literal)cell.FindControl("emptydataheader");
        //emptydataheader.Text = str;
        cell.Text = str;
    }
    //public void ddlbind(DropDownList ddl, string query, string datatextfield, string datavaluefield, string selected)
    //{
    //    cls_connection MyCon = new cls_connection();
    //    ddl.Items.Clear();
    //    Mycon.cmd.CommandType = CommandType.Text;
    //    Mycon.cmd.CommandText = query;
    //    Mycon.open();
    //    dr = Mycon.cmd.ExecuteReader();
    //    ddl.DataSource = dr;
    //    ddl.DataTextField = datatextfield;
    //    ddl.DataValueField = datavaluefield;
    //    ddl.DataBind();
    //    dr.Close();
    //    Mycon.close();
    //    if (selected != "")
    //    {
    //        ListItem lst = new ListItem();
    //        lst.Value = "0";
    //        lst.Text = selected;
    //        ddl.Items.Insert(0,lst);
    //    }

    //}
    public void LoadRole(ref  DropDownList ddl)
    {

        ddl.Items.Clear();
        Mycon.cmd.CommandType = CommandType.Text;
        Mycon.cmd.CommandText = "exec LoadAllRole_SP";
        Mycon.open();

        dr = Mycon.cmd.ExecuteReader();
        ddl.DataSource = dr;
        ddl.DataTextField = "RollName";
        ddl.DataValueField = "RollId";
        ddl.DataBind();
        dr.Close();
        Mycon.close();
        ddl.Items.Insert(0, "<--Select Role-->");
        ddl.Items[0].Value = "000000";
    }
    public DataTable Login(string Uname, string Pass, string Role)
    {
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "Login_sp";
        Mycon.cmd.Parameters.AddWithValue("@UName", Uname);
        Mycon.cmd.Parameters.AddWithValue("@pass", Pass);
        Mycon.cmd.Parameters.AddWithValue("@role", Role);
        Mycon.open();
        dr = Mycon.cmd.ExecuteReader();
        dt.Load(dr);
        dr.Close();
        Mycon.close();
        return dt;
    }   
}

