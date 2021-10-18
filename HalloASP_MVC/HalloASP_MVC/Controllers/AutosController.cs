using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HalloASP_MVC.Data;
using HalloASP_MVC.Models;

namespace HalloASP_MVC.Controllers
{
    public class AutosController : Controller
    {
        private readonly HalloASP_MVCContext _context;

        public AutosController(HalloASP_MVCContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: Autos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auto.ToListAsync());
        }

        // GET: Autos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Autos/Create
        public IActionResult Create()
        {
            return View(new Auto() { Hersteller = "NEU", Baujahr = DateTime.Now });
        }

        // POST: Autos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modell,Hersteller,PS,Gewicht,Baujahr")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auto);
        }

        // GET: Autos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modell,Hersteller,PS,Gewicht,Baujahr")] Auto auto)
        {
            if (id != auto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.Id))
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
            return View(auto);
        }

        // GET: Autos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto = await _context.Auto.FindAsync(id);
            _context.Auto.Remove(auto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
            return _context.Auto.Any(e => e.Id == id);
        }
    }
}
