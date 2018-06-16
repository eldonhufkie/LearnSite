using LearnSite.Context;
using LearnSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.Data
{
    public class DbInitializer
    {
        public static void Initializer(LearnContext context)
        {
            context.Database.EnsureCreated();
            //check for videos
            if (context.Videos.Any())
            {
                return; //db seeded
            }
            var vid = new Video[]
            {
                new Video{VideoName = "Introduction to python.", VideoUrl ="zpOULjyy-n8" }
            };
            foreach (Video v in vid)
            {
                context.Videos.Add(v);
            }
            context.SaveChanges();
        }
    }
}
