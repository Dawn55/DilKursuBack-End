﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StudentLesson : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }

    }
}
