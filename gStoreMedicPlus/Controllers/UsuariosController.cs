using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gStoreMedicPlus.Models;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using gStoreMedicPlus.Clases;

namespace gStoreMedicPlus.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DbGstoreMedic2Context _context;
        private int idUsuario;

        public UsuariosController(DbGstoreMedic2Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbUsuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbUsuarios == null)
            {
                return NotFound();
            }

            var tbUsuario = await _context.TbUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbUsuario == null)
            {
                return NotFound();
            }

            return View(tbUsuario);
        }

        // Login

        public IActionResult Login()
        {
            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }

        // Sesion de Usuario

        [HttpPost]
        public async Task<IActionResult> Login(TbUsuario U) 
        {
            try
            {
                using (SqlConnection con = new(_context.Database.GetConnectionString()))
                {
                    using (SqlCommand cmd = new("sp_validar_usuario", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar).Value = U.Usuario;
                        cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = U.Password;
                        con.Open();
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["usuario"] != null && U.Usuario != null)
                            {
                                VariablesGlobales.NombreUsuario = dr["nombre"].ToString();
                                VariablesGlobales.IdUsuario = dr["id"].ToString();
                                List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, U.Usuario)
                                };

                                ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                                AuthenticationProperties p = new();

                                p.AllowRefresh = true;
                                p.IsPersistent = false;

                                if (p.IsPersistent)
                                {
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1);
                                }
                                else
                                {
                                    p.ExpiresUtc = DateTimeOffset.Now.AddDays(1);
                                }
                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);

                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Error = "Credenciales incorrectas o cuenta inválida";
                            }
                        }
                        return View();
                    }
                }
            }catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            IdUsuario();
            ViewData["id"] = this.idUsuario; 
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Usuario,Password,FechaCreado,FechaModificado,FechaUltimoAcceso,Tipo,Estado")] TbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbUsuario);
        }

        // Metodo para obtener el id automatico
        public void IdUsuario()
        {
            if (_context.TbUsuarios.OrderByDescending(x => x.Id).FirstOrDefault() != null) {
                this.idUsuario = _context.TbUsuarios.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;                
            }
            else
            {
                this.idUsuario = 1;
            }
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbUsuarios == null)
            {
                return NotFound();
            }

            var tbUsuario = await _context.TbUsuarios.FindAsync(id);
            if (tbUsuario == null)
            {
                return NotFound();
            }
            return View(tbUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Usuario,Password,FechaCreado,FechaModificado,FechaUltimoAcceso,Tipo,Estado")] TbUsuario tbUsuario)
        {
            if (id != tbUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbUsuarioExists(tbUsuario.Id))
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
            return View(tbUsuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbUsuarios == null)
            {
                return NotFound();
            }

            var tbUsuario = await _context.TbUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbUsuario == null)
            {
                return NotFound();
            }

            return View(tbUsuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbUsuarios == null)
            {
                return Problem("Entity set 'DbGstoreMedicContext.TbUsuarios'  is null.");
            }
            var tbUsuario = await _context.TbUsuarios.FindAsync(id);
            if (tbUsuario != null)
            {
                _context.TbUsuarios.Remove(tbUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbUsuarioExists(int id)
        {
            return _context.TbUsuarios.Any(e => e.Id == id);
        }
    }
}
