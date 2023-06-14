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
                return RedirectToAction("", "");
            else
                return View();
        }


        public IActionResult EmployerLogin(Employer employer)
        {
            var adminControl = loginManager.GetEmployer(employer.Email, employer.Password);    

            if (adminControl != null)
                return RedirectToAction("", "");
            else
                return View();
        }



        public IActionResult JobSeekerLogin(JobSeeker jobSeeker)
        {
            var adminControl = loginManager.GetJobSeeker(jobSeeker.Email, jobSeeker.Password);

            if (adminControl != null)
                return RedirectToAction("", "");
            else
                return View();
        }

    }
}