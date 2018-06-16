using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
    }
}
