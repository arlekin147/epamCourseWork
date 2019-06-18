using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Servises;
using Training.ViewModels;
using Training.Exceptions.RepositoryExceptions;
using ASPDemo.Utils;
using Training.Exceptions;

namespace ASPDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectorController : ControllerBase
    {
        private readonly IService<LectorViewModel> lectorServ;
        private Dictionary<PersonState, JsonResult> states = new Dictionary<PersonState, JsonResult>()
        {
            { PersonState.MissId, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: id")) },
            { PersonState.MissName, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: name")) },
            { PersonState.MissSurname, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: surname")) },
            { PersonState.MissEmail, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: email")) },
            { PersonState.OK, new JsonResult(new HttpState(200, "OK")) }
        };

        public LectorController(IService<LectorViewModel> lectorServ)
        {
            this.lectorServ = lectorServ;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<LectorViewModel>> GetAll()
        {
            return new JsonResult(this.lectorServ.GetList());
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<LectorViewModel> Get([FromQuery] int? id)
        {
            if (id == null) return this.states[PersonState.MissId];
            try
            {
                return this.lectorServ.Get(id.Value);
            }
            catch(LectionDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
        [HttpPost]
        [Route("add")]
        public ActionResult<JsonResult> Add([FromQuery] int? id, [FromQuery] string name,
            [FromQuery] string surname, [FromQuery] string email)
        {
            if (id == null) return this.states[PersonState.MissId];
            if (name == null) return this.states[PersonState.MissName];
            if (surname == null) return this.states[PersonState.MissSurname];
            if (email == null) return this.states[PersonState.MissEmail];
            try
            {
                this.lectorServ.Create(new LectorViewModel(id.Value, name, surname, email));
                return this.states[PersonState.OK];
            }
            catch(WrongEmailException e)
            {
                return new JsonResult(new HttpState(400, e.Message));
            }
            catch (LectorHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<HttpState> Update([FromQuery] int? id, [FromQuery] string name,
           [FromQuery] string surname, [FromQuery] string email)
        {
            if (id == null) return this.states[PersonState.MissId];
            if (name == null) return this.states[PersonState.MissName];
            if (surname == null) return this.states[PersonState.MissSurname];
            if (email == null) return this.states[PersonState.MissEmail];
            try
            {
                this.lectorServ.Update(new LectorViewModel(id.Value, name, surname, email));
                return this.states[PersonState.OK];
            }
            catch (WrongEmailException e)
            {
                return new JsonResult(new HttpState(400, e.Message));
            }
            catch (StudentHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
        }
        [HttpDelete]
        [Route("Remove")]
        public ActionResult<HttpState> Remove([FromQuery] int? id)
        {
            if (id == null) return this.states[PersonState.MissId];
            try
            {
                this.lectorServ.Delete(id.Value);
                return this.states[PersonState.OK];
            }
            catch (StudentDoesNotExistsException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
    }
}