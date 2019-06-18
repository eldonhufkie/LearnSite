using System.Threading.Tasks;
using LearnSite.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnSite.Controllers
{
    public class SectionController : Controller
    {
        private readonly LearnContext context;

        public SectionController(LearnContext _context)
        {
            context = _context;
        }

        // GET: Section
        public async Task<IActionResult> Index()
        {
            var section = context.Sections
                .Include(c => c.Videos);
            return View(await section.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetVideo(int id)
        {
            var ad = context.Videos.Find(id);
            return View(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var ad = context.Videos.Find(id);
            return View(ad);
        }

        public async Task<IActionResult> GetVideoList()
        {
            return View();
        }

        // GET: Section/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Section/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Section/Create
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

        // GET: Section/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Section/Edit/5
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

        // GET: Section/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Section/Delete/5
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