using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialAncelmo.Database;
using ParcialAncelmo.Models;

namespace ParcialAncelmo.Controllers
{
    public class ConteudosController : Controller
    {
        private readonly Conexao _context;

        public ConteudosController(Conexao context)
        {
            _context = context;
        }

        // GET: Conteudos
        public async Task<IActionResult> Index()
        {
            var conexao = _context.Conteudos.Include(c => c.autor).Include(c => c.tipoConteudo);
            return View(await conexao.ToListAsync());
        }

        // GET: Conteudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudos
                .Include(c => c.autor)
                .Include(c => c.tipoConteudo)
                .FirstOrDefaultAsync(m => m.id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // GET: Conteudos/Create
        public IActionResult Create()
        {
            ViewData["idAutor"] = new SelectList(_context.Autores, "id", "id");
            ViewData["idTipoConteudo"] = new SelectList(_context.TipoConteudos, "id", "id");
            return View();
        }

        // POST: Conteudos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,dataDeCadastro,texto,link,idTipoConteudo,idAutor")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAutor"] = new SelectList(_context.Autores, "id", "id", conteudo.idAutor);
            ViewData["idTipoConteudo"] = new SelectList(_context.TipoConteudos, "id", "id", conteudo.idTipoConteudo);
            return View(conteudo);
        }

        // GET: Conteudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }
            ViewData["idAutor"] = new SelectList(_context.Autores, "id", "id", conteudo.idAutor);
            ViewData["idTipoConteudo"] = new SelectList(_context.TipoConteudos, "id", "id", conteudo.idTipoConteudo);
            return View(conteudo);
        }

        // POST: Conteudos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,dataDeCadastro,texto,link,idTipoConteudo,idAutor")] Conteudo conteudo)
        {
            if (id != conteudo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExists(conteudo.id))
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
            ViewData["idAutor"] = new SelectList(_context.Autores, "id", "id", conteudo.idAutor);
            ViewData["idTipoConteudo"] = new SelectList(_context.TipoConteudos, "id", "id", conteudo.idTipoConteudo);
            return View(conteudo);
        }

        // GET: Conteudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudos
                .Include(c => c.autor)
                .Include(c => c.tipoConteudo)
                .FirstOrDefaultAsync(m => m.id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // POST: Conteudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conteudo = await _context.Conteudos.FindAsync(id);
            _context.Conteudos.Remove(conteudo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteudoExists(int id)
        {
            return _context.Conteudos.Any(e => e.id == id);
        }
    }
}
