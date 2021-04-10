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
    [Authorize]
    [Authorize(Roles = "admin")]
    public class GruposController : Controller
    {
        private readonly RosarioDBContext _context;

        public GruposController(RosarioDBContext context)
        {
            _context = context;
        }
        #region

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            var rosarioDBContext = _context.Grupo.Include(g => g.IdgradoNavigation);
              
            return View(await rosarioDBContext.ToListAsync());
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            var grupo = await _context.Grupo            
                .Include(g => g.IdgradoNavigation)

                 .Include(a => a.Asignar)
                  .ThenInclude(e => e.docente)

                .FirstOrDefaultAsync(m => m.Idgrupo == id);

            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Grado1");

            return View();
        }




        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado", grupo.Idgrado);
            return View(grupo);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado", grupo.Idgrado);
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idgrupo,Idgrado,seccion")] Grupo grupo)
        {
            if (id != grupo.Idgrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.Idgrupo))
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
            ViewData["Idgrado"] = new SelectList(_context.Grado, "Idgrado", "Idgrado", grupo.Idgrado);
            return View(grupo);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo
                .Include(g => g.IdgradoNavigation)
                .FirstOrDefaultAsync(m => m.Idgrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupo.FindAsync(id);
            _context.Grupo.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupo.Any(e => e.Idgrupo == id);
        }
        #endregion

        #region
        // GET: Asignar/Create
        // GET: Asignar/Create
        //Metodo para agregar asignacion tipo CREATE

        //MAESTRO DETALLE/ Asignar detalle de los grupos... metodos crear GET Y POST
        public async Task<IActionResult> CreateAsignar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo

           .Include(g => g.IdgradoNavigation)
                 .Include(a => a.Asignar)
                .FirstOrDefaultAsync(m => m.Idgrupo == id);

            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Iddocente");
            var view = new Asignar { Idgrupo = grupo.Idgrupo, };
            return View(view);
        }

        // POST: Asignar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsignar(Asignar asignar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignar);
                await _context.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", asignar.Idgrupo));
            }
            ViewData["Iddocente"] = new SelectList(_context.Docente, "Iddocente", "Iddocente", asignar.Iddocente);
            
            return View(asignar);
        }
        #endregion
    }
}

