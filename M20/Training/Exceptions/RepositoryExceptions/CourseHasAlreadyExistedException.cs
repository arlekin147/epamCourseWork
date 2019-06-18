using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class CourseHasAlreadyExistedException : RepositoryException
    {
        public CourseHasAlreadyExistedException() : base() { }
        public CourseHasAlreadyExistedException(string what) : base(what) { }
        public CourseHasAlreadyExistedException(string what, Exception old) : base(what, old) { }
    }
}
