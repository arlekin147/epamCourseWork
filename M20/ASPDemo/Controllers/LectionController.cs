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
    public class LectionController : ControllerBase
    {
        private readonly IService<LectionViewModel> lectionServ;
        private readonly Dictionary<LectionState, JsonResult> states = new Dictionary<LectionState, JsonResult>()
        {
            {LectionState.MissLectionId,  new JsonResult(new HttpState(400, "Пропущен обязательный аргумент LectionId"))},
            {LectionState.MissName, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент LectionName"))},
            {LectionState.MissLectorId, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент LectorId"))},
            {LectionState.MissCourseId, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент CourseId"))},
            {LectionState.MissDate, new JsonResult(new HttpState(400, "Пропущен обязательный аргумент Date"))},
            {LectionState.WrongDate, new JsonResult(new HttpState(400, "Неверный формат даты"))},
            {LectionState.OK, new JsonResult(new HttpState(200, "OK"))},
        };

        public LectionController(IService<LectionViewModel> lectionServ)
        {
            this.lectionServ = lectionServ;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<LectionViewModel>> GetAll()
        {
            return new JsonResult(this.lectionServ.GetList());
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<LectionViewModel> Get([FromQuery] int? id)
        {
            if (id == null) return this.states[LectionState.MissLectionId];
            try
            {
                return new JsonResult(this.lectionServ.Get(id.Value));
            }catch(LectionDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
        [HttpPost]
        [Route("add")]
        public ActionResult<HttpState> Add([FromQuery] int? id, [FromQuery] string name, [FromQuery] DateTime? date,
            [FromQuery] int? lectorId, [FromQuery] int? courseId)
        {
            if (id == null) return this.states[LectionState.MissLectionId];
            if (name == null) return this.states[LectionState.MissName];
            if (date == null) return this.states[LectionState.MissDate];
            if (lectorId == null) return this.states[LectionState.MissLectorId];
            if (courseId == null) return this.states[LectionState.MissCourseId];

            try
            {
                this.lectionServ.Create(new LectionViewModel(id.Value, name, date.Value, lectorId.Value, courseId.Value));
                return this.states[LectionState.OK];
            }
            catch (LectionHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
            catch(LectorDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
            catch (CourseDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
            catch(FormatException e)
            {
                return new JsonResult(new HttpState(400, e.Message));
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<HttpState> Update([FromQuery] int? id, [FromQuery] string name, [FromQuery] DateTime? date,
            [FromQuery] int? lectorId, [FromQuery] int? courseId)
        {
            if (id == null) return this.states[LectionState.MissLectionId];
            if (name == null) return this.states[LectionState.MissName];
            if (date == null) return this.states[LectionState.MissDate];
            if (lectorId == null) return this.states[LectionState.MissLectorId];
            if (courseId == null) return this.states[LectionState.MissCourseId];

            try
            {
                this.lectionServ.Update(new LectionViewModel(id.Value, name, date.Value, lectorId.Value, courseId.Value));
                return this.states[LectionState.OK];
            }
            catch (LectionHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
            catch (LectorDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
            catch (CourseDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
            catch (FormatException e)
            {
                return new JsonResult(new HttpState(400, e.Message));
            }
        }
        [HttpDelete]
        [Route("Remove")]
        public ActionResult<HttpState> Remove([FromQuery] int? id)
        {
            if (id == null) return this.states[LectionState.MissLectionId];
            try
            {
                this.lectionServ.Delete(id.Value);
                return this.states[LectionState.OK];
            }
            catch (LectionDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
    }
}