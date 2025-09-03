using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

public partial class Careers1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    string sql = "";
    NurtureLib oo = new NurtureLib();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["CISCon"].ConnectionString;
        if (!IsPostBack)
        {
            sql = "select id,name from Icountry order by name";
            oo.FillDropDownWithID(sql, drpCountry, "name", "id");
        }
    }

    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select id,name from Istate where Country_Id=" + drpCountry.SelectedValue.ToString();
        oo.FillDropDownWithID(sql, drpState, "name", "id");
        //
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //@FullName ,@Email ,@mobileNo ,@address ,@Country ,@State ,@City ,@HighestEdu ,
//@MajorFieldStudy ,@NameofInstitution ,@YearofPassing ,@TickMess,@SchoolName ,@Subject ,@GradeTaught ,@DurationofEmp ,@TotalWorkExp ,@TeachingCertifiate ,
//@SpecializedTraining,@SkillCompetencies ,@ProfessionalRefName ,@RealtionShip ,@ContactNoRelationship,@ContactNoRelation,@ContactEmail, @CoverLetterStrenght ,@Resume ,getdate(),
        //@ProfessionalRefName1,@RealtionShip1,@ContactNoRelationship1,@ContactEmail1
        string tickeMess="";
       
        string SmallestFname = "";
        string Fna = "";
        SmallestFname = FileUpload1.FileName.ToString();


        SqlCommand cmd = new SqlCommand();
        if (FileUpload1.FileName == "")
        {
            oo.MessageBox("Only PDF format allowed.", this.Page);
             lblMsg.Text = "Only PDF format allowed.";
        }

        else if (SmallestFname.Substring(SmallestFname.Length - 3, 3).ToUpper() == "PDF")
        {
            cmd.CommandText = "CareerTab2024Proc";
            cmd.CommandType = CommandType.StoredProcedure;
            Fna = oo.GetPassword();
            FileUpload1.SaveAs(Server.MapPath("~/Resume/" + Fna+FileUpload1.FileName));
            cmd.Parameters.AddWithValue("@Resume", "~/Resume/" + Fna +  FileUpload1.FileName);



           
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@mobileNo", txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@Country", drpCountry.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@State", drpState.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@City", drpCity.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@HighestEdu", drpHighestQuali.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@MajorFieldStudy", txtMajorFieldStudy.Text.Trim());
            cmd.Parameters.AddWithValue("@NameofInstitution", txtNameOfInsitution.Text.Trim());
            cmd.Parameters.AddWithValue("@YearofPassing", txtYearOfPassing.Text.Trim());

            int i = 0;
            tickeMess = "";
            for (i = 0; i <= chkTick.Items.Count - 1; i++)
            {

                if (chkTick.Items[i].Selected == true)
                {
                    tickeMess = tickeMess + chkTick.Items[i].Text.Trim() + ",";
                }
            }

            cmd.Parameters.AddWithValue("@TickMess", tickeMess.Trim());


            cmd.Parameters.AddWithValue("@SchoolName", txtSchoolOrganization.Text.Trim());
            cmd.Parameters.AddWithValue("@Subject", txtSubjectTaught.Text.Trim());
            cmd.Parameters.AddWithValue("@GradeTaught", txtGrades.Text.Trim());
            cmd.Parameters.AddWithValue("@DurationofEmp", txtDuration.Text.Trim());
            cmd.Parameters.AddWithValue("@TotalWorkExp", txtTotalWorkExp.Text.Trim());
            cmd.Parameters.AddWithValue("@TeachingCertifiate", txtTeachingCertificate.Text.Trim());
            cmd.Parameters.AddWithValue("@SpecializedTraining", txtSpecialized.Text.Trim());
            cmd.Parameters.AddWithValue("@SkillCompetencies", txtSkillsCompeten.Text.Trim());
            cmd.Parameters.AddWithValue("@ProfessionalRefName", txtProfessionalName.Text.Trim());

            cmd.Parameters.AddWithValue("@RealtionShip", txtRelationShip.Text.Trim());
            cmd.Parameters.AddWithValue("@ContactNoRelationship", txtPreofessPhoneNo.Text.Trim());
            cmd.Parameters.AddWithValue("@ContactEmail", txtProfessEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@CoverLetterStrenght", txtSpecialStrenths.Text.Trim());
            cmd.Parameters.AddWithValue("@ContactNoRelation",txtPreofessPhoneNo.Text.Trim());

            cmd.Parameters.AddWithValue("@ProfessionalRefName1", txtProfessionalName1.Text.Trim());
            cmd.Parameters.AddWithValue("@RealtionShip1", txtRelationShip1.Text.Trim());
            cmd.Parameters.AddWithValue("@ContactNoRelationship1", txtPreofessPhoneNo1.Text.Trim());
            cmd.Parameters.AddWithValue("@ContactEmail1", txtProfessEmail1.Text.Trim());
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMsg.Text = "Submitted Successfully.";
            }
            catch (Exception) { }
        }
    }
    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select id,name from ICity where State_Id='" + drpState.SelectedValue + "' order by Name";
        oo.FillDropDownWithID(sql, drpCity, "name", "id");
    }
}