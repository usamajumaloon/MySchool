﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.DAL.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
