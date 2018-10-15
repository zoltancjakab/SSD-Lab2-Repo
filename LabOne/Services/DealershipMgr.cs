using System;
using System.Collections.Generic;
using System.Linq;
using LabOne.Models;

namespace LabOne.Services
{
    public class DealershipMgr : IDealershipManager
    {
        private static List<Dealership> Dealerships { get; set; }
        public DealershipMgr()
        {
            //create the dealerships if a list does not exist.
            if (Dealerships == null)
                Dealerships = new List<Dealership>();
        }

        public DealershipMgr(bool seed) : this()
        {
            if (seed)
                SeedDealerships();
        }


        private void SeedDealerships()
        {
            Dealerships.Add(new Dealership()
            {
                DealershipId = 0,
                Name = "Toyota Dealership",
                Email = "Toyota@Dealership.com",
                PhoneNumber = "905 567 8979"
            });
            Dealerships.Add(new Dealership()
            {
                DealershipId = 1,
                Name = "Volkswagen Dealership",
                Email = "Volkswagen@Dealership.com",
                PhoneNumber = "905 666 6666"
            });
        }

        public bool CreateDealership(Dealership dealership)
        {
            try
            {
                dealership.DealershipId = GenerateId();
                if (dealership.Validate().SelectMany(x => x.ErrorMessage).Count() <= 0)
                    Dealerships.Add(dealership);
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool DeleteDealership(int id)
        {
            try
            {
                Dealerships.Remove(GetDealership(id));
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public Dealership GetDealership(int id)
        {
            return Dealerships.FirstOrDefault(x => x.DealershipId == id);
        }

        public List<Dealership> GetDealerships()
        {
            return Dealerships;
        }

        public bool UpdateDealership(int id, Dealership dealership)
        {
            if (dealership.DealershipId != id) return false;
            try
            {
                Dealerships.Remove(GetDealership(id));


                    
                return CreateDealership(dealership);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int GenerateId()
        {
            if (Dealerships.Count() <= 0) return 0;
            return Dealerships.Max(x => x.DealershipId) + 1;
        }
    }
}
