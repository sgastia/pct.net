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
    [Route("backend/musicos")]
    public class MusicosController : Controller
    {
        private const string ROOT_PATH = "~/Views/Backend/Musicos/";

        private const string CREATE_VIEW = ROOT_PATH + "Create.cshtml";
        private const string DELETE_VIEW = ROOT_PATH + "Delete.cshtml";
        private const string DETAILS_VIEW = ROOT_PATH + "Details.cshtml";
        private const string EDIT_VIEW = ROOT_PATH + "Edit.cshtml";
        private const string INDEX_VIEW = ROOT_PATH + "Index.cshtml";

        private readonly PCTContext _context;

        public MusicosController(PCTContext context)
        {
            _context = context;
        }

        // GET: BackendMusicos
        [Route("")]
        [Route("index")]
        [Route("home")]
        public async Task<IActionResult> Index()
        {
            return View(INDEX_VIEW,await _context.Musicos.ToListAsync());
        }

        // GET: BackendMusicos/Details/5
        [Route("details")]
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

            return View(DETAILS_VIEW,musico);
        }

        // GET: BackendMusicos/Create
        [Route("create")]
        public IActionResult Create()
        {
            return View(CREATE_VIEW);
        }

        // POST: BackendMusicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> Create([Bind("IdMusico,Nombre,Apellido,FechaNacimiento,Instrumentos,Publicar,EsIntegrantePermanente")] Musico musico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CREATE_VIEW,musico);
        }

        // GET: BackendMusicos/Edit/5
        [Route("edit")]
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
            return View(EDIT_VIEW,musico);
        }

        // POST: BackendMusicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public async Task<IActionResult> Edit(int idMusico, [Bind("IdMusico,Nombre,Apellido,FechaNacimiento,Instrumentos,Publicar,EsIntegrantePermanente")] Musico musico)
        {
            if (idMusico != musico.IdMusico)
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
            return View(EDIT_VIEW,musico);
        }

        // GET: BackendMusicos/Delete/5
        [Route("delete")]
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

            return View(DELETE_VIEW,musico);
        }

        // POST: BackendMusicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete")]
        public async Task<IActionResult> DeleteConfirmed(int idMusico)
        {
            var musico = await _context.Musicos.FindAsync(idMusico);
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
