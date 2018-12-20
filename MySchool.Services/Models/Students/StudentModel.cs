using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Services.Models.Students
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int GradeClassId { get; set; }
    }
}
