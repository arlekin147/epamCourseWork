using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Lection
    {
        public Lection() { }
        public Lection(int ID, string name, int LectorID, DateTime date, int CourseId)
        {
            this.ID = ID;
            this.Name = name;
            this.LectorID = LectorID;
            this.Date = date;
            this.CourseId = CourseId;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int LectorID { get; set; }
        public DateTime Date { get; set;  }
        public int CourseId { get; set; }
        public override string ToString()
        {
            return this.ID + " " + this.Name + " " + LectorID + " " + this.Date.ToString() +
                " " + this.CourseId;
        }
    }
}
