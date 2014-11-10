using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StepOneEducation_1_0.Models
{
    public class HighSchool
    {
        //private string time;


        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public double Tuition { get; set; }
        public byte[] Image { get; set; }

        //public string DateCreated
        //{
        //    get { return time; }
        //    set { time = DateTime.Now.ToString(); }
        //}
    }
}