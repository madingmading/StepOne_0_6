using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StepOneEducation_1_0.Controllers
{
    public class OnlineTrainingController : Controller
    {
        //
        // GET: /OnlineTraining/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StepFlow()
        {
            return View();
        }

        public ActionResult TeacherList()
        {
            return View();
        }

        public ActionResult onlineTrainingCategory()
        {
            return View();
        }

        public ActionResult teacherDetails(string name)
        {
            if (name == "NickFeng")
            {
                ViewData["PictureName"] = "/Images/" + name + "750x500.jpg";
                ViewData["Name"] = name;
                ViewData["School"] = "TJ High School";
                ViewData["Introducation"] = "He used to be shenandoah university, gian the MBA degree, currtenly he is working in Sprint as a web develper.";
                ViewData["SmallPictureName1"] = "/Images/TianLan正面照235x235.jpg";
                ViewData["SmallPictureName2"] = "/Images/Christ正面照235x235.jpg";
            }
            else if(name == "TianLan")
            {
                ViewData["PictureName"] = "/Images/" + name + "750x500.jpg";
                ViewData["Name"] = name;
                ViewData["School"] = "Bill High School";
                ViewData["Introducation"] = "He used to be shenandoah university, gian the MBA degree, currtenly he is working in Sprint as a web develper.";
                ViewData["SmallPictureName1"] = "/Images/NickFeng正面照235x235.jpg";
                ViewData["SmallPictureName2"] = "/Images/Christ正面照235x235.jpg";
            }
            else if(name == "ChristBill")
            {
                ViewData["PictureName"] = "/Images/" + name + "750x500.jpg";
                ViewData["Name"] = name;
                ViewData["School"] = "WoodBerry High School";
                ViewData["Introducation"] = "He used to be shenandoah university, gian the MBA degree, currtenly he is working in Sprint as a web develper.";
                ViewData["SmallPictureName1"] = "/Images/TianLan正面照235x235.jpg";
                ViewData["SmallPictureName2"] = "/Images/NickFeng正面照235x235.jpg";
            }



            return View();
        }
            
	}
}