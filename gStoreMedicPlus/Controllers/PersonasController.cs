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
    public class PersonasController : Controller
    {
        private readonly DbGstoreMedic2Context _context;
        private int idPersona;

        public PersonasController(DbGstoreMedic2Context context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var dbGstoreMedicContext = _context.TbPersonas.Include(t => t.TbUsuarios);
            return View(await dbGstoreMedicContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbPersonas == null)
            {
                return NotFound();
            }

            var tbPersona = await _context.TbPersonas
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbPersona == null)
            {
                return NotFound();
            }

            return View(tbPersona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            IdPersona();
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id");
            ViewData["id"] = this.idPersona;
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaNacimiento,Direccion,Telefono1,Telefono2,Correo,FechaCreacion,FechaModificacion,FechaUltimaVisita,Estado,Tipo,Dpi,TbUsuariosId")] TbPersona tbPersona)
        {
            if (ModelState.IsValid || !ModelState.IsValid)
            {
                tbPersona.FechaCreacion = DateTime.Now;
                tbPersona.Telefono1 = string.Format("+502{0}", tbPersona.Telefono1.Replace("+502", "").Replace("-","").Trim());
                tbPersona.Telefono2 = string.Format("+502{0}", tbPersona.Telefono2.Replace("+502", "").Replace("-", "").Trim());
                tbPersona.Nombre = tbPersona.Nombre.ToUpper();
                tbPersona.Direccion = tbPersona.Direccion.ToUpper();

                _context.Add(tbPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbPersona.TbUsuariosId);
            return View(tbPersona);
        }

        // Metodo para obtener el id automatico
        public void IdPersona()
        {
            if (_context.TbPersonas.OrderByDescending(x => x.Id).FirstOrDefault() != null)
            {
                this.idPersona = _context.TbPersonas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            else
            {
                this.idPersona = 1;
            }
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbPersonas == null)
            {
                return NotFound();
            }

            var tbPersona = await _context.TbPersonas.FindAsync(id);
            if (tbPersona == null)
            {
                return NotFound();
            }
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbPersona.TbUsuariosId);
            return View(tbPersona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaNacimiento,Direccion,Telefono1,Telefono2,Correo,FechaCreacion,FechaModificacion,FechaUltimaVisita,Estado,Tipo,Dpi,TbUsuariosId")] TbPersona tbPersona)
        {
            if (id != tbPersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPersonaExists(tbPersona.Id))
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
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbPersona.TbUsuariosId);
            return View(tbPersona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbPersonas == null)
            {
                return NotFound();
            }

            var tbPersona = await _context.TbPersonas
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbPersona == null)
            {
                return NotFound();
            }

            return View(tbPersona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbPersonas == null)
            {
                return Problem("Entity set 'DbGstoreMedic2Context.TbPersonas'  is null.");
            }
            var tbPersona = await _context.TbPersonas.FindAsync(id);
            if (tbPersona != null)
            {
                _context.TbPersonas.Remove(tbPersona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPersonaExists(int id)
        {
          return _context.TbPersonas.Any(e => e.Id == id);
        }
    }
}
