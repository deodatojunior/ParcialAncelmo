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
    public class TipoConteudosController : Controller
    {
        private readonly Conexao _context;

        public TipoConteudosController(Conexao context)
        {
            _context = context;
        }

        // GET: TipoConteudos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoConteudos.ToListAsync());
        }

        // GET: TipoConteudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConteudo = await _context.TipoConteudos
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }

            return View(tipoConteudo);
        }

        // GET: TipoConteudos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoConteudos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao")] TipoConteudo tipoConteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoConteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConteudo);
        }

        // GET: TipoConteudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConteudo = await _context.TipoConteudos.FindAsync(id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }
            return View(tipoConteudo);
        }

        // POST: TipoConteudos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao")] TipoConteudo tipoConteudo)
        {
            if (id != tipoConteudo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoConteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoConteudoExists(tipoConteudo.id))
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
            return View(tipoConteudo);
        }

        // GET: TipoConteudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConteudo = await _context.TipoConteudos
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }

            return View(tipoConteudo);
        }

        // POST: TipoConteudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoConteudo = await _context.TipoConteudos.FindAsync(id);
            _context.TipoConteudos.Remove(tipoConteudo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoConteudoExists(int id)
        {
            return _context.TipoConteudos.Any(e => e.id == id);
        }
    }
}
