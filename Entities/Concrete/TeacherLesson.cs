using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TeacherLesson : IEntity
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int LessonId { get; set; }

    }
}
