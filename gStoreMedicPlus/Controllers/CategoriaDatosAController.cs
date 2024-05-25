using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gStoreMedicPlus.Models;

namespace gStoreMedicPlus.Controllers
{
    public class CategoriaDatosAController : Controller
    {
        private readonly DbGstoreMedicContext _context;

        public CategoriaDatosAController(DbGstoreMedicContext context)
        {
            _context = context;
        }

        // GET: CategoriaDatosA
        public async Task<IActionResult> Index()
        {
            var dbGstoreMedicContext = _context.TbCategoriaDatosAs.Include(t => t.TbUsuarios);
            //var dbGstoreMedicContext = _context.TbCategoriaDatosAs;
            return View(await dbGstoreMedicContext.ToListAsync());
        }

        // GET: CategoriaDatosA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbCategoriaDatosAs == null)
            {
                return NotFound();
            }

            var tbCategoriaDatosA = await _context.TbCategoriaDatosAs.Include(t => t.TbUsuarios).FirstOrDefaultAsync(m => m.Id == id);
            //var tbCategoriaDatosA = await _context.TbCategoriaDatosAs.FirstOrDefaultAsync(m => m.Id == id);
            if (tbCategoriaDatosA == null)
            {
                return NotFound();
            }

            return View(tbCategoriaDatosA);
        }

        // GET: CategoriaDatosA/Create
        public IActionResult Create()
        {
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id");
            return View();
        }

        // POST: CategoriaDatosA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaCreado,FechaModificado,TbUsuariosId")] TbCategoriaDatosA tbCategoriaDatosA)
        {
            if (ModelState.IsValid || !ModelState.IsValid)
            {
                _context.Add(tbCategoriaDatosA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbCategoriaDatosA.TbUsuariosId);
            return View(tbCategoriaDatosA);
        }

        // GET: CategoriaDatosA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbCategoriaDatosAs == null)
            {
                return NotFound();
            }

            var tbCategoriaDatosA = await _context.TbCategoriaDatosAs.FindAsync(id);
            if (tbCategoriaDatosA == null)
            {
                return NotFound();
            }
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbCategoriaDatosA.TbUsuariosId);
            return View(tbCategoriaDatosA);
        }

        // POST: CategoriaDatosA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaCreado,FechaModificado,TbUsuariosId")] TbCategoriaDatosA tbCategoriaDatosA)
        {
            if (id != tbCategoriaDatosA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCategoriaDatosA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCategoriaDatosAExists(tbCategoriaDatosA.Id))
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
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbCategoriaDatosA.TbUsuariosId);
            return View(tbCategoriaDatosA);
        }

        // GET: CategoriaDatosA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbCategoriaDatosAs == null)
            {
                return NotFound();
            }

            var tbCategoriaDatosA = await _context.TbCategoriaDatosAs
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCategoriaDatosA == null)
            {
                return NotFound();
            }

            return View(tbCategoriaDatosA);
        }

        // POST: CategoriaDatosA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbCategoriaDatosAs == null)
            {
                return Problem("Entity set 'DbGstoreMedicContext.TbCategoriaDatosAs'  is null.");
            }
            var tbCategoriaDatosA = await _context.TbCategoriaDatosAs.FindAsync(id);
            if (tbCategoriaDatosA != null)
            {
                _context.TbCategoriaDatosAs.Remove(tbCategoriaDatosA);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCategoriaDatosAExists(int id)
        {
          return _context.TbCategoriaDatosAs.Any(e => e.Id == id);
        }
    }
}
