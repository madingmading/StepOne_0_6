using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StepOneEducation_1_0.Models;
using System.IO;

namespace StepOneEducation_1_0.Controllers
{
    public class HighSchoolController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /HighSchool/
        public ActionResult GetImage(int id)
        {
            var image = (from o in db.HighSchools
                         where o.id == id
                         select o.Image).First();
            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            //var model = (from o in db.HighSchools
            //            select new { id = o.id, name = o.Name, location = o.Location, tuition = o.Tuition }).ToList();
            return View(db.HighSchools.ToList());
            //return View(model);
        }

        // GET: /HighSchool/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighSchool highschool = db.HighSchools.Find(id);
            if (highschool == null)
            {
                return HttpNotFound();
            }
            return View(highschool);
        }

        // GET: /HighSchool/Create
        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HighSchool/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Location,Tuition", Exclude = "image")] HighSchool highschool, HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                if (imgUpload != null )// Save image to database
                {
                    byte[] byteImage = new byte[imgUpload.ContentLength];
                    int result = imgUpload.InputStream.Read(byteImage, 0, imgUpload.ContentLength);
                    highschool.Image = byteImage;

                }            
                
                db.HighSchools.Add(highschool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(highschool);
        }

        // GET: /HighSchool/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighSchool highschool = db.HighSchools.Find(id);
            if (highschool == null)
            {
                return HttpNotFound();
            }
            return View(highschool);
        }

        // POST: /HighSchool/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Location,Tuition", Exclude = "Image")] HighSchool highschool, HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                if (imgUpload != null)
                {
                    byte[] byteImage = new byte[imgUpload.ContentLength];
                    int result = imgUpload.InputStream.Read(byteImage, 0, imgUpload.ContentLength);
                    highschool.Image = byteImage;
                }


                db.Entry(highschool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(highschool);
        }

        // GET: /HighSchool/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighSchool highschool = db.HighSchools.Find(id);
            if (highschool == null)
            {
                return HttpNotFound();
            }
            return View(highschool);
        }

        // POST: /HighSchool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HighSchool highschool = db.HighSchools.Find(id);
            db.HighSchools.Remove(highschool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
