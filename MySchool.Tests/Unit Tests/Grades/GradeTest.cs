using MySchool.DAL.Repository.GradeRepository;
using MySchool.Services.Models.Grades;
using MySchool.Services.Services.Grades;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests.Unit_Tests.Grades
{
    public class GradeTest: GradeTestBase
    {
        [Fact]
        public async Task Task_GetAll_Grade_OkResult()
        {
            var query = new GradeService(new GradeRepository(context));
            var result = await query.GetGradeAsync();

            Assert.Equal(2, result.Count());
        }

        [Theory]
        [InlineData(2)]
        public async Task Task_GetById_Grade_OkResult(int id)
        {
            var query = new GradeService(new GradeRepository(context));

            var result = await query.GetGradeByIdAsync(id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(3)]
        public async Task Task_GetById_Grade_NoResult(int id)
        {
            var query = new GradeService(new GradeRepository(context));

            var result = await query.GetGradeByIdAsync(id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(3, "10")]
        [InlineData(4, "9")]
        public async Task Task_Add_Grade_OkResult(int id, string name)
        {
            var query = new GradeService(new GradeRepository(context));

            var output = await query.AddGradeAsync(new GradeCreateModel
            {
                Id = id,
                Name = name
            });

            Assert.NotNull(output);
        }

        [Theory]
        [InlineData(1, "5")] // Existing ID
        public async Task Task_Add_Grade_BadResult(int id, string name)
        {
            var query = new GradeService(new GradeRepository(context));

            await Assert.ThrowsAsync<InvalidOperationException>(() => query.AddGradeAsync(new GradeCreateModel
            {
                Id = id,
                Name = name
            }));
        }

        [Theory]
        [InlineData(1, "7")]
        public async Task Task_Update_Grade_OkResult(int id, string name)
        {
            var query = new GradeService(new GradeRepository(context));

            await query.UpdateGradeAsync(new GradeUpdateModel
            {
                Id = id,
                Name = name
            });

            var output = await query.GetGradeByIdAsync(id);

            Assert.Equal(name, output.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task Task_Delete_Grade_OkResult(int id)
        {
            var query = new GradeService(new GradeRepository(context));

            await query.DeleteGradeAsync(id);

            var output = await query.GetGradeByIdAsync(id);

            Assert.Null(output);
        }
    }
}
