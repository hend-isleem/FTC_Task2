using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.DTOs
{
    public class PostFlightDto
    {
        public string DepartureAddress { get; set; }
        public string DestinationAddress { get; set; }
        public float Length { get; set; }
        public int PlaneId { get; set; }
    }
}
