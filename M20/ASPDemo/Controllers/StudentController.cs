using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.ViewModels;
using Training.Servises;
using Training.Exceptions.RepositoryExceptions;
using Microsoft.Extensions.Logging;
using ASPDemo.Utils;
using Training.Exceptions;

namespace ASPDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly IService<StudentViewModel> studentServ;
        private readonly Dictionary<PersonState, JsonResult> states = new Dictionary<PersonState, JsonResult>()
        {
            { PersonState.MissId, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: id")) },
            { PersonState.MissName, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: name")) },
            { PersonState.MissSurname, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: surname")) },
            { PersonState.MissEmail, new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: email")) },
            { PersonState.OK, new JsonResult(new HttpState(200, "OK")) }
        };

        public StudentController(IService<StudentViewModel> studentServ, ILogger<StudentController> logger)
        {

            this.logger = logger;
            this.studentServ = studentServ;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<StudentViewModel>> GetAll(){
            logger.LogInformation("ogo");
            logger.LogCritical("aga");
            return new JsonResult(this.studentServ.GetList());
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<StudentViewModel> Get([FromQuery] int? id)
        {
            if(id ==  null) return new JsonResult(new HttpState(400, "Отсутствует обязательный параметр: id"));
            try
            {
                return this.studentServ.Get(id.Value);
            }catch(StudentDoesNotExistsException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
        [HttpPost]
        [Route("add")]
        public ActionResult<HttpState> Add([FromQuery] int? id, [FromQuery] string name,
            [FromQuery] string surname, [FromQuery] string email, [FromQuery] string phoneNumber)
        {
            if (id == null) return this.states[PersonState.MissId];
            if (name == null) return this.states[PersonState.MissName];
            if (surname == null) return this.states[PersonState.MissSurname];
            if (email == null) return this.states[PersonState.MissEmail];
            if (phoneNumber == null) return new JsonResult(new HttpState(400, "Пропущен обязательный параметр phoneNumber"));
            try
            {
                this.studentServ.Create(new StudentViewModel(id.Value, name, surname, email, phoneNumber));
            }
            catch(WrongEmailException e)
            {
                return new JsonResult(new HttpState(400, e.Message));
            }
            catch(StudentHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
            return this.states[PersonState.OK];
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<HttpState> Update([FromQuery] int? id, [FromQuery] string name,
           [FromQuery] string surname, [FromQuery] string email, [FromQuery] string phoneNumber)
        {
            if (id == null) return this.states[PersonState.MissId];
            if (name == null) return this.states[PersonState.MissName];
            if (surname == null) return this.states[PersonState.MissSurname];
            if (email == null) return this.states[PersonState.MissEmail];
            if (phoneNumber == null) return new JsonResult(new HttpState(400, "Пропущен оьязательный параметр phoneNumber"));
            try
            {
                this.studentServ.Update(new StudentViewModel(id.Value, name, surname, email, phoneNumber));
                return this.states[PersonState.OK];
            }
            catch(WrongEmailException e)
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
                this.studentServ.Delete(id.Value);
                return this.states[PersonState.OK];
            }
            catch(StudentDoesNotExistsException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }

    }
}