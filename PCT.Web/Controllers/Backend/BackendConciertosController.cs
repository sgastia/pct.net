using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCT.BD;
using PCT.Dominio;

namespace PCT.Web.Controllers.Backend
{
    public class BackendConciertosController : Controller
    {
        private readonly PCTContext _context;

        public BackendConciertosController(PCTContext context)
        {
            _context = context;
        }

        // GET: BackendConciertos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conciertos.ToListAsync());
        }

        // GET: BackendConciertos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _context.Conciertos
                .FirstOrDefaultAsync(m => m.IdConcierto == id);
            if (concierto == null)
            {
                return NotFound();
            }

            return View(concierto);
        }

        // GET: BackendConciertos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BackendConciertos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConcierto,Publicar,Nombre,Descripcion,UrlPoster,Fecha")] Concierto concierto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concierto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concierto);
        }

        // GET: BackendConciertos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _context.Conciertos.FindAsync(id);
            if (concierto == null)
            {
                return NotFound();
            }
            return View(concierto);
        }

        // POST: BackendConciertos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConcierto,Publicar,Nombre,Descripcion,UrlPoster,Fecha")] Concierto concierto)
        {
            if (id != concierto.IdConcierto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concierto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConciertoExists(concierto.IdConcierto))
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
            return View(concierto);
        }

        // GET: BackendConciertos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _context.Conciertos
                .FirstOrDefaultAsync(m => m.IdConcierto == id);
            if (concierto == null)
            {
                return NotFound();
            }

            return View(concierto);
        }

        // POST: BackendConciertos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concierto = await _context.Conciertos.FindAsync(id);
            _context.Conciertos.Remove(concierto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConciertoExists(int id)
        {
            return _context.Conciertos.Any(e => e.IdConcierto == id);
        }
    }
}
