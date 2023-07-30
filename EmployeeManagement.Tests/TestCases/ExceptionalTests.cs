using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;
using EmployeeManagement.Models;
using EmployeeManagement.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.DataAccess;

namespace EmployeeManagement.Tests.TestCases
{
    public class ExceptionalTests : IClassFixture<TestFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly EmployeeDbContext _dbContext;
        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output, TestFixture fixture)
        {
            _output = output;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task<bool> OnGet_ReturnsEmployeeData_IsNotNull()
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
                if (response !=null)
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
        public async Task<bool> OnGet_ReturnsEmployee_Count()
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
                if (response.Count==5)
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
        public async Task<bool> OnGet_ReturnsEmployeeData_IsNotEmpty()
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
                if (response.Count!=0)
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
        public async Task<bool> OnPost_WithValidData_AddsNewEmployee_IsNotNull()
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
                if (result !=null)
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
        public async Task<bool> OnPost_WithValidData_AddsNewEmployee_EmployeeIsNotNull()
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
                var employees = indexModel.Employees;
                //Assertion
                if (employees !=null)
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
        public async Task<bool> AddEmployee_ShouldNotReturnNull()
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
                if (_dbContext.Employees.ToList() != null)
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
