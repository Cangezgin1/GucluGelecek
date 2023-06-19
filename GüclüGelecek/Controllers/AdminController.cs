using BusinessLayer.Concrete;
using DataAccsesLayer.Abstract;
using DataAccsesLayer.Concrete;
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concrete;
using GüclüGelecek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace GüclüGelecek.Controllers
{
    public class AdminController : Controller
    {
        #region Managers

        JobManager jobManager = new JobManager(new EfJobDal());
        EmployerManager employerManager= new EmployerManager(new EfEmployerDal());
        JobSeekerManager jobseekerManager= new JobSeekerManager(new EfJobSeekerDal());
        CategoryManager categoryManager= new CategoryManager(new EfCategoryDal());

        #endregion

        Context context = new Context();

        #region Job

        public IActionResult JobList()
        {
            var jobList = context.Jobs
                .Include(x => x.Employer)
                .Include(y => y.Category)
                .ToList();
            return View(jobList);
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
            .ThenInclude(x=>x.Category)
            .FirstOrDefault(x => x.EmployerID == id);

            return View(employerDetails);
        }

        #endregion


        #region JobSeeker

        public IActionResult JobSeekerList()
        { 
            var jobSeeker = context.JobSeekers.ToList();
            return View(jobSeeker);
        }

        #endregion


        #region Category

        public IActionResult CategoryList()
        {
            var category = categoryManager.GetAll();
            return View(category);
        }

        #endregion
    }
}
