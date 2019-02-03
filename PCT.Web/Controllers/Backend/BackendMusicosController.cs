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
    public class BackendMusicosController : Controller
    {
        private readonly PCTContext _context;

        public BackendMusicosController(PCTContext context)
        {
            _context = context;
        }

        // GET: BackendMusicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Musicos.ToListAsync());
        }

        // GET: BackendMusicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musico = await _context.Musicos
                .FirstOrDefaultAsync(m => m.IdMusico == id);
            if (musico == null)
            {
                return NotFound();
            }

            return View(musico);
        }

        // GET: BackendMusicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BackendMusicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMusico,Nombre,Apellido,FechaNacimiento,Instrumentos,Publicar,EsIntegrantePermanente")] Musico musico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musico);
        }

        // GET: BackendMusicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musico = await _context.Musicos.FindAsync(id);
            if (musico == null)
            {
                return NotFound();
            }
            return View(musico);
        }

        // POST: BackendMusicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMusico,Nombre,Apellido,FechaNacimiento,Instrumentos,Publicar,EsIntegrantePermanente")] Musico musico)
        {
            if (id != musico.IdMusico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicoExists(musico.IdMusico))
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
            return View(musico);
        }

        // GET: BackendMusicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musico = await _context.Musicos
                .FirstOrDefaultAsync(m => m.IdMusico == id);
            if (musico == null)
            {
                return NotFound();
            }

            return View(musico);
        }

        // POST: BackendMusicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musico = await _context.Musicos.FindAsync(id);
            _context.Musicos.Remove(musico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicoExists(int id)
        {
            return _context.Musicos.Any(e => e.IdMusico == id);
        }
    }
}
