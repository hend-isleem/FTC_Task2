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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _DB;
        public EmployeeController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _DB.Employees.Include(x => x.Plane).Include(x => x.EmployeeType).ToList();
            List<EmployeeViewModel> res = new List<EmployeeViewModel>();
            foreach(Employee c in employees)
            {
                EmployeeViewModel n = new EmployeeViewModel();
                n.Name = c.Name;
                n.EmploymentDate = c.EmploymentDate;
                n.Phone = c.Phone;
                n.PlaneName = c.Plane.Name;
                n.EmployeeType = c.EmployeeType.Name;
                res.Add(n);
            }
            return Ok(res);
        }
        
        [HttpPost]
        public IActionResult AddEmployee([FromBody] PostEmployeeDto employee)
        {
            Employee c = new Employee();
            c.Name = employee.Name;
            c.Address = employee.Address;
            c.Salary = employee.Salary;
            c.Phone = employee.Phone;
            c.PlaneId = employee.PlaneId;
            c.EmployeeTypeId = employee.EmployeeTypeId;
            _DB.Employees.Add(c);
            _DB.SaveChanges();
            return Ok("Employee: " + c.Name + " has been added :)");
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int id, [FromBody] PostEmployeeDto employee)
        {
            Employee c = _DB.Employees.SingleOrDefault(x => x.EmployeeId == id);
            if(employee.Name != "") c.Name = employee.Name;
            if (employee.Salary != 0) c.Salary = employee.Salary;
            if (employee.Address != "") c.Address = employee.Address;
            if (employee.Phone != "") c.Phone = employee.Phone;
            if (employee.PlaneId != 0) c.PlaneId = employee.PlaneId;
            if (employee.EmployeeTypeId != 0) c.EmployeeTypeId = employee.EmployeeTypeId;
            _DB.Employees.Update(c);
            _DB.SaveChanges();
            return Ok("Employee: " + c.Name + " has been updated :)");
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            Employee c = _DB.Employees.SingleOrDefault(x => x.EmployeeId == id);
            string name = c.Name;
            _DB.Employees.Remove(c);
            _DB.SaveChanges();
            return Ok("Employee: " + name + " has been deleted :)");        
        }
    }
}
