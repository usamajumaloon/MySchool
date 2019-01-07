using MySchool.DAL.Repository.StudentRepository;
using MySchool.Services.Models.Students;
using MySchool.Services.Services.Students;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests.Unit_Tests.Students
{
    public class StudentTest : StudentTestBase
    {
        [Fact]
        public async Task Task_GetAll_Student_OkResult()
        {
            var query = new StudentService(new StudentRepository(context));
            var result = await query.GetStudentAsync();

            Assert.Equal(3, result.Count());
        }

        [Theory]
        [InlineData(2)]
        public async Task Task_GetById_Student_OkResult(int id)
        {
            var query = new StudentService(new StudentRepository(context));

            var result = await query.GetStudentByIdAsync(id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(5)]
        public async Task Task_GetById_Student_NoResult(int id)
        {
            var query = new StudentService(new StudentRepository(context));

            var result = await query.GetStudentByIdAsync(id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(4, "Afrah", "Jumaloon", "Female", 1)]
        [InlineData(5, "Amani", "Jumaloon", "Female", 1)]
        public async Task Task_Add_Student_OkResult(int id, string firstName, string lastName, string gender, int gradeClassId)
        {
            var query = new StudentService(new StudentRepository(context));

            var output = await query.AddStudentAsync(new StudentCreateModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1999, 01, 01),
                Gender = gender,
                GradeClassId = gradeClassId
            });

            Assert.NotNull(output);
        }

        [Theory]
        [InlineData(1, "Afrah", "Jumaloon", "Female", 1)]// Existing ID
        public async Task Task_Add_Student_BadResult(int id, string firstName, string lastName, string gender, int gradeClassId)
        {
            var query = new StudentService(new StudentRepository(context));

            await Assert.ThrowsAsync<InvalidOperationException>(() => query.AddStudentAsync(new StudentCreateModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1999, 01, 01),
                Gender = gender,
                GradeClassId = gradeClassId
            }));
        }

        [Theory]
        [InlineData(2, "Essam", "Hussain", "Male", 1)]
        public async Task Task_Update_Student_OkResult(int id, string firstName, string lastName, string gender, int gradeClassId)
        {
            var query = new StudentService(new StudentRepository(context));

            await query.UpdateStudentAsync(new StudentUpdateModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1995, 06, 23),
                Gender = gender,
                GradeClassId = gradeClassId
            });

            var output = await query.GetStudentByIdAsync(id);

            Assert.Equal(firstName, output.FirstName);
        }

        [Theory]
        [InlineData(1)]
        public async Task Task_Delete_Student_OkResult(int id)
        {
            var query = new StudentService(new StudentRepository(context));

            await query.DeleteStudentAsync(id);

            var output = await query.GetStudentByIdAsync(id);

            Assert.Null(output);
        }
    }
}