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
    public class PassengerController : Controller
    {
        private ApplicationDbContext _DB;
        public PassengerController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPassengers()
        {
            var passengers = _DB.Passengers.Include(x => x.Tickets).ToList();
            List<PassengerViewModel> res = new List<PassengerViewModel>();
            foreach (Passenger s in passengers)
            {
                PassengerViewModel n = new PassengerViewModel();
                n.Name = s.Name;
                n.Address = s.Address;
                n.Phone = s.Phone;
                res.Add(n);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddPassenger([FromBody] PostPassengerDto t)
        {
            Passenger c = new Passenger();
            c.Name = t.Name;
            c.Address = t.Address;
            c.Phone = t.Phone;
            _DB.Passengers.Add(c);
            _DB.SaveChanges();
            return Ok("Passenger: " + c.Name + " has been added :)");
        }

        [HttpPut]
        public IActionResult UpdatePassenger(int id, [FromBody] PostPassengerDto passenger)
        {
            Passenger c = _DB.Passengers.SingleOrDefault(x => x.PassengerId == id);
            if (passenger.Name != "") c.Name = passenger.Name;
            if (passenger.Phone != "") c.Phone = passenger.Phone;
            if (passenger.Address != "") c.Address = passenger.Address;
            _DB.Passengers.Update(c);
            _DB.SaveChanges();
            return Ok("Passenger: " + c.Name + " has been updated :)");
        }

        [HttpDelete]
        public IActionResult DeletePassenger(int id)
        {
            Passenger c = _DB.Passengers.SingleOrDefault(x => x.PassengerId == id);
            string name = c.Name;
            _DB.Passengers.Remove(c);
            _DB.SaveChanges();
            return Ok("Passenger: " + name + " has been deleted :)");
        }
    }
}
