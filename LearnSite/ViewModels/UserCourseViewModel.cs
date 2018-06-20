using LearnSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.ViewModels
{
    public class UserCourseViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
