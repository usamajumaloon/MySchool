using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySchool.DAL;
using MySchool.DAL.Entities;
using MySchool.WEB.Common;
using System;

namespace MySchool.Tests.Unit_Tests.Subjects
{
    public class SubjectTestBase
    {
        protected readonly MySchoolDb context;

        public SubjectTestBase()
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
            context.Subjects.Add(new Subject { Id = 1, Name = "Biology" });
            context.Subjects.Add(new Subject { Id = 2, Name = "Chemistry" });

            context.SaveChanges();
        }
    }
}
