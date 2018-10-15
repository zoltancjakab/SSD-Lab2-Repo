using System;
using System.Collections.Generic;
using LabOneB.Models;
using Microsoft.AspNetCore.Identity;

namespace LabOneB.Data
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

        public static List<Dealership> Dealers => new List<Dealership>
        {
            new Dealership
            {
                DealershipId = 0,
                Name= "Toyota Dealership",
                Email="Toyota@toyota.ca",
                 PhoneNumber="905 777 8888"
            },
            new Dealership
            {
                DealershipId = 1,
                Name= "Hyundai Dealership",
                Email="Hyundai@hyundai.ca",
                PhoneNumber="905 666 5555"
            },
        };



        public static List<ApplicationUser> Members => new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id= "7782b9c2-0928-4620-9e39-06ad013a125b",
                UserName = "john@manager.ca",
                FirstName = "Zoltan",
                LastName="Jakab",
                BirthDate=new DateTime(1996,3,6),
                Company="Mohawk",
                Email="zoltan@employee.ca",
                Position = "Software Development Student",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser
            {
                Id= "7782b9c2-0928-4620-9e39-06ad013a125u",
                UserName = "john@manager.ca",
                FirstName = "John",
                LastName="smith",
                BirthDate=new DateTime(1996,3,6),
                Company="Mohawk",
                Email="john@manager.ca",
                Position = "Software Development Student",
                SecurityStamp = Guid.NewGuid().ToString()
            }
        };

        public static List<IdentityRole> Roles => new List<IdentityRole>
        {
            new IdentityRole
            {
                Id="Employee",
                Name="Employee",
            },
            new IdentityRole
            {
                Id="Manager",
                Name="Manager",
            }
        };

    }
}
