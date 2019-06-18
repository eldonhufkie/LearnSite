using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LearnSite.Context;
using LearnSite.Models;
using LearnSite.Ulitity;
using LearnSite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnSite.Controllers
{
    public class CourseController : Controller
    {
        private readonly LearnContext context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        private string userId;

        public CourseController(LearnContext _context)
        {
            context = _context;
        }

        // GET: Course
        public IActionResult Index(string userId = null)
        {
            if (userId == null) userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserCourse = new UserCourseViewModel
            {
                Courses = context.Courses.ToList(),
                UserObj = context.Users.FirstOrDefault(u => u.Id == userId)
            };

            return View(UserCourse);
        }

        //
        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            if (User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.ViewerEndUser))
            {
                if (User.Identity.IsAuthenticated)
                {
                    userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var myCourseCount = context.MyCourses.Where(x => x.CourseID == id && x.UserId == userId).Count();
                    if (myCourseCount == 0)
                    {
                        //var course = context.Courses.FirstOrDefault(x => x.Id == id);
                        var UserCourse = new UserCourseViewModel
                        {
                            Courses = context.Courses.ToList(),
                            UserObj = context.Users.FirstOrDefault(u => u.Id == userId)
                        };
                        return View(UserCourse);
                    }

                    var TheUserId = context.MyCourses.FirstOrDefault(u => u.UserId == userId);
                    var TheCourseId = context.MyCourses.FirstOrDefault(c => c.CourseID == id).CourseID;
                    if (userId == TheUserId.UserId
                        && id == TheCourseId)
                        return RedirectToAction("Index", "Section");
                }
            }
            else
            {
                var UserCourse = new UserCourseViewModel
                {
                    Courses = context.Courses.ToList()
                };
                return View(UserCourse);
                //var course = context.Courses.FirstOrDefault(x => x.Id == id);
                //return View(course);
            }

            return View();
        }

        // GET: Course
        public async Task<IActionResult> MyCourses(string userId = null)
        {
            if (userId == null) userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myCourses = new MyCoursesViewModel
            {
                Courses = await context.MyCourses.Include(c => c.Courses).Include(x => x.ApplicationUser).Where(c => c.UserId == userId).ToListAsync(),
                UserObj = context.Users.FirstOrDefault(u => u.Id == userId)
            };

            return View(myCourses);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var course = new Course();
                course.CourseName = collection["CourseName"];
                course.CourseBriefDescription = collection["CourseBriefDescription"];
                course.CourseDetailedDescription = collection["CourseDetailedDescription"];
                course.ThingsYouWillLearn = collection["ThingsYouWillLearn"];

                context.Courses.Add(course);
                context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/EnrollCourse/5
        [HttpGet]
        public ActionResult EnrollCourse(int id)
        {
            context.Courses.First(x => x.Id == id);
            return View();
        }

        // POST: Course/EnrollCourse/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnrollCourseP(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var date = DateTime.Now;
                try
                {
                    var myCourse = new MyCourse();
                    myCourse.CourseID = id;
                    myCourse.UserId = userId;
                    myCourse.EnrolledDate = date;

                    // TODO: Add Enroll logic here

                    context.MyCourses.Add(myCourse);
                    context.SaveChangesAsync();
                    return RedirectToAction("Index", "Section");
                }
                catch
                {
                    return View();
                }
            }

            return RedirectToAction("Login", "Account");
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        context.Dispose();
        //    }
        //}
    }
}