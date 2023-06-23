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
    public class HomeController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Jobs.Include(x=>x.Employer).ToList();
            return View(values);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

    }
}


