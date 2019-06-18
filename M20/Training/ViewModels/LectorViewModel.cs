using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModels
{
    public class LectorViewModel : PersonViewModel
    {
        public LectorViewModel() { }
        public LectorViewModel(int id, string name, string surname, string email) : base(id, name, surname, email) { }
    }
}
