using FTC_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.ViewModels
{
    public class TicketViewModel
    {
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public PassengerViewModel Passenger { get; set; }
        public FlightViewModel Flight { get; set; }
    }
}
