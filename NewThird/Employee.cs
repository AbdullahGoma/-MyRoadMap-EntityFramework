using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThird
{
    internal class Employee
    {
        // By Convention
        public int ID { get; set; }
        //public int EmployeeID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        // By Convention it will be FK
        public  int DepartmentID { get; set; }
        public virtual Department Department { get; set; } // Navigation Property
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}
