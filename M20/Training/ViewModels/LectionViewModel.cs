using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModels
{
    public class LectionViewModel
    {
        public LectionViewModel() {}
        public LectionViewModel(int id, string name, DateTime date, int lectorId, int courseId)
        {
            this.LectionID = id;
            this.LectionName = name;
            this.Date = date;
            this.LectorID = lectorId;
            this.CourseID = courseId;
        }
        public int LectionID { get; set; }
        public string LectionName { get; set; }
        public DateTime Date { get; set; }
        public int LectorID { get; set; }
        public string LectorName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public override string ToString()
        {
            return this.LectionName + " " + this.Date + "  " + this.LectorName + " " + this.CourseName;
        }
    }
}
