
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Xunit;
using CoreExample;




namespace UnitTestApp.Tests
{
    public class ConnectionTest
    {

        [Fact]
        public void TestConnection()
        {
            Assert.Equal(0, CoreExample.Program.Connection());
        }

    }

    public class CRUDTests
    {
        [Fact]
        public void DeleteTesterTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0, CoreExample.Program.DeleteTester(options, 12));
        }

        [Fact]
        public void InsertTesterTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0, CoreExample.Program.InsertTester(options, "KarpovSS"));
        }

        [Fact]
        public void UpdateTesterTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0, CoreExample.Program.UpdateTester(options, 11, "Tom Hiddle"));
        }

       
    }
}
