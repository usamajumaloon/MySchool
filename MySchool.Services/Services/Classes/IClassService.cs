using MySchool.Services.Models.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Services.Services.Classes
{
    public interface IClassService
    {
        IEnumerable<ClassModel> GetClass();
        ClassModel GetClassById(int Id);
        void AddClass(ClassCreateModel input);
        void UpdateClass(ClassUpdateModel input);
        void DeleteClass(int Id);
    }
}
