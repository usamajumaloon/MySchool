using AutoMapper;
using MySchool.DAL.Repository.ClassRepository;
using MySchool.Services.Models.Classes;
using MySchool.Services.Services.Classes;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests.Unit_Tests.Classes
{
    public class ClassTest : ClassTestBase
    {
        [Fact]
        public async Task Task_GetAll_Class_OkResult()
        {
            var query = new ClassService(new ClassRepository(context));
            var result = await query.GetClassAsync();

            Assert.Equal(2, result.Count());
        }

        [Theory]
        [InlineData(2)]
        public async Task Task_GetById_Class_OkResult(int id)
        {
            var query = new ClassService(new ClassRepository(context));

            var result = await query.GetClassByIdAsync(id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(3)]
        public async Task Task_GetById_Class_NoResult(int id)
        {
            var query = new ClassService(new ClassRepository(context));

            var result = await query.GetClassByIdAsync(id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(3, "C")]
        [InlineData(4, "D")]
        public async Task Task_Add_Class_OkResult(int id, string name)
        {
            var query = new ClassService(new ClassRepository(context));

            var output = await query.AddClassAsync(new ClassCreateModel
            {
                Id = id,
                Name = name
            });

            Assert.NotNull(output);
        }

        [Theory]
        [InlineData(1, "C")] // Existing ID
        public async Task Task_Add_Class_BadResult(int id, string name)
        {
            var query = new ClassService(new ClassRepository(context));

            await Assert.ThrowsAsync<InvalidOperationException>(() => query.AddClassAsync(new ClassCreateModel
            {
                Id = id,
                Name = name
            }));
        }

        [Theory]
        [InlineData(1, "C")]
        public async Task Task_Update_Class_OkResult(int id, string name)
        {
            var query = new ClassService(new ClassRepository(context));
            
            await query.UpdateClassAsync(new ClassUpdateModel
            {
                Id = id,
                Name = name
            });

            var output = await query.GetClassByIdAsync(id);

            Assert.Equal(name, output.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task Task_Delete_Class_OkResult(int id)
        {
            var query = new ClassService(new ClassRepository(context));

            await query.DeleteClassAsync(id);

            var output = await query.GetClassByIdAsync(id);

            Assert.Null(output);
        }
    }
}
