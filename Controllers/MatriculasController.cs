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

    public class MatriculasController : Controller
    {
        private readonly RosarioDBContext _context;

        public MatriculasController(RosarioDBContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var rosarioDBContext = _context.Matricula.Include(m => m.IdestudianteNavigation).Include(m => m.IdgrupoNavigation).Include(m => m.IdmodalidadNavigation);
            return View(await rosarioDBContext.ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .Include(m => m.IdestudianteNavigation)
                .Include(m => m.IdgrupoNavigation)
                .Include(m => m.IdmodalidadNavigation)
                .FirstOrDefaultAsync(m => m.Idmatricula == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewData["Idestudiante"] = new SelectList(_context.Estudiante, "Idestudiante", "Fullestudiante");
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Fullgrupo");
            ViewData["Idmodalidad"] = new SelectList(_context.Modalidad, "Idmodalidad", "Modalidad1");

         
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmatricula,Idestudiante,Idmodalidad,Idgrupo,año_lectivo,fecha_matricula,repitente,tarjeta,estado, observacion")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestudiante"] = new SelectList(_context.Estudiante, "Idestudiante", "Idestudiante", matricula.Idestudiante);
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Idgrupo", matricula.Idgrupo);
            ViewData["Idmodalidad"] = new SelectList(_context.Modalidad, "Idmodalidad", "Idmodalidad", matricula.Idmodalidad);

          
            return View(matricula);


        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["Idestudiante"] = new SelectList(_context.Estudiante, "Idestudiante", "Idestudiante", matricula.Idestudiante);
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Idgrupo", matricula.Idgrupo);
            ViewData["Idmodalidad"] = new SelectList(_context.Modalidad, "Idmodalidad", "Idmodalidad", matricula.Idmodalidad);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmatricula,Idestudiante,Idmodalidad,Idgrupo,año_lectivo,fecha_matricula,repitente,tarjeta,estado, observacion")] Matricula matricula)
        {
            if (id != matricula.Idmatricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Idmatricula))
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
            ViewData["Idestudiante"] = new SelectList(_context.Estudiante, "Idestudiante", "Idestudiante", matricula.Idestudiante);
            ViewData["Idgrupo"] = new SelectList(_context.Grupo, "Idgrupo", "Fullgrupo", matricula.Idgrupo);
            ViewData["Idmodalidad"] = new SelectList(_context.Modalidad, "Idmodalidad", "Modalidad1", matricula.Idmodalidad);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matricula
                .Include(m => m.IdestudianteNavigation)
                .Include(m => m.IdgrupoNavigation)
                .Include(m => m.IdmodalidadNavigation)
                .FirstOrDefaultAsync(m => m.Idmatricula == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matricula.FindAsync(id);
            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matricula.Any(e => e.Idmatricula == id);
        }
    }
}
