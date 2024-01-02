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
            return RedirectToAction("JobList", "Employer");
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

            var sessionid = Convert.ToInt32(HttpContext.Session.GetInt32("EmployerID"));
            var employer = employerManager.GetById(sessionid);

            List<SelectListItem> ViewEmployer = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = employer.EmployerID.ToString(),
                    Text = employer.Name.ToString()
                }
            };

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


        public IActionResult JobApplicationListDetails(int id)
        {
            var jobApplications = context.JobApplications
            .Include(a => a.JobSeeker)
            .Where(x => x.JobID == id)
            .ToList();

            return View(jobApplications);
        }

        #endregion


        #region İş Yayınlama

        [HttpGet]
        public IActionResult AddJob()
        {
            var sessionid = Convert.ToInt32(HttpContext.Session.GetInt32("EmployerID"));
            var employer = employerManager.GetById(sessionid);

            List<SelectListItem> ViewEmployer = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = employer.EmployerID.ToString(),
                    Text = employer.Name.ToString()
                }
            };

            List<SelectListItem> ViewCategory = (from x in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.CategoryID.ToString(),
                                                     Text = x.CategoryName.ToString()
                                                 }).ToList();

            ViewBag.employer = ViewEmployer;
            ViewBag.category = ViewCategory;

            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            jobManager.Create(job);
            return RedirectToAction("JobList", "Employer");
        }

        #endregion


        #region İş Arayanlar

        public IActionResult JobSeekerList()
        {
            var jobSeeker = jobseekerManager.GetAll();
            return View(jobSeeker);
        }

        #endregion
    }
}
