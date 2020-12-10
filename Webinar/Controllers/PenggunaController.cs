using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webinar.Data;
using Webinar.Models;

namespace Webinar.Controllers
{
    public class PenggunaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PenggunaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pengguna
        public async Task<IActionResult> Index()
        {
            return View(await _context.PenggunaModels.ToListAsync());
        }

        // GET: Pengguna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggunaModel = await _context.PenggunaModels
                .FirstOrDefaultAsync(m => m.PenggunaID == id);
            if (penggunaModel == null)
            {
                return NotFound();
            }

            return View(penggunaModel);
        }

        // GET: Pengguna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pengguna/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PenggunaID,NamaDepan,NamaBelakang")] PenggunaModel penggunaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penggunaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penggunaModel);
        }

        // GET: Pengguna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggunaModel = await _context.PenggunaModels.FindAsync(id);
            if (penggunaModel == null)
            {
                return NotFound();
            }
            return View(penggunaModel);
        }

        // POST: Pengguna/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PenggunaID,NamaDepan,NamaBelakang")] PenggunaModel penggunaModel)
        {
            if (id != penggunaModel.PenggunaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penggunaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenggunaModelExists(penggunaModel.PenggunaID))
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
            return View(penggunaModel);
        }

        // GET: Pengguna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penggunaModel = await _context.PenggunaModels
                .FirstOrDefaultAsync(m => m.PenggunaID == id);
            if (penggunaModel == null)
            {
                return NotFound();
            }

            return View(penggunaModel);
        }

        // POST: Pengguna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penggunaModel = await _context.PenggunaModels.FindAsync(id);
            _context.PenggunaModels.Remove(penggunaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenggunaModelExists(int id)
        {
            return _context.PenggunaModels.Any(e => e.PenggunaID == id);
        }
    }
}
