using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySchool.DAL;
using MySchool.DAL.Entities;
using MySchool.WEB.Common;
using System;

namespace MySchool.Tests.Unit_Tests.Classes
{
    public class ClassTestBase : IDisposable
    {
        protected readonly MySchoolDb context;

        public ClassTestBase()
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
            context.Classes.Add(new Class { Id = 1, Name = "A" });
            context.Classes.Add(new Class { Id = 2, Name = "B" });

            context.SaveChanges();
        }
    }
}
