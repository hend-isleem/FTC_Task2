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
    public class PlaneController : Controller
    {
        private ApplicationDbContext _DB;
        public PlaneController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPlanes()
        {
            var Planes = _DB.Planes.Include(x => x.Employees).ThenInclude(x => x.EmployeeType).Include(x => x.Flights).ToList();
            List<PlaneViewModel> res = new List<PlaneViewModel>();
            foreach (Plane t in Planes)
            {
                PlaneViewModel nn = new PlaneViewModel();
                nn.Type = t.Type;
                nn.Name = t.Name;
                if (t.Flights != null)
                {
                    nn.Flights = new List<FlightViewModel>();
                    foreach (Flight d in t.Flights)
                    {
                        FlightViewModel n = new FlightViewModel();
                        n.DepartureAddress = d.DepartureAddress;
                        n.DestinationAddress = d.DestinationAddress;
                        n.FlightDate = d.FlightDate;
                        n.Length = d.Length;
                        n.PlaneName = d.Plane.Name;
                        nn.Flights.Add(n);
                    }
                }
                if (t.Employees != null)
                {
                    nn.Employees = new List<EmployeeViewModel>();
                    foreach (Employee c in t.Employees)
                    {
                        EmployeeViewModel n = new EmployeeViewModel();
                        n.Name = c.Name;
                        n.EmploymentDate = c.EmploymentDate;
                        n.Phone = c.Phone;
                        n.PlaneName = c.Plane.Name;
                        n.EmployeeType = c.EmployeeType.Name;
                        nn.Employees.Add(n);
                    }
                }
                res.Add(nn);
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddPlane([FromBody] PostPlaneDto sc)
        {
            Plane c = new Plane();
            c.Type = sc.Type;
            c.Name = sc.Name;
            _DB.Planes.Add(c);
            _DB.SaveChanges();
            return Ok("Plane: " + c.Name + " has been added :)");
        }

        [HttpPut]
        public IActionResult UpdatePlane(int id , [FromBody] PostPlaneDto plane)
        {
            Plane c = _DB.Planes.SingleOrDefault(x =>  x.PlaneId == id);
            if (plane.Type != "") c.Type = plane.Type;
            if (plane.Name != "") c.Name = plane.Name;
            _DB.Planes.Update(c);
            _DB.SaveChanges();
            return Ok("Plane: " + c.PlaneId + " has been updated :)");
        }

        [HttpDelete]
        public IActionResult DeletePlane(int id)
        {
            Plane c = _DB.Planes.SingleOrDefault(x => x.PlaneId == id);
            _DB.Planes.Remove(c);
            _DB.SaveChanges();
            return Ok("Plane has been deleted :)");
        }
    }
}
