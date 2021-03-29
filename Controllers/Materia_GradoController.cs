using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROSARIOAPP.Models;

namespace ROSARIOAPP.Controllers
{
    public class Materia_GradoController : Controller
    {
        private readonly RosarioDBContext _context;

        public Materia_GradoController(RosarioDBContext context)
        {
            _context = context;
        }

        // GET: Materia_Grado
        public async Task<IActionResult> Index()    
        {
            var rosarioDBContext = _context.Materia_Grado.Include(m => m.Grado).Include(m => m.materia);
            return View(await rosarioDBContext.ToListAsync());
        }

        // GET: Materia_Grado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia_Grado = await _context.Materia_Grado
                .Include(m => m.Grado)
                .Include(m => m.materia)
                .FirstOrDefaultAsync(m => m.Idmateria == id);
            if (materia_Grado == null)
            {
                return NotFound();
            }

            return View(materia_Grado);
        }

        // GET: Materia_Grado/Create
        public IActionResult Create()
        {
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado");
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria");
            return View();
        }

        // POST: Materia_Grado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idgrado,Idmateria,tutor")] Materia_Grado materia_Grado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia_Grado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado", materia_Grado.Idgrado);
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", materia_Grado.Idmateria);
            return View(materia_Grado);
        }

        // GET: Materia_Grado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia_Grado = await _context.Materia_Grado.FindAsync(id);
            if (materia_Grado == null)
            {
                return NotFound();
            }
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado", materia_Grado.Idgrado);
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", materia_Grado.Idmateria);
            return View(materia_Grado);
        }

        // POST: Materia_Grado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idgrado,Idmateria,tutor")] Materia_Grado materia_Grado)
        {
            if (id != materia_Grado.Idmateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia_Grado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Materia_GradoExists(materia_Grado.Idmateria))
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
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado", materia_Grado.Idgrado);
            ViewData["Idmateria"] = new SelectList(_context.Materia, "Idmateria", "Idmateria", materia_Grado.Idmateria);
            return View(materia_Grado);
        }

        // GET: Materia_Grado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia_Grado = await _context.Materia_Grado
                .Include(m => m.Grado)
                .Include(m => m.materia)
                .FirstOrDefaultAsync(m => m.Idmateria == id);
            if (materia_Grado == null)
            {
                return NotFound();
            }

            return View(materia_Grado);
        }

        // POST: Materia_Grado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia_Grado = await _context.Materia_Grado.FindAsync(id);
            _context.Materia_Grado.Remove(materia_Grado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Materia_GradoExists(int id)
        {
            return _context.Materia_Grado.Any(e => e.Idmateria == id);
        }
    }
}
