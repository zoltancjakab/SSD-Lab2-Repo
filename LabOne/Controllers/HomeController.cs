using System.Diagnostics;
using System.Linq;
using LabOne.Data;
using LabOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabOne.Controllers
{
    public class HomeController : Controller
    {
        private DealershipContext _context;

        public HomeController(DealershipContext context)
        {
            this._context = context;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult SeedDatabase()
        {
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
                foreach (var member in SeedData.Members)
                {
                    if (_context.Members.FirstOrDefault(x => x.UserName == member.UserName) == null)
                    {
                        _context.Members.Add(member);
                    }
                }
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
