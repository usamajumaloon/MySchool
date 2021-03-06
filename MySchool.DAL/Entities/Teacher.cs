﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int GradeClassId { get; set; }
        public int SubjectId { get; set; }
        public GradeClass GradeClasses { get; set; }
        public Subject Subjects { get; set; }
        public bool IsDeleted { get; set; }
    }
}
