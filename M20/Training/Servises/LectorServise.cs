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
    public class LectorServise : IService<LectorViewModel>
    {
        private readonly IRepository<Lector> repo;
        private readonly IMapper mapper;

        public LectorServise(IRepository<Lector> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public void Create(LectorViewModel t)
        {
            this.repo.Create(this.mapper.Map<Lector>(t));
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public LectorViewModel Get(int id)
        {
            return this.mapper.Map<LectorViewModel>(this.repo.Get(id));
        }

        public IEnumerable<LectorViewModel> GetList()
        {
            return this.mapper.Map<IEnumerable<LectorViewModel>>(this.repo.GetList());
        }

        public void Update(LectorViewModel t)
        {
            this.repo.Update(this.mapper.Map<Lector>(t));
        }
    }
}
