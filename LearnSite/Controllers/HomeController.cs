using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LearnSite.Context;
using LearnSite.Models;
using LearnSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            if (userId == null) userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserCourse = new UserCourseViewModel
            {
                Courses = context.Courses.ToList(),
                UserObj = context.Users.FirstOrDefault(u => u.Id == userId)
            };
            return View(UserCourse);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}