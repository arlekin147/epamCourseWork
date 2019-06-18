using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDemo.Utils
{
    public class HttpState
    {
        public int State { get; set; }
        public string Description { get; set; }
        public HttpState(int state, string description)
        {
            this.State = state;
            this.Description = description;
        }
    }
}
