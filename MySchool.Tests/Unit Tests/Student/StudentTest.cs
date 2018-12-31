using MySchool.DAL.Repository.StudentRepository;
using MySchool.Services.Models.Students;
using MySchool.Services.Services.Students;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests.Unit_Tests.Student
{
    public class StudentTest : MySchoolTestBase
    {
        //Task_CRUD_Name
        //eg: Task_Add_Valid/Invalid_Result

        [Theory]
        [InlineData(4, "Afrah", "Jumaloon", "Female", 1)]
        [InlineData(5, "Amani", "Jumaloon", "Female", 1)]
        [InlineData(6, "Essam", "Jumaloon", "Male", 1)]
        public async Task Task_Add_ValidData_OkResult(int id, string firstName, string lastName, string gender, int gradeClassId)
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
        [InlineData(3, "Afrah", "Jumaloon", "Female", 1)] // Existing ID
        [InlineData(3, "Amani", "Jumaloon", "Female", 69)] // Existing ID
        public async Task Task_Add_InvalidData_BadRequest(int id, string firstName, string lastName, string gender, int gradeClassId)
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
    }
}
