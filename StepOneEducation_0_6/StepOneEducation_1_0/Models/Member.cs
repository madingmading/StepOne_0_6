using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Web.Mvc;

namespace StepOneEducation_1_0.Models
{
    public class Member
    {
        private string psw;
        private int _isAdmin = 0;
        private DateTime _dateCreate = DateTime.Now;
        //private int phoneNumber;
        
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "请输入用户名")]
        [DisplayName("用户名：")]
        [MaxLength(25, ErrorMessage = "用户名长度不能超过25个字节")]
        public string UserName { get; set; }
        
        [DisplayName("邮箱")]
        [Required(ErrorMessage = "请输入 Email 地址")]
        [Description("您的 Email 会成为您作为会员的登陆账号")]
        [MaxLength(250, ErrorMessage = "Email 地址长度不能超过250个字节")]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckDup", "Member", HttpMethod = "POST", ErrorMessage = "您輸入的 Email 已經有人註冊過了!")]
        public string Email { get; set; }

        [DisplayName("会员密码")]
        [Required(ErrorMessage = "请输入密码")]
        [MaxLength(40, ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("您的中文姓名")]
        [Required(ErrorMessage = "请输入中文姓名")]
        [MaxLength(6, ErrorMessage = "中文姓名不可超过6个字")]
        public string Name { get; set; }

        [DisplayName("电话号码")]
        [Required(ErrorMessage = "请输入电话号码")]
        public string PhoneNumber { get; set; }
        

        [DisplayName("当前学位")]
        public string degree { get; set; }

        [DisplayName("是否订阅邮件新闻")]
        public bool isEmailInfo { get; set; }

        [DisplayName("会员注册时间")]
        public DateTime RegisterOn 
        { 
            get { return _dateCreate; }
            set { _dateCreate = value; } 
        }

        public int isAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }



        [DisplayName("会员启用认证码")]
        [MaxLength(36)]
        [Description("当 AuthCode 等于 null ，则代表此会员已经通过 Email 有效性认证")]
        public string AuthCode { get; set; }

        //public virtual ICollection<>




    }
}