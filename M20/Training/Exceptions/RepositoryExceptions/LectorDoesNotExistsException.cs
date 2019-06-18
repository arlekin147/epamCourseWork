using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.RepositoryExceptions
{
    class LectorDoesNotExistsException : PersonDoesNotExistsException
    {
        public LectorDoesNotExistsException() : base() { }
        public LectorDoesNotExistsException(string what) : base(what) { }
        public LectorDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
