using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gStoreMedicPlus.Models;
using gStoreMedicPlus.Clases;
using System.IO;

namespace gStoreMedicPlus.Controllers
{
    public class TbConsultasController : Controller
    {
        private readonly DbGstoreMedic2Context _context;
        private int idConsulta;

        public TbConsultasController(DbGstoreMedic2Context context)
        {
            _context = context;
        }

        // GET: TbConsultas
        public async Task<IActionResult> Index()
        {
            var dbGstoreMedic2Context = _context.TbConsultas.Include(t => t.TbPersonas).Include(t => t.TbUsuarios);
            return View(await dbGstoreMedic2Context.ToListAsync());
        }

        // GET: TbConsultas/Details/5
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

        // GET: TbConsultas/Create
        public IActionResult Create()
        {
            IdConsulta();
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Nombre");
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id");
            ViewData["id"] = this.idConsulta;
            return View();
        }

        // POST: TbConsultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,FechaCreado,FechaModificado,ProximaCita,MotivoConsulta,Tratamiento,ImpresionClinica,AntecedentesMedicos,AntecedentesQuirurgicos,AntecedentesFamiliares,AntecedentesOftalmicos,AntecedentesAlergicos,AntecedentesOtros,AvlScOd,AvlScOs,WOd,WOs,AvlCcOd,AvlCcOs,AvcScOd,AvcScOs,AddOd,AddOs,AvcCcOd,AvcCcOs,MsLejosOdEsf,MsLejosOdCil,MsLejosOdEje,MsLejosOdAdicion,MsLejosOdMateriales,MsLejosOsEsf,MsLejosOsCil,MsLejosOsEje,MsLejosOsAdicion,MsLejosOsMateriales,MsCercaOdEsf,MsCercaOdCil,MsCercaOdEje,MsCercaOdAdicion,MsCercaOdMateriales,MsCercaOsEsf,MsCercaOsCil,MsCercaOsEje,MsCercaOsAdicion,MsCercaOsMateriales,MrLejosOdEsf,MrLejosOdCil,MrLejosOdEje,MrLejosOdAdicion,MrLejosOdMateriales,MrLejosOsEsf,MrLejosOsCil,MrLejosOsEje,MrLejosOsAdicion,MrLejosOsMateriales,Dip,LhOd,LhOs,ButOd,ButOs,PioOd,PioOs,ExcOd,ExcOs,FoiOd,FoiOs,TbPersonasId,TbUsuariosId")] TbConsulta tbConsulta)
        {
            try
            {
                if (ModelState.IsValid || !ModelState.IsValid)
                {
                    tbConsulta.FechaCreado = DateTime.Now;
                    tbConsulta.FechaModificado = null;

                    _context.Add(tbConsulta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbConsulta.TbPersonasId);
                ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbConsulta.TbUsuariosId);
                return View(tbConsulta);
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }

        // Metodo para obtener el id automatico
        public void IdConsulta()
        {
            if (_context.TbConsultas.OrderByDescending(x => x.Id).FirstOrDefault() != null)
            {
                this.idConsulta = _context.TbConsultas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            else
            {
                this.idConsulta = 1;
            }
        }

        // GET: TbConsultas/Edit/5
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

        // GET: TbConsultas/Reconsulta/5
        public async Task<IActionResult> Reconsulta(int? id)
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
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Nombre", tbConsulta.TbPersonasId);
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbConsulta.TbUsuariosId);
            return View(tbConsulta);
        }

        // GET: TbConsultas/GenerarConsulta/5
        public async Task<IActionResult> GenerarConsulta(int? id)
        {
            var tbConsulta = await _context.TbConsultas.FindAsync(id);
            tbConsulta.TbPersonas = await _context.TbPersonas.FindAsync(tbConsulta.TbPersonasId);
            //var tbPersonas = await _context.TbPersonas.FirstAsync(tbConsulta.TbPersonasId);
            if (tbConsulta == null)
            {
                return NotFound();
            }
            
            //File.WriteAllBytes("archivo.pdf", iText7Pdf.CrearConsultaPdf(tbConsulta, tbConsulta.TbPersonas));
            //string pm = "CONSULTA " + _consulta.Id + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Replace(":", "_").Replace("/", "_") + ".pdf";

            return File(iText7Pdf.CrearConsultaPdf(tbConsulta), "application/pdf", "Consulta.pdf");
        }

        // GET: TbConsultas/GenerarReporteLentes/5
        public async Task<IActionResult> GenerarReporteLentes(int? id)
        {
            var tbConsulta = await _context.TbConsultas.FindAsync(id);
            tbConsulta.TbPersonas = await _context.TbPersonas.FindAsync(tbConsulta.TbPersonasId);
            if (tbConsulta == null)
            {
                return NotFound();
            }

            return File(iText7Pdf.DatosLentesPdf(tbConsulta), "application/pdf", "Lentes.pdf");
        }

        // GET: TbConsultas/GenerarReporteTratamiento/5
        public async Task<IActionResult> GenerarReporteTratamiento(int? id)
        {
            var tbConsulta = await _context.TbConsultas.FindAsync(id);
            tbConsulta.TbPersonas = await _context.TbPersonas.FindAsync(tbConsulta.TbPersonasId);
            if (tbConsulta == null)
            {
                return NotFound();
            }

            return File(iText7Pdf.TramientoPdf(tbConsulta), "application/pdf", "Tratamiento.pdf");
        }

        // POST: TbConsultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,FechaCreado,FechaModificado,ProximaCita,MotivoConsulta,Tratamiento,ImpresionClinica,AntecedentesMedicos,AntecedentesQuirurgicos,AntecedentesFamiliares,AntecedentesOftalmicos,AntecedentesAlergicos,AntecedentesOtros,AvlScOd,AvlScOs,WOd,WOs,AvlCcOd,AvlCcOs,AvcScOd,AvcScOs,AddOd,AddOs,AvcCcOd,AvcCcOs,MsLejosOdEsf,MsLejosOdCil,MsLejosOdEje,MsLejosOdAdicion,MsLejosOdMateriales,MsLejosOsEsf,MsLejosOsCil,MsLejosOsEje,MsLejosOsAdicion,MsLejosOsMateriales,MsCercaOdEsf,MsCercaOdCil,MsCercaOdEje,MsCercaOdAdicion,MsCercaOdMateriales,MsCercaOsEsf,MsCercaOsCil,MsCercaOsEje,MsCercaOsAdicion,MsCercaOsMateriales,MrLejosOdEsf,MrLejosOdCil,MrLejosOdEje,MrLejosOdAdicion,MrLejosOdMateriales,MrLejosOsEsf,MrLejosOsCil,MrLejosOsEje,MrLejosOsAdicion,MrLejosOsMateriales,Dip,LhOd,LhOs,ButOd,ButOs,PioOd,PioOs,ExcOd,ExcOs,FoiOd,FoiOs,TbPersonasId,TbUsuariosId")] TbConsulta tbConsulta)
        {
            if (id != tbConsulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    tbConsulta.FechaModificado = DateTime.Now;
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

        // POST: TbConsultas/Reconsulta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reconsulta(int id, [Bind("Id,Descripcion,FechaCreado,FechaModificado,ProximaCita,MotivoConsulta,Tratamiento,ImpresionClinica,AntecedentesMedicos,AntecedentesQuirurgicos,AntecedentesFamiliares,AntecedentesOftalmicos,AntecedentesAlergicos,AntecedentesOtros,AvlScOd,AvlScOs,WOd,WOs,AvlCcOd,AvlCcOs,AvcScOd,AvcScOs,AddOd,AddOs,AvcCcOd,AvcCcOs,MsLejosOdEsf,MsLejosOdCil,MsLejosOdEje,MsLejosOdAdicion,MsLejosOdMateriales,MsLejosOsEsf,MsLejosOsCil,MsLejosOsEje,MsLejosOsAdicion,MsLejosOsMateriales,MsCercaOdEsf,MsCercaOdCil,MsCercaOdEje,MsCercaOdAdicion,MsCercaOdMateriales,MsCercaOsEsf,MsCercaOsCil,MsCercaOsEje,MsCercaOsAdicion,MsCercaOsMateriales,MrLejosOdEsf,MrLejosOdCil,MrLejosOdEje,MrLejosOdAdicion,MrLejosOdMateriales,MrLejosOsEsf,MrLejosOsCil,MrLejosOsEje,MrLejosOsAdicion,MrLejosOsMateriales,Dip,LhOd,LhOs,ButOd,ButOs,PioOd,PioOs,ExcOd,ExcOs,FoiOd,FoiOs,TbPersonasId,TbUsuariosId")] TbConsulta tbConsulta)
        {
            if (id != tbConsulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid || !ModelState.IsValid)
            {
                try
                {
                    IdConsulta();
                    tbConsulta.Id = this.idConsulta;
                    tbConsulta.FechaCreado = DateTime.Now;
                    tbConsulta.FechaModificado = null;

                    _context.Add(tbConsulta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
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
            }
            ViewData["TbPersonasId"] = new SelectList(_context.TbPersonas, "Id", "Id", tbConsulta.TbPersonasId);
            ViewData["TbUsuariosId"] = new SelectList(_context.TbUsuarios, "Id", "Id", tbConsulta.TbUsuariosId);
            return View(tbConsulta);
        }

        // GET: TbConsultas/Delete/5
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

        // POST: TbConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbConsultas == null)
            {
                return Problem("Entity set 'DbGstoreMedic2Context.TbConsultas'  is null.");
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
          return (_context.TbConsultas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
