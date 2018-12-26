using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Students;
using MySchool.Services.Services.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<StudentModel>> GetAsync()
        {
            return await studentService.GetStudentAsync();
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<StudentModel> GetAsync(int Id)
        {
            return await studentService.GetStudentByIdAsync(Id);
        }

        [HttpPost]
        public async Task PostAsync(StudentCreateModel value)
        {
            await studentService.AddStudentAsync(value);
        }

        [HttpPut]
        public async Task PutAsync(StudentUpdateModel data)
        {
            await studentService.UpdateStudentAsync(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task DeleteAsync(int Id)
        {
            await studentService.DeleteStudentAsync(Id);
        }
    }
}