using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSite.Context;
using LearnSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnSite.Controllers
{
    public class VideoController : Controller
    {
        private readonly LearnContext context;

        public VideoController(LearnContext _context)
        {
            context = _context;
        }
        // GET: Video
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var section = context.Sections
                .Include(c => c.Videos);
            return View(await section.ToListAsync());
        }
        //Get all Videos
        public IActionResult GetAllVideos()
        {
            List<Video> data = context.Videos.ToList();
            return new JsonResult(data);
        }
        // GET: Video/Details/5
        public IActionResult GetVideoByID(int? id)
        {
            Video data = context.Videos.Find(id);
            return new JsonResult(data);
        }
        [HttpGet]
        public IActionResult GetVideoByID(int id)
        {
            Video data = context.Videos.Find(id);
            return View(data);
        }
        public IActionResult GetFirstVideo()
        {
            Video data = context.Videos.FirstOrDefault();
            return new JsonResult(data);
        }
        public async Task<IActionResult> GetCourse()
        {
            var section = context.Courses.Include(c => c.Sections).AsNoTracking();
            return View(await section.ToListAsync());
        }
        public async Task<IActionResult> GetSection()
        {
            var section = context.Sections.Include(c => c.Videos.First()).AsNoTracking();
            return Json(await section.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetActionSection()
        {
            var section = context.Sections
                .Include(c => c.Videos);
            return View(await section.ToListAsync());
        }

        [HttpPost]
        public IActionResult GetActionSection(int id)
        {
            TempData["VideoUrl"] = context.Videos.FirstOrDefault(x => x.Id == id).VideoUrl;
            TempData["VideoName"] = context.Videos.FirstOrDefault(x => x.Id == id).VideoName;
            TempData["VideoDescription"] = context.Videos.FirstOrDefault(x => x.Id == id).VideoDescription;
            return RedirectToAction("Index");
        }

        // GET: Video/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
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

        // GET: Video/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Video/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Video/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Video/Delete/5
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
    }
}