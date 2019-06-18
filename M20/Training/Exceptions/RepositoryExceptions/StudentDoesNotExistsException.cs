using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class StudentDoesNotExistsException : PersonDoesNotExistsException
    {
        public StudentDoesNotExistsException() : base() { }
        public StudentDoesNotExistsException(string what) : base(what) { }
        public StudentDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
