using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using Training.ViewModels;

namespace Training.Utils
{
    public class ScoreTuple
    {
        public Score ScoreEl { get; set; }
        public StudentViewModel StudentEl { get; set; }
        public LectionViewModel LectionEl { get; set; }
    }
}
