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
    public class HospitalController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public HospitalController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Hospital
        public async Task<IActionResult> Index()
        {
            var clinicaDSBDIContext = _context.HospitalModel.Include(h => h.Cidade);
            return View(await clinicaDSBDIContext.ToListAsync());
        }

        // GET: Hospital/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalModel = await _context.HospitalModel
                .Include(h => h.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalModel == null)
            {
                return NotFound();
            }

            return View(hospitalModel);
        }

        // GET: Hospital/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome");
            return View();
        }

        // POST: Hospital/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CidadeId")] HospitalModel hospitalModel)
        {
            if (ModelState.IsValid)
            {
                hospitalModel.Nome = hospitalModel.Nome.ToUpper();
                _context.Add(hospitalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome", hospitalModel.CidadeId);
            return View(hospitalModel);
        }

        // GET: Hospital/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalModel = await _context.HospitalModel.FindAsync(id);
            if (hospitalModel == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome", hospitalModel.CidadeId);
            return View(hospitalModel);
        }

        // POST: Hospital/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CidadeId")] HospitalModel hospitalModel)
        {
            if (id != hospitalModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hospitalModel.Nome = hospitalModel.Nome.ToUpper();
                    _context.Update(hospitalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalModelExists(hospitalModel.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome", hospitalModel.CidadeId);
            return View(hospitalModel);
        }

        // GET: Hospital/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalModel = await _context.HospitalModel
                .Include(h => h.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospitalModel == null)
            {
                return NotFound();
            }

            return View(hospitalModel);
        }

        // POST: Hospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospitalModel = await _context.HospitalModel.FindAsync(id);
            _context.HospitalModel.Remove(hospitalModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalModelExists(int id)
        {
            return _context.HospitalModel.Any(e => e.Id == id);
        }
    }
}
