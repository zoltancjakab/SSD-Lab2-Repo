using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabOneB.Models;
using Microsoft.AspNetCore.Identity;
using LabOneB.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace LabOneB.Controllers
{
    //I, Zoltan Jakab, 000373180, certify that this is my own work.No other person’s work was used without due acknowledgement and I have not made my work available to anyone else.
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private RoleManager<IdentityRole> _roleManager;

        private DealershipContext _context;

        public HomeController(UserManager<ApplicationUser> usermgr, RoleManager<IdentityRole> rolemgr, DealershipContext dbctx)
        {
            _userManager = usermgr;
            _roleManager = rolemgr;
            _context = dbctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> SeedDatabase()
        {

            ApplicationUser user1 = new ApplicationUser
            {
                UserName = "zoltan@employee.ca",
                FirstName = "Zoltan",
                LastName = "Jakab",
                BirthDate = new DateTime(1996, 3, 6),
                Company = "Mohawk",
                Email = "zoltan@employee.ca",
                Position = "Software Development Student",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            ApplicationUser user2 = new ApplicationUser
            {
                UserName = "john@manager.ca",
                FirstName = "John",
                LastName = "smith",
                BirthDate = new DateTime(1996, 3, 6),
                Company = "Mohawk",
                Email = "john@manager.ca",
                Position = "Software Development Student",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            IdentityResult result = await _userManager.CreateAsync(user1, "P@ssword1");
            //if (!result.Succeeded)
            //    return View("Error", new ErrorViewModel { RequestId = result.Errors.Select(x=>x.Description).Join("\n") });

            result = await _userManager.CreateAsync(user2, "P@ssword1");
            //if (!result.Succeeded)
            //    return View("Error", new ErrorViewModel { RequestId = result.Errors.Select(x => x.Description).Join("\n") });

            result = await _roleManager.CreateAsync(new IdentityRole("Employee"));
            //if (!result.Succeeded)
            //    return View("Error", new ErrorViewModel { RequestId = result.Errors.Select(x => x.Description).Join("\n") });

            result = await _roleManager.CreateAsync(new IdentityRole("Manager"));
            //if (!result.Succeeded)
            //    return View("Error", new ErrorViewModel { RequestId = result.Errors.Select(x => x.Description).Join("\n") });


            result = await _userManager.AddToRoleAsync(user1, "Employee");
            //if (!result.Succeeded)
            //    return View("Error", new ErrorViewModel { RequestId = result.Errors.Select(x => x.Description).Join("\n") });

            result = await _userManager.AddToRoleAsync(user2, "Manager");
            //if (!result.Succeeded)
            //    return View("Error", new ErrorViewModel { RequestId = result.Errors.Select(x => x.Description).Join("\n") });

            try
            {
                foreach (var car in SeedData.Cars)
                {
                    if (_context.Cars.FirstOrDefault(x => x.Id == car.Id) == null)
                    {
                        _context.Cars.Add(car);
                    }
                }
                _context.SaveChanges();
                foreach (var dealer in SeedData.Dealers)
                {
                    if (_context.Dealerships.FirstOrDefault(x => x.DealershipId == dealer.DealershipId) == null)
                    {
                        _context.Dealerships.Add(dealer);
                    }
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
