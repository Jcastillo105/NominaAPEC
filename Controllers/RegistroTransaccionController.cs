using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NominaAPEC.Data;
using NominaAPEC.Models;

namespace NominaAPEC.Controllers
{
    public class RegistroTransaccionController : Controller
    {
        private readonly MyDbContext _context;

        public RegistroTransaccionController(MyDbContext context)
        {
            _context = context;
        }

        // GET: RegistroTransaccion
        public async Task<IActionResult> Index()
        {
            var transacciones = _context.RegistroTransacciones
                .Include(rt => rt.Empleado)
                .Include(rt => rt.TipoIngreso)
                .Include(rt => rt.TipoDeduccion);
            return View(await transacciones.ToListAsync());
        }

        // GET: RegistroTransaccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransacciones
                .Include(rt => rt.Empleado)
                .Include(rt => rt.TipoIngreso)
                .Include(rt => rt.TipoDeduccion)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (registroTransaccion == null)
            {
                return NotFound();
            }

            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Create
        public IActionResult Create()
        {
            CargarListas(); // Cargar listas de empleados, ingresos, deducciones y tipos de transacción
            return View();
        }

        // POST: RegistroTransaccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,TipoIngresoId,TipoDeduccionId,TipoTransaccion,Fecha,Monto,Estado")] RegistroTransaccion registroTransaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroTransaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarListas(registroTransaccion);
            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransacciones.FindAsync(id);
            if (registroTransaccion == null)
            {
                return NotFound();
            }

            CargarListas(registroTransaccion);
            return View(registroTransaccion);
        }

        // POST: RegistroTransaccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,TipoIngresoId,TipoDeduccionId,TipoTransaccion,Fecha,Monto,Estado")] RegistroTransaccion registroTransaccion)
        {
            if (id != registroTransaccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroTransaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroTransaccionExists(registroTransaccion.Id))
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

            CargarListas(registroTransaccion);
            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransacciones
                .Include(rt => rt.Empleado)
                .Include(rt => rt.TipoIngreso)
                .Include(rt => rt.TipoDeduccion)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (registroTransaccion == null)
            {
                return NotFound();
            }

            return View(registroTransaccion);
        }

        // POST: RegistroTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroTransaccion = await _context.RegistroTransacciones.FindAsync(id);
            if (registroTransaccion != null)
            {
                _context.RegistroTransacciones.Remove(registroTransaccion);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroTransaccionExists(int id)
        {
            return _context.RegistroTransacciones.Any(e => e.Id == id);
        }

        // Método auxiliar para cargar listas en la vista
        private void CargarListas(RegistroTransaccion registroTransaccion = null)
        {
            ViewBag.EmpleadoId = new SelectList(_context.Empleados, "Id", "Nombre", registroTransaccion?.EmpleadoId);
            ViewBag.TipoIngresoId = new SelectList(_context.TiposIngreso, "Id", "Nombre", registroTransaccion?.TipoIngresoId);
            ViewBag.TipoDeduccionId = new SelectList(_context.TiposDeduccion, "Id", "Nombre", registroTransaccion?.TipoDeduccionId);
            ViewBag.TipoTransaccion = new SelectList(new[]
            {
                new { Value = "Ingreso", Text = "Ingreso" },
                new { Value = "Deducción", Text = "Deducción" }
            }, "Value", "Text", registroTransaccion?.TipoTransaccion);
        }
    }
}
