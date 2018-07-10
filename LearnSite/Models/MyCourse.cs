using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.Models
{
    public class MyCourse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrolledDate { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Courses { get; set; }
    }
}
