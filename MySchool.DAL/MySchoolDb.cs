using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;

namespace MySchool.DAL
{
    public class MySchoolDb : DbContext
    {
        public MySchoolDb(DbContextOptions<MySchoolDb> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string cn = "Server=DESKTOP-QQ3218V\\SQLEXPRESS;database=MySchool;Trusted_connection=true;pooling=true;MultipleActiveResultSets=True";
        //    optionsBuilder.UseSqlServer(cn);
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GradeClass> GradeClasses { get; set; }
        public DbSet<SubjectGrade> SubjectGrades { get; set; }
    }

}
