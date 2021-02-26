using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROSARIOAPP.Models;
using Microsoft.AspNetCore.Authorization;
namespace ROSARIOAPP.Controllers
{

    //Asignacion de permisos
    [Authorize]
    [Authorize(Roles = "admin")]
    public class ModalidadsController : Controller
    {
        private readonly RosarioDBContext _context;

        public ModalidadsController(RosarioDBContext context)
        {
            _context = context;
        }

        // GET: Modalidads

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modalidad.ToListAsync());
        }

        // GET: Modalidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidad
                .FirstOrDefaultAsync(m => m.Idmodalidad == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // GET: Modalidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modalidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmodalidad,Modalidad1")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modalidad);
        }

        // GET: Modalidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidad.FindAsync(id);
            if (modalidad == null)
            {
                return NotFound();
            }
            return View(modalidad);
        }

        // POST: Modalidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmodalidad,Modalidad1")] Modalidad modalidad)
        {
            if (id != modalidad.Idmodalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadExists(modalidad.Idmodalidad))
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
            return View(modalidad);
        }

        // GET: Modalidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidad
                .FirstOrDefaultAsync(m => m.Idmodalidad == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // POST: Modalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidad = await _context.Modalidad.FindAsync(id);
            _context.Modalidad.Remove(modalidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadExists(int id)
        {
            return _context.Modalidad.Any(e => e.Idmodalidad == id);
        }
    }
}
