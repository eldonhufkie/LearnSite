﻿using System.Collections.Generic;
using LearnSite.Models;

namespace LearnSite.ViewModels
{
    public class UserCourseViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}