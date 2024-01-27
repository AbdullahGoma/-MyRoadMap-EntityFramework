using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewThird
{
    internal class Attendance
    {
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }

    }
}

