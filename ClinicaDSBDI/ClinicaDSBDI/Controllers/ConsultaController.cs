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
    public class ConsultaController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public ConsultaController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var clinicaDSBDIContext = _context.ConsultaModel.Include(c => c.Animal).Include(c => c.Veterinario);
            return View(await clinicaDSBDIContext.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.ConsultaModel
                .Include(c => c.Animal)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.AnimalModel, "Id", "Id");
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioModel, "Id", "Id");
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VeterinarioId,AnimalId,DataDaConsulta,HoraDaConsulta")] ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.AnimalModel, "Id", "Id", consultaModel.AnimalId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioModel, "Id", "Id", consultaModel.VeterinarioId);
            return View(consultaModel);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.ConsultaModel.FindAsync(id);
            if (consultaModel == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.AnimalModel, "Id", "Id", consultaModel.AnimalId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioModel, "Id", "Id", consultaModel.VeterinarioId);
            return View(consultaModel);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VeterinarioId,AnimalId,DataDaConsulta,HoraDaConsulta")] ConsultaModel consultaModel)
        {
            if (id != consultaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaModelExists(consultaModel.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.AnimalModel, "Id", "Id", consultaModel.AnimalId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioModel, "Id", "Id", consultaModel.VeterinarioId);
            return View(consultaModel);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.ConsultaModel
                .Include(c => c.Animal)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaModel = await _context.ConsultaModel.FindAsync(id);
            _context.ConsultaModel.Remove(consultaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaModelExists(int id)
        {
            return _context.ConsultaModel.Any(e => e.Id == id);
        }
    }
}
