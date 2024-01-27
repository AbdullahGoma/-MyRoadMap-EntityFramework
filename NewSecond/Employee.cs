using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSecond
{
    internal class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("FullName")]
        [Required, MaxLength(100)] 
        public string Name { get; set; }
        public double? Salary { get; set; } 
        public string Address { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }

        // The base to connect tables to each other is Navigation properties

        //[ForeignKey("Dept")]
        public int DepartmentID { get; set; }
        public int? SupervisedDepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Dept { get; set; } // In Run Time do Lazy Loading
        [ForeignKey("SupervisedDepartmentID")]
        public virtual Department SupervisedDept { get; set; }
        //public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorksFor> WorksFors { get; set; }



    }
}
