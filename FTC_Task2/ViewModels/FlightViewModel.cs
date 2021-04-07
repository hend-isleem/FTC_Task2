using FTC_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.ViewModels
{
    public class FlightViewModel
    {
        public string DepartureAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime FlightDate { get; set; }
        public float Length { get; set; }
        public string PlaneName { get; set; }
    }
}
