using LearnSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSite.ViewModels
{
    public class SectionVideoViewModel
    {
        public IEnumerable<Section> Sections { get; set; }
        public Video Videos { get; set; }
    }
}
