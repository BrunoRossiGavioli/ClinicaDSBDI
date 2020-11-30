using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica_DS_BDI_MVC.Data;
using Clinica_DS_BDI_MVC.Models;

namespace Clinica_DS_BDI_MVC.Controllers
{
    public class PaisController : Controller
    {
        private readonly Clinica_DS_BDI_MVCContext _context;

        public PaisController(Clinica_DS_BDI_MVCContext context)
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
