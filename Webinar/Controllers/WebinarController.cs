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
    public class WebinarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebinarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Webinar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WebinarModels.Include(w => w.PembicaraModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Webinar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webinarModel = await _context.WebinarModels
                .Include(w => w.PembicaraModel)
                .FirstOrDefaultAsync(m => m.WebinarModelID == id);
            if (webinarModel == null)
            {
                return NotFound();
            }

            return View(webinarModel);
        }

        // GET: Webinar/Create
        public IActionResult Create()
        {
            ViewData["PembicaraModelID"] = new SelectList(_context.PembicaraModels, "ID", "NamaBelakang");
            return View();
        }

        // POST: Webinar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WebinarModelID,JudulWebinar,Deskripsi,Tanggal,Platform,GambarUrl,PembicaraModelID")] WebinarModel webinarModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webinarModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PembicaraModelID"] = new SelectList(_context.PembicaraModels, "ID", "NamaBelakang", webinarModel.PembicaraModelID);
            return View(webinarModel);
        }

        // GET: Webinar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webinarModel = await _context.WebinarModels.FindAsync(id);
            if (webinarModel == null)
            {
                return NotFound();
            }
            ViewData["PembicaraModelID"] = new SelectList(_context.PembicaraModels, "ID", "NamaBelakang", webinarModel.PembicaraModelID);
            return View(webinarModel);
        }

        // POST: Webinar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WebinarModelID,JudulWebinar,Deskripsi,Tanggal,Platform,GambarUrl,PembicaraModelID")] WebinarModel webinarModel)
        {
            if (id != webinarModel.WebinarModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webinarModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebinarModelExists(webinarModel.WebinarModelID))
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
            ViewData["PembicaraModelID"] = new SelectList(_context.PembicaraModels, "ID", "NamaBelakang", webinarModel.PembicaraModelID);
            return View(webinarModel);
        }

        // GET: Webinar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webinarModel = await _context.WebinarModels
                .Include(w => w.PembicaraModel)
                .FirstOrDefaultAsync(m => m.WebinarModelID == id);
            if (webinarModel == null)
            {
                return NotFound();
            }

            return View(webinarModel);
        }

        // POST: Webinar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webinarModel = await _context.WebinarModels.FindAsync(id);
            _context.WebinarModels.Remove(webinarModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebinarModelExists(int id)
        {
            return _context.WebinarModels.Any(e => e.WebinarModelID == id);
        }
    }
}
