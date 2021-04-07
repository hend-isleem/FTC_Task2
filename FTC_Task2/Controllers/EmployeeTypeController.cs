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
    public class EmployeeTypeController : Controller
    {
        private ApplicationDbContext _DB;
        public EmployeeTypeController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployeeTypes()
        {
            var employees = _DB.EmployeeTypes.ToList();
            List<EmployeeTypeViewModel> res = new List<EmployeeTypeViewModel>();
            foreach(EmployeeType c in employees)
            {
                EmployeeTypeViewModel n = new EmployeeTypeViewModel();
                n.Name = c.Name;
                res.Add(n);
            }
            return Ok(res);
        }
        
        [HttpPost]
        public IActionResult AddEmployeeType([FromBody] PostEmployeeTypeDto employee)
        {
            EmployeeType c = new EmployeeType();
            c.Name = employee.Name;
            _DB.EmployeeTypes.Add(c);
            _DB.SaveChanges();
            return Ok("EmployeeType: " + c.Name + " has been added :)");
        }

        [HttpPut]
        public IActionResult UpdateEmployeeType(int id, [FromBody] PostEmployeeTypeDto employee)
        {
            EmployeeType c = _DB.EmployeeTypes.SingleOrDefault(x => x.EmployeeTypeId == id);
            if(employee.Name != "") c.Name = employee.Name;
            _DB.EmployeeTypes.Update(c);
            _DB.SaveChanges();
            return Ok("EmployeeType: " + c.Name + " has been updated :)");
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeType(int id)
        {
            EmployeeType c = _DB.EmployeeTypes.SingleOrDefault(x => x.EmployeeTypeId == id);
            string name = c.Name;
            _DB.EmployeeTypes.Remove(c);
            _DB.SaveChanges();
            return Ok("EmployeeType: " + name + " has been deleted :)");        
        }
    }
}
