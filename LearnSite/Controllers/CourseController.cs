using System;
using System.Collections.Generic;
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
        string userId;
        IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        public CourseController(LearnContext _context)
        {
            context = _context;

        }

        // GET: Course
        public async Task<IActionResult> Index(string userId = null)
        {
            //if (userId == null)
            //{
            //    userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //}
            //var UserCourse = new UserCourseViewModel
            //{
            //    Courses= (IEnumerable<Course>)context.Courses.SingleOrDefaultAsync(),
            //    UserObj = context.Users.FirstOrDefault(u => u.Id == userId)
            //};
            var model = context.Courses.ToListAsync();
            return View(await model);
        }
        //
        // GET: Course/Details/5
        public async Task<ActionResult> Details(int id)
        {


            if (User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.ViewerEndUser))
            {
                if (User.Identity.IsAuthenticated)
                {
                    userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    if (context.Courses.Count() < 1)
                    {
                        var course = context.Courses.FirstOrDefault(x => x.Id == id);
                        return View(course);
                    }
                    else
                    {
                        var TheUserId = context.MyCourses.FirstOrDefault(u => u.UserId == userId).UserId;
                        var TheCourseId = context.MyCourses.FirstOrDefault(c => c.CourseID == id).CourseID;
                        if (userId == TheUserId
                            && id == TheCourseId)
                        {
                            return RedirectToAction("Index", "Section");
                        }
                    }

                }
            }
            else
            {
                var course = context.Courses.FirstOrDefault(x => x.Id == id);
                return View(course);
            }
            return View();
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
            userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            DateTime date = DateTime.Now;
            try
            {
                MyCourse myCourse = new MyCourse();
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