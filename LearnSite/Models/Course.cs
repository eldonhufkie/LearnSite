using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseBriefDescription { get; set; }
        public string ThingsYouWillLearn { get; set; }
        public string CourseDetailedDescription { get; set; }
        //instructor
        public ICollection<Section> Sections { get; set; }
    }
}
