using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models.Utils
{
    struct Info
    {
        public bool Visiting;
        private int score;
        public int Score
        {
            get => score;
            set => score = Visiting ? value : 0;
        }
    }
}
