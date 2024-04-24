using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AG_Examen.Data;
using AG_Examen.Models;

namespace AG_Examen.Controllers
{
    public class AG_MateriaController : Controller
    {
        private readonly AG_ExamenContext _context;

        public AG_MateriaController(AG_ExamenContext context)
        {
            _context = context;
        }

        // GET: AG_Materia
        public async Task<IActionResult> Index()
        {
            return View(await _context.AG_Materia.ToListAsync());
        }

        // GET: AG_Materia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aG_Materia = await _context.AG_Materia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aG_Materia == null)
            {
                return NotFound();
            }

            return View(aG_Materia);
        }

        // GET: AG_Materia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AG_Materia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Aprobado,Nota")] AG_Materia aG_Materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aG_Materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aG_Materia);
        }

        // GET: AG_Materia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aG_Materia = await _context.AG_Materia.FindAsync(id);
            if (aG_Materia == null)
            {
                return NotFound();
            }
            return View(aG_Materia);
        }

        // POST: AG_Materia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Aprobado,Nota")] AG_Materia aG_Materia)
        {
            if (id != aG_Materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aG_Materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AG_MateriaExists(aG_Materia.Id))
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
            return View(aG_Materia);
        }

        // GET: AG_Materia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aG_Materia = await _context.AG_Materia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aG_Materia == null)
            {
                return NotFound();
            }

            return View(aG_Materia);
        }

        // POST: AG_Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aG_Materia = await _context.AG_Materia.FindAsync(id);
            if (aG_Materia != null)
            {
                _context.AG_Materia.Remove(aG_Materia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AG_MateriaExists(int id)
        {
            return _context.AG_Materia.Any(e => e.Id == id);
        }
    }
}
