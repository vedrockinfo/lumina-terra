/*  Project Name : EnviSage
 *  Page Name : SendingMail.cs
 *  Created By : Rajan Misra
 *  Date : 10th November 2008 
 * **/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
//using System.Web.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
//using log4net;


public class SendingEmail
{

    #region Declaring variables
    public int intval = 0;
    #endregion
    /// <summary>
    /// Code for sending email on google accounts
    /// </summary>
    /// <param name="pGmailEmail"></param>
    /// <param name="pGmailPassword"></param>
    /// <param name="pTo"></param>
    /// <param name="pSubject"></param>
    /// <param name="pFormat"></param>
    /// <param name="pAttachmentPath"></param>
    /// <param name="mailfrom"></param>

    public void SendEmailGmail(string pGmailEmail, string pGmailPassword, string pTo,string pSubject, System.Web.Mail.MailFormat pFormat, string pAttachmentPath, string mailfrom, string mailbody)
    {
        try
        {
            System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
            myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
            myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
            myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            //sendusing: cdoSendUsingPort, value 2, for sending the message using 
            //the network.

            //smtpauthenticate: Specifies the mechanism used when authenticating 
            //to an SMTP 
            //service over the network. Possible values are:
            //- cdoAnonymous, value 0. Do not authenticate.
            //- cdoBasic, value 1. Use basic clear-text authentication. 
            //When using this option you have to provide the user name and password 
            //through the sendusername and sendpassword fields.
            //- cdoNTLM, value 2. The current process security context is used to 
            // authenticate with the service.
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //Use 0 for anonymous
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/sendusername", pGmailEmail);
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/sendpassword", pGmailPassword);
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            myMail.From = mailfrom;
            myMail.To = pTo;
            myMail.Bcc = "anit@globalmail.in";
            myMail.Subject = pSubject;
            myMail.BodyFormat = pFormat;

            /*Mail Body*/
            //string BodyText = "";
            //BodyText = "Feed Back<br><br>";
            //BodyText = BodyText + "Name : " + Request["username"] + "<br>";
            //BodyText = BodyText + "Address : " + Request["address"] + "<br>";
            //BodyText = BodyText + "Phone : " + Request["Phone"] + "<br>";
            //BodyText = BodyText + "Email : " + Request["email"] + "<br>";
            //BodyText = BodyText + "Message : " + Request["Message"] + "<br>";
            //    lblMsg.Text = BodyText;

            // myMail.Body = BodyText;
            myMail.Body = mailbody;

            if (pAttachmentPath.Trim() != "")
            {
                System.Web.Mail.MailAttachment MyAttachment =
                new System.Web.Mail.MailAttachment(pAttachmentPath);
                myMail.Attachments.Add(MyAttachment);
                myMail.Priority = System.Web.Mail.MailPriority.High;

            }

            System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";
            System.Web.Mail.SmtpMail.Send(myMail);
            //return true;
        }
        catch (Exception ex)
        {
            throw new Exception("email sending error!");
        }
    }

    public void SendMail(string MailTo, string MailFrom, string Subject, string MailBody, Boolean IsBodyHtml)
    {
        try
        {
            MailMessage msg = new MailMessage();
            MailAddress mailaddressfrom = new MailAddress(MailFrom);
            MailAddress mailaddressTo = new MailAddress(MailTo);
            MailAddress mailaddressBCC = new MailAddress("srcpindia@gmail.com");            
            

            msg.From = mailaddressfrom;
            msg.To.Add(mailaddressTo);
            //msg.CC.Add(mailaddressCC);
            msg.Bcc.Add(mailaddressBCC);
            msg.Subject = Subject;
            msg.Body = MailBody;
            
            if(IsBodyHtml)
                msg.IsBodyHtml = true;
            else
                msg.IsBodyHtml = false;

            msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(MailBody, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(MailBody, null, "text/html");
            msg.AlternateViews.Add(plainView);
            msg.AlternateViews.Add(htmlView);

            SmtpClient objSmtp = new SmtpClient();
            System.Net.NetworkCredential smtpUser = new NetworkCredential(MailFrom, "123456");
            objSmtp.Credentials = smtpUser;
            //objSmtp.Host = "webmail.isacon2010.com"; //Sample - "mceinnon.easycgi.com";
            objSmtp.Send(msg);
        }
        catch (Exception ex)
        {
            //DBLayer.DBLInstance.GlobalInstance.ExceptionAndEventHandling(ex);
            throw new Exception("Mail Sending Error Occured!");
        }
    }

   

   
}
