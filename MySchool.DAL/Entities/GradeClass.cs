using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.DAL.Entities
{
    public class GradeClass
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int GradeId { get; set; }
        public Class Classes { get; set; }
        public Grade Grades { get; set; }
    }
}
