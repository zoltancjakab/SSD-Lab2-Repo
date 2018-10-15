using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabOne;
using LabOne.Data;
using LabOne.Models;
using Microsoft.EntityFrameworkCore;
using LabOne.Services;

namespace UnitTests
{
    [TestClass]
    public class LabATests
    {
        private static IDealershipManager _dealershipManager;
        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            _dealershipManager = new DealershipMgr(true); //enable seeding.
        }

        [TestMethod]
        public void GetAllDealers()
        {
            var result = _dealershipManager.GetDealerships();

            if (result.Count <= 0)
                throw new AssertFailedException("Could not fetch all dealerships.");

            var dealer = result.Find(x=>x.DealershipId == 0);
            Assert.AreEqual(0, dealer.DealershipId);
            Assert.AreEqual("Toyota Dealership", dealer.Name);
        }
        [TestMethod]
        public void GetSingleDealer()
        {
            var result = _dealershipManager.GetDealership(1);
            Assert.AreEqual(1, result.DealershipId);
            Assert.AreEqual("Volkswagen Dealership", result.Name);
        }
        [TestMethod]
        public void UpdateSingleDealer()
        {
            var testName = "Mitsubishi Dealership";
            var testEmail = "Mitsu@Dealer.com";

            var result = _dealershipManager.GetDealership(1);
            result.Name = testName;
            result.Email = testEmail;
            _dealershipManager.UpdateDealership(1, result);


            result = _dealershipManager.GetDealership(1);
            Assert.AreEqual(1, result.DealershipId);
            Assert.AreEqual(testName, result.Name);
            Assert.AreEqual(testEmail, result.Email);
        }
        [TestMethod]
        public void DeleteSingleDealer()
        {
            _dealershipManager.DeleteDealership(1);
            var result = _dealershipManager.GetDealership(1);
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void CreateSingleDealer()
        {
            var testObject = new Dealership()
            {
                Name = "Chevy Dealer",
                Email = "Chevy@Dealer.ca",
                PhoneNumber = "905 888 7777"
            };

            _dealershipManager.CreateDealership(testObject);

            var result = _dealershipManager.GetDealerships().Find(x => x.Name == testObject.Name);
            if (result == null)
                throw new AssertFailedException("No object was created");


            Assert.AreEqual(testObject.Name, result.Name);
            Assert.AreEqual(testObject.Email, result.Email);
            Assert.AreEqual(testObject.PhoneNumber, result.PhoneNumber);
        }
        [TestMethod]
        public void CreateSingleDealer_Fail()
        {
            var testObject = new Dealership()
            {
                Name = "Honda Dealer",
                Email = null, //no email should fail.
                PhoneNumber = "905 888 7777"
            };

            _dealershipManager.CreateDealership(testObject);
            var result = _dealershipManager.GetDealerships().Find(x => x.Name == testObject.Name);
            Assert.AreEqual(null, result);
        }

        public void UpdateDealer_Fail()
        {
            var testObject = new Dealership()
            {
                Name = "Chevy Dealer",
                Email = "Chevy@Dealer.ca",
                PhoneNumber = "905 888 7777"
            };

            var result = _dealershipManager.GetDealerships().Find(x => x.Name == testObject.Name);
            result.Email = null;
            var success = _dealershipManager.UpdateDealership(result.DealershipId, result);
            Assert.AreEqual(false, success);
        }
    }
}
