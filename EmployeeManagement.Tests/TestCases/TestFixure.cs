using EmployeeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Tests.TestCases
{
    public class TestFixture : IDisposable
    {
        public EmployeeDbContext DbContext { get; private set; }

        public TestFixture()
        {
            // Set up your DbContext using an in-memory database for testing purposes
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            DbContext = new EmployeeDbContext(options);
        }

        public void Dispose()
        {
            // Clean up resources if needed
            DbContext.Dispose();
        }
    }

}
