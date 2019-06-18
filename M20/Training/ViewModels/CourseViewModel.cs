using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
