using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.ConfigExceptions
{
    public class ConnectionStringDoesNotExistsException : ConfigException
    {
        public ConnectionStringDoesNotExistsException() : base() { }
        public ConnectionStringDoesNotExistsException(string what) : base(what) { }
        public ConnectionStringDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
