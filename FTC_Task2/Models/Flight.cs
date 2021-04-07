using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string DepartureAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime FlightDate { get; set; }
        public float Length { get; set; }
        public List<Ticket> Tickets { get; set; }

        // [ForeignKey("Plane")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
    }
}
