using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Exceptions.ConfigExceptions
{
    
    public class ConfigException : Exception
    {
        public ConfigException() : base() { }
        public ConfigException(string what) : base(what) { }
        public ConfigException(string what, Exception old) : base(what, old) { }
    }
}
