using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnSite.Models
{
    public class MyCourse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrolledDate { get; set; }

        [ForeignKey("UserId")] public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("CourseID")] public virtual Course Courses { get; set; }
    }
}