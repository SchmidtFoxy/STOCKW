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
    public class TipoMovimentacoesController : Controller
    {
        private readonly MeuDbContext _context;

        public TipoMovimentacoesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: TipoMovimentacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMovimentacao.ToListAsync());
        }

        // GET: TipoMovimentacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimentacao = await _context.TiposMovimentacao
                .FirstOrDefaultAsync(m => m.ID_TipoMovimentacao == id);
            if (tipoMovimentacao == null)
            {
                return NotFound();
            }

            return View(tipoMovimentacao);
        }

        // GET: TipoMovimentacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimentacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_TipoMovimentacao,Descricao")] TipoMovimentacao tipoMovimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMovimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimentacao);
        }

        // GET: TipoMovimentacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimentacao = await _context.TiposMovimentacao.FindAsync(id);
            if (tipoMovimentacao == null)
            {
                return NotFound();
            }
            return View(tipoMovimentacao);
        }

        // POST: TipoMovimentacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_TipoMovimentacao,Descricao")] TipoMovimentacao tipoMovimentacao)
        {
            if (id != tipoMovimentacao.ID_TipoMovimentacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimentacaoExists(tipoMovimentacao.ID_TipoMovimentacao))
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
            return View(tipoMovimentacao);
        }

        // GET: TipoMovimentacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimentacao = await _context.TiposMovimentacao
                .FirstOrDefaultAsync(m => m.ID_TipoMovimentacao == id);
            if (tipoMovimentacao == null)
            {
                return NotFound();
            }

            return View(tipoMovimentacao);
        }

        // POST: TipoMovimentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMovimentacao = await _context.TiposMovimentacao.FindAsync(id);
            if (tipoMovimentacao != null)
            {
                _context.TiposMovimentacao.Remove(tipoMovimentacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimentacaoExists(int id)
        {
            return _context.TiposMovimentacao.Any(e => e.ID_TipoMovimentacao == id);
        }
    }
}
