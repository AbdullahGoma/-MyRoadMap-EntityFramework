using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThird
{
    internal class Department
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}
