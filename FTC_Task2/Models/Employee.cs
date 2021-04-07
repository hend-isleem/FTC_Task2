using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.Models
{

    // hend was here 
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime EmploymentDate { get; set; }
        public float Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // [ForeignKey("Plane")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        // [ForeignKey("EmployeeType")]
        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}
