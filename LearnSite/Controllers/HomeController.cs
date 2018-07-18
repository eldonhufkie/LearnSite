using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearnSite.Models;
using LearnSite.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using LearnSite.ViewModels;

namespace LearnSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly LearnContext context;

        public HomeController(LearnContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index(string userId = null)
        {
            if (userId == null)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            var UserCourse = new UserCourseViewModel
            {
                Courses = context.Courses.ToList(),
                UserObj = context.Users.FirstOrDefault(u => u.Id == userId)
            };
            return View(UserCourse);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
