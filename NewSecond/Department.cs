using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSecond
{
    [Table("Department", Schema = "HR")] // To Set Name Table in Database, and Set Schema to HR 
    internal class Department
    {
        // Data Annotation, Fluent API

        public int ID { get; set; }
        [Required] // To Set it to not allow null
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }

        // The base to connect tables to each other is Navigation properties

        [InverseProperty("Dept")]
        public virtual ICollection<Employee> Employees { get; set; }
        [InverseProperty("SupervisedDept")]
        public virtual ICollection<Employee> Supervisors { get; set; }
        public virtual ICollection<Project> Projects { get; set; }


    }
}
