using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.Services.Models.Classes;
using MySchool.Services.Services.Classes;

namespace MySchool.WEB.Controllers.Classes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassModel>> GetAsync()
        {
            return await classService.GetClassAsync();
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<ClassModel> GetAsync(int Id)
        {
            return await classService.GetClassByIdAsync(Id);
        }

        [HttpPost]
        public async Task PostAsync(ClassCreateModel value)
        {
            await classService.AddClassAsync(value);
        }

        [HttpPut]
        public async Task PutAsync(ClassUpdateModel data)
        {
            await classService.UpdateClassAsync(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task DeleteAsync(int Id)
        {
            await classService.DeleteClassAsync(Id);
        }
    }
}