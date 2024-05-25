using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gStoreMedicPlus.Models;
using gStoreMedicPlus.Clases;

namespace gStoreMedicPlus.Controllers
{
    public class DatosController : Controller
    {
        private readonly DbGstoreMedicContext _context;

        public DatosController(DbGstoreMedicContext context)
        {
            _context = context;
        }

        // GET: Datos
        public async Task<IActionResult> Index()
        {
            var dbGstoreMedicContext = _context.TbDatos.Include(t => t.TbCategoriaDatosA).Include(t => t.TbCategoriaDatosB).Include(t => t.TbConsultas).Include(t => t.TbPersonas);
            return View(await dbGstoreMedicContext.ToListAsync());
        }

        // GET: Datos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbDatos == null)
            {
                return NotFound();
            }

            var tbDato = await _context.TbDatos
                .Include(t => t.TbCategoriaDatosA)
                .Include(t => t.TbCategoriaDatosB)
                .Include(t => t.TbConsultas)
                .Include(t => t.TbPersonas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbDato == null)
            {
                return NotFound();
            }

            return View(tbDato);
        }

        // GET: Datos/Create
        public IActionResult Create()
        {
            ViewData["TbCategoriaDatosAId"] = new SelectList(_context.TbCategoriaDatosAs, "Id", "Id");
            ViewData["TbCategoriaDatosBId"] = new SelectList(_context.TbCategoriaDatosBs, "Id", "Id");
            ViewData["TbConsultasId"] = new SelectList(_context.TbConsultas, "Id", "Id");
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id");
            return View();
        }

        // POST: Datos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,FechaCreado,FechaModificado,FechaUltimaImpresion,TbCategoriaDatosAId,TbCategoriaDatosBId,TbPersonasId,TbConsultasId")] TbDato tbDato)
        {
            if (ModelState.IsValid || !ModelState.IsValid)
            {
                _context.Add(tbDato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TbCategoriaDatosAId"] = new SelectList(_context.TbCategoriaDatosAs, "Id", "Id", tbDato.TbCategoriaDatosAId);
            ViewData["TbCategoriaDatosBId"] = new SelectList(_context.TbCategoriaDatosBs, "Id", "Id", tbDato.TbCategoriaDatosBId);
            ViewData["TbConsultasId"] = new SelectList(_context.TbConsultas, "Id", "Id", tbDato.TbConsultasId);
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbDato.TbPersonasId);
            return View(tbDato);
        }

        // GET: Datos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbDatos == null)
            {
                return NotFound();
            }

            var tbDato = await _context.TbDatos.FindAsync(id);
            if (tbDato == null)
            {
                return NotFound();
            }
            ViewData["TbCategoriaDatosAId"] = new SelectList(_context.TbCategoriaDatosAs, "Id", "Id", tbDato.TbCategoriaDatosAId);
            ViewData["TbCategoriaDatosBId"] = new SelectList(_context.TbCategoriaDatosBs, "Id", "Id", tbDato.TbCategoriaDatosBId);
            ViewData["TbConsultasId"] = new SelectList(_context.TbConsultas, "Id", "Id", tbDato.TbConsultasId);
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbDato.TbPersonasId);
            return View(tbDato);
        }

        // POST: Datos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,FechaCreado,FechaModificado,FechaUltimaImpresion,TbCategoriaDatosAId,TbCategoriaDatosBId,TbPersonasId,TbConsultasId")] TbDato tbDato)
        {
            if (id != tbDato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDatoExists(tbDato.Id))
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
            ViewData["TbCategoriaDatosAId"] = new SelectList(_context.TbCategoriaDatosAs, "Id", "Id", tbDato.TbCategoriaDatosAId);
            ViewData["TbCategoriaDatosBId"] = new SelectList(_context.TbCategoriaDatosBs, "Id", "Id", tbDato.TbCategoriaDatosBId);
            ViewData["TbConsultasId"] = new SelectList(_context.TbConsultas, "Id", "Id", tbDato.TbConsultasId);
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbDato.TbPersonasId);
            return View(tbDato);
        }

        // GET: Datos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbDatos == null)
            {
                return NotFound();
            }

            var tbDato = await _context.TbDatos
                .Include(t => t.TbCategoriaDatosA)
                .Include(t => t.TbCategoriaDatosB)
                .Include(t => t.TbConsultas)
                .Include(t => t.TbPersonas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbDato == null)
            {
                return NotFound();
            }

            return View(tbDato);
        }

        // POST: Datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbDatos == null)
            {
                return Problem("Entity set 'DbGstoreMedicContext.TbDatos'  is null.");
            }
            var tbDato = await _context.TbDatos.FindAsync(id);
            if (tbDato != null)
            {
                _context.TbDatos.Remove(tbDato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDatoExists(int id)
        {
          return _context.TbDatos.Any(e => e.Id == id);
        }
    }
}
