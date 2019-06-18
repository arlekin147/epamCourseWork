using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    public class LectorDoesNotExistException : PersonDoesNotExistsException
    {
        public LectorDoesNotExistException() : base() { }
        public LectorDoesNotExistException(string what) : base(what) { }
        public LectorDoesNotExistException(string what, Exception old) : base(what, old) { }
    }
}
