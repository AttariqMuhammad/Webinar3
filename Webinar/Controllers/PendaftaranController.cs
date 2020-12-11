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
    public class PendaftaranController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PendaftaranController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pendaftaran
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PendaftaranModels.Include(p => p.PenggunaModel).Include(p => p.WebinarModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pendaftaran/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendaftaranModel = await _context.PendaftaranModels
                .Include(p => p.PenggunaModel)
                .Include(p => p.WebinarModel)
                .FirstOrDefaultAsync(m => m.PendaftaranModelID == id);
            if (pendaftaranModel == null)
            {
                return NotFound();
            }

            return View(pendaftaranModel);
        }

        // GET: Pendaftaran/Create
        public IActionResult Create()
        {
            ViewData["PenggunaModelID"] = new SelectList(_context.PenggunaModels, "PenggunaID", "NamaPanjang");
            ViewData["WebinarModelID"] = new SelectList(_context.WebinarModels, "WebinarModelID", "JudulWebinar");
            return View();
        }

        // POST: Pendaftaran/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PendaftaranModelID,PenggunaModelID,WebinarModelID")] PendaftaranModel pendaftaranModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pendaftaranModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PenggunaModelID"] = new SelectList(_context.PenggunaModels, "PenggunaID", "NamaPanjang", pendaftaranModel.PenggunaModelID);
            ViewData["WebinarModelID"] = new SelectList(_context.WebinarModels, "WebinarModelID", "JudulWebinar", pendaftaranModel.WebinarModelID);
            return View(pendaftaranModel);
        }

        // GET: Pendaftaran/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendaftaranModel = await _context.PendaftaranModels.FindAsync(id);
            if (pendaftaranModel == null)
            {
                return NotFound();
            }
            ViewData["PenggunaModelID"] = new SelectList(_context.PenggunaModels, "PenggunaID", "NamaPanjang", pendaftaranModel.PenggunaModelID);
            ViewData["WebinarModelID"] = new SelectList(_context.WebinarModels, "WebinarModelID", "JudulWebinar", pendaftaranModel.WebinarModelID);
            return View(pendaftaranModel);
        }

        // POST: Pendaftaran/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PendaftaranModelID,PenggunaModelID,WebinarModelID")] PendaftaranModel pendaftaranModel)
        {
            if (id != pendaftaranModel.PendaftaranModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pendaftaranModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PendaftaranModelExists(pendaftaranModel.PendaftaranModelID))
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
            ViewData["PenggunaModelID"] = new SelectList(_context.PenggunaModels, "PenggunaID", "PenggunaID", pendaftaranModel.PenggunaModelID);
            ViewData["WebinarModelID"] = new SelectList(_context.WebinarModels, "WebinarModelID", "JudulWebinar", pendaftaranModel.WebinarModelID);
            return View(pendaftaranModel);
        }

        // GET: Pendaftaran/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendaftaranModel = await _context.PendaftaranModels
                .Include(p => p.PenggunaModel)
                .Include(p => p.WebinarModel)
                .FirstOrDefaultAsync(m => m.PendaftaranModelID == id);
            if (pendaftaranModel == null)
            {
                return NotFound();
            }

            return View(pendaftaranModel);
        }

        // POST: Pendaftaran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pendaftaranModel = await _context.PendaftaranModels.FindAsync(id);
            _context.PendaftaranModels.Remove(pendaftaranModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PendaftaranModelExists(int id)
        {
            return _context.PendaftaranModels.Any(e => e.PendaftaranModelID == id);
        }
    }
}
