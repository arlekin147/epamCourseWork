using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Score
    {
        public int LectionId { get; set; }
        public int StudentId { get; set; }
        public bool IsVisit { get; set; }
        public bool IsHomework { get; set; }
        public int Mark { get; set; }

        public Score(int lectionId, int studentId, bool isVisit, bool isHomeWork, int mark)
        {
            this.LectionId = lectionId;
            this.StudentId = studentId;
            this.IsVisit = isVisit;
            this.IsHomework = isHomeWork;
            if (mark < 0 || mark > 10) throw new ArgumentException();
            if (!isVisit || !isHomeWork) this.Mark = 0;
            else this.Mark = mark;
        }

        public override string ToString()
        {
            return this.LectionId + " " + this.StudentId + " " +
                this.IsVisit + " " + this.IsHomework + " " + this.Mark;
        }
    }
}
