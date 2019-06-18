using System.Linq;
using LearnSite.Context;
using LearnSite.Models;

namespace LearnSite.Data
{
    public class DbInitializer
    {
        public static void Initializer(LearnContext context)
        {
            context.Database.EnsureCreated();
            //check for videos
            if (context.Videos.Any()) return; //db seeded
            var vid = new[]
            {
                new Video {VideoName = "Introduction to python.", VideoUrl = "zpOULjyy-n8"}
            };
            foreach (var v in vid) context.Videos.Add(v);
            context.SaveChanges();
        }
    }
}