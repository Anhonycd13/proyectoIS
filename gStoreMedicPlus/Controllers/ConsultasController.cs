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
    public class ConsultasController : Controller
    {
        private readonly DbGstoreMedicContext _context;
        private int id;

        public ConsultasController(DbGstoreMedicContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index(string buscar)
        {
            ViewData["NombreUsuario"] = VariablesGlobales.NombreUsuario;
            /*
            var consultas = from consulta in _context.TbConsultas 
                            join persona in _context.TbPersonas   
                            on consulta.TbPersonasId equals persona.Id
                            select new { consulta.Id, consulta.Descripcion, consulta.FechaCreado, persona.Nombre };
            
            */
            var consultas = _context.TbConsultas.Include(t => t.TbPersonas);
            //var consultas = _context.TbConsultas.Join(_context.TbPersonas, x => x.TbPersonasId, y => y.Id, (x, y) => new { x.Id, x.Descripcion, x.FechaCreado, y.Nombre });

            if (!String.IsNullOrWhiteSpace(buscar))
            {
                //consultas = consultas.Where(x => x.Descripcion.Contains(buscar));
                //consultas = consultas.Where(x => x.Descripcion.Contains(buscar));
            }

            //var dbGstoreMedicContext = _context.TbConsultas.Include(t => t.TbPersonas).Include(t => t.TbUsuarios);
            return View(await consultas.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbConsultas == null)
            {
                return NotFound();
            }

            var tbConsulta = await _context.TbConsultas
                .Include(t => t.TbPersonas)
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbConsulta == null)
            {
                return NotFound();
            }

            return View(tbConsulta);
        }

        // Metodo para obtener el id automatico
        public void Id()
        {
            if (_context.TbConsultas.OrderByDescending(x => x.Id).FirstOrDefault() != null)
            {
                this.id = _context.TbConsultas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            else
            {
                this.id = 1;
            }
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            Id();
            ViewData["id"] = this.id;
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Nombre");
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,FechaCreado,FechaModificado,TbPersonasId,TbUsuariosId")] TbConsulta tbConsulta)
        {
            if (ModelState.IsValid || !ModelState.IsValid)
            {
                _context.Add(tbConsulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbConsulta.TbPersonasId);
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbConsulta.TbUsuariosId);
            return View(tbConsulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbConsultas == null)
            {
                return NotFound();
            }

            var tbConsulta = await _context.TbConsultas.FindAsync(id);
            if (tbConsulta == null)
            {
                return NotFound();
            }
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbConsulta.TbPersonasId);
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbConsulta.TbUsuariosId);
            return View(tbConsulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,FechaCreado,FechaModificado,TbPersonasId,TbUsuariosId")] TbConsulta tbConsulta)
        {
            if (id != tbConsulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbConsulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbConsultaExists(tbConsulta.Id))
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
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbConsulta.TbPersonasId);
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbConsulta.TbUsuariosId);
            return View(tbConsulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbConsultas == null)
            {
                return NotFound();
            }

            var tbConsulta = await _context.TbConsultas
                .Include(t => t.TbPersonas)
                .Include(t => t.TbUsuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbConsulta == null)
            {
                return NotFound();
            }

            return View(tbConsulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbConsultas == null)
            {
                return Problem("Entity set 'DbGstoreMedicContext.TbConsultas'  is null.");
            }
            var tbConsulta = await _context.TbConsultas.FindAsync(id);
            if (tbConsulta != null)
            {
                _context.TbConsultas.Remove(tbConsulta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbConsultaExists(int id)
        {
          return _context.TbConsultas.Any(e => e.Id == id);
        }
    }
}
