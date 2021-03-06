﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROSARIOAPP.Models;

namespace ROSARIOAPP.Controllers
{
    public class AsignarController : Controller
    {
        private readonly RosarioDBContext _context;

        public AsignarController(RosarioDBContext context)
        {
            _context = context;
        }

        // GET: Asignar
        public async Task<IActionResult> Index()
        {
            var rosarioDBContext = _context.Asignar.Include(a => a.docente).Include(a => a.grupo);
            return View(await rosarioDBContext.ToListAsync());
        }

        // GET: Asignar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignar = await _context.Asignar
                .Include(a => a.docente)
                .Include(a => a.grupo)
                .FirstOrDefaultAsync(m => m.Iddocente == id);
            if (asignar == null)
            {
                return NotFound();
            }

            return View(asignar);
        }

        // GET: Asignar/Create
        public IActionResult Create()
        {
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Fulldocente");
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Fullgrupo");
            return View();
        }

        // POST: Asignar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddocente,Idgrupo,tutor")] Asignar asignar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Iddocente", asignar.Iddocente);
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Idgrupo", asignar.Idgrupo);
            return View(asignar);
        }

        // GET: Asignar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignar = await _context.Asignar.FindAsync(id);
            if (asignar == null)
            {
                return NotFound();
            }
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Iddocente", asignar.Iddocente);
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Idgrupo", asignar.Idgrupo);
            return View(asignar);
        }

        // POST: Asignar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddocente,Idgrupo,tutor")] Asignar asignar)
        {
            if (id != asignar.Iddocente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignarExists(asignar.Iddocente))
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
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Iddocente", asignar.Iddocente);
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Idgrupo", asignar.Idgrupo);
            return View(asignar);
        }

        // GET: Asignar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignar = await _context.Asignar
                .Include(a => a.docente)
                .Include(a => a.grupo)
                .FirstOrDefaultAsync(m => m.Iddocente == id);
            if (asignar == null)
            {
                return NotFound();
            }

            return View(asignar);
        }

        // POST: Asignar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignar = await _context.Asignar.FindAsync(id);
            _context.Asignar.Remove(asignar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignarExists(int id)
        {
            return _context.Asignar.Any(e => e.Iddocente == id);
        }
    }
}
