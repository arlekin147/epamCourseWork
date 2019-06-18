using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class StudentHasAlreadyExistedException : PersonHasAlreadyExistedException
    {
        public StudentHasAlreadyExistedException() : base() { }
        public StudentHasAlreadyExistedException(string what) : base(what) { }
        public StudentHasAlreadyExistedException(string what, Exception old) : base(what, old) { }
    }
}
