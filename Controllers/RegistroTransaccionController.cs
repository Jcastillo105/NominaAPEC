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
                Console.WriteLine("Error en Details: ID es null.");
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransacciones
                .Include(rt => rt.Empleado)
                .Include(rt => rt.TipoIngreso)
                .Include(rt => rt.TipoDeduccion)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (registroTransaccion == null)
            {
                Console.WriteLine($"Error en Details: No se encontró el registro con ID {id}.");
                return NotFound();
            }

            return View(registroTransaccion);
        }

        // GET: RegistroTransaccion/Create
        public IActionResult Create()
        {
            CargarListas();
            return View();
        }

        // POST: RegistroTransaccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,TipoIngresoId,TipoDeduccionId,TipoTransaccion,Fecha,Monto,Estado")] RegistroTransaccion registroTransaccion)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error de validación en Create: {error.ErrorMessage}");
                }

                CargarListas(registroTransaccion);
                return View(registroTransaccion);
            }

            try
            {
                // Agregar la lógica de registro automático
                _context.Add(registroTransaccion);
                await _context.SaveChangesAsync();

                Console.WriteLine("Registro de transacción creado exitosamente.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el registro de transacción: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el registro de transacción.");
                CargarListas(registroTransaccion);
                return View(registroTransaccion);
            }
        }

        // GET: RegistroTransaccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Edit: ID es null.");
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransacciones.FindAsync(id);
            if (registroTransaccion == null)
            {
                Console.WriteLine($"Error en Edit: No se encontró el registro con ID {id}.");
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
                Console.WriteLine("Error en Edit: ID no coincide.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error de validación en Edit: {error.ErrorMessage}");
                }

                CargarListas(registroTransaccion);
                return View(registroTransaccion);
            }

            try
            {
                _context.Update(registroTransaccion);
                await _context.SaveChangesAsync();
                Console.WriteLine("Registro de transacción editado exitosamente.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el registro de transacción: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurrió un error al editar el registro de transacción.");
                CargarListas(registroTransaccion);
                return View(registroTransaccion);
            }
        }

        // GET: RegistroTransaccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Delete: ID es null.");
                return NotFound();
            }

            var registroTransaccion = await _context.RegistroTransacciones
                .Include(rt => rt.Empleado)
                .Include(rt => rt.TipoIngreso)
                .Include(rt => rt.TipoDeduccion)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (registroTransaccion == null)
            {
                Console.WriteLine($"Error en Delete: No se encontró el registro con ID {id}.");
                return NotFound();
            }

            return View(registroTransaccion);
        }

        // POST: RegistroTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var registroTransaccion = await _context.RegistroTransacciones.FindAsync(id);
                if (registroTransaccion != null)
                {
                    _context.RegistroTransacciones.Remove(registroTransaccion);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Registro de transacción eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"Error en DeleteConfirmed: No se encontró el registro con ID {id}.");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el registro de transacción: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurrió un error al eliminar el registro de transacción.");
                return RedirectToAction(nameof(Delete), new { id });
            }

            return RedirectToAction(nameof(Index));
        }

        private void CargarListas(RegistroTransaccion? registroTransaccion = null)
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
