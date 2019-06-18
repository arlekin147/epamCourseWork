using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.ViewModels;

namespace Training.Servises
{
    class TrainingService
    {
        public IService<CourseViewModel> CourseServ { get; set; }
        public IService<StudentViewModel> StudentServ { get; set; }
        public IService<LectorServise> LectorServ { get; set; }
        public IService<LectionViewModel> LectionServ { get; set; }
        //public IDataBase database
        public TrainingService(IService<CourseViewModel> courseServ, IService<StudentViewModel> studentServ,
            IService<LectionViewModel> lectionServ, IService<LectorServise> lectorServ)
        {
            this.CourseServ = courseServ;
            this.StudentServ = studentServ;
            this.LectionServ = lectionServ;
            this.LectorServ = lectorServ;
        }
    }
}
