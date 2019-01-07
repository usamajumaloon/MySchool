using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Grades;
using MySchool.Services.Services.Grades;

namespace MySchool.WEB.Controllers.Grades
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService gradeService;

        public GradeController(IGradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IEnumerable<GradeModel>> GetAsync()
        {
            return await gradeService.GetGradeAsync();
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<GradeModel> GetAsync(int Id)
        {
            return await gradeService.GetGradeByIdAsync(Id);
        }

        [HttpPost]
        public async Task<GradeCreateModel> PostAsync(GradeCreateModel value)
        {
            return await gradeService.AddGradeAsync(value);
        }

        [HttpPut]
        public void PutAsync(GradeUpdateModel data)
        {
            gradeService.UpdateGradeAsync(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task DeleteAsync(int Id)
        {
            await gradeService.DeleteGradeAsync(Id);
        }
    }
}