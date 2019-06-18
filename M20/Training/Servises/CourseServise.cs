using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Repositories;
using Training.Models;
using Training.ViewModels;
using AutoMapper;

namespace Training.Servises
{
    public class CourseServise : IService<CourseViewModel>
    {
        private readonly IRepository<Course> repo;
        private readonly IMapper mapper;

        public CourseServise(IRepository<Course> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public void Create(CourseViewModel t)
        {
            this.repo.Create(this.mapper.Map<Course>(t));
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public CourseViewModel Get(int id)
        {
            return  this.mapper.Map<CourseViewModel>(this.repo.Get(id));
        }

        public IEnumerable<CourseViewModel> GetList()
        {
            return this.mapper.Map<IEnumerable<CourseViewModel>>(this.repo.GetList());
        }

        public void Update(CourseViewModel t)
        {
            this.repo.Update(this.mapper.Map<Course>(t));
        }
    } 
}
