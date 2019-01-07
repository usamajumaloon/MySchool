using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySchool.DAL;
using MySchool.DAL.Entities;
using MySchool.WEB.Common;
using System;

namespace MySchool.Tests.Unit_Tests.Grades
{
    public class GradeTestBase: IDisposable
    {
        protected readonly MySchoolDb context;

        public GradeTestBase()
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
            context.Grades.Add(new Grade { Id = 1, Name = "11" });
            context.Grades.Add(new Grade { Id = 2, Name = "12" });

            context.SaveChanges();
        }
    }
}
