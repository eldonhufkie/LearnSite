using System.Collections.Generic;
using LearnSite.Models;

namespace LearnSite.ViewModels
{
    public class MyCoursesViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<MyCourse> Courses { get; set; }
    }
}