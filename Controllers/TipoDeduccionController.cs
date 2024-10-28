using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,DependeDeSalario,Estado")] TipoDeduccion tipoDeduccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,DependeDeSalario,Estado")] TipoDeduccion tipoDeduccion)
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeduccionExists(tipoDeduccion.Id))
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
            var tipoDeduccion = await _context.TiposDeduccion.FindAsync(id);
            if (tipoDeduccion != null)
            {
                _context.TiposDeduccion.Remove(tipoDeduccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeduccionExists(int id)
        {
            return _context.TiposDeduccion.Any(e => e.Id == id);
        }
    }
}
