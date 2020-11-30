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
    public class CidadeController : Controller
    {
        private readonly Clinica_DS_BDI_MVCContext _context;

        public CidadeController(Clinica_DS_BDI_MVCContext context)
        {
            _context = context;
        }

        // GET: Cidade
        public async Task<IActionResult> Index()
        {
            return View(await _context.CidadeModel.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.CidadeModel
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
                _context.Add(cidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
