using FTC_Task2.Data;
using FTC_Task2.DTOs;
using FTC_Task2.Models;
using FTC_Task2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTC_Task2.Controllers
{
    public class FlightController : Controller
    {
        private ApplicationDbContext _DB;
        public FlightController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetFlights()
        {
            var deps = _DB.Flights.Include(x => x.Plane).Include(x => x.Tickets).ToList();
            List<FlightViewModel> res = new List<FlightViewModel>();
            foreach (Flight d in deps)
            {
                FlightViewModel n = new FlightViewModel();
                n.DepartureAddress = d.DepartureAddress;
                n.DestinationAddress = d.DestinationAddress;
                n.FlightDate = d.FlightDate;
                n.Length = d.Length;
                n.PlaneName = d.Plane.Name;
                res.Add(n);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] PostFlightDto t)
        {
            Flight c = new Flight();
            c.DepartureAddress = t.DepartureAddress;
            c.DestinationAddress = t.DestinationAddress;
            c.Length = t.Length;
            c.PlaneId = t.PlaneId;
            _DB.Flights.Add(c);
            _DB.SaveChanges();
            return Ok("Flight: " + c.FlightId + " has been added :)");
        }

        [HttpPut]
        public IActionResult UpdateFlight(int id, [FromBody] PostFlightDto flight)
        {
            Flight c = _DB.Flights.SingleOrDefault(x => x.FlightId == id);
            if (flight.DepartureAddress != "") c.DepartureAddress = flight.DepartureAddress;
            if (flight.DestinationAddress != "") c.DestinationAddress = flight.DestinationAddress;
            if (flight.Length <= 0) c.Length = flight.Length;
            if (flight.PlaneId != 0) c.PlaneId = flight.PlaneId;
            _DB.Flights.Update(c);
            _DB.SaveChanges();
            return Ok("Flight: " + c.FlightId + " has been updated :)");
        }

        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            Flight c = _DB.Flights.SingleOrDefault(x => x.FlightId == id);
            int FlightId = c.FlightId;
            _DB.Flights.Remove(c);
            _DB.SaveChanges();
            return Ok("Flight: " + FlightId + " has been deleted :)");
        }
    }
}
