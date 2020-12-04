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
    public class ProprietarioController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public ProprietarioController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Proprietario
        public async Task<IActionResult> Index()
        {
            var clinicaDSBDIContext = _context.ProprietarioModel.Include(p => p.Cidade);
            return View(await clinicaDSBDIContext.ToListAsync());
        }

        // GET: Proprietario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietarioModel = await _context.ProprietarioModel
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proprietarioModel == null)
            {
                return NotFound();
            }

            return View(proprietarioModel);
        }

        // GET: Proprietario/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome");
            return View();
        }

        // POST: Proprietario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,Rua,CidadeId")] ProprietarioModel proprietarioModel)
        {
            if (ModelState.IsValid)
            {
                proprietarioModel.Nome = proprietarioModel.Nome.ToUpper();
                _context.Add(proprietarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome", proprietarioModel.CidadeId);
            return View(proprietarioModel);
        }

        // GET: Proprietario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietarioModel = await _context.ProprietarioModel.FindAsync(id);
            if (proprietarioModel == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome", proprietarioModel.CidadeId);
            return View(proprietarioModel);
        }

        // POST: Proprietario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,Rua,CidadeId")] ProprietarioModel proprietarioModel)
        {
            if (id != proprietarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    proprietarioModel.Nome = proprietarioModel.Nome.ToUpper();
                    _context.Update(proprietarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietarioModelExists(proprietarioModel.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.CidadeModel, "Id", "Nome", proprietarioModel.CidadeId);
            return View(proprietarioModel);
        }

        // GET: Proprietario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietarioModel = await _context.ProprietarioModel
                .Include(p => p.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proprietarioModel == null)
            {
                return NotFound();
            }

            return View(proprietarioModel);
        }

        // POST: Proprietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proprietarioModel = await _context.ProprietarioModel.FindAsync(id);
            _context.ProprietarioModel.Remove(proprietarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprietarioModelExists(int id)
        {
            return _context.ProprietarioModel.Any(e => e.Id == id);
        }
    }
}
