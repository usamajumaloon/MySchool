using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Teachers;
using MySchool.Services.Services.Teachers;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<TeacherModel>> GetAsync()
        {
            return await teacherService.GetTeacherAsync();
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<TeacherModel> GetAsync(int Id)
        {
            return await teacherService.GetTeacherByIdAsync(Id);
        }

        [HttpPost]
        public async Task<TeacherCreateModel> PostAsync(TeacherCreateModel value)
        {
            return await teacherService.AddTeacherAsync(value);
        }

        [HttpPut]
        public async Task PutAsync(TeacherUpdateModel data)
        {
            await teacherService.UpdateTeacherAsync(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task DeleteAsync(int Id)
        {
            await teacherService.DeleteTeacherAsync(Id);
        }
    }
}