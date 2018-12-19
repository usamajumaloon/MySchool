using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.DAL.Entities
{
    public class SubjectGrade
    {
        public int Id { get; set; }
        public Subject Subjects { get; set; }
        public Grade Grades { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
    }
}
