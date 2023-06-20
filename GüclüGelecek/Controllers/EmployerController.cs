using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccsesLayer.Abstract;
using DataAccsesLayer.Concrete;
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concrete;
using GüclüGelecek.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GüclüGelecek.Controllers
{
    public class EmployerController : Controller
    {
        Context context = new Context();

        #region Managers

        JobManager jobManager = new JobManager(new EfJobDal());
        EmployerManager employerManager = new EmployerManager(new EfEmployerDal());
        JobSeekerManager jobseekerManager = new JobSeekerManager(new EfJobSeekerDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        JobApplicationManager jobApplicationManager = new JobApplicationManager(new EfJobApplicationDal());

        #endregion


        #region Yayınladığım İşler

        public IActionResult JobList()
        {
            var sessionid = HttpContext.Session.GetInt32("EmployerID");
            var jobList = context.Jobs
                .Include(x => x.Employer)
                .Include(y => y.Category)
                .Where(x => x.EmployerID == sessionid)
                .ToList();

            foreach (var job in jobList)
            {
                int applicationCount = context.JobApplications
                    .Count(a => a.JobID == job.JobID);

                job.ApplicationCount = applicationCount;
            }

            return View(jobList);
        }


        public IActionResult JobDelete(int id)
        {
            var job = jobManager.GetById(id);
            job.Status = false;
            jobManager.Update(job);
            return RedirectToAction("JobList","Employer");
        }

        public IActionResult JobActive(int id)
        {
            var job = jobManager.GetById(id);
            job.Status = true;
            jobManager.Update(job);
            return RedirectToAction("JobList", "Employer");
        }

        [HttpGet]
        public IActionResult JobUpdate(int id)
        {
            var job = context.Jobs
                .Include(x => x.Employer)
                .Include(y => y.Category)
                .Where(x => x.JobID == id)
                .FirstOrDefault();

            List<SelectListItem> ViewEmployer = (from x in employerManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.EmployerID.ToString(),
                                                     Text = x.Name.ToString()
                                                 }).ToList();

            List<SelectListItem> ViewCategory = (from x in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.CategoryID.ToString(),
                                                     Text = x.CategoryName.ToString()
                                                 }).ToList();

            ViewBag.employer = ViewEmployer;
            ViewBag.category = ViewCategory;

            return View(job);
        }
        [HttpPost]
        public IActionResult JobUpdate(Job job)
        {
            jobManager.Update(job);
            return RedirectToAction("JobList", "Employer");
        }


        #endregion

    }
}