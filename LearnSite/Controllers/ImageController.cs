using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearnSite.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnSite.Controllers
{
    public class ImageController : Controller
    {
        private readonly LearnContext context;
        public ImageController(LearnContext learnContext)
        {
            context = learnContext;
        }
        // GET: Image
        [HttpGet]
        public IActionResult Index()
        {

            //List<Guid> iamgeIds = context.Images.Select(m => m.Id).ToList();
            //return View(iamgeIds);
            return View();

        }

        [HttpPost]
        public IActionResult UploadImage(IList<IFormFile> files)
        {
            IFormFile uploadedImage = files.FirstOrDefault();
            if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {

                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);

                //System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                Models.Image imageEntity = new Models.Image()
                {
                    //Id = Guid.NewGuid(),
                    Name = uploadedImage.Name,
                    Data = ms.ToArray(),
                    //Width = image.Width,
                    //Height = image.Height,
                    ContentType = uploadedImage.ContentType
                };

                context.Images.Add(imageEntity);

                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewImage(Guid id)
        {

            //Models.Image image = context.Images.FirstOrDefault(m => m.Id == id);

            //MemoryStream ms = new MemoryStream(image.Data);

            //return new FileStreamResult(ms, image.ContentType);
            return View();

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
