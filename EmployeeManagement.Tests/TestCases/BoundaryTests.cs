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
    public class BoundaryTests : IClassFixture<TestFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly EmployeeDbContext _dbContext;
        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output, TestFixture fixture)
        {
            _output = output;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task<bool> OnPost_WithMinimumAllowedValues_SubmitsFormSuccessfully()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext)
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 0.01m
            };


            //Action
            try
            {
                var result = indexModel.OnPost() as ContentResult;
                //Assertion
                if (result.Content == "Form submitted successfully.")
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
        public async Task<bool> OnPost_WithMinimumAllowedValues_ResultIsNotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext)
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 0.01m
            };


            //Action
            try
            {
                var result = indexModel.OnPost() as ContentResult;
                //Assertion
                if (result!=null)
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
        public async Task<bool> OnPost_WithMaximumAllowedValues_SubmitsFormSuccessfully()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext)
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Salary = decimal.MaxValue
            };


            //Action
            try
            {
                var result = indexModel.OnPost() as ContentResult;
                //Assertion
                if (result.Content == "Form submitted successfully.")
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
        public async Task<bool> OnPost_WithMaximumAllowedValues_ResultIsNotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var indexModel = new IndexModel(_dbContext)
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Salary = decimal.MaxValue
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
        public async Task<bool> AddEmployeeCount_ShouldNotBeZero()
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
                if (_dbContext.Employees.ToList().Count != 0)
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
