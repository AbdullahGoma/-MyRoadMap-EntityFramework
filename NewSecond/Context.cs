using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSecond
{
    internal class Context : DbContext
    {
        // Send Conection String Here Not the best Choice
        public Context() : base(@"Data Source = ABDULLAH; Initial catalog = NewSecond; Integrated Security = true")
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
