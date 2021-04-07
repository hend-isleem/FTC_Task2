using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }

        // [ForeignKey("Passenger")]
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        // [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
