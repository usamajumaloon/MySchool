using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySchool.DAL;
using MySchool.DAL.Entities;
using MySchool.WEB.Common;
using System;

namespace MySchool.Tests
{
    public class MySchoolTestBase: IDisposable
    {
        protected readonly MySchoolDb context;

        public MySchoolTestBase()
        {
            var options = new DbContextOptionsBuilder<MySchoolDb>()
                              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                              .Options;
            context = new MySchoolDb(options);
            context.Database.EnsureCreated();
            Seed();
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
            var grades = new Grade { Id = 1, Name = "12" };
            var classes = new Class { Id = 2, Name = "B" };
            context.Grades.Add(grades);
            context.Classes.Add(classes);

            context.GradeClasses.Add(new GradeClass { Id = 1, GradeId = 1, ClassId = 2});

            context.Students.Add(new Student { Id = 1, FirstName = "Usama", LastName = "Jumaloon", Gender = "Male", DateOfBirth = new DateTime(1995, 11, 25), GradeClassId = 1 });
            context.Students.Add(new Student { Id = 2, FirstName = "Amjad", LastName = "Hussain", Gender = "Male", DateOfBirth = new DateTime(1995, 06, 23), GradeClassId = 1 });
            context.Students.Add(new Student { Id = 3, FirstName = "Thanzeel", LastName = "Jalaldeen", Gender = "Male", DateOfBirth = new DateTime(1995, 12, 18), GradeClassId = 1 });

            context.SaveChanges();
        }
    }
}
