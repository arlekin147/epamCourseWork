using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Course
    {
        public Course(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.ID + " " + this.Name;
        }
    }
}
