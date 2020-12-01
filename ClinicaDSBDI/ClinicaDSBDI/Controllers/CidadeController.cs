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
    public class CidadeController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public CidadeController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Cidade
        public async Task<IActionResult> Index()
        {
            var clinicaDSBDIContext = _context.CidadeModel.Include(c => c.Estado);
            return View(await clinicaDSBDIContext.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.CidadeModel
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidadeModel == null)
            {
                return NotFound();
            }

            return View(cidadeModel);
        }

        // GET: Cidade/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.EstadoModel, "Id", "Nome");
            return View();
        }

        // POST: Cidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CidadeId")] CidadeModel cidadeModel)
        {
            if (ModelState.IsValid)
            {
                cidadeModel.Nome = cidadeModel.Nome.ToUpper();
                _context.Add(cidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.EstadoModel, "Id", "Nome", cidadeModel.CidadeId);
            return View(cidadeModel);
        }

        // GET: Cidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.CidadeModel.FindAsync(id);
            if (cidadeModel == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.EstadoModel, "Id", "Nome", cidadeModel.CidadeId);
            return View(cidadeModel);
        }

        // POST: Cidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CidadeId")] CidadeModel cidadeModel)
        {
            if (id != cidadeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cidadeModel.Nome = cidadeModel.Nome.ToUpper();
                    _context.Update(cidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeModelExists(cidadeModel.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.EstadoModel, "Id", "Nome", cidadeModel.CidadeId);
            return View(cidadeModel);
        }

        // GET: Cidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.CidadeModel
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidadeModel == null)
            {
                return NotFound();
            }

            return View(cidadeModel);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidadeModel = await _context.CidadeModel.FindAsync(id);
            _context.CidadeModel.Remove(cidadeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeModelExists(int id)
        {
            return _context.CidadeModel.Any(e => e.Id == id);
        }
    }
}
