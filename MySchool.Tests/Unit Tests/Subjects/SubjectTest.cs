using MySchool.DAL.Repository.SubjectRepository;
using MySchool.Services.Models.Subjects;
using MySchool.Services.Services.Subjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests.Unit_Tests.Subjects
{
    public class SubjectTest : SubjectTestBase
    {
        [Fact]
        public async Task Task_GetAll_Subject_OkResult()
        {
            var query = new SubjectService(new SubjectRepository(context));
            var result = await query.GetSubjectAsync();

            Assert.Equal(2, result.Count());
        }

        [Theory]
        [InlineData(2)]
        public async Task Task_GetById_Subject_OkResult(int id)
        {
            var query = new SubjectService(new SubjectRepository(context));

            var result = await query.GetSubjectByIdAsync(id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(3)]
        public async Task Task_GetById_Subject_NoResult(int id)
        {
            var query = new SubjectService(new SubjectRepository(context));

            var result = await query.GetSubjectByIdAsync(id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(3, "Physics")]
        [InlineData(4, "Maths")]
        public async Task Task_Add_Subject_OkResult(int id, string name)
        {
            var query = new SubjectService(new SubjectRepository(context));

            var output = await query.AddSubjectAsync(new SubjectCreateModel
            {
                Id = id,
                Name = name
            });

            Assert.NotNull(output);
        }

        [Theory]
        [InlineData(1, "Arabic")] // Existing ID
        public async Task Task_Add_Subject_BadResult(int id, string name)
        {
            var query = new SubjectService(new SubjectRepository(context));

            await Assert.ThrowsAsync<InvalidOperationException>(() => query.AddSubjectAsync(new SubjectCreateModel
            {
                Id = id,
                Name = name
            }));
        }

        [Theory]
        [InlineData(1, "Science")]
        public async Task Task_Update_Subject_OkResult(int id, string name)
        {
            var query = new SubjectService(new SubjectRepository(context));

            await query.UpdateSubjectAsync(new SubjectUpdateModel
            {
                Id = id,
                Name = name
            });

            var output = await query.GetSubjectByIdAsync(id);

            Assert.Equal(name, output.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task Task_Delete_Subject_OkResult(int id)
        {
            var query = new SubjectService(new SubjectRepository(context));

            await query.DeleteSubjectAsync(id);

            var output = await query.GetSubjectByIdAsync(id);

            Assert.Null(output);
        }
    }
}
