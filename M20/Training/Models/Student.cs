using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models
{
    public class Student : Person
    {
        public string PhoneNumber { get; set; }
        public Student(int ID, string name, string surname, string email, string phonenumber):base(ID, name, surname, email) {
            this.PhoneNumber = phonenumber;
        }
        
    }
}
