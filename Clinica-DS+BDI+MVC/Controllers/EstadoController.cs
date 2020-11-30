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
    public class EstadoController : Controller
    {
        private readonly Clinica_DS_BDI_MVCContext _context;

        public EstadoController(Clinica_DS_BDI_MVCContext context)
        {
            _context = context;
        }

        // GET: Estado
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoModel.ToListAsync());
        }

        // GET: Estado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoModel = await _context.EstadoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoModel == null)
            {
                return NotFound();
            }

            return View(estadoModel);
        }

        // GET: Estado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,PaisId")] EstadoModel estadoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoModel);
        }

        // GET: Estado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoModel = await _context.EstadoModel.FindAsync(id);
            if (estadoModel == null)
            {
                return NotFound();
            }
            return View(estadoModel);
        }

        // POST: Estado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,PaisId")] EstadoModel estadoModel)
        {
            if (id != estadoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoModelExists(estadoModel.Id))
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
            return View(estadoModel);
        }

        // GET: Estado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoModel = await _context.EstadoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoModel == null)
            {
                return NotFound();
            }

            return View(estadoModel);
        }

        // POST: Estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoModel = await _context.EstadoModel.FindAsync(id);
            _context.EstadoModel.Remove(estadoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoModelExists(int id)
        {
            return _context.EstadoModel.Any(e => e.Id == id);
        }
    }
}
