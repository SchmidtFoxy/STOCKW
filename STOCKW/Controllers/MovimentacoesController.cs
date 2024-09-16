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
    public class MovimentacoesController : Controller
    {
        private readonly MeuDbContext _context;

        public MovimentacoesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Movimentacaos
        public async Task<IActionResult> Index()
        {
            var meuDbContext = _context.Movimentacoes.Include(m => m.Pessoa).Include(m => m.Item).Include(m => m.TipoMovimentacao).Include(m => m.Usuario);
            return View(await meuDbContext.ToListAsync());
        }

        // GET: Movimentacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.Pessoa)
                .Include(m => m.Item)
                .Include(m => m.TipoMovimentacao)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.ID_Movimentacao == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacaos/Create
        public IActionResult Create()
        {
            ViewData["ID_Pessoa"] = new SelectList(_context.Pessoas, "ID_Pessoa", "Nome");
            ViewData["ID_Item"] = new SelectList(_context.Itens, "ID_Item", "Nome");
            ViewData["ID_TipoMovimentacao"] = new SelectList(_context.TiposMovimentacao, "ID_TipoMovimentacao", "Descricao");
            ViewData["ID_Usuario"] = new SelectList(_context.Usuarios, "ID_Usuario", "Nome");
            return View();
        }

        // POST: Movimentacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Movimentacao,ID_Item,ID_Pessoa,ID_TipoMovimentacao,ID_Usuario,Data,QuantidadeMovimentada")] Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Pessoa"] = new SelectList(_context.Pessoas, "ID_Pessoa", "ID_Pessoa", movimentacao.ID_Pessoa);
            ViewData["ID_Item"] = new SelectList(_context.Itens, "ID_Item", "Nome", movimentacao.ID_Item);
            ViewData["ID_TipoMovimentacao"] = new SelectList(_context.TiposMovimentacao, "ID_TipoMovimentacao", "ID_TipoMovimentacao", movimentacao.ID_TipoMovimentacao);
            ViewData["ID_Usuario"] = new SelectList(_context.Usuarios, "ID_Usuario", "ID_Usuario", movimentacao.ID_Usuario);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["ID_Pessoa"] = new SelectList(_context.Pessoas, "ID_Pessoa", "ID_Pessoa", movimentacao.ID_Pessoa);
            ViewData["ID_Item"] = new SelectList(_context.Itens, "ID_Item", "Nome", movimentacao.ID_Item);
            ViewData["ID_TipoMovimentacao"] = new SelectList(_context.TiposMovimentacao, "ID_TipoMovimentacao", "ID_TipoMovimentacao", movimentacao.ID_TipoMovimentacao);
            ViewData["ID_Usuario"] = new SelectList(_context.Usuarios, "ID_Usuario", "ID_Usuario", movimentacao.ID_Usuario);
            return View(movimentacao);
        }

        // POST: Movimentacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Movimentacao,ID_Item,ID_Pessoa,ID_TipoMovimentacao,ID_Usuario,Data,QuantidadeMovimentada")] Movimentacao movimentacao)
        {
            if (id != movimentacao.ID_Movimentacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.ID_Movimentacao))
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
            ViewData["ID_Pessoa"] = new SelectList(_context.Pessoas, "ID_Pessoa", "ID_Pessoa", movimentacao.ID_Pessoa);
            ViewData["ID_Item"] = new SelectList(_context.Itens, "ID_Item", "Nome", movimentacao.ID_Item);
            ViewData["ID_TipoMovimentacao"] = new SelectList(_context.TiposMovimentacao, "ID_TipoMovimentacao", "ID_TipoMovimentacao", movimentacao.ID_TipoMovimentacao);
            ViewData["ID_Usuario"] = new SelectList(_context.Usuarios, "ID_Usuario", "ID_Usuario", movimentacao.ID_Usuario);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.Pessoa)
                .Include(m => m.Item)
                .Include(m => m.TipoMovimentacao)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.ID_Movimentacao == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao != null)
            {
                _context.Movimentacoes.Remove(movimentacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacoes.Any(e => e.ID_Movimentacao == id);
        }
    }
}
