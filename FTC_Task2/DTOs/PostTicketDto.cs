using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.DTOs
{
    public class PostTicketDto
    {
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
    }
}
