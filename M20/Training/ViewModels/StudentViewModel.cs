using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Training.Exceptions;

namespace Training.ViewModels
{
    public class StudentViewModel : PersonViewModel
    {
        public string PhoneNumber { get; set; }
        public StudentViewModel() { }
        public StudentViewModel(string name, string surname, string email, string phoneNumber) : base(name, surname, email) {
            this.PhoneNumber = phoneNumber;
        }
        public StudentViewModel(int id, string name, string surname, string email, string phoneNummber) : this(name, surname, email, phoneNummber)
        {
            this.ID = id;
        }
    }
}
