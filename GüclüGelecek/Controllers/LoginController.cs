using BusinessLayer.Concrete;
using DataAccsesLayer.Abstract;
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concrete;
using GüclüGelecek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GüclüGelecek.Controllers
{
    public class LoginController : Controller
    {

        #region Managers

        LoginManager loginManager = new LoginManager(new EfAdminDal(),new EfEmployerDal(),new EfJobSeekerDal()); 
 
        #endregion


        public IActionResult AdminLogin(Admin admin) 
        {
            var adminControl = loginManager.GetAdmin(admin.Username, admin.Password);

            if (adminControl != null)
                return RedirectToAction("JobList", "Admin");
            else 
                return View();
        }


 

        [HttpGet]
        public IActionResult EmployerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployerLogin(Employer employer)
        {
            var employerControl = loginManager.GetEmployer(employer.Email, employer.Password);

            if (employerControl != null)
            {
                HttpContext.Session.SetInt32("EmployerID", employerControl.EmployerID);
                return RedirectToAction("JobList", "Employer");
            }
            else
                return View();
        }




        public IActionResult JobSeekerLogin(JobSeeker jobSeeker)
        {
            var jobSeekerControl = loginManager.GetJobSeeker(jobSeeker.Email, jobSeeker.Password);

            if (jobSeekerControl != null)
                return RedirectToAction("", "");
            else
                return View();
        }

    }
}
