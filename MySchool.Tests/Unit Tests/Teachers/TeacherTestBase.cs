using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySchool.DAL;
using MySchool.DAL.Entities;
using MySchool.WEB.Common;
using System;

namespace MySchool.Tests.Unit_Tests.Teachers
{
    public class TeacherTestBase
    {
        protected readonly MySchoolDb context;

        public TeacherTestBase()
        {
            var options = new DbContextOptionsBuilder<MySchoolDb>()
                              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                              .Options;
            context = new MySchoolDb(options);
            context.Database.EnsureCreated();
            Seed();
            Mapper.Reset();
            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }


        public void Seed()
        {
            //Grades
            context.Grades.Add(new Grade { Id = 1, Name = "12" });
            context.Grades.Add(new Grade { Id = 2, Name = "11" });

            //Classes
            context.Classes.Add(new Class { Id = 1, Name = "A" });
            context.Classes.Add(new Class { Id = 2, Name = "B" });

            //GradeClasses
            context.GradeClasses.Add(new GradeClass { Id = 1, GradeId = 1, ClassId = 2 });

            //Subjects
            context.Subjects.Add(new Subject { Id = 1, Name = "Science" });
            context.Subjects.Add(new Subject { Id = 2, Name = "Maths" });

            //Students
            context.Teachers.Add(new Teacher { Id = 1, FirstName = "Fazlan", LastName = "Fairooz", Gender = "Male", DateOfBirth = new DateTime(1995, 11, 25), GradeClassId = 1, SubjectId = 1 });
            context.Teachers.Add(new Teacher { Id = 2, FirstName = "Irfan", LastName = "Faiz", Gender = "Male", DateOfBirth = new DateTime(1995, 06, 23), GradeClassId = 1, SubjectId = 2 });
            context.Teachers.Add(new Teacher { Id = 3, FirstName = "Thanzeel", LastName = "Jalaldeen", Gender = "Male", DateOfBirth = new DateTime(1995, 12, 18), GradeClassId = 1, SubjectId = 2 });

            context.SaveChanges();
        }
    }
}
