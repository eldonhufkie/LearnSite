using LearnSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.Context
{
    public class LearnContext : DbContext
    {
        public LearnContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
