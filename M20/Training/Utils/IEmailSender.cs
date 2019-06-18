using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utils
{
    interface IEmailSender
    {
        void SendEmail(string email, string message);
    }
}
