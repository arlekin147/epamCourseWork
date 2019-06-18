using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using Training.Repositories;
using Training.ViewModels;
using AutoMapper;

namespace Training.Servises
{
    public class StudentService : IService<StudentViewModel>
    {
        private readonly IRepository<Student> repo;
        private readonly IMapper mapper;

        public StudentService(IRepository<Student> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public void Create(StudentViewModel t)
        {
            this.repo.Create(mapper.Map<Student>(t));
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public StudentViewModel Get(int id)
        {
            return this.mapper.Map<StudentViewModel>(this.repo.Get(id));
        }

        public IEnumerable<StudentViewModel> GetList()
        {
            return this.mapper.Map<IEnumerable<StudentViewModel>>(this.repo.GetList());
        }

        public void Update(StudentViewModel t)
        {
            this.repo.Update(this.mapper.Map<Student>(t));
        }
    }
}
