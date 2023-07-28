using BusinessLayer.Concrete;
using DataAccsesLayer.Abstract;
using DataAccsesLayer.Concrete; 
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concrete;
using GüclüGelecek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GüclüGelecek.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context(); 

        #region Managers

        JobManager jobManager = new JobManager(new EfJobDal());
        EmployerManager employerManager = new EmployerManager(new EfEmployerDal());
        JobSeekerManager jobseekerManager = new JobSeekerManager(new EfJobSeekerDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        JobApplicationManager jobApplicationManager = new JobApplicationManager(new EfJobApplicationDal());

        #endregion


        #region Job 

        public IActionResult JobList()
        {
            var jobList = context.Jobs
                .Include(x => x.Employer)
                .Include(y => y.Category)
                .ToList();

            foreach (var job in jobList)
            {
                int applicationCount = context.JobApplications
                    .Count(a => a.JobID == job.JobID);

                job.ApplicationCount = applicationCount;
            }

            return View(jobList);
        }

        public IActionResult JobApplicationListDetails(int id)
        {
            var jobApplications = context.JobApplications
                .Include(a => a.JobSeeker)
                .Where(x => x.JobID == id)
                .ToList();

            return View(jobApplications);
        }

        [HttpGet]
        public IActionResult JobUpdate(int id)
        {
            var job = context.Jobs
                .Include(x => x.Employer)
                .Include(y => y.Category)
                .Where(x=>x.JobID==id)
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
                                                  Value= x.CategoryID.ToString(),
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
            return RedirectToAction("JobList");   
        }

        public IActionResult JobDelete(int id)
        {
            var job = jobManager.GetById(id);
            job.Status = false;
            jobManager.Update(job);
            return RedirectToAction("JobList", "Admin");
        }

        public IActionResult JobActive(int id)
        {
            var job = jobManager.GetById(id);
            job.Status = true;
            jobManager.Update(job);
            return RedirectToAction("JobList", "Admin");
        }


        #endregion


        #region Employer 

        public IActionResult EmployerList()
        {
            var employerList = context.Employers.Include(x => x.Jobs).ToList();
            return View(employerList);
        }

        public IActionResult EmployerDetails(int id)
        {
            var employerDetails = context.Employers
            .Include(x => x.Jobs)
            .ThenInclude(x => x.Category)
            .FirstOrDefault(x => x.EmployerID == id);

            return View(employerDetails);
        }

        [HttpGet]
        public IActionResult EmployerUpdate(int id)
        {
            var employer = employerManager.GetById(id);
            return View(employer);
        }
        [HttpPost]
        public IActionResult EmployerUpdate(Employer employer)
        {
            employerManager.Update(employer);
            return RedirectToAction("EmployerList");
        }

        public IActionResult EmployerDelete(int id)
        {
            var employer = employerManager.GetById(id);
            employerManager.Delete(employer);
            return RedirectToAction("EmployerList");
        }

        #endregion 


        #region JobSeeker 

        public IActionResult JobSeekerList()
        {
            var jobSeeker = context.JobSeekers.ToList();
            return View(jobSeeker);
        }

        [HttpGet]
        public IActionResult JobSeekerUpdate(int id)
        {
            var jobSeeker = jobseekerManager.GetById(id);
            return View(jobSeeker);
        }
        [HttpPost]
        public IActionResult JobSeekerUpdate(JobSeeker jobSeeker)
        {
            jobseekerManager.Update(jobSeeker);
            return RedirectToAction("JobSeekerList");
        }

        public IActionResult JobSeekerDelete(int id)
        {
            var jobSeeker = jobseekerManager.GetById(id);
            jobseekerManager.Delete(jobSeeker);
            return RedirectToAction("JobSeekerList");
        }

        #endregion


        #region Category 

        public IActionResult CategoryList()
        {
            var category = categoryManager.GetAll();
            return View(category);
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var category = categoryManager.GetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryDelete(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.Delete(category);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            categoryManager.Create(category);
            return RedirectToAction("CategoryList");
        }


        #endregion


        #region JobAplicationList

        public IActionResult JobApplicationList()
        {
            var jobAplication = context.JobApplications
                .Include(x => x.Job)
                .Include(x => x.JobSeeker)
                .ToList();

            return View(jobAplication);
        }

        #endregion
    }
}
