using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThird
{
    [Table("Branch")]
    internal class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Department> Departments { get; set; }    
    }
}
