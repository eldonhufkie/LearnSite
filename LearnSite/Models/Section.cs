using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public int SectionNumber { get; set; }
        public string SectionDescription { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
