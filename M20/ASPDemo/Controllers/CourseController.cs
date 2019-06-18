using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.ViewModels;
using Training.Servises;
using Training.Exceptions;
using Training.Exceptions.RepositoryExceptions;
using ASPDemo.Utils;

namespace ASPDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IService<CourseViewModel> courseServ;
        private readonly Dictionary<CourseState, JsonResult> states = new Dictionary<CourseState, JsonResult>()
        {
            { CourseState.MissId, new JsonResult(new HttpState(400, "Пропущен обязательный аргмуент: id")) },
            { CourseState.MissName, new JsonResult(new HttpState(400, "Пропущен обязательный аргмуент: name")) },
            { CourseState.OK, new JsonResult(new HttpState(200, "OK")) },
        };

        public CourseController(IService<CourseViewModel> courseServ)
        {
            this.courseServ = courseServ;
        }
        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<CourseViewModel>> GetAll()
        {
            return new JsonResult(this.courseServ.GetList());
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<CourseViewModel> Get([FromQuery] int? id)
        {
            if (id == null) return this.states[CourseState.MissId];
            try
            {
                return new JsonResult(this.courseServ.Get(id.Value));
            }catch(CourseDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
        [HttpPost]
        [Route("add")]
        public ActionResult<HttpState> Add([FromQuery] int? id, [FromQuery] string name)
        {
            if (id == null) return this.states[CourseState.MissId];
            if (name == null) return this.states[CourseState.MissName];
            try
            {
                this.courseServ.Create(new CourseViewModel(id.Value, name));
                return this.states[CourseState.OK];
            }
            catch (CourseHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<HttpState> Update([FromQuery] int? id, [FromQuery] string name)
        {
            if (id == null) return this.states[CourseState.MissId];
            if (name == null) return this.states[CourseState.MissName];
            try
            {
                this.courseServ.Update(new CourseViewModel(id.Value, name));
                return this.states[CourseState.OK];
            }
            catch (CourseHasAlreadyExistedException e)
            {
                return new JsonResult(new HttpState(409, e.Message));
            }
        }
        [HttpDelete]
        [Route("Remove")]
        public ActionResult<HttpState> Remove([FromQuery] int? id)
        {
            if (id == null) return this.states[CourseState.MissId];
            try
            {
                this.courseServ.Delete(id.Value);
                return this.states[CourseState.OK];
            }
            catch (CourseDoesNotExistException e)
            {
                return new JsonResult(new HttpState(404, e.Message));
            }
        }
    }
}