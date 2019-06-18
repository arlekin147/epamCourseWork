using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class ScoreDoesNotExistException : RepositoryException
    {
        public ScoreDoesNotExistException() : base() { }
        public ScoreDoesNotExistException(string what) : base(what) { }
        public ScoreDoesNotExistException(string what, Exception old) : base(what, old) { }
    }
}
