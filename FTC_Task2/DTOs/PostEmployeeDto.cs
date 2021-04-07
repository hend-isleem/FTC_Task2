using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.DTOs
{
    public class PostEmployeeDto
    {
        public string Name { get; set; }
        //public DateTime EmploymentDate { get; set; }
        public float Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int PlaneId { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
