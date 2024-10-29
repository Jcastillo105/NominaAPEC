using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPEC.Data;
using NominaAPEC.Models;

namespace NominaAPEC.Controllers
{
    public class TipoIngresoController : Controller
    {
        private readonly MyDbContext _context;

        public TipoIngresoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoIngreso
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposIngreso.ToListAsync());
        }

        // GET: TipoIngreso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TiposIngreso
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // GET: TipoIngreso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIngreso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoIngreso tipoIngreso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tipoIngreso);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tipo de Ingreso creado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el Tipo de Ingreso: " + ex.Message);
                }
            }
            return View(tipoIngreso);
        }

        // GET: TipoIngreso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TiposIngreso.FindAsync(id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // POST: TipoIngreso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoIngreso tipoIngreso)
        {
            if (id != tipoIngreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIngreso);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tipo de Ingreso actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIngresoExists(tipoIngreso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al actualizar el Tipo de Ingreso.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al actualizar el Tipo de Ingreso: " + ex.Message);
                }
            }
            return View(tipoIngreso);
        }

        // GET: TipoIngreso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TiposIngreso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // POST: TipoIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tipoIngreso = await _context.TiposIngreso.FindAsync(id);
                if (tipoIngreso != null)
                {
                    _context.TiposIngreso.Remove(tipoIngreso);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tipo de Ingreso eliminado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el Tipo de Ingreso: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TipoIngresoExists(int id)
        {
            return _context.TiposIngreso.Any(e => e.Id == id);
        }
    }
}
