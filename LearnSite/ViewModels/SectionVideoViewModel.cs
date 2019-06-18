using System.Collections.Generic;
using LearnSite.Models;

namespace LearnSite.ViewModels
{
    public class SectionVideoViewModel
    {
        public IEnumerable<Section> Sections { get; set; }
        public Video Videos { get; set; }
    }
}