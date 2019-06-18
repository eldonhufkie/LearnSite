using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnSite.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseBriefDescription { get; set; }
        public string ThingsYouWillLearn { get; set; }
        public string CourseDetailedDescription { get; set; }

        public string UserId { get; set; }

        //instructor
        public ICollection<Section> Sections { get; set; }
        public byte[] ImageData { get; set; }

        [ForeignKey("UserId")] public virtual ApplicationUser ApplicationUser { get; set; }
    }
}