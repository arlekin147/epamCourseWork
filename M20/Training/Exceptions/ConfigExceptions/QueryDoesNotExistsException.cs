using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.ConfigExceptions
{ 
    class QueryDoesNotExistsException : ConfigException
    {
        public QueryDoesNotExistsException() : base() { }
        public QueryDoesNotExistsException(string what) : base(what) { }
        public QueryDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
