using EmployeeManagement.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Xunit;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeManagement.DataAccess;

namespace EmployeeManagement.Tests.TestCases
{
    public class FunctionalTests : IClassFixture<TestFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly EmployeeDbContext _dbContext;
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output, TestFixture fixture)
        {
            _output = output;
            _dbContext = fixture.DbContext;
        }


        [Fact]
        public async Task<bool> OnGet_ReturnsEmployeeData()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext);


            //Action
            try
            {
                indexModel.OnGet();
                var response = indexModel.Employees;
                //Assertion
                if (response is List<Employee>)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> OnPost_WithValidData_AddsNewEmployee()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext)
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 50000
            };

            //Action
            try
            {
                var result = indexModel.OnPost() as ContentResult;
                //Assertion
                if (result.Content== "Form submitted successfully.")
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> OnPost_WithInvalidData_ReturnsPagee()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext);
            indexModel.ModelState.AddModelError("Name", "Name is required.");


            //Action
            try
            {
                var result = indexModel.OnPost();
                //Assertion
                if (result is PageResult)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> AddEmployee_ShouldAddEmployeeToDatabase()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext);
           

            //Action
            try
            {
                indexModel.AddEmployee();
                //Assertion
                if (_dbContext.Employees.ToList().Count!=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}


