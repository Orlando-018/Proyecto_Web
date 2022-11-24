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
    public class ReservacionsController : Controller
    {
        private readonly ProyectoPWContext _context;

        public ReservacionsController(ProyectoPWContext context)
        {
            _context = context;
        }

        // GET: Reservacions
        public async Task<IActionResult> Index()
        {
            var proyectoPWContext = _context.Reservacions.Include(r => r.IdHabitacionNavigation).Include(r => r.IdUsuarioNavigation);
            return View(await proyectoPWContext.ToListAsync());
        }

        // GET: Reservacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions
                .Include(r => r.IdHabitacionNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // GET: Reservacions/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Reservacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,IdHabitacion,IdUsuario")] Reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion", reservacion.IdHabitacion);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacion.IdUsuario);
            return View(reservacion);
        }

        // GET: Reservacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion", reservacion.IdHabitacion);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacion.IdUsuario);
            return View(reservacion);
        }

        // POST: Reservacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion,IdHabitacion,IdUsuario")] Reservacion reservacion)
        {
            if (id != reservacion.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionExists(reservacion.IdReservacion))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion", reservacion.IdHabitacion);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", reservacion.IdUsuario);
            return View(reservacion);
        }

        // GET: Reservacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions
                .Include(r => r.IdHabitacionNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // POST: Reservacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservacions == null)
            {
                return Problem("Entity set 'ProyectoPWContext.Reservacions'  is null.");
            }
            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion != null)
            {
                _context.Reservacions.Remove(reservacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionExists(int id)
        {
          return _context.Reservacions.Any(e => e.IdReservacion == id);
        }
    }
}
