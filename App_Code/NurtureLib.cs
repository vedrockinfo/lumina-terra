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
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

/// <summary>
/// Summary description for NurtureLib
/// </summary>
public class NurtureLib
{
    Random random = new Random();
    SqlConnection con = new SqlConnection();
    public string ReportPath = "";
    public string ReportfileName = "";
    public string ReportQuery = "";
	public NurtureLib()
	{
        con.ConnectionString = ConfigurationManager.ConnectionStrings["CISCon"].ConnectionString;
	}


    public void FillChekckBoxWithID(string qry, CheckBoxList drp, string ColumnName, string ColumnId)
    {
        try
        {
            con.Open();

            SqlDataAdapter sd = new SqlDataAdapter(qry, con);
            drp.Items.Clear();
            DataSet ds = new DataSet();
            sd.Fill(ds, "temp");

            if (ds.Tables["temp"].Rows.Count > 0)
            {
                drp.DataSource = ds.Tables["temp"];
                drp.DataTextField = ColumnName;
                drp.DataValueField = ColumnId;
                drp.DataBind();

            }
            con.Close();
        }
        catch (Exception ex)
        {
        }

    }


    public void FillChekckBoxWithIDSelected(string qry, CheckBoxList drp, string ColumnName, string ColumnId)
    {
        try
        {
            con.Open();

            SqlDataAdapter sd = new SqlDataAdapter(qry, con);
            drp.Items.Clear();
            DataSet ds = new DataSet();
            sd.Fill(ds, "temp");

            if (ds.Tables["temp"].Rows.Count > 0)
            {
                drp.DataSource = ds.Tables["temp"];
                drp.DataTextField = ColumnName;
                drp.DataValueField = ColumnId;
                drp.DataBind();

            }
            con.Close();


            int i = 0;
            for (i = 0; i <= drp.Items.Count - 1; i++)
            {
                drp.Items[i].Selected = true;
            }
        }
        catch (Exception ex)
        {
        }

    }





    public void AddFieldsInTableStringOrNumeric(string TableName, string FieldName, string Datatype, string size)
    {
        string sql = "";
        sql = "ALTER TABLE " + TableName + " ADD " + FieldName + " " + Datatype + "(" + size + ") NULL";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException) { con.Close(); }

    }


    public void AddFieldsInTableInt(string TableName, string FieldName, string Datatype)
    {
        string sql = "";
        sql = "ALTER TABLE " + TableName + " ADD " + FieldName + " " + Datatype + " NULL";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException) { con.Close(); }

    }
    public void AddFieldsInTableIntOrDatetime(string TableName, string FieldName, string Datatype, string size)
    {
        string sql = "";
        sql = "ALTER TABLE " + TableName + " ADD " + FieldName + " " + Datatype + "(" + size + ") NULL";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException) { con.Close(); }

    }

    public void ProcedureDatabase(string ProcedureQuery)
    {
        string sql = "";
        sql = ProcedureQuery;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (SqlException) { con.Close(); }
        catch (Exception) { con.Close(); }
    }

    public Boolean Duplicate(string qry)
    {
        //con.ConnectionString = "Data Source=Axon;User ID=sa;Password=vikash;Initial Catalog=LPSFees;";
        int co = 0;
        Boolean flag = false;
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.CommandText = qry;
            SqlDataReader dr;
            cmd.Connection = con;

            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                co++;
            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }

        if (co >= 1)
        {
            flag = true;
        }
        return flag;
    }
    public void FillCheckBox(string qry, CheckBoxList chk, string ColumnName)
    {
        string ss = "";
        SqlCommand cmd = new SqlCommand();
        try
        {
            // ss = "Select '<--Select-->' as " + ColumnName + " Union ";
            //ss = ss + qry;

            cmd.CommandText = qry;
            SqlDataReader dr;

            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader();

            chk.Items.Clear();

            while (dr.Read())
            {

                chk.Items.Add(dr[ColumnName].ToString());
            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }
    }

    public void FillDropDown(string qry, DropDownList drp, string ColumnName)
    {
        string ss = "";
        SqlCommand cmd = new SqlCommand();
        drp.Items.Clear();
        try
        {
            ss = "Select '--Select--' as " + ColumnName + " Union ";
            ss = ss + qry;
            cmd.CommandText = ss;
            SqlDataReader dr;

            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                drp.Items.Add(dr[ColumnName].ToString());
            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }
        catch (Exception) { }
    }


    public string ConvertMultiColumnInASingleColumn(string qry, string ColumnName)
    {
        string ss = "";
        SqlCommand cmd = new SqlCommand();
        string MultiColumnValue = "";
        try
        {
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                MultiColumnValue = MultiColumnValue + dr[ColumnName].ToString() + ", ";
            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }
        catch (Exception) { }
        return MultiColumnValue;
    }




    public void FillDropDownWithID(string qry, DropDownList drp, string ColumnName, string ColumnId)
    {
        try
        {
            con.Open();

            SqlDataAdapter sd = new SqlDataAdapter(qry, con);
            drp.Items.Clear();
            DataSet ds = new DataSet();
            sd.Fill(ds, "temp");

            if (ds.Tables["temp"].Rows.Count > 0)
            {
                drp.DataSource = ds.Tables["temp"];
                drp.DataTextField = ColumnName;
                drp.DataValueField = ColumnId;
                drp.DataBind();
                drp.Items.Insert(0, "--Select--");
                drp.Items[0].Value = "0";

            }
            con.Close();
        }
        catch (Exception ex)
        {
        }

    }



    public void FillRadioWithID(string qry, RadioButtonList drp, string ColumnName, string ColumnId)
    {
        try
        {
            con.Open();

            SqlDataAdapter sd = new SqlDataAdapter(qry, con);
            drp.Items.Clear();
            DataSet ds = new DataSet();
            sd.Fill(ds, "temp");

            if (ds.Tables["temp"].Rows.Count > 0)
            {
                drp.DataSource = ds.Tables["temp"];
                drp.DataTextField = ColumnName;
                drp.DataValueField = ColumnId;
                drp.DataBind();

            }
            con.Close();
        }
        catch (Exception ex)
        {
        }

    }


    public void FillDropDownWithIDAll(string qry, DropDownList drp, string ColumnName, string ColumnId)
    {
        try
        {
            con.Open();

            SqlDataAdapter sd = new SqlDataAdapter(qry, con);
            drp.Items.Clear();
            DataSet ds = new DataSet();
            sd.Fill(ds, "temp");

            if (ds.Tables["temp"].Rows.Count > 0)
            {
                drp.DataSource = ds.Tables["temp"];
                drp.DataTextField = ColumnName;
                drp.DataValueField = ColumnId;
                drp.DataBind();
                drp.Items.Insert(0, "--All--");
                drp.Items[0].Value = "0";
                

            }
            con.Close();
        }
        catch (Exception ex)
        {
        }

    }

    public void FillDropDownWithOutSelect(string qry, DropDownList drp, string ColumnName)
    {
        string ss = "";
        SqlCommand cmd = new SqlCommand();
        drp.Items.Clear();
        try
        {

            cmd.CommandText = qry;
            SqlDataReader dr;

            cmd.Connection = con;
            con.Open();
            dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                drp.Items.Add(dr[ColumnName].ToString());
            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }
        catch (Exception) { }
    }
    public string ReturnTag(string qry, string ColumnNameValue)
    {
        SqlCommand cmd = new SqlCommand();
        string ss = "";
        try
        {
            cmd.CommandText = qry;
            SqlDataReader dr;

            cmd.Connection = con;

            try
            {
                con.Open();
            }
            catch (Exception) { con.Close(); con.Open(); }


            dr = cmd.ExecuteReader();


            while (dr.Read())
            {

                ss = dr[ColumnNameValue].ToString();
            }
            con.Close();
        }
        catch (SqlException)
        {
            con.Close();
        }

        catch (Exception) { con.Close(); }
        return ss;
    }


    public DataSet GridFill(string qry)
    {
        bool result = false;
        SqlDataAdapter sd = new SqlDataAdapter(qry, con);
        DataSet ds = new DataSet();
        try
        {

            con.Open();
            sd.Fill(ds, "#temp");

            con.Close();
            result = true;
        }
        catch (SqlException ee) { con.Close(); }
        catch (Exception) { con.Close(); }
        if (result)
        {
            return ds;
        }
        else
        {
            return null;
        }
    }


    public void MonthDropDown(DropDownList dropDownYear, DropDownList drpDownMonth, DropDownList DropDownDate)
    {
        int yy, i;

        if (drpDownMonth.SelectedItem.ToString() == "Jan" || drpDownMonth.SelectedItem.ToString() == "Mar" || drpDownMonth.SelectedItem.ToString() == "May" || drpDownMonth.SelectedItem.ToString() == "Jul" || drpDownMonth.SelectedItem.ToString() == "Aug" || drpDownMonth.SelectedItem.ToString() == "Oct" || drpDownMonth.SelectedItem.ToString() == "Dec")
        {
            DropDownDate.Items.Clear();
            for (i = 1; i <= 31; i++)
            {

                DropDownDate.Items.Add(i.ToString());
            }
        }
        else if (drpDownMonth.SelectedItem.ToString() == "Apr" || drpDownMonth.SelectedItem.ToString() == "Jun" || drpDownMonth.SelectedItem.ToString() == "Sep" || drpDownMonth.SelectedItem.ToString() == "Nov")
        {
            DropDownDate.Items.Clear();
            for (i = 1; i <= 30; i++)
            {
                DropDownDate.Items.Add(i.ToString());
            }

        }
        else
        {
            yy = Convert.ToInt32(dropDownYear.SelectedItem.ToString());
            yy = yy % 4;
            if (yy == 0 && drpDownMonth.SelectedItem.ToString() == "Feb")
            {
                DropDownDate.Items.Clear();
                for (i = 1; i <= 29; i++)
                {
                    DropDownDate.Items.Add(i.ToString());
                }

            }
            else
            {

                DropDownDate.Items.Clear();
                for (i = 1; i < 29; i++)
                {
                    DropDownDate.Items.Add(i.ToString());
                }


            }



        }
    }


    public void YearDropDown(DropDownList dropDownYear, DropDownList drpDownMonth, DropDownList DropDownDate)
    {
        int yy, i;
        yy = Convert.ToInt32(dropDownYear.SelectedItem.ToString());
        yy = yy % 4;
        if (yy == 0 && drpDownMonth.SelectedItem.ToString() == "Feb")
        {
            DropDownDate.Items.Clear();
            for (i = 1; i <= 29; i++)
            {
                DropDownDate.Items.Add(i.ToString());
            }

        }
        else if (yy != 0 && drpDownMonth.SelectedItem.ToString() == "Jan" || drpDownMonth.SelectedItem.ToString() == "Mar" || drpDownMonth.SelectedItem.ToString() == "May" || drpDownMonth.SelectedItem.ToString() == "Jul" || drpDownMonth.SelectedItem.ToString() == "Aug" || drpDownMonth.SelectedItem.ToString() == "Oct" || drpDownMonth.SelectedItem.ToString() == "Dec")
        {
            DropDownDate.Items.Clear();
            for (i = 1; i <= 31; i++)
            {
                DropDownDate.Items.Add(i.ToString());
            }

        }


        else if (yy != 0 && drpDownMonth.SelectedItem.ToString() == "Apr" || drpDownMonth.SelectedItem.ToString() == "Jun" || drpDownMonth.SelectedItem.ToString() == "Sep" || drpDownMonth.SelectedItem.ToString() == "Nov")
        {
            DropDownDate.Items.Clear();
            for (i = 1; i <= 30; i++)
            {
                DropDownDate.Items.Add(i.ToString());
            }

        }


        else if (yy != 0 && drpDownMonth.SelectedItem.ToString() == "Feb")
        {
            DropDownDate.Items.Clear();
            for (i = 1; i <= 28; i++)
            {
                DropDownDate.Items.Add(i.ToString());
            }

        }

    }

    public void AddDateMonthYearDropDown(DropDownList dropDownYear, DropDownList drpDownMonth, DropDownList DropDownDate)
    {

        int i;
        string yy;
        //For Date Of Birth
        if (DropDownDate.Items.Count == 0)
        {
            for (i = 1; i <= 31; i++)
            {
                DropDownDate.Items.Add(i.ToString());
            }

        }
        if (drpDownMonth.Items.Count == 0)
        {

            drpDownMonth.Items.Add("Jan");
            drpDownMonth.Items.Add("Feb");
            drpDownMonth.Items.Add("Mar");
            drpDownMonth.Items.Add("Apr");
            drpDownMonth.Items.Add("May");
            drpDownMonth.Items.Add("Jun");
            drpDownMonth.Items.Add("Jul");
            drpDownMonth.Items.Add("Aug");
            drpDownMonth.Items.Add("Sep");
            drpDownMonth.Items.Add("Oct");
            drpDownMonth.Items.Add("Nov");
            drpDownMonth.Items.Add("Dec");


        }
        if (dropDownYear.Items.Count == 0)
        {
            yy = ReturnTag("Select Year(getdate()) as YearYY ", "YearYY");

            for (i = 1900; i <= Convert.ToInt32(yy) + 1; i++)
            {
                dropDownYear.Items.Add(i.ToString());
            }
        }


        // End




    }




    public bool EmailSending(string Mess, string subjectParameter, string emailId)
    {
        string sql = "";
        string ss = "";
        bool flag = true;
        MailMessage mail = new MailMessage();
        mail.To.Add(emailId);//to ID
        string fromID = "", Pass = "";
        sql = "Select Email,Password from EmailPanelSetting where Id=1";
        fromID = ReturnTag(sql, "Email");
        Pass = ReturnTag(sql, "Password");

        mail.From = new MailAddress(fromID);
        mail.Subject = subjectParameter;



        mail.Body = Mess;
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential(fromID, Pass);//from id
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = true;
        try
        {
            smtp.Send(mail);
        }
        catch (Exception ee) { flag = false; }
        return flag;
    }


    public bool EmailSendingForUser(string Mess, string subjectParameter, string emailId)
    {
        string sql = "";
        string ss = "";
        bool flag = true;
        MailMessage mail = new MailMessage();
        mail.To.Add(emailId);//to ID
        mail.Bcc.Add("anit@globalmail.in");
        string fromID = "", Pass = "";

        fromID = "donotreply@globaleducation.org";
        Pass = "donotreply@1";
        mail.From = new MailAddress(fromID);
        mail.Subject = subjectParameter;
        mail.Body = Mess;
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        smtp.Port = 587;
        mail.Priority = MailPriority.High;
        smtp.Credentials = new System.Net.NetworkCredential(fromID, Pass);//from id
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = true;
        try
        {
            smtp.Send(mail);
        }
        catch (Exception ee) { flag = false; }
        return flag;
    }

    public string NumberToString(long Rs)
    {
        string functionReturnValue = null;
        string char1 = null;
        //Dim rs As Long
        long t = 0;
        string[] digit = new string[20];
        string[] tens = new string[11];
        //digit
        digit[1] = "One";
        digit[2] = "Two";
        digit[3] = "Three";
        digit[4] = "Four";
        digit[5] = "Five";
        digit[6] = "Six";
        digit[7] = "Seven";
        digit[8] = "Eight";
        digit[9] = "Nine";
        digit[10] = "Ten";
        digit[11] = "Eleven";
        digit[12] = "Twelve";
        digit[13] = "Thirteen";
        digit[14] = "Fourteen";
        digit[15] = "Fifteen";
        digit[16] = "Sixteen";
        digit[17] = "Seventeen";
        digit[18] = "Eighteen";
        digit[19] = "Ninteen";

        //tens value
        tens[2] = "Twenty";
        tens[3] = "Thirty";
        tens[4] = "Fourty";
        tens[5] = "Fifty";
        tens[6] = "Sixty";
        tens[7] = "Seventy";
        tens[8] = "Eighty";
        tens[9] = "Ninty";

        while ((Rs > 0))
        {

            if (Rs < 20)
            {
                char1 = char1 + " " + digit[Rs];
                Rs = Rs - Rs;
            }
            else if ((Rs < 100))
            {
                t = Convert.ToInt32((Rs / 10));
                char1 = char1 + " " + tens[t];
                Rs = Rs - (t * 10);
            }
            else if ((Rs < 1000))
            {
                t = Convert.ToInt32((Rs / 100));
                char1 = char1 + " " + digit[t] + " Hundred";
                Rs = Rs - (t * 100);

            }
            else if ((Rs < 100000))
            {
                if ((Rs > 20000))
                {
                    t = Convert.ToInt32((Rs / 10000));
                    char1 = char1 + " " + tens[t];
                    Rs = Rs - (t * 10000);
                }
                else
                {
                    if ((Rs >= 1000))
                    {
                        t = Convert.ToInt32(Rs / 1000);
                        char1 = char1 + " " + digit[t] + " Thousand";
                        Rs = Rs - (t * 1000);
                    }
                    else
                    {
                        char1 = char1 + " " + "Thousand";
                    }

                }
                //
            }
            else if ((Rs < 10000000))
            {
                if ((Rs >= 2000000))
                {
                    t = Convert.ToInt32((Rs / 1000000));
                    char1 = char1 + " " + tens[t];
                    Rs = Rs - (t * 1000000);
                }
                else
                {
                    if ((Rs >= 100000))
                    {
                        t = Convert.ToInt32((Rs / 100000));
                        char1 = char1 + " " + digit[t] + " Lacs";
                        Rs = Rs - (t * 100000);
                    }
                    else
                    {
                        char1 = char1 + " " + "Lacs";
                    }
                }
            }
            else
            {
                functionReturnValue = "Out Of Range...";
                System.Environment.Exit(0);

            }
        }
        if (string.IsNullOrEmpty(char1))
        {
            functionReturnValue = "Zero";
        }
        else
        {
            functionReturnValue = char1 + " Rupees Only";
        }
        return functionReturnValue;
    }

    public void MessageBox(string msg, Page xx)
    {
        Label lbl = new Label();
        //lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        lbl.Text = "<script> smoke.alert('" + msg + "')</script>";
        //Page.Controls.Add(lbl);
        xx.Controls.Add(lbl);

    }

    public string Isnull(string DataValue)
    {
        if (DataValue == null)
        {
            return " ";
        }
        else
        {
            return DataValue;
        }
    }
    public void FindCurrentDateandSetinDropDown(DropDownList DrpYear, DropDownList DrpMonth, DropDownList DrpDate)
    {
        string dd = "", mm = "", yy = "";


        dd = ReturnTag("Select day(getdate()) as DateDD", "DateDD");
        mm = ReturnTag("Select Month(getdate())as MonthMM", "MonthMM");
        yy = ReturnTag("Select Year(getdate()) as YearYY ", "YearYY");

        DrpYear.Text = yy;
        if (mm == "1")
        {
            DrpMonth.Text = "Jan";
        }
        else if (mm == "2")
        {
            DrpMonth.Text = "Feb";
        }
        else if (mm == "3")
        {
            DrpMonth.Text = "Mar";
        }
        else if (mm == "4")
        {
            DrpMonth.Text = "Apr";
        }
        else if (mm == "5")
        {
            DrpMonth.Text = "May";
        }
        else if (mm == "6")
        {
            DrpMonth.Text = "Jun";

        }
        else if (mm == "7")
        {
            DrpMonth.Text = "Jul";
        }
        else if (mm == "8")
        {
            DrpMonth.Text = "Aug";
        }
        else if (mm == "9")
        {
            DrpMonth.Text = "Sep";
        }
        else if (mm == "10")
        {
            DrpMonth.Text = "Oct";
        }
        else if (mm == "11")
        {
            DrpMonth.Text = "Nov";
        }
        else if (mm == "12")
        {
            DrpMonth.Text = "Dec";
        }


        DrpDate.Text = dd;
    }
    public void ClearControls(Control parent)
    {

        foreach (Control _ChildControl in parent.Controls)
        {
            if ((_ChildControl.Controls.Count > 0))
            {
                ClearControls(_ChildControl);
            }
            else
            {
                if (_ChildControl is TextBox)
                {
                    ((TextBox)_ChildControl).Text = string.Empty;
                }
                else if (_ChildControl is CheckBox)
                {
                    ((CheckBox)_ChildControl).Checked = false;
                }

            }
        }

    }


    public void ReadOnlyControls(Control parent)
    {

        foreach (Control _ChildControl in parent.Controls)
        {
            if ((_ChildControl.Controls.Count > 0))
            {
                ReadOnlyControls(_ChildControl);
            }
            else
            {
                if (_ChildControl is TextBox)
                {
                    ((TextBox)_ChildControl).ReadOnly = true;
                }


            }
        }

    }



    public void UnReadOnlyControls(Control parent)
    {

        foreach (Control _ChildControl in parent.Controls)
        {
            if ((_ChildControl.Controls.Count > 0))
            {
                UnReadOnlyControls(_ChildControl);
            }
            else
            {
                if (_ChildControl is TextBox)
                {
                    ((TextBox)_ChildControl).ReadOnly = false;
                }


            }
        }

    }

    public string ReadDD(string dd)
    {
        if (dd.Substring(0, 1) == "0")
        {
            dd = dd.Substring(1, 1);
        }

        return dd;
    }

    public string ReadDD1(string dd)
    {
        if (dd.Substring(0, 1) == "0")
        {
            dd = dd.Substring(1, 1);
        }
        else
        {

            if (dd.Length == 2)
            {

            }
            else
            {
                dd = "0" + dd;
            }
        }
        return dd;
    }
    public string CurrentMonthFind()
    {
        string mmm = "";
        string sql = "";
        int mo = 0;
        sql = "select month(getdate()) as mont";

        mo = Convert.ToInt32(ReturnTag(sql, "mont"));
        switch (mo)
        {
            case 1:
                mmm = "Jan";
                break;
            case 2:
                mmm = "Feb";
                break;
            case 3:
                mmm = "Mar";
                break;
            case 4:
                mmm = "Apr";
                break;
            case 5:
                mmm = "May";
                break;
            case 6:
                mmm = "Jun";
                break;
            case 7:
                mmm = "Jul";
                break;
            case 8:
                mmm = "Aug";
                break;
            case 9:
                mmm = "Sep";
                break;
            case 10:
                mmm = "Oct";
                break;
            case 11:
                mmm = "Nov";
                break;
            case 12:
                mmm = "Dec";
                break;

        }
        return mmm;
    }

    public int CurrentMonthCheckValue(string month)
    {
        int mo = 0;
        if (month == "Jan")
        {
            mo = 10;
        }
        if (month == "Feb")
        {
            mo = 11;
        }
        if (month == "Mar")
        {
            mo = 12;
        }
        if (month == "Apr")
        {
            mo = 1;
        }
        if (month == "May")
        {
            mo = 2;
        }
        if (month == "Jun")
        {
            mo = 3;
        }
        if (month == "Jul")
        {
            mo = 4;
        }
        if (month == "Aug")
        {
            mo = 5;
        }

        if (month == "Sep")
        {
            mo = 6;
        }
        if (month == "Oct")
        {
            mo = 7;
        }
        if (month == "Nov")
        {
            mo = 8;
        }
        if (month == "Dec")
        {
            mo = 9;
        }
        if (month == "Jan")
        {
            mo = 10;
        }
        if (month == "Feb")
        {
            mo = 11;
        }
        if (month == "Mar")
        {
            mo = 12;
        }
        return mo;
    }


    public string Encode(string sData)
    {
        try
        {
            byte[] encData_byte = new byte[sData.Length];

            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

            string encodedData = Convert.ToBase64String(encData_byte);

            return encodedData;

        }
        catch (Exception ex)
        {
            return "";
        }
    }


    public string Decode(string sData)
    {

        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

        System.Text.Decoder utf8Decode = encoder.GetDecoder();

        byte[] todecode_byte = Convert.FromBase64String(sData);

        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

        char[] decoded_char = new char[charCount];

        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

        string result = new String(decoded_char);

        return result;

    }


    public string IDGeneration(string FixedString, string x)
    {
        string xx = "";
        if (x.Length == 1)
        {
            xx = FixedString + "000000" + x;

        }
        else if (x.Length == 2)
        {
            xx = FixedString + "00000" + x;
        }
        else if (x.Length == 3)
        {
            xx = FixedString + "0000" + x;
        }
        else if (x.Length == 4)
        {
            xx = FixedString + "000" + x;
        }
        else if (x.Length == 5)
        {
            xx = FixedString + "00" + x;
        }
        else if (x.Length == 6)
        {
            xx = FixedString + "0" + x;
        }
        else
        {
            xx = FixedString + x;
        }
        return xx;
    }



    //=======================================Password Generation Process  Start===================================
    private int RandomNumber(int min, int max)
    {

        int temp = random.Next(min, max);
        //Random random = new Random();
        //int temp = Random.Next(min, max);
        return temp;
        //return random.Next(min, max);
    }



    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();

        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }


    public string GetPassword()
    {

        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(4, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, true));
        return builder.ToString();

    }

    //=======================================Password Generation Process  End===================================



    public void ExportToExcel(string fileName, GridView gv)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
        "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                // Create a form to contain the grid
                Table table = new Table();

                // add the header row to the table
                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                // add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                // add the footer row to the table
                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                // render the table into the htmlwriter
                table.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }


    public void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }



    public void ExportToWord(HttpResponse hh, string fname, HtmlGenericControl dd)
    {
        hh.Clear();
        hh.AddHeader("content-disposition", "attachment;filename=" + dd + ".doc");
        hh.Charset = "";
        hh.Cache.SetCacheability(HttpCacheability.NoCache);
        hh.ContentType = "application/doc";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        dd.RenderControl(htmlWrite);
        hh.Write(stringWrite.ToString());
        hh.End();
    }




    public string StringToHTML(string xx)
    {
        int i;
        string yy = "";
        for (i = 0; i <= xx.Length - 1; i++)
        {
            if (xx[i].ToString() == "\n")
            {
                yy = yy + "<br>" + "<p>";
            }
            else
            {
                yy = yy + xx[i];
            }
        }
        return yy;
    }
    public string CurrentDate()
    {

        string sql = "";
        sql = "select convert(nvarchar,getdate(),106) as CDate";
        sql = ReturnTag(sql, "Cdate");
        return sql;

    }
    public string CurrentYear()
    {

        string sql = "";
        sql = "select   year(getdate()) as yy";
        sql = ReturnTag(sql, "yy");
        return sql;

    }


    public string DecimalPlaceMustTwoZero(string xx)
    {
        int l, i, j, k, m;
        l = xx.Length - 1;
        bool flag = false;
        string kk = "";
        for (i = 0; i <= l; i++)
        {
            if (xx[i] == '.')
            {
                kk = kk + xx[i];
                flag = true;
                break;
            }
            else
            {
                kk = kk + xx[i];
            }
        }


        if (flag)
        {
            k = l - i;
            if (k < 2)
            {
                kk = kk + xx[i + 1] + "0";
            }
            else
            {
                kk = kk + xx[i + 1] + xx[i + 2];
            }

        }
        else
        {
            kk = kk + ".00";
        }

        return kk;

    }





    public string DayOfMonthString01(string month)
    {
        string mo = month.Trim();
        string d = "0";
        switch (mo)
        {
            case "Jan":
                d = d + "1";
                break;
            case "Feb":
                d = d + "2";
                break;
            case "Mar":
                d = d + "3";
                break;
            case "Apr":
                d = d + "4";
                break;
            case "May":
                d = d + "5";
                break;
            case "Jun":
                d = d + "6";
                break;
            case "Jul":
                d = d + "7";
                break;
            case "Aug":
                d = d + "8";
                break;
            case "Sep":
                d = d + "9";
                break;
            case "Oct":
                d = "10";
                break;
            case "Nov":
                d = "11";
                break;
            case "Dec":
                d = "12";
                break;
        }


        return d;
    }
    private void DecryptFile(string inputFile, string outputFile)
    {

        {
            string password = @"myKey123"; // Your Key Here

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();

        }
    }
    private void EncryptFile(string inputFile, string outputFile)
    {

        try
        {
            string password = @"myKey123"; // Your Key Here
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            string cryptFile = outputFile;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);


            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
        }
        catch
        {

        }
    }
    public string GetMACAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        } return sMacAddress;
    }


    public byte[] ConvertTheImageIntoBiary(string FileName)
    {

        byte[] Buffer = null;
        try
        {

            // Open file for reading

            System.IO.FileStream FileStream = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);



            // attach filestream to binary reader

            System.IO.BinaryReader BinaryReader = new System.IO.BinaryReader(FileStream);



            // get total byte length of the file

            long _TotalBytes = new System.IO.FileInfo(FileName).Length;



            // read entire file into buffer

            Buffer = BinaryReader.ReadBytes((Int32)_TotalBytes);



            // close file reader

            FileStream.Close();
            FileStream.Dispose();

            BinaryReader.Close();

        }

        catch (Exception) { }
        return Buffer;

    }



    public String urlEncode(String Code)
    {
        try
        {
            string EncodedText;
            char[] charArray = new char[6];
            charArray = Code.ToCharArray();
            Array.Reverse(charArray);
            string reverseTxt = new string(charArray);
            EncodedText = reverseTxt.Substring(0, 4) + "-" + Convert.ToInt16(reverseTxt.Substring(reverseTxt.Length - 4, 4)).ToString("X") + "-" + reverseTxt.Substring(reverseTxt.Length - 4, 4) + "-" + Convert.ToInt16(reverseTxt.Substring(0, 4)).ToString("X");
            return EncodedText;
        }
        catch (Exception)
        {
            return null;
        }

    }

    public String urlDecode(String Code)
    {
        try
        {
            char[] charArray = new char[6];
            string[] splitTxt = new string[3];
            splitTxt = Code.Split('-');
            charArray = (splitTxt[0].Substring(0, 3) + "" + splitTxt[2].Substring(splitTxt[2].Length - 3, 3)).ToCharArray();
            Array.Reverse(charArray);
            string DecodedText = new string(charArray);
            return DecodedText;
        }
        catch (Exception)
        {
            return null;
        }

    }


    public DateTime CurrentTime()
    {
        string sql = "";
        DateTime time;
        sql = "SELECT [dbo].[udf_GetTime](GETDATE()) as CurrentTime";
        time = Convert.ToDateTime(ReturnTag(sql, "CurrentTime"));
        return time;
    }
}