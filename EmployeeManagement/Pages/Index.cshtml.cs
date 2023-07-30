using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using EmployeeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeDbContext _dbContext;

        public IndexModel(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public int EmployeeID { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.00")]
        public decimal Salary { get; set; }

        public List<Employee> Employees { get; set; }

        public void OnGet()
        {
            AddEmployee();
            Employees = _dbContext.Employees.ToList();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Employees = EmployeeList();

            int newEmployeeId = Employees.Max(e => e.EmployeeID) + 1;

            var newEmployee = new Employee
            {
                Name = Name,
                Email = Email,
                Salary = Salary
            };

            Employees.Add(newEmployee);

            return Content("Form submitted successfully.");
        }

        private List<Employee> EmployeeList()
        {
            return new List<Employee>
            {
                new Employee {  Name = "Harry", Email = "harry@example.com", Salary = 50000 },
                new Employee {  Name = "Ren", Email = "ren@example.com", Salary = 60000 },
                new Employee {  Name = "Choe", Email = "choe@example.com", Salary = 70000 },
                new Employee {  Name = "Neel", Email = "neel@example.com", Salary = 63000 },
                new Employee {  Name = "Sob", Email = "sob@example.com", Salary = 10000 }
            };
        }

        public void AddEmployee()
        {
            if (!_dbContext.Employees.Any())
            {
                Employees = EmployeeList();
                _dbContext.Employees.AddRange(Employees);
                _dbContext.SaveChanges();
            }
        }

    }
}