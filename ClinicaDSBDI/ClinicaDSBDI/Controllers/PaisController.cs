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
    public class PaisController : Controller
    {
        private readonly ClinicaDSBDIContext _context;

        public PaisController(ClinicaDSBDIContext context)
        {
            _context = context;
        }

        // GET: Pais
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaisModel.ToListAsync());
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisModel = await _context.PaisModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paisModel == null)
            {
                return NotFound();
            }

            return View(paisModel);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] PaisModel paisModel)
        {
            if (ModelState.IsValid)
            {
                paisModel.Nome = paisModel.Nome.ToUpper();
                _context.Add(paisModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paisModel);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisModel = await _context.PaisModel.FindAsync(id);
            if (paisModel == null)
            {
                return NotFound();
            }
            return View(paisModel);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] PaisModel paisModel)
        {
            if (id != paisModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paisModel.Nome = paisModel.Nome.ToUpper();
                    _context.Update(paisModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisModelExists(paisModel.Id))
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
            return View(paisModel);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisModel = await _context.PaisModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paisModel == null)
            {
                return NotFound();
            }

            return View(paisModel);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paisModel = await _context.PaisModel.FindAsync(id);
            _context.PaisModel.Remove(paisModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisModelExists(int id)
        {
            return _context.PaisModel.Any(e => e.Id == id);
        }
    }
}
