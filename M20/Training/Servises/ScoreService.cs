using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.ViewModels;
using Training.Servises;
using Training.Repositories;
using Training.Exceptions.RepositoryExceptions;
using Training.Models;
using Training.Utils;
using AutoMapper;

namespace Training.Servises
{
    public class ScoreService : ITwoIdService<ScoreViewModel>
    {
        private readonly ITwoKeysRepository<Score> scoreRepo;
        private readonly IMapper mapper;
        private readonly IService<StudentViewModel> studentServ;
        private readonly IService<LectionViewModel> lectionServ;

        public ScoreService(ITwoKeysRepository<Score> scoreRepo, IService<StudentViewModel> studentServ,
            IService<LectionViewModel> lectionServ, IMapper mapper)
        {
            this.scoreRepo = scoreRepo;
            this.mapper = mapper;
            this.studentServ = studentServ;
            this.lectionServ = lectionServ;
        }

        public void Create(ScoreViewModel t)
        {
            try
            {
                this.studentServ.Get(t.StudentId);
            }
            catch (StudentDoesNotExistsException)
            {
                throw;
            }

            try
            {
                this.lectionServ.Get(t.LectionId);
            }
            catch (LectionDoesNotExistException)
            {
                throw;
            }
            this.scoreRepo.Create(this.mapper.Map<Score>(t));
        }

        public void Delete(int studentid, int lectionId)
        {
            this.scoreRepo.Delete(lectionId, studentid);
        }

        public ScoreViewModel Get(int studentid, int lectionId)
        {
            var tuple = new ScoreTuple();
            tuple.ScoreEl = this.scoreRepo.Get(lectionId, studentid);
            tuple.StudentEl = this.studentServ.Get(tuple.ScoreEl.StudentId);
            tuple.LectionEl = this.lectionServ.Get(tuple.ScoreEl.LectionId);
            return this.mapper.Map<ScoreViewModel>(tuple);
        }

        public IEnumerable<ScoreViewModel> GetAllByFirstId(int firstId)
        {
            var tuples = new List<ScoreTuple>();
            var scores = this.scoreRepo.GetAllByFirstId(firstId);
            foreach (var s in scores)
            {
                var tuple = new ScoreTuple();
                tuple.ScoreEl = s;
                tuple.StudentEl = this.studentServ.Get(tuple.ScoreEl.StudentId);
                tuple.LectionEl = this.lectionServ.Get(tuple.ScoreEl.LectionId);
                tuples.Add(tuple);
            }
            return this.mapper.Map<IEnumerable<ScoreViewModel>>(tuples);
        }

        public IEnumerable<ScoreViewModel> GetAllBySecondId(int secondId)
        {
            var tuples = new List<ScoreTuple>();
            var scores = this.scoreRepo.GetAllBySecondId(secondId);
            foreach (var s in scores)
            {
                var tuple = new ScoreTuple();
                tuple.ScoreEl = s;
                tuple.StudentEl = this.studentServ.Get(tuple.ScoreEl.StudentId);
                tuple.LectionEl = this.lectionServ.Get(tuple.ScoreEl.LectionId);
                tuples.Add(tuple);
            }
            return this.mapper.Map<IEnumerable<ScoreViewModel>>(tuples);
        }

        public IEnumerable<ScoreViewModel> GetList()
        {
            var tuples = new List<ScoreTuple>();
            var scores = this.scoreRepo.GetList();
            foreach(var s in scores)
            {
                var tuple = new ScoreTuple();
                tuple.ScoreEl = s;
                tuple.StudentEl = this.studentServ.Get(tuple.ScoreEl.StudentId);
                tuple.LectionEl = this.lectionServ.Get(tuple.ScoreEl.LectionId);
                tuples.Add(tuple);
            }
            return this.mapper.Map<IEnumerable<ScoreViewModel>>(tuples);
        }

        public void Update(ScoreViewModel t)
        {
            try
            {
                this.studentServ.Get(t.StudentId);
            }
            catch (StudentDoesNotExistsException)
            {
                throw;
            }

            try
            {
                this.lectionServ.Get(t.LectionId);
            }
            catch (LectionDoesNotExistException)
            {
                throw;
            }
            this.scoreRepo.Update(this.mapper.Map<Score>(t));
        }
    }
}
