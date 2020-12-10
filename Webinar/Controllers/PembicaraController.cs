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
    public class PembicaraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PembicaraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pembicara
        public async Task<IActionResult> Index()
        {
            return View(await _context.PembicaraModels.ToListAsync());
        }

        // GET: Pembicara/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembicaraModel = await _context.PembicaraModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pembicaraModel == null)
            {
                return NotFound();
            }

            return View(pembicaraModel);
        }

        // GET: Pembicara/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pembicara/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NamaDepan,NamaBelakang,Email,Kontak")] PembicaraModel pembicaraModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembicaraModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pembicaraModel);
        }

        // GET: Pembicara/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembicaraModel = await _context.PembicaraModels.FindAsync(id);
            if (pembicaraModel == null)
            {
                return NotFound();
            }
            return View(pembicaraModel);
        }

        // POST: Pembicara/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NamaDepan,NamaBelakang,Email,Kontak")] PembicaraModel pembicaraModel)
        {
            if (id != pembicaraModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembicaraModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembicaraModelExists(pembicaraModel.ID))
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
            return View(pembicaraModel);
        }

        // GET: Pembicara/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembicaraModel = await _context.PembicaraModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pembicaraModel == null)
            {
                return NotFound();
            }

            return View(pembicaraModel);
        }

        // POST: Pembicara/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembicaraModel = await _context.PembicaraModels.FindAsync(id);
            _context.PembicaraModels.Remove(pembicaraModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembicaraModelExists(int id)
        {
            return _context.PembicaraModels.Any(e => e.ID == id);
        }
    }
}
