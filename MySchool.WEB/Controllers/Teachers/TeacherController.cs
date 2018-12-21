using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Teachers;
using MySchool.Services.Services.Teachers;
using System.Collections.Generic;

namespace MySchool.WEB.Controllers.Teachers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        public IEnumerable<TeacherModel> Get()
        {
            return teacherService.GetTeacher();
        }

        [HttpGet, Route("{Id:int}")]
        public TeacherModel Get(int Id)
        {
            return teacherService.GetTeacherById(Id);
        }

        [HttpPost]
        public void Post(TeacherCreateModel value)
        {
            teacherService.AddTeacher(value);
        }

        [HttpPut]
        public void Put(TeacherUpdateModel data)
        {
            teacherService.UpdateTeacher(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public void Delete(int Id)
        {
            teacherService.DeleteTeacher(Id);
        }
    }
}