using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace StepOneEducation_1_0.Models
{
    public class AppUser1
    {

        private string psw;
        private int _isAdmin = 0;
        private DateTime _dateCreate = DateTime.Now;
        private int PhoneNumber;

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "用户名必填")]
        [Display(Name = "用户名：")]
        [StringLength(50, ErrorMessage = "用户名不能多于25个汉字")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码必填")]
        [StringLength(16, ErrorMessage = "密码必须大于{2} 和少于{0}个字母或数字", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码：")]
        public string Password
        {
            get { return psw; }
            set { psw = Crypto.HashPassword(value); }
        }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码：")]
        [Compare("Password", ErrorMessage = "确认密码不吻合")]
        [NotMapped]
        public string ConfirmPassword
        {
            get { return psw; }
            set { psw = Crypto.HashPassword(value); }
        }

        [Display(Name = "记住邮箱")]
        [NotMapped]
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "邮件必填")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "邮件:")]
        public string email { get; set; }

        [Display(Name = "电话号码：")]
        [Required(ErrorMessage = "电话必填")]
        //[StringLength(13)]
        [RegularExpression(@"^[\d]{9}|[\d]{13}$",
            ErrorMessage = @"电话格式不正确，请输入格式如：139002158936")]
        public int phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

        [Display(Name = "当前学位：")]
        public string degree { get; set; }

        [Display(Name = "是否订阅邮件新闻")]
        public bool isEmailInfor { get; set; }

        public int isAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public DateTime? dateCreate
        {
            get { return _dateCreate; }
            set { _dateCreate = (DateTime)value; }
        }

    }
}