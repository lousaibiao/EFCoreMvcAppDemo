using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
