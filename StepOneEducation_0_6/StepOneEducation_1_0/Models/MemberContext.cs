using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StepOneEducation_1_0.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext()
            : base("name=DefaultConnection")
        { 
        }

        public System.Data.Entity.DbSet<StepOneEducation_1_0.Models.Member> Members { get; set; }
    }
}