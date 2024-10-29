using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominaAPEC.Data;
using NominaAPEC.Models;

namespace NominaAPEC.Controllers
{
    public class TipoDeduccionController : Controller
    {
        private readonly MyDbContext _context;

        public TipoDeduccionController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeduccion
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDeduccion.ToListAsync());
        }

        // GET: TipoDeduccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeduccion = await _context.TiposDeduccion
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tipoDeduccion == null)
            {
                return NotFound();
            }

            return View(tipoDeduccion);
        }

        // GET: TipoDeduccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeduccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDeduccion tipoDeduccion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tipoDeduccion);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tipo de Deducción creado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el Tipo de Deducción: " + ex.Message);
                }
            }
            return View(tipoDeduccion);
        }

        // GET: TipoDeduccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeduccion = await _context.TiposDeduccion.FindAsync(id);
            if (tipoDeduccion == null)
            {
                return NotFound();
            }

            return View(tipoDeduccion);
        }

        // POST: TipoDeduccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoDeduccion tipoDeduccion)
        {
            if (id != tipoDeduccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeduccion);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tipo de Deducción actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeduccionExists(tipoDeduccion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al actualizar el Tipo de Deducción.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al actualizar el Tipo de Deducción: " + ex.Message);
                }
            }
            return View(tipoDeduccion);
        }

        // GET: TipoDeduccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeduccion = await _context.TiposDeduccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeduccion == null)
            {
                return NotFound();
            }

            return View(tipoDeduccion);
        }

        // POST: TipoDeduccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tipoDeduccion = await _context.TiposDeduccion.FindAsync(id);
                if (tipoDeduccion != null)
                {
                    _context.TiposDeduccion.Remove(tipoDeduccion);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tipo de Deducción eliminado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el Tipo de Deducción: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeduccionExists(int id)
        {
            return _context.TiposDeduccion.Any(e => e.Id == id);
        }
    }
}
