using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Primeruso.Models.dbModels;

namespace Primeruso.Controllers
{
    public class HabitacionsController : Controller
    {
        private readonly ProyectoPWContext _context;

        public HabitacionsController(ProyectoPWContext context)
        {
            _context = context;
        }

        // GET: Habitacions
        public async Task<IActionResult> Index()
        {
            var proyectoPWContext = _context.Habitacions.Include(h => h.IdHotelNavigation).Include(h => h.IdTipoHabitacionNavigation);
            return View(await proyectoPWContext.ToListAsync());
        }

        // GET: Habitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitacions == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdHotelNavigation)
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitacions/Create
        public IActionResult Create()
        {
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel");
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoDeHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion");
            return View();
        }

        // POST: Habitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion,IdHotel,NumHabitacion,CostoHabitacion,IdTipoHabitacion")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", habitacion.IdHotel);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoDeHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitacions == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", habitacion.IdHotel);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoDeHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // POST: Habitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabitacion,IdHotel,NumHabitacion,CostoHabitacion,IdTipoHabitacion")] Habitacion habitacion)
        {
            if (id != habitacion.IdHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IdHabitacion))
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
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", habitacion.IdHotel);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoDeHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitacions == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdHotelNavigation)
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitacions == null)
            {
                return Problem("Entity set 'ProyectoPWContext.Habitacions'  is null.");
            }
            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion != null)
            {
                _context.Habitacions.Remove(habitacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(int id)
        {
          return _context.Habitacions.Any(e => e.IdHabitacion == id);
        }
    }
}
