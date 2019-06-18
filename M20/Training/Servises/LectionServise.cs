using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models;
using Training.Repositories;
using Training.ViewModels;
using Training.Utils;
using AutoMapper;
using Training.Exceptions.RepositoryExceptions;
using Training.AutoMapper;

namespace Training.Servises
{

    public class LectionServise : IService<LectionViewModel>
    {
        private readonly IRepository<Lection> lectionRepo;
        private readonly IService<LectorViewModel> lectorServ;
        private readonly IService<CourseViewModel> courseServ;
        private readonly IMapper mapper;
        public LectionServise(IRepository<Lection> lectionRepo,
            IService<LectorViewModel> lectorServ, IService<CourseViewModel> courseServ, IMapper mapper)
        {
            this.mapper = mapper;
            this.lectionRepo = lectionRepo;
            this.lectorServ = lectorServ;
            this.courseServ = courseServ;
        }

        public void Create(LectionViewModel t)
        {
            try
            {
                this.lectorServ.Get(t.LectorID);
            }
            catch (LectorDoesNotExistException)
            {
                throw;
            }
            try
            {
                this.courseServ.Get(t.CourseID);
            }
            catch (CourseDoesNotExistException)
            {
                throw;
            }
            this.lectionRepo.Create(this.mapper.Map<Lection>(t));
        }

        public void Delete(int id)
        {
            this.lectionRepo.Delete(id);
        }

        public LectionViewModel Get(int id)
        {
            
            var tuple = new LectionTuple();
            tuple.LectionEl = this.lectionRepo.Get(id);
            tuple.LectorEl = this.lectorServ.Get(tuple.LectionEl.LectorID);
            tuple.CourseEl = this.courseServ.Get(tuple.LectionEl.CourseId);
            return this.mapper.Map<LectionViewModel>(tuple);
        }

        public IEnumerable<LectionViewModel> GetList()
        {
            var tuples = new List<LectionTuple>();
            var lections = this.lectionRepo.GetList();
            foreach(var l in lections)
            {
                var tuple = new LectionTuple();
                tuple.LectionEl = l;
                tuple.LectorEl = this.lectorServ.Get(tuple.LectionEl.LectorID);
                tuple.CourseEl = this.courseServ.Get(tuple.LectionEl.CourseId);
                tuples.Add(tuple);
            }
            return this.mapper.Map<IEnumerable<LectionViewModel>>(tuples);
        }

        public void Update(LectionViewModel t)
        {
            try
            {
                this.lectorServ.Get(t.LectorID);
            }
            catch (LectorDoesNotExistException)
            {
                throw;
            }
            try
            {
                this.courseServ.Get(t.CourseID);
            }
            catch (CourseDoesNotExistException)
            {
                throw;
            }
            this.lectionRepo.Update(this.mapper.Map<Lection>(t));
        }
    }
}
