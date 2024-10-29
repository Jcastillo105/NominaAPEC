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
    public class AsientoContableController : Controller
    {
        private readonly MyDbContext _context;

        public AsientoContableController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AsientoContable
        public async Task<IActionResult> Index()
        {
            var asientos = _context.AsientosContables.Include(a => a.Empleado);
            return View(await asientos.ToListAsync());
        }

        // GET: AsientoContable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Details: ID es null.");
                return NotFound();
            }

            var asientoContable = await _context.AsientosContables
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asientoContable == null)
            {
                Console.WriteLine($"Error en Details: No se encontró el registro con ID {id}.");
                return NotFound();
            }

            // Debugging: Imprimir valores obtenidos
            Console.WriteLine("----- Debugging de los valores obtenidos en Details -----");
            Console.WriteLine($"ID: {asientoContable.Id}");
            Console.WriteLine($"Empleado: {asientoContable.Empleado?.Nombre}");
            Console.WriteLine($"Descripción: {asientoContable.Descripcion}");
            Console.WriteLine($"Cuenta: {asientoContable.Cuenta}");
            Console.WriteLine($"Tipo de Movimiento: {asientoContable.TipoMovimiento}");
            Console.WriteLine($"Fecha del Asiento: {asientoContable.FechaAsiento}");
            Console.WriteLine($"Monto del Asiento: {asientoContable.MontoAsiento}");
            Console.WriteLine($"Estado: {asientoContable.Estado}");
            Console.WriteLine("--------------------------------------------------------");

            return View(asientoContable);
        }

        // GET: AsientoContable/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: AsientoContable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion,EmpleadoId,Cuenta,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientoContable asientoContable)
        {
            if (!ModelState.IsValid)
            {
                // Imprimir errores de validación en la consola
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error de validación en Create: {error.ErrorMessage}");
                }

                ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", asientoContable.EmpleadoId);
                return View(asientoContable);
            }

            // Debugging: Imprimir valores recibidos
            Console.WriteLine("----- Debugging de los valores recibidos en Create -----");
            Console.WriteLine($"EmpleadoId: {asientoContable.EmpleadoId}");
            Console.WriteLine($"Descripción: {asientoContable.Descripcion}");
            Console.WriteLine($"Cuenta: {asientoContable.Cuenta}");
            Console.WriteLine($"Tipo de Movimiento: {asientoContable.TipoMovimiento}");
            Console.WriteLine($"Fecha del Asiento: {asientoContable.FechaAsiento}");
            Console.WriteLine($"Monto del Asiento: {asientoContable.MontoAsiento}");
            Console.WriteLine($"Estado: {asientoContable.Estado}");
            Console.WriteLine("--------------------------------------------------------");

            try
            {
                _context.Add(asientoContable);
                await _context.SaveChangesAsync();
                Console.WriteLine("Asiento contable creado exitosamente.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el asiento contable: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el asiento contable.");
                ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", asientoContable.EmpleadoId);
                return View(asientoContable);
            }
        }

        // GET: AsientoContable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Edit: ID es null.");
                return NotFound();
            }

            var asientoContable = await _context.AsientosContables.FindAsync(id);
            if (asientoContable == null)
            {
                Console.WriteLine($"Error en Edit: No se encontró el registro con ID {id}.");
                return NotFound();
            }

            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", asientoContable.EmpleadoId);
            return View(asientoContable);
        }

        // POST: AsientoContable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,EmpleadoId,Cuenta,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientoContable asientoContable)
        {
            if (id != asientoContable.Id)
            {
                Console.WriteLine("Error en Edit: ID no coincide.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                // Imprimir errores de validación en la consola
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error de validación en Edit: {error.ErrorMessage}");
                }

                ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", asientoContable.EmpleadoId);
                return View(asientoContable);
            }

            // Debugging: Imprimir valores recibidos
            Console.WriteLine("----- Debugging de los valores recibidos en Edit -----");
            Console.WriteLine($"EmpleadoId: {asientoContable.EmpleadoId}");
            Console.WriteLine($"Descripción: {asientoContable.Descripcion}");
            Console.WriteLine($"Cuenta: {asientoContable.Cuenta}");
            Console.WriteLine($"Tipo de Movimiento: {asientoContable.TipoMovimiento}");
            Console.WriteLine($"Fecha del Asiento: {asientoContable.FechaAsiento}");
            Console.WriteLine($"Monto del Asiento: {asientoContable.MontoAsiento}");
            Console.WriteLine($"Estado: {asientoContable.Estado}");
            Console.WriteLine("--------------------------------------------------------");

            try
            {
                _context.Update(asientoContable);
                await _context.SaveChangesAsync();
                Console.WriteLine("Asiento contable editado exitosamente.");
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoContableExists(asientoContable.Id))
                {
                    Console.WriteLine("Error de concurrencia en la edición del asiento contable.");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el asiento contable: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurrió un error al editar el asiento contable.");
                ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", asientoContable.EmpleadoId);
                return View(asientoContable);
            }
        }

        // GET: AsientoContable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Delete: ID es null.");
                return NotFound();
            }

            var asientoContable = await _context.AsientosContables
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asientoContable == null)
            {
                Console.WriteLine($"Error en Delete: No se encontró el registro con ID {id}.");
                return NotFound();
            }

            // Debugging: Imprimir valores obtenidos
            Console.WriteLine("----- Debugging de los valores obtenidos en Delete -----");
            Console.WriteLine($"ID: {asientoContable.Id}");
            Console.WriteLine($"Empleado: {asientoContable.Empleado?.Nombre}");
            Console.WriteLine($"Descripción: {asientoContable.Descripcion}");
            Console.WriteLine($"Cuenta: {asientoContable.Cuenta}");
            Console.WriteLine($"Tipo de Movimiento: {asientoContable.TipoMovimiento}");
            Console.WriteLine($"Fecha del Asiento: {asientoContable.FechaAsiento}");
            Console.WriteLine($"Monto del Asiento: {asientoContable.MontoAsiento}");
            Console.WriteLine($"Estado: {asientoContable.Estado}");
            Console.WriteLine("--------------------------------------------------------");

            return View(asientoContable);
        }

        // POST: AsientoContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientoContable = await _context.AsientosContables.FindAsync(id);
            if (asientoContable != null)
            {
                _context.AsientosContables.Remove(asientoContable);
                await _context.SaveChangesAsync();
                Console.WriteLine("Asiento contable eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error en DeleteConfirmed: El registro no se encontró.");
            }

            return RedirectToAction(nameof(Index));
        }

        // Método para verificar si existe un asiento contable
        private bool AsientoContableExists(int id)
        {
            return _context.AsientosContables.Any(e => e.Id == id);
        }
    }
}
