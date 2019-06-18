using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModels
{
    public class ScoreViewModel
    {
        public int LectionId { get; set; }
        public string LectionName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool IsVisit { get; set; }
        public bool IsHomework { get; set; }
        public int Mark { get; set; }

        public ScoreViewModel() { }
        public ScoreViewModel(int LectionId, int StudentId, bool isVisit, bool isHomeWork, int mark)
        {
            this.LectionId = LectionId;
            this.StudentId = StudentId;
            this.IsVisit = isVisit;
            this.IsHomework = isHomeWork;
            this.Mark = mark;
        }
    }
}
