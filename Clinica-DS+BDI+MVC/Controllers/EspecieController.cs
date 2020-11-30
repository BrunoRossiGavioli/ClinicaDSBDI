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
    public class EspecieController : Controller
    {
        private readonly Clinica_DS_BDI_MVCContext _context;

        public EspecieController(Clinica_DS_BDI_MVCContext context)
        {
            _context = context;
        }

        // GET: Especie
        public async Task<IActionResult> Index()
        {
            return View(await _context.EspecieModel.ToListAsync());
        }

        // GET: Especie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especieModel = await _context.EspecieModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especieModel == null)
            {
                return NotFound();
            }

            return View(especieModel);
        }

        // GET: Especie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] EspecieModel especieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especieModel);
        }

        // GET: Especie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especieModel = await _context.EspecieModel.FindAsync(id);
            if (especieModel == null)
            {
                return NotFound();
            }
            return View(especieModel);
        }

        // POST: Especie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] EspecieModel especieModel)
        {
            if (id != especieModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieModelExists(especieModel.Id))
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
            return View(especieModel);
        }

        // GET: Especie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especieModel = await _context.EspecieModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especieModel == null)
            {
                return NotFound();
            }

            return View(especieModel);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especieModel = await _context.EspecieModel.FindAsync(id);
            _context.EspecieModel.Remove(especieModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecieModelExists(int id)
        {
            return _context.EspecieModel.Any(e => e.Id == id);
        }
    }
}
