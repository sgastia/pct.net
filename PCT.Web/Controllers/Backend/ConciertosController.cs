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
    [Route("backend/conciertos")]
    public class ConciertosController : Controller
    {
        private const string ROOT_PATH = "~/Views/Backend/Conciertos/";
        
        private const string CREATE_VIEW = ROOT_PATH + "Create.cshtml";
        private const string DELETE_VIEW = ROOT_PATH + "Delete.cshtml";
        private const string DETAILS_VIEW = ROOT_PATH + "Details.cshtml";
        private const string EDIT_VIEW = ROOT_PATH + "Edit.cshtml";
        private const string INDEX_VIEW = ROOT_PATH + "Index.cshtml";

        private readonly PCTContext _context;

        public ConciertosController(PCTContext context)
        {
            _context = context;
        }

        // GET: BackendConciertos
        [Route("")]
        [Route("index")]
        [Route("home")]
        public async Task<IActionResult> Index()
        {
            return View(INDEX_VIEW, await _context.Conciertos.ToListAsync());
        }

        // GET: BackendConciertos/Details/5
        [Route("details")]
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

            return View(DETAILS_VIEW,concierto);
        }

        // GET: BackendConciertos/Create
        [Route("create")]
        public IActionResult Create()
        {
            return View(CREATE_VIEW);
        }

        // POST: BackendConciertos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> Create([Bind("IdConcierto,Publicar,Nombre,Descripcion,UrlPoster,Fecha")] Concierto concierto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concierto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CREATE_VIEW,concierto);
        }

        // GET: BackendConciertos/Edit/5
        [Route("edit")]
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
            return View(EDIT_VIEW,concierto);
        }

        // POST: BackendConciertos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public async Task<IActionResult> Edit(int idConcierto, [Bind("IdConcierto,Publicar,Nombre,Descripcion,UrlPoster,Fecha")] Concierto concierto)
        {
            if (idConcierto != concierto.IdConcierto)
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
            return View(EDIT_VIEW,concierto);
        }

        // GET: BackendConciertos/Delete/5
        [Route("delete")]
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

            return View(DELETE_VIEW,concierto);
        }

        // POST: BackendConciertos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete")]
        public async Task<IActionResult> DeleteConfirmed(int idConcierto)
        {
            var concierto = await _context.Conciertos.FindAsync(idConcierto);
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
