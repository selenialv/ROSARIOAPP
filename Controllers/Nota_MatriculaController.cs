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
    public class Nota_MatriculaController : Controller
    {
        private readonly RosarioDBContext _context;

        public Nota_MatriculaController(RosarioDBContext context)
        {
            _context = context;
        }

        // GET: Nota_Matricula
        public async Task<IActionResult> Index()
        {
            var rosarioDBContext = _context.Nota_Matricula.Include(n => n.Matricula).Include(n => n.Nota);
            return View(await rosarioDBContext.ToListAsync());
        }

        // GET: Nota_Matricula/Details/5
        public async Task<IActionResult> Details(int? Idnota, int? Idmatricula)
        {
            if (Idnota == null && Idmatricula == null)
            {
                return NotFound();
            }

            var nota_Matricula = await _context.Nota_Matricula
                .Include(n => n.Matricula)
                .Include(n => n.Nota)
                .FirstOrDefaultAsync(m => m.Idnota == Idnota);
            if (nota_Matricula == null)
            {
                return NotFound();
            }

            return View(nota_Matricula);
        }

        // GET: Nota_Matricula/Create
        public IActionResult Create()
        {
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula");
            ViewData["Idnota"] = new SelectList(_context.Nota, "Idnota", "Idnota");
            return View();
        }

        // POST: Nota_Matricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnota,Idmatricula")] Nota_Matricula nota_Matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nota_Matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula", nota_Matricula.Idmatricula);
            ViewData["Idnota"] = new SelectList(_context.Nota, "Idnota", "Idnota", nota_Matricula.Idnota);
            return View(nota_Matricula);
        }

        // GET: Nota_Matricula/Edit/5
        public async Task<IActionResult> Edit(int? Idnota,  int? Idmatricula)
        {
            if (Idnota == null && Idmatricula == null)
            {
                return NotFound();
            }

            var nota_Matricula = await _context.Nota_Matricula.FindAsync(Idnota);
            if (nota_Matricula == null)
            {
                return NotFound();
            }
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula", nota_Matricula.Idmatricula);
            ViewData["Idnota"] = new SelectList(_context.Nota, "Idnota", "Idnota", nota_Matricula.Idnota);
            return View(nota_Matricula);
        }

        // POST: Nota_Matricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Idnota, int Idmatricula, [Bind("Idnota,Idmatricula")] Nota_Matricula nota_Matricula)
        {
            if (Idnota != nota_Matricula.Idnota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota_Matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Nota_MatriculaExists(nota_Matricula.Idnota))
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
            ViewData["Idmatricula"] = new SelectList(_context.Matricula, "Idmatricula", "Idmatricula", nota_Matricula.Idmatricula);
            ViewData["Idnota"] = new SelectList(_context.Nota, "Idnota", "Idnota", nota_Matricula.Idnota);
            return View(nota_Matricula);
        }

        // GET: Nota_Matricula/Delete/5
        public async Task<IActionResult> Delete(int? Idnota, int? Idmatricula)
        {
            if (Idnota == null || Idmatricula== null )
            {
                return NotFound();
            }

            var nota_Matricula = await _context.Nota_Matricula
                .Include(n => n.Matricula)
                .Include(n => n.Nota)
                .FirstOrDefaultAsync(m => m.Idnota == Idnota);
            if (nota_Matricula == null)
            {
                return NotFound();
            }

            return View(nota_Matricula);
        }

        // POST: Nota_Matricula/Delete/5        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Idnota, int Idmatricula)
        {
            var nota_Matricula = await _context.Nota_Matricula.FindAsync(Idnota, Idmatricula);
            _context.Nota_Matricula.Remove(nota_Matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Nota_MatriculaExists(int id)
        {
            return _context.Nota_Matricula.Any(e => e.Idnota == id);
        }
    }
}
