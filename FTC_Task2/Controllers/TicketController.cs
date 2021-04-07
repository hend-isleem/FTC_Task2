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
    public class TicketController : Controller
    {
        private ApplicationDbContext _DB;
        public TicketController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            var Tickets = _DB.Tickets.Include(x => x.Flight).Include(x => x.Passenger).ToList();
            List<TicketViewModel> res = new List<TicketViewModel>();
            foreach (Ticket t in Tickets)
            {
                TicketViewModel nn = new TicketViewModel();
                nn.OrderDate = t.OrderDate;
                nn.Price = t.Price;
                FlightViewModel n = new FlightViewModel();
                Flight d = t.Flight;
                n.DepartureAddress = d.DepartureAddress;
                n.DestinationAddress = d.DestinationAddress;
                n.FlightDate = d.FlightDate;
                n.Length = d.Length;
                n.PlaneName = d.Plane.Name;
                nn.Flight = n;
                PassengerViewModel p = new PassengerViewModel();
                Passenger s = t.Passenger;
                p.Name = s.Name;
                p.Address = s.Address;
                p.Phone = s.Phone;
                nn.Passenger = p;
                res.Add(nn);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddTicket([FromBody] PostTicketDto t)
        {
            Ticket c = new Ticket();
            c.OrderDate = t.OrderDate;
            c.Price = t.Price;
            c.PassengerId = t.PassengerId;
            c.FlightId = t.FlightId;
            _DB.Tickets.Add(c);
            _DB.SaveChanges();
            return Ok("Ticket: " + c.TicketId + " has been added :)");
        }

        [HttpPut]
        public IActionResult UpdateTicket(int id, [FromBody] PostTicketDto ticket)
        {
            Ticket c = _DB.Tickets.SingleOrDefault(x => x.TicketId == id);
            if (ticket.OrderDate != null) c.OrderDate = ticket.OrderDate;
            if (ticket.Price <= 0) c.Price = ticket.Price;
            if (ticket.PassengerId != 0) c.PassengerId = ticket.PassengerId;
            if (ticket.FlightId != 0) c.FlightId = ticket.FlightId;
            _DB.Tickets.Update(c);
            _DB.SaveChanges();
            return Ok("Ticket: " + id + " has been updated :)");
        }

        [HttpDelete]
        public IActionResult DeleteTicket(int id)
        {
            Ticket c = _DB.Tickets.SingleOrDefault(x => x.TicketId == id);
            int tid = c.TicketId;
            _DB.Tickets.Remove(c);
            _DB.SaveChanges();
            return Ok("Ticket: " + tid + " has been deleted :)");
        }
    }
}
