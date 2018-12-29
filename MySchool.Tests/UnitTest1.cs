using MySchool.DAL.Repository.StudentRepository;
using MySchool.Services.Services.Students;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MySchool.Tests
{
    public class UnitTest1: MySchoolTestBase
    {
        [Fact]
        public async Task GetAllStudentsAsync()
        {
            var query = new StudentService(new StudentRepository(context));
            var result = await query.GetStudentAsync();

            Assert.Equal(3, result.Count());
        }
    }
}
