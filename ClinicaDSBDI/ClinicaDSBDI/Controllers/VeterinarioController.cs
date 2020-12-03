using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaDSBDI.Data;
using ClinicaDSBDI.Models;

namespace ClinicaDSBDI.Controllers
{
    public class VeterinarioController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public VeterinarioController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Veterinario
        public async Task<IActionResult> Index()
        {
            var clinicaDSBDIContext = _context.VeterinarioModel.Include(v => v.Hospital);
            return View(await clinicaDSBDIContext.ToListAsync());
        }

        // GET: Veterinario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioModel = await _context.VeterinarioModel
                .Include(v => v.Hospital)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarioModel == null)
            {
                return NotFound();
            }

            return View(veterinarioModel);
        }

        // GET: Veterinario/Create
        public IActionResult Create()
        {
            ViewData["HospitalId"] = new SelectList(_context.HospitalModel, "Id", "Nome");
            return View();
        }

        // POST: Veterinario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HospitalId,Nome,CRV")] VeterinarioModel veterinarioModel)
        {
            if (ModelState.IsValid)
            {
                veterinarioModel.Nome = veterinarioModel.Nome.ToUpper();
                _context.Add(veterinarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospitalId"] = new SelectList(_context.HospitalModel, "Id", "Nome", veterinarioModel.HospitalId);
            return View(veterinarioModel);
        }

        // GET: Veterinario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioModel = await _context.VeterinarioModel.FindAsync(id);
            if (veterinarioModel == null)
            {
                return NotFound();
            }
            ViewData["HospitalId"] = new SelectList(_context.HospitalModel, "Id", "Nome", veterinarioModel.HospitalId);
            return View(veterinarioModel);
        }

        // POST: Veterinario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HospitalId,Nome,CRV")] VeterinarioModel veterinarioModel)
        {
            if (id != veterinarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    veterinarioModel.Nome = veterinarioModel.Nome.ToUpper();
                    _context.Update(veterinarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinarioModelExists(veterinarioModel.Id))
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
            ViewData["HospitalId"] = new SelectList(_context.HospitalModel, "Id", "Nome", veterinarioModel.HospitalId);
            return View(veterinarioModel);
        }

        // GET: Veterinario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarioModel = await _context.VeterinarioModel
                .Include(v => v.Hospital)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarioModel == null)
            {
                return NotFound();
            }

            return View(veterinarioModel);
        }

        // POST: Veterinario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinarioModel = await _context.VeterinarioModel.FindAsync(id);
            _context.VeterinarioModel.Remove(veterinarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarioModelExists(int id)
        {
            return _context.VeterinarioModel.Any(e => e.Id == id);
        }
    }
}
