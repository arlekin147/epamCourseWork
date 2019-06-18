using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.ConfigExceptions
{
    class FactoryNameDoesNotExistsException : ConfigException
    {
        public FactoryNameDoesNotExistsException() : base() { }
        public FactoryNameDoesNotExistsException(string what) : base(what) { }
        public FactoryNameDoesNotExistsException(string what, Exception old) : base(what, old) { }
    }
}
