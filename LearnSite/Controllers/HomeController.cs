using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearnSite.Models;
using LearnSite.Context;
using Microsoft.EntityFrameworkCore;

namespace LearnSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly LearnContext context;

        public HomeController(LearnContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            TempData["VideoId"] = null;
            return View();
        }
       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
