using Microsoft.AspNetCore.Mvc;
using Bantucan_ITELEC1C.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bantucan_ITELEC1C.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> EmployeeList = new List<Employee>
        {
            new Employee()
            {
                Id = 1, FirstName = "Khun", LastName = "Aguerro", Birthday = DateTime.Parse("1990-07-19"),
                Email = "khunaguerro@gmail.com", SalaryPerHour = 20.00M, IsTenured = true
            },
            new Employee()
            {
                Id = 2, FirstName = "Yu", LastName = "Haibara", Birthday = DateTime.Parse("2003-08-20"),
                Email = "yuhaibara@example.com", SalaryPerHour = 18.50M, IsTenured = true
            },
            new Employee()
            {
                Id = 3, FirstName = "Ace", LastName = "Portgas", Birthday = DateTime.Parse("1992-12-31"),
                Email = "portgasdace@gmail.com", SalaryPerHour = 22.00M, IsTenured = false
            },
            new Employee()
            {
                Id = 4, FirstName = "Kuro", LastName = "Sensei", Birthday = DateTime.Parse("1990-01-12"),
                Email = "kurosensei@yahoo.com", SalaryPerHour = 25.00M, IsTenured = false
            }
        };

        public IActionResult Index()
        {
            foreach (var employee in EmployeeList)
            {
                DateTime today = DateTime.Today;
                employee.Age = today.Year - employee.Birthday.Year;
                if (today < employee.Birthday.AddYears(employee.Age))
                {
                    employee.Age--;
                }

                string[] emailParts = employee.Email.Split('@');
                if (emailParts.Length == 2)
                {
                    employee.UserName = emailParts[0];
                    employee.DomainName = emailParts[1];
                }
            }

            return View(EmployeeList);
        }

        public IActionResult ShowDetail(int id)
        {
            // Search for the employee whose id matches the given id
            Employee? employee = EmployeeList.FirstOrDefault(emp => emp.Id == id);

            if (employee != null) // Was an employee found?
                return View(employee);

            return NotFound();
        }
    }
}
