using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaDSBDI.Data;
using Clinica_DS_BDI_MVC.Models;

namespace ClinicaDSBDI.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public AnimalController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var clinicaDSBDIContext = _context.AnimalModel.Include(a => a.Especie).Include(a => a.Proprietario);
            return View(await clinicaDSBDIContext.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalModel = await _context.AnimalModel
                .Include(a => a.Especie)
                .Include(a => a.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalModel == null)
            {
                return NotFound();
            }

            return View(animalModel);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["EspecieId"] = new SelectList(_context.EspecieModel, "Id", "Nome");
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,ProprietarioId,EspecieId,Peso,Altura,Comprimento,Pedigree")] AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                animalModel.Nome = animalModel.Nome.ToUpper();
                //Convert.ToDecimal(animalModel.Altura);
                //Convert.ToDecimal(animalModel.Comprimento);
                //Convert.ToDecimal(animalModel.Peso);
                _context.Add(animalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecieId"] = new SelectList(_context.EspecieModel, "Id", "Nome", animalModel.EspecieId);
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome", animalModel.ProprietarioId);
            return View(animalModel);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalModel = await _context.AnimalModel.FindAsync(id);
            if (animalModel == null)
            {
                return NotFound();
            }
            ViewData["EspecieId"] = new SelectList(_context.EspecieModel, "Id", "Nome", animalModel.EspecieId);
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome", animalModel.ProprietarioId);
            return View(animalModel);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,ProprietarioId,EspecieId,Peso,Altura,Comprimento,Pedigree")] AnimalModel animalModel)
        {
            if (id != animalModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    animalModel.Nome = animalModel.Nome.ToUpper();
                    _context.Update(animalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalModelExists(animalModel.Id))
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
            ViewData["EspecieId"] = new SelectList(_context.EspecieModel, "Id", "Nome", animalModel.EspecieId);
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome", animalModel.ProprietarioId);
            return View(animalModel);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalModel = await _context.AnimalModel
                .Include(a => a.Especie)
                .Include(a => a.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalModel == null)
            {
                return NotFound();
            }

            return View(animalModel);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalModel = await _context.AnimalModel.FindAsync(id);
            _context.AnimalModel.Remove(animalModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalModelExists(int id)
        {
            return _context.AnimalModel.Any(e => e.Id == id);
        }
    }
}
