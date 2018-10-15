using LabOneA.Models;
using LabOneA.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabOneA.Controllers
{
    public class DealershipsController : Controller
    {
        private readonly IDealershipManager _dealershipsManager;

        public DealershipsController(IDealershipManager dealershipsManager)
        {
            _dealershipsManager = dealershipsManager;
        }

        // GET: Dealerships
        public IActionResult Index()
        {
            return View(_dealershipsManager.GetDealerships());
        }

        // GET: Dealerships/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = _dealershipsManager.GetDealership((int)id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // GET: Dealerships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealerships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DealershipID,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                _dealershipsManager.CreateDealership(dealership);
                return RedirectToAction(nameof(Index));
            }
            return View(dealership);
        }

        // GET: Dealerships/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = _dealershipsManager.GetDealership((int)id);
            if (dealership == null)
            {
                return NotFound();
            }
            return View(dealership);
        }

        // POST: Dealerships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DealershipID,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (id != dealership.DealershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dealershipsManager.UpdateDealership(id, dealership);

                return RedirectToAction(nameof(Index));
            }
            return View(dealership);
        }

        // GET: Dealerships/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership =  _dealershipsManager.GetDealership((int)id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // POST: Dealerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dealership = _dealershipsManager.DeleteDealership(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DealershipExists(int id)
        {
            return _dealershipsManager.GetDealership(id) != null;
        }
    }
}
