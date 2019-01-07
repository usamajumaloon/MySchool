using MySchool.DAL.Repository.TeacherRepository;
using MySchool.Services.Models.Teachers;
using MySchool.Services.Services.Teachers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests.Unit_Tests.Teachers
{
    public class TeacherTest : TeacherTestBase
    {
        [Fact]
        public async Task Task_GetAll_Teacher_OkResult()
        {
            var query = new TeacherService(new TeacherRepository(context));
            var result = await query.GetTeacherAsync();

            Assert.Equal(3, result.Count());
        }

        [Theory]
        [InlineData(2)]
        public async Task Task_GetById_Teacher_OkResult(int id)
        {
            var query = new TeacherService(new TeacherRepository(context));

            var result = await query.GetTeacherByIdAsync(id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(5)]
        public async Task Task_GetById_Teacher_NoResult(int id)
        {
            var query = new TeacherService(new TeacherRepository(context));

            var result = await query.GetTeacherByIdAsync(id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(4, "Afrah", "Jumaloon", "Female", 1, 1)]
        [InlineData(5, "Amani", "Jumaloon", "Female", 1, 2)]
        public async Task Task_Add_Teacher_OkResult(int id, string firstName, string lastName, string gender, int gradeClassId, int subjectId)
        {
            var query = new TeacherService(new TeacherRepository(context));

            var output = await query.AddTeacherAsync(new TeacherCreateModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1999, 01, 01),
                Gender = gender,
                GradeClassId = gradeClassId,
                SubjectId = subjectId
            });

            Assert.NotNull(output);
        }

        [Theory]
        [InlineData(1, "Afrah", "Jumaloon", "Female", 1, 2)]// Existing ID
        public async Task Task_Add_Teacher_BadResult(int id, string firstName, string lastName, string gender, int gradeClassId, int subjectId)
        {
            var query = new TeacherService(new TeacherRepository(context));

            await Assert.ThrowsAsync<InvalidOperationException>(() => query.AddTeacherAsync(new TeacherCreateModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1999, 01, 01),
                Gender = gender,
                GradeClassId = gradeClassId,
                SubjectId = subjectId
            }));
        }

        [Theory]
        [InlineData(2, "Essam", "Hussain", "Male", 1, 1)]
        public async Task Task_Update_Teacher_OkResult(int id, string firstName, string lastName, string gender, int gradeClassId, int subjectId)
        {
            var query = new TeacherService(new TeacherRepository(context));

            await query.UpdateTeacherAsync(new TeacherUpdateModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1995, 06, 23),
                Gender = gender,
                GradeClassId = gradeClassId,
                SubjectId = subjectId
            });

            var output = await query.GetTeacherByIdAsync(id);

            Assert.Equal(firstName, output.FirstName);
        }

        [Theory]
        [InlineData(1)]
        public async Task Task_Delete_Teacher_OkResult(int id)
        {
            var query = new TeacherService(new TeacherRepository(context));

            await query.DeleteTeacherAsync(id);

            var output = await query.GetTeacherByIdAsync(id);

            Assert.Null(output);
        }
    }
}