﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string TeacherNumber { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserId { get; set; }

    }
}
