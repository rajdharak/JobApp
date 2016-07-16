using jobapptest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace jobapptest.Controllers
{
    public class JobAppController : Controller
    {
        private AppDBContext db = new AppDBContext(); 
        public ActionResult Index()
        {
            return View(db.JobDetail.ToList());
        }

        public ActionResult CreateJob()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJob([Bind(Include = "JobId,JobName,Description,NoOfPositios")]JobDetails jobDetails)
        {
            if (ModelState.IsValid)
            {
                db.JobDetail.Add(jobDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



        public ActionResult ApplyFor()
        {
            PopulateJobDropDownList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyFor([Bind(Include = "ApplyId,Name,Email,Phone,GitHubUrl,JobId")]Applicants applicants)
        {
            if (ModelState.IsValid)
            {
                db.Apllicant.Add(applicants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult ViewFor()
        {
            return View(db.Apllicant.ToList());
        }
        private void PopulateJobDropDownList(object selectedDepartment = null)
        {
            var jobQuery = from d in db.JobDetail
                                   orderby d.JobName
                                   select d;
            ViewBag.JobId = new SelectList(jobQuery, "JobId", "JobName", selectedDepartment);
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