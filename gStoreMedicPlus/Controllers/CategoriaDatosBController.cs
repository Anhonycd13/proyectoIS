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
    public class CategoriaDatosBController : Controller
    {
        private readonly DbGstoreMedicContext _context;

        public CategoriaDatosBController(DbGstoreMedicContext context)
        {
            _context = context;
        }

        // GET: CategoriaDatosB
        public async Task<IActionResult> Index()
        {
            var dbGstoreMedicContext = _context.TbCategoriaDatosBs.Include(t => t.TbUsuarios);
            return View(await dbGstoreMedicContext.ToListAsync());
        }

        // GET: CategoriaDatosB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbCategoriaDatosBs == null)
            {
                return NotFound();
            }

            var tbCategoriaDatosB = await _context.TbCategoriaDatosBs
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCategoriaDatosB == null)
            {
                return NotFound();
            }

            return View(tbCategoriaDatosB);
        }

        // GET: CategoriaDatosB/Create
        public IActionResult Create()
        {
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id");
            return View();
        }

        // POST: CategoriaDatosB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaCreado,FechaModificado,TbUsuariosId")] TbCategoriaDatosB tbCategoriaDatosB)
        {
            if (ModelState.IsValid || !ModelState.IsValid)
            {
                _context.Add(tbCategoriaDatosB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbCategoriaDatosB.TbUsuariosId);
            return View(tbCategoriaDatosB);
        }

        // GET: CategoriaDatosB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbCategoriaDatosBs == null)
            {
                return NotFound();
            }

            var tbCategoriaDatosB = await _context.TbCategoriaDatosBs.FindAsync(id);
            if (tbCategoriaDatosB == null)
            {
                return NotFound();
            }
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbCategoriaDatosB.TbUsuariosId);
            return View(tbCategoriaDatosB);
        }

        // POST: CategoriaDatosB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaCreado,FechaModificado,TbUsuariosId")] TbCategoriaDatosB tbCategoriaDatosB)
        {
            if (id != tbCategoriaDatosB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCategoriaDatosB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCategoriaDatosBExists(tbCategoriaDatosB.Id))
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
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbCategoriaDatosB.TbUsuariosId);
            return View(tbCategoriaDatosB);
        }

        // GET: CategoriaDatosB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbCategoriaDatosBs == null)
            {
                return NotFound();
            }

            var tbCategoriaDatosB = await _context.TbCategoriaDatosBs
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCategoriaDatosB == null)
            {
                return NotFound();
            }

            return View(tbCategoriaDatosB);
        }

        // POST: CategoriaDatosB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbCategoriaDatosBs == null)
            {
                return Problem("Entity set 'DbGstoreMedicContext.TbCategoriaDatosBs'  is null.");
            }
            var tbCategoriaDatosB = await _context.TbCategoriaDatosBs.FindAsync(id);
            if (tbCategoriaDatosB != null)
            {
                _context.TbCategoriaDatosBs.Remove(tbCategoriaDatosB);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCategoriaDatosBExists(int id)
        {
          return _context.TbCategoriaDatosBs.Any(e => e.Id == id);
        }
    }
}
