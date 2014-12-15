using StepOneEducation_1_0.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StepOneEducation_1_0.Controllers
{
    public class BaseController : Controller
    {
        protected MemberContext db = new MemberContext();

        //protected List<Cart> Carts
        //{
        //    get
        //    {
        //        if (Session["Carts"] == null)
        //        {
        //            Session["Carts"] = new List<Cart>();
        //        }
        //        return (Session["Carts"] as List<Cart>);
        //    }
        //    set { Session["Carts"] = value; }
        //}
    }
}
