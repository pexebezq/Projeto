using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octo1.Models;

namespace Octo1.Controllers
{
    public class TbTelefonesController : Controller
    {
        private readonly AppDbContext _context;

        public TbTelefonesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TbTelefones
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TbTelefone.Include(t => t.CodPessoaNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TbTelefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTelefone = await _context.TbTelefone
                .Include(t => t.CodPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tbTelefone == null)
            {
                return NotFound();
            }

            return View(tbTelefone);
        }

        // GET: TbTelefones/Create
        public IActionResult Create()
        {
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj");
            return View();
        }

        // POST: TbTelefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,CodPessoa,Tipo,Ddd,Numero,Observacoes")] TbTelefone tbTelefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTelefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj", tbTelefone.CodPessoa);
            return View(tbTelefone);
        }

        // GET: TbTelefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTelefone = await _context.TbTelefone.FindAsync(id);
            if (tbTelefone == null)
            {
                return NotFound();
            }
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj", tbTelefone.CodPessoa);
            return View(tbTelefone);
        }

        // POST: TbTelefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,CodPessoa,Tipo,Ddd,Numero,Observacoes")] TbTelefone tbTelefone)
        {
            if (id != tbTelefone.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTelefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTelefoneExists(tbTelefone.Codigo))
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
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj", tbTelefone.CodPessoa);
            return View(tbTelefone);
        }

        // GET: TbTelefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTelefone = await _context.TbTelefone
                .Include(t => t.CodPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tbTelefone == null)
            {
                return NotFound();
            }

            return View(tbTelefone);
        }

        // POST: TbTelefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTelefone = await _context.TbTelefone.FindAsync(id);
            _context.TbTelefone.Remove(tbTelefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTelefoneExists(int id)
        {
            return _context.TbTelefone.Any(e => e.Codigo == id);
        }
    }
}
