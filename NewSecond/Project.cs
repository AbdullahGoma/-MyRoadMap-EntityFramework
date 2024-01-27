using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSecond
{
    internal class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation property
        public virtual Department Department { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<WorksFor> WorksFors { get; set; }
    }
}
