using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    class CourseDoesNotExistsException : RepositoryException
    {
        public CourseDoesNotExistsException() : base() { }
        public CourseDoesNotExistsException(string what) : base(what) { }
        public CourseDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
