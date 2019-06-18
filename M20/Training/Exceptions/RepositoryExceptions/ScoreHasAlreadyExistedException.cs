using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class ScoreHasAlreadyExistedException : RepositoryException
    {
        public ScoreHasAlreadyExistedException() : base() { }
        public ScoreHasAlreadyExistedException(string what) : base(what) { }
        public ScoreHasAlreadyExistedException(string what, Exception old) : base(what, old) { }
    }
}
