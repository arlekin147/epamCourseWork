using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using Training.ViewModels;

namespace Training.Utils
{
    public class LectionTuple
    {
        public Lection LectionEl { get; set; }
        public LectorViewModel LectorEl { get; set; }
        public CourseViewModel CourseEl { get; set; }
    }
}
