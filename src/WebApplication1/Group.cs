using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Group
    {
        public Group()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
