using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STOCKW.Data;
using STOCKW.Models.Dominio;

namespace STOCKW.Controllers
{
    public class FisicasController : Controller
    {
        private readonly MeuDbContext _context;

        public FisicasController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Fisicas
        public async Task<IActionResult> Index()
        {
            var meuDbContext = _context.Fisicas.Include(f => f.Cidade);
            return View(await meuDbContext.ToListAsync());
        }

        // GET: Fisicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisicas
                .Include(f => f.Cidade)
                .FirstOrDefaultAsync(m => m.ID_Pessoa == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // GET: Fisicas/Create
        public IActionResult Create()
        {
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade");
            return View();
        }

        // POST: Fisicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CPF,ID_Pessoa,Nome,Numero,Logradouro,Complemento,Bairro,ID_Cidade,Tipo")] Fisica fisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade", fisica.ID_Cidade);
            return View(fisica);
        }

        // GET: Fisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisicas.FindAsync(id);
            if (fisica == null)
            {
                return NotFound();
            }
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade", fisica.ID_Cidade);
            return View(fisica);
        }

        // POST: Fisicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CPF,ID_Pessoa,Nome,Numero,Logradouro,Complemento,Bairro,ID_Cidade,Tipo")] Fisica fisica)
        {
            if (id != fisica.ID_Pessoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FisicaExists(fisica.ID_Pessoa))
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
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade", fisica.ID_Cidade);
            return View(fisica);
        }

        // GET: Fisicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisicas
                .Include(f => f.Cidade)
                .FirstOrDefaultAsync(m => m.ID_Pessoa == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // POST: Fisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fisica = await _context.Fisicas.FindAsync(id);
            if (fisica != null)
            {
                _context.Fisicas.Remove(fisica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FisicaExists(int id)
        {
            return _context.Fisicas.Any(e => e.ID_Pessoa == id);
        }
    }
}
