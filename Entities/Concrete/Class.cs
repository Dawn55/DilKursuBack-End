using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Class : IEntity
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Letter { get; set; }
    }
}
