using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using StepOneEducation_1_0.Models;
using System.IO;
using Common;

namespace StepOneEducation_1_0.Controllers
{
    //[Authorize]
    public class EssayCorrectionController : Controller
    {
        //
        // GET: /EssayCorrection/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendFileByEmail(HttpPostedFileBase essaySubmit, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string name = form["name"].ToString();
                string emailfrom = form["email"].ToString();
                //string To = "steponeeducationusa@gmail.com";
                string textIntxtArea = form["txtEssay"].ToString();
                string essayType = "作文类型为：" + form["essayType"].ToString() + "\t";
                string comment = form["comment"].ToString();

                if (essaySubmit != null || (textIntxtArea != null && textIntxtArea.Trim().Length != 0))
                {
                    Email email = new Email();

                    email.sendFormEmail(name, emailfrom, comment, textIntxtArea, essayType, essaySubmit);

                    //using(MailMessage mail = new MailMessage(from, To))
                    //{
                    //    //mail.Subject = objModelMail.Subject;
                    //    //mail.Body = objModelMail.Body;                        

                    //    mail.Subject = "作业修改";
                    //    mail.Body = essayType + "请批改作业\t";

                    //    if (essaySubmit != null)
                    //    {   
                    //        string fileName = Path.GetFileName(essaySubmit.FileName);
                    //        mail.Attachments.Add(new Attachment(essaySubmit.InputStream, fileName));
                    //    }
                    //    else
                    //    {
                    //        mail.Body += textIntxtArea;
                    //    }

                    //    mail.IsBodyHtml = false;
                    //    SmtpClient smtp = new SmtpClient();
                    //    smtp.Host = "smtp.gmail.com";
                    //    smtp.EnableSsl = true;
                    //    NetworkCredential nc = new NetworkCredential(from, "Hope7890");
                    //    smtp.UseDefaultCredentials = true;
                    //    smtp.Credentials = nc;
                    //    smtp.Port = 587;
                    //    smtp.Send(mail);
                    //}
                }
            }
            return RedirectToAction("index", "OnlineTraining");
        }
    }
}