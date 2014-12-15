using System;
using System.Collections.Generic;
using System.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StepOneEducation_1_0.Models;
using StepOneEducation_1_0.Controllers;

namespace StepOneEducation_1_0.Controllers
{
    public class MemberController : BaseController
    {
        private MemberContext db = new MemberContext();

        //会员注册页面
        public ActionResult Register()
        {
            return View();
        }

        //密码加密所需要的 Salt 数值
        private string pwdSalt = "A1rySq1oPe2Mh784QQwG6jRAfkdPpDa90J0i";

        //注册会员资料
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn,AuthCode")] Member member)
        {
            //检查会员是否已经存在
            var chk_member = db.Members.Where(p => p.Email == member.Email).FirstOrDefault();
            if (chk_member != null)
            {
                ModelState.AddModelError("Email", "您输入的 Email 已经有人使用过了！");
            }

            if (ModelState.IsValid)
            {
                //加密会员输入的密码 
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdSalt + member.Password, "SHA1");
                // 会员注册时间
                member.RegisterOn = DateTime.Now;
                // 会员验证码
                member.AuthCode = Guid.NewGuid().ToString();

                db.Members.Add(member);
                db.SaveChanges();

                SendAuthCodeToMember(member);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        private void SendAuthCodeToMember(Member member)
        {
            // 准备确认信内容
            string mailBody = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/MemberRegisterEMailTemplate.htm"));

            mailBody = mailBody.Replace("{{Name}}", member.Name);
            mailBody = mailBody.Replace("{{RegisterOn}}", member.RegisterOn.ToString("F"));
            var auth_url = new UriBuilder(Request.Url)
            {
                Path = Url.Action("ValidateRegister", new { id = member.AuthCode }),
                Query = ""
            };
            mailBody = mailBody.Replace("{{AUTH_URL}}", auth_url.ToString());

            // 发送邮件给会员
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("steponebridge", "steponebridge888");
                SmtpServer.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("steponebridge@gmail.com");
                mail.To.Add(member.Email);
                mail.Subject = "【StepOne教育集团】会员注册确认信";
                mail.Body = mailBody;
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public ActionResult ValidateRegister(string id)
        {
            if (String.IsNullOrEmpty(id))
                return HttpNotFound();

            var member = db.Members.Where(p => p.AuthCode == id).FirstOrDefault();

            if (member != null)
            {
                TempData["LastTempMessage"] = "会员验证成功，您现在可以进入网站了！";
                // 验证成功后将 member.AuthCode 的内容清空
                member.AuthCode = null;
                db.SaveChanges();
            }
            else
            {
                TempData["LastTempMessage"] = "查无此会员验证码，您可能已经验证过了!";
            }

            return RedirectToAction("Login", "Member");
        }

        //显示会员登录页面
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        //执行会员登录
        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            
            if (ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                
                if (String.IsNullOrEmpty(returnUrl))
                {
                    
                    ViewData["hasPermission"] = "1";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                    ViewData["hasPermission"] = "0";
                    return Redirect(returnUrl);
                }
            }

            return View();
        }

        private bool ValidateUser(string email, string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdSalt + password, "SHA1");

            var member = (from p in db.Members
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault();

            //如果 member 不为 null，则代表会员的账号，密码输入正确
            if (member != null)
            {
                if (member.AuthCode == null)
                {
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "您尚未通过会员验证，请查阅邮件并点击会员验证链接");
                    return false;
                }
            }
            else
            {
                ModelState.AddModelError("", "您输入的账号或密码错误");
                return false;
            }
 
        }

        //执行会员登出
        public ActionResult Logout()
        {
            //清除表单验证的 Cookies
            FormsAuthentication.SignOut();

            //清除所有曾经写入过的 Session 资料
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CheckDup(string Email)
        {
            var member = db.Members.Where(p => p.Email == Email).FirstOrDefault();

            if (member != null)
                return Json(false);
            else
                return Json(true);
        }
    }

    }

