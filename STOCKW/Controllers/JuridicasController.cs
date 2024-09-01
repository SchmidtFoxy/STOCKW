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
    public class JuridicasController : Controller
    {
        private readonly MeuDbContext _context;

        public JuridicasController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Juridicas
        public async Task<IActionResult> Index()
        {
            var meuDbContext = _context.Juridicas.Include(j => j.Cidade);
            return View(await meuDbContext.ToListAsync());
        }

        // GET: Juridicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridicas
                .Include(j => j.Cidade)
                .FirstOrDefaultAsync(m => m.ID_Pessoa == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // GET: Juridicas/Create
        public IActionResult Create()
        {
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade");
            return View();
        }

        // POST: Juridicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNPJ,InscricaoEstadual,InscricaoMunicipal,ID_Pessoa,Nome,Numero,Logradouro,Complemento,Bairro,ID_Cidade,Tipo")] Juridica juridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade", juridica.ID_Cidade);
            return View(juridica);
        }

        // GET: Juridicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridicas.FindAsync(id);
            if (juridica == null)
            {
                return NotFound();
            }
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade", juridica.ID_Cidade);
            return View(juridica);
        }

        // POST: Juridicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CNPJ,InscricaoEstadual,InscricaoMunicipal,ID_Pessoa,Nome,Numero,Logradouro,Complemento,Bairro,ID_Cidade,Tipo")] Juridica juridica)
        {
            if (id != juridica.ID_Pessoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuridicaExists(juridica.ID_Pessoa))
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
            ViewData["ID_Cidade"] = new SelectList(_context.Cidades, "ID_Cidade", "ID_Cidade", juridica.ID_Cidade);
            return View(juridica);
        }

        // GET: Juridicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridicas
                .Include(j => j.Cidade)
                .FirstOrDefaultAsync(m => m.ID_Pessoa == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // POST: Juridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juridica = await _context.Juridicas.FindAsync(id);
            if (juridica != null)
            {
                _context.Juridicas.Remove(juridica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuridicaExists(int id)
        {
            return _context.Juridicas.Any(e => e.ID_Pessoa == id);
        }
    }
}
