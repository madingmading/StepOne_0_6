using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Common
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void sendFormEmail(string name, string emailfrom, string comment, string textIntxtArea, string essayType, HttpPostedFileBase essaySubmit)
        {
            string from = "soeduwebsite@gmail.com";
            string To = "soeduwebsite@gmail.com";
            //string textIntxtArea = form["txtEssay"].ToString();
            //string essayType = "作文类型为：" + form["essayType"].ToString() + "\t";


            using (MailMessage mail = new MailMessage(emailfrom, To))
            {
                //mail.Subject = objModelMail.Subject;
                //mail.Body = objModelMail.Body;                        

                mail.Subject = "作文修改  来自" + name + " " + emailfrom;
                mail.Body = essayType + "\t请批改作业\n\n" + comment + "\n\n";

                if (essaySubmit != null)
                {
                    string fileName = Path.GetFileName(essaySubmit.FileName);
                    mail.Attachments.Add(new Attachment(essaySubmit.InputStream, fileName));
                }
                else
                {
                    mail.Body += textIntxtArea;
                }

                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential(from, "Hope4321");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(mail);
            }
        }
    }
}
