using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class CourseDoesNotExistException : RepositoryException
    {
        public CourseDoesNotExistException() : base() { }
        public CourseDoesNotExistException(string what) : base(what) { }
        public CourseDoesNotExistException(string what, Exception old) : base(what, old) { }
    }
}
