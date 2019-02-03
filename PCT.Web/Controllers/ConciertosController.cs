using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCT.BD;
using PCT.Dominio;

namespace PCT.Web.Controllers
{
    public class ConciertosController : Controller
    {
        private readonly IPCTRepository _repo;

        public ConciertosController(IPCTRepository repo)
        {
            _repo = repo;
        }

        // GET: Conciertos
        public async Task<IActionResult> Index()
        {
            return View(await _repo.Conciertos_ToListAsync());
        }

        // GET: Conciertos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _repo.Conciertos_FindById(id);
            if (concierto == null)
            {
                return NotFound();
            }

            return View(concierto);
        }

        // GET: Conciertos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conciertos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConcierto,Publicar,Nombre,Descripcion,UrlPoster,Fecha")] Concierto concierto)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(concierto);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concierto);
        }

        // GET: Conciertos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _repo.Conciertos_FindById(id);
            if (concierto == null)
            {
                return NotFound();
            }
            return View(concierto);
        }

        // POST: Conciertos/Edit/5
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
                    _repo.Update(concierto);
                    await _repo.SaveChangesAsync();
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

        // GET: Conciertos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Concierto concierto = await _repo.Conciertos_FindById(id);
            if (concierto == null)
            {
                return NotFound();
            }

            return View(concierto);
        }

        // POST: Conciertos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Concierto concierto = await _repo.Conciertos_FindAsync(id);
            _repo.Remove(concierto);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConciertoExists(int id)
        {
            return _repo.ConciertoExists(id);
        }
    }
}
