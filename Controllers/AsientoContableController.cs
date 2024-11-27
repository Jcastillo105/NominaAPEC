using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NominaAPEC.Data; // Incluir el contexto de base de datos
using NominaAPEC.Models;
using AsientoContableService; // Namespace actualizado

namespace NominaAPEC.Controllers
{
    public class AsientoContableController : Controller
    {
        private readonly MyDbContext _context;
        private readonly AsientoContableServiceSoapClient _client;

        public AsientoContableController(MyDbContext context)
        {
            _context = context;
            _client = new AsientoContableServiceSoapClient(AsientoContableServiceSoapClient.EndpointConfiguration.AsientoContableServiceSoap);
        }

        // GET: AsientoContable
        public IActionResult Index()
        {
            try
            {
                List<AsientoContable> asientos = new List<AsientoContable>(); // Simulación
                return View(asientos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Index: {ex.Message}");
                return View(new List<AsientoContable>());
            }
        }

        // GET: AsientoContable/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Details: ID es null.");
                return NotFound();
            }

            try
            {
                AsientoContable? asiento = null; // Simulación
                return View(asiento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Details: {ex.Message}");
                return NotFound();
            }
        }

        // GET: AsientoContable/Create
        public IActionResult Create()
        {
            // Cargar lista de empleados para el dropdown
            ViewBag.EmpleadoId = new SelectList(_context.Empleados, "Id", "Nombre");
            ViewBag.TiposIngreso = new SelectList(_context.TiposIngreso.Where(t => t.Estado), "Id", "Nombre");
            ViewBag.TiposDeduccion = new SelectList(_context.TiposDeduccion.Where(t => t.Estado), "Id", "Nombre");

            return View();
        }

        // POST: AsientoContable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAuxiliar,Descripcion,CuentaDB,CuentaCR,Monto,EmpleadoId,TipoTransaccion")] AsientoContable asiento)
        {
            if (!ModelState.IsValid)
            {
                // Recargar lista de empleados en caso de error
                ViewBag.EmpleadoId = new SelectList(_context.Empleados, "Id", "Nombre");
                ViewBag.TiposIngreso = new SelectList(_context.TiposIngreso.Where(t => t.Estado), "Id", "Nombre", asiento.TipoIngresoId);
                ViewBag.TiposDeduccion = new SelectList(_context.TiposDeduccion.Where(t => t.Estado), "Id", "Nombre", asiento.TipoDeduccionId);

                return View(asiento);
            }

            try
            {
                Console.WriteLine("Iniciando registro del asiento contable...");
                Console.WriteLine($"Datos del asiento: Auxiliar={asiento.IdAuxiliar}, Descripción={asiento.Descripcion}, DB={asiento.CuentaDB}, CR={asiento.CuentaCR}, Monto={asiento.Monto}");

                // Llamar al WS para registrar el asiento
                var response = await _client.RegistrarAsientoAsync(asiento.IdAuxiliar, asiento.Descripcion, asiento.CuentaDB, asiento.CuentaCR, asiento.Monto);
                int idAsiento = response.Body.RegistrarAsientoResult;

                Console.WriteLine($"Respuesta del servicio: IdAsiento={idAsiento}");

                if (idAsiento > 0)
                {
                    Console.WriteLine("Asiento registrado correctamente. Procediendo con la transacción...");

                    // Registrar la transacción en la tabla de RegistroTransacciones
                    var transaccion = new RegistroTransaccion
                    {
                        EmpleadoId = asiento.EmpleadoId,
                        TipoTransaccion = asiento.TipoTransaccion,
                        TipoIngresoId = asiento.TipoTransaccion == "Ingreso" ? asiento.TipoIngresoId : null, // Solo si es ingreso
                        TipoDeduccionId = asiento.TipoTransaccion == "Deducción" ? asiento.TipoDeduccionId : null, // Solo si es deducción
                        Fecha = DateTime.Now,
                        Monto = asiento.Monto,
                        Estado = true,
                        IdAsiento = idAsiento
                    };

                    Console.WriteLine($"Datos de la transacción: {transaccion.EmpleadoId}, {transaccion.TipoTransaccion}, {transaccion.Fecha}, {transaccion.Monto}, {transaccion.IdAsiento}, {transaccion.TipoIngresoId}, {transaccion.TipoDeduccionId}");

                    // Guardar en la base de datos
                    _context.RegistroTransacciones.Add(transaccion);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = $"Asiento y transacción registrados exitosamente con ID Asiento: {idAsiento}.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Console.WriteLine("El servicio devolvió un ID inválido.");
                    ModelState.AddModelError("", "Error al registrar el asiento contable en el servicio externo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Create: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al registrar el asiento contable.");
            }

            // Recargar lista de empleados en caso de error
            ViewBag.EmpleadoId = new SelectList(_context.Empleados, "Id", "Nombre");
            return View(asiento);
        }

        // GET: AsientoContable/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Edit: ID es null.");
                return NotFound();
            }

            try
            {
                AsientoContable? asiento = null; // Simulación
                return View(asiento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Edit: {ex.Message}");
                return NotFound();
            }
        }

        // POST: AsientoContable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IdAuxiliar,Descripcion,CuentaDB,CuentaCR,Monto")] AsientoContable asiento)
        {
            if (id != asiento.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(asiento);
            }

            try
            {
                Console.WriteLine("Edición de asiento completada.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Edit: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al editar el asiento contable.");
            }

            return View(asiento);
        }

        // GET: AsientoContable/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Error en Delete: ID es null.");
                return NotFound();
            }

            try
            {
                AsientoContable? asiento = null; // Simulación
                return View(asiento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete: {ex.Message}");
                return NotFound();
            }
        }

        // POST: AsientoContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Console.WriteLine("Asiento contable eliminado.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteConfirmed: {ex.Message}");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
