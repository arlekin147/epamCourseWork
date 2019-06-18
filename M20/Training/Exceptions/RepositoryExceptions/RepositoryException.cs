using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException() : base() { }
        public RepositoryException(string what) : base(what) { }
        public RepositoryException(string what, Exception old) : base(what, old) { }
    }
}
