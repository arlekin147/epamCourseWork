using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.ViewModels;
using Training.Servises;
using Training.Exceptions.RepositoryExceptions;
using ASPDemo.Utils;

namespace ASPDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ITwoIdService<ScoreViewModel> scoreServ;
        private readonly Dictionary<ScoreState, JsonResult> states = new Dictionary<ScoreState, JsonResult>()
        {
            {ScoreState.MissStudentId, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент: StudentId")) },
            {ScoreState.MissLectionId, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент: LectionId")) },
            {ScoreState.MissVisit, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент: isVisit")) },
            {ScoreState.MissHomework, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент: isHomework")) },
            {ScoreState.MissMark, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент: mark")) },
            {ScoreState.OK, new JsonResult(new HttpState(200, "OK")) }
        };

        public ScoreController(ITwoIdService<ScoreViewModel> scoreServ)
        {
            this.scoreServ = scoreServ;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<ScoreViewModel>> GetAll()
        {
            return new JsonResult(this.scoreServ.GetList());
        }
        [HttpGet]
        [Route("getallbystudentid")]
        public ActionResult<IEnumerable<ScoreViewModel>> GetAllByStudentId([FromQuery] int studentId)
        {
            return new JsonResult(this.scoreServ.GetAllByFirstId(studentId));
        }
        [HttpGet]
        [Route("getallbylectionid")]
        public ActionResult<IEnumerable<ScoreViewModel>> GetAllByLectionId([FromQuery] int lectionId)
        {
            return new JsonResult(this.scoreServ.GetAllBySecondId(lectionId));
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<ScoreViewModel> Get([FromQuery] int? studentId, [FromQuery] int? lectionId)
        {
            if (studentId == null) return this.states[ScoreState.MissStudentId];
            if (lectionId == null) return this.states[ScoreState.MissLectionId];
            try
            {
                return this.scoreServ.Get(studentId.Value, lectionId.Value);
            }
            catch(ScoreDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
        [HttpPost]
        [Route("add")]
        public ActionResult<HttpState> Add([FromQuery] int? lectionId, [FromQuery] int? studentId,
            [FromQuery] bool? isVisit, [FromQuery] bool? isHomework, [FromQuery] int? mark)
        {
            if (studentId == null) return this.states[ScoreState.MissStudentId];
            if (lectionId == null) return this.states[ScoreState.MissLectionId];
            if (isVisit == null) return this.states[ScoreState.MissVisit];
            if (isHomework == null) return this.states[ScoreState.MissHomework];
            if (mark == null) return this.states[ScoreState.MissMark];
            try
            {
                this.scoreServ.Create(new ScoreViewModel(lectionId.Value, studentId.Value, isVisit.Value, isHomework.Value, mark.Value));
                return this.states[ScoreState.OK];
            }
            catch (ScoreHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
            catch(LectionDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
            catch(StudentDoesNotExistsException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }  
        }
        [HttpDelete]
        [Route("Remove")]
        public ActionResult<HttpState> Remove([FromQuery] int? studentId, [FromQuery] int? lectionId)
        {
            if (studentId == null) return this.states[ScoreState.MissStudentId];
            if (lectionId == null) return this.states[ScoreState.MissLectionId];
            try
            {
                this.scoreServ.Delete(studentId.Value, lectionId.Value);
                return this.states[ScoreState.OK];
            }
            catch (StudentDoesNotExistsException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<HttpState> Update([FromQuery] int? lectionId, [FromQuery] int? studentId,
            [FromQuery] bool? isVisit, [FromQuery] bool? isHomework, [FromQuery] int? mark)
        {
            if (studentId == null) return this.states[ScoreState.MissStudentId];
            if (lectionId == null) return this.states[ScoreState.MissLectionId];
            if (isVisit == null) return this.states[ScoreState.MissVisit];
            if (isHomework == null) return this.states[ScoreState.MissHomework];
            if (mark == null) return this.states[ScoreState.MissMark];
            try
            {
                this.scoreServ.Update(new ScoreViewModel(lectionId.Value, studentId.Value, isVisit.Value, isHomework.Value, mark.Value));
                return this.states[ScoreState.OK];
            }
            catch (ScoreHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
            catch (LectionDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
            catch (StudentDoesNotExistsException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
    }
}