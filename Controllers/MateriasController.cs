﻿using System;
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

    [Authorize]
    [Authorize(Roles = "admin")]
    public class MateriasController : Controller
    {
        private readonly RosarioDBContext _context;

        public MateriasController(RosarioDBContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            var rosarioDBContext = _context.Materia.Include(m => m.IddocenteNavigation);
            return View(await rosarioDBContext.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia
                .Include(m => m.IddocenteNavigation)
                .FirstOrDefaultAsync(m => m.Idmateria == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create( )
        {
            
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Fulldocente");
         
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmateria,Iddocente, Nombre")] Materia materia)
        {
            if (_context.Materia.Any(c => c.Nombre == materia.Nombre))
            {
                ModelState.AddModelError("Nombre", $"Esta materia ya esta registrado.");
            }


            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Fulldocente", materia.Iddocente);
            return View(materia);


        }


        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Fulldocente", materia.Iddocente);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmateria,Iddocente")] Materia materia)
        {
            if (id != materia.Idmateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Idmateria))
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
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Nombres", materia.Iddocente);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia
                .Include(m => m.IddocenteNavigation)
                .FirstOrDefaultAsync(m => m.Idmateria == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.Materia.FindAsync(id);
            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return _context.Materia.Any(e => e.Idmateria == id);
        }
    }
}
