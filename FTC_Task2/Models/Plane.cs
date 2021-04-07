using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.Models
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
