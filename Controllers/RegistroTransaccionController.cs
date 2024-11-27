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
                Console.WriteLine($"Error en Details: No se encontr� el registro con ID {id}.");
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
                    Console.WriteLine($"Error de validaci�n en Create: {error.ErrorMessage}");
                }

                CargarListas(registroTransaccion);
                return View(registroTransaccion);
            }

            try
            {
                // Agregar la l�gica de registro autom�tico
                _context.Add(registroTransaccion);
                await _context.SaveChangesAsync();

                Console.WriteLine("Registro de transacci�n creado exitosamente.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el registro de transacci�n: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurri� un error al crear el registro de transacci�n.");
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
                Console.WriteLine($"Error en Edit: No se encontr� el registro con ID {id}.");
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
                    Console.WriteLine($"Error de validaci�n en Edit: {error.ErrorMessage}");
                }

                CargarListas(registroTransaccion);
                return View(registroTransaccion);
            }

            try
            {
                _context.Update(registroTransaccion);
                await _context.SaveChangesAsync();
                Console.WriteLine("Registro de transacci�n editado exitosamente.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el registro de transacci�n: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurri� un error al editar el registro de transacci�n.");
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
                Console.WriteLine($"Error en Delete: No se encontr� el registro con ID {id}.");
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
                    Console.WriteLine("Registro de transacci�n eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"Error en DeleteConfirmed: No se encontr� el registro con ID {id}.");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el registro de transacci�n: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocurri� un error al eliminar el registro de transacci�n.");
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
                new { Value = "Deducci�n", Text = "Deducci�n" }
            }, "Value", "Text", registroTransaccion?.TipoTransaccion);
        }
    }
}
