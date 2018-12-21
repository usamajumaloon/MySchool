using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Students;
using MySchool.Services.Services.Students;
using System.Collections.Generic;

namespace MySchool.WEB.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            return studentService.GetStudent();
        }

        [HttpGet, Route("{Id:int}")]
        public StudentModel Get(int Id)
        {
            return studentService.GetStudentById(Id);
        }

        [HttpPost]
        public void Post(StudentCreateModel value)
        {
            studentService.AddStudent(value);
        }

        [HttpPut]
        public void Put(StudentUpdateModel data)
        {
            studentService.UpdateStudent(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public void Delete(int Id)
        {
            studentService.DeleteStudent(Id);
        }
    }
}