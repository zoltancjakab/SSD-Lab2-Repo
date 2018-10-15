using System;
using System.Collections.Generic;
using LabOne.Models;

namespace LabOne.Data
{
    public static class SeedData
    {
        public static List<Car> Cars => new List<Car>
        {
            new Car
            {
                Id=0,
                Make="Toyota",
                Model="Camry",
                Color="Red",
                Year=2015,
                VIN="123-456-5252"
            },
            new Car
            {
                Id=0,
                Make="Volkswagen",
                Model="Beetle",
                Color="Purple",
                Year=2011,
                VIN="123-456-7894"
            }
        };


        public static List<Member> Members => new List<Member>
        {
            new Member
            {
                UserName = "jakab.zoltan",
                FirstName = "Zoltan",
                LastName="Jakab",
                BirthDate=new DateTime(1996,3,6),
                Comapny="Mohawk",
                Email="Zoltan.jakab1@mohawkcollege.ca",
                Position = "Software Development Student"
            }
        };
    }
}
