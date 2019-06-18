using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Training.Exceptions;

namespace Training.Models
{
    public abstract class Person
    {

        private static Regex mailExp = new Regex(@"\w+@\w+\.\w+");
        private string email;
        public int ID { get; set; }
        public string Name { get; set;}
        public string Surname { get; set; }
        public string Email
        {
            get => this.email;
            set
            {
                if (!mailExp.IsMatch(value)) throw new WrongEmailException($"Строка {value} не соотвествует формату Email адреса");
                this.email = value;
            }
        }
        public Person(int ID, string name, string surname, string email)
        {
            this.ID = ID;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
        }
        public override string ToString()
        {
            return this.ID + " " + this.Name + " " + this.Surname + " " + this.Email;
        }
    }
}
