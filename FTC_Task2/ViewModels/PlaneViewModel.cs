using FTC_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.ViewModels
{
    public class PlaneViewModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<FlightViewModel> Flights { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

    }
}
