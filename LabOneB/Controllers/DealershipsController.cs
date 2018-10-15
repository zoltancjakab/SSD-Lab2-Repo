using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabOneB.Data;
using LabOneB.Models;
using Microsoft.AspNetCore.Authorization;

namespace LabOneB.Controllers
{

    //I, Zoltan Jakab, 000373180, certify that this is my own work.No other person’s work was used without due acknowledgement and I have not made my work available to anyone else.
    [Authorize(Roles = "Employee,Manager")]
    public class DealershipsController : Controller
    {
        private readonly DealershipContext _context;

        public DealershipsController(DealershipContext context)
        {
            _context = context;
        }

        // GET: Dealerships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dealerships.ToListAsync());
        }

        // GET: Dealerships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships
                .SingleOrDefaultAsync(m => m.DealershipId == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }
        [Authorize(Roles = "Manager")]
        // GET: Dealerships/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        // POST: Dealerships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DealershipId,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dealership);
        }
        [Authorize(Roles = "Manager")]
        // GET: Dealerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships.SingleOrDefaultAsync(m => m.DealershipId == id);
            if (dealership == null)
            {
                return NotFound();
            }
            return View(dealership);
        }
        [Authorize(Roles = "Manager")]
        // POST: Dealerships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DealershipId,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (id != dealership.DealershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealershipExists(dealership.DealershipId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dealership);
        }
        [Authorize(Roles = "Manager")]
        // GET: Dealerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealerships
                .SingleOrDefaultAsync(m => m.DealershipId == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }
        [Authorize(Roles = "Manager")]
        // POST: Dealerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealership = await _context.Dealerships.SingleOrDefaultAsync(m => m.DealershipId == id);
            _context.Dealerships.Remove(dealership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealershipExists(int id)
        {
            return _context.Dealerships.Any(e => e.DealershipId == id);
        }
    }
}
