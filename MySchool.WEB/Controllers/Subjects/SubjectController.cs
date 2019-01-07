using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Subjects;
using MySchool.Services.Services.Subjects;

namespace MySchool.WEB.Controllers.Subjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectModel>> GetAsync()
        {
            return await subjectService.GetSubjectAsync();
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<SubjectModel> GetAsync(int Id)
        {
            return await subjectService.GetSubjectByIdAsync(Id);
        }

        [HttpPost]
        public async Task<SubjectCreateModel> PostAsync(SubjectCreateModel value)
        {
            return await subjectService.AddSubjectAsync(value);
        }

        [HttpPut]
        public void PutAsync(SubjectUpdateModel data)
        {
            subjectService.UpdateSubjectAsync(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task DeleteAsync(int Id)
        {
            await subjectService.DeleteSubjectAsync(Id);
        }
    }
}