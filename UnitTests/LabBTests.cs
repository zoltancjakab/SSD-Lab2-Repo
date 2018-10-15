using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabOne.Services;
using LabOneB.Data;
using LabOneB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    
    public class LabBTests
    {
        private static DealershipContext _dealershipContext;
        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            var options = new DbContextOptionsBuilder<DealershipContext>()
                .UseInMemoryDatabase(databaseName: "SDD_DealershipTestDB2").Options;
            _dealershipContext = new DealershipContext(options);


            _dealershipContext.Dealerships.Add(new Dealership()
            {
                DealershipId = 0,
                Email = "Toyota@test.ca",
                Name = "Toyota",
                PhoneNumber = "9057874545"
            });
            _dealershipContext.SaveChanges();
        }
        [TestMethod]
        public void GetDealership()
        {
            var result = _dealershipContext.Dealerships.FirstOrDefault(x => x.DealershipId == 1);
            if(result == null)
                throw new AssertFailedException("Object with id of 1 does not exist.");
            Assert.AreEqual("Toyota", result.Name);
        }
        [TestMethod]
        public void CreateDealership()
        {
            try
            {
                _dealershipContext.Dealerships.Add(new Dealership()
                {
                    DealershipId = 2,
                    Email = "Hyundai@test.ca",
                    Name = "Hyundai",
                    PhoneNumber = "9889898989"
                });
                _dealershipContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new AssertFailedException(e.Message);
            }
            var result = _dealershipContext.Dealerships.FirstOrDefault(x => x.DealershipId == 2);
            if (result == null)
                throw new AssertFailedException("Object with id of 2 does not exist.");
            Assert.AreEqual("Hyundai", result.Name);
        }
        [TestMethod]
        public void EditDealership()
        {
            var result = _dealershipContext.Dealerships.FirstOrDefault(x => x.DealershipId == 1);
            if (result == null)
            {
                throw new AssertFailedException("Object with id of 1 does not exist.");
            }
            result.Name = "Volkswagen Dealership";
            _dealershipContext.SaveChanges();

            result = _dealershipContext.Dealerships.FirstOrDefault(x => x.DealershipId == 1);
            if (result == null)
            {
                throw new AssertFailedException("Object with id of 1 does not exist.");
            }
            Assert.AreEqual("Volkswagen Dealership", result.Name);
        }
    }
}
