using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaAPEC.Models;
using AsientoContableService; // Namespace actualizado

namespace NominaAPEC.Controllers
{
    public class AsientoContableController : Controller
    {
        private readonly AsientoContableServiceSoapClient _client;

        public AsientoContableController()
        {
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
            return View();
        }

        // POST: AsientoContable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAuxiliar,Descripcion,CuentaDB,CuentaCR,Monto")] AsientoContable asiento)
        {
            if (!ModelState.IsValid)
            {
                return View(asiento);
            }

            try
            {
                // Llamar al WS para registrar el asiento
                var response = await _client.RegistrarAsientoAsync(asiento.IdAuxiliar, asiento.Descripcion, asiento.CuentaDB, asiento.CuentaCR, asiento.Monto);
                int result = response.Body.RegistrarAsientoResult; // Extraer el resultado de la respuesta

                if (result > 0)
                {
                    TempData["Message"] = "Asiento registrado exitosamente con ID: " + result;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar el asiento contable.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Create: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al registrar el asiento contable.");
            }

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
