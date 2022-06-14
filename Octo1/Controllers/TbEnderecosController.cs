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
    public class TbEnderecosController : Controller
    {
        private readonly AppDbContext _context;

        public TbEnderecosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TbEnderecos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TbEndereco.Include(t => t.CodPessoaNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TbEnderecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEndereco = await _context.TbEndereco
                .Include(t => t.CodPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tbEndereco == null)
            {
                return NotFound();
            }

            return View(tbEndereco);
        }

        // GET: TbEnderecos/Create
        public IActionResult Create()
        {
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj");
            return View();
        }

        // POST: TbEnderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,CodPessoa,Tipo,Logradouro,Numero,Complemento,Bairro,Cidade,Uf,Cep")] TbEndereco tbEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj", tbEndereco.CodPessoa);
            return View(tbEndereco);
        }

        // GET: TbEnderecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEndereco = await _context.TbEndereco.FindAsync(id);
            if (tbEndereco == null)
            {
                return NotFound();
            }
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj", tbEndereco.CodPessoa);
            return View(tbEndereco);
        }

        // POST: TbEnderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,CodPessoa,Tipo,Logradouro,Numero,Complemento,Bairro,Cidade,Uf,Cep")] TbEndereco tbEndereco)
        {
            if (id != tbEndereco.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbEnderecoExists(tbEndereco.Codigo))
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
            ViewData["CodPessoa"] = new SelectList(_context.TbCliente, "Codigo", "CpfCnpj", tbEndereco.CodPessoa);
            return View(tbEndereco);
        }

        // GET: TbEnderecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEndereco = await _context.TbEndereco
                .Include(t => t.CodPessoaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tbEndereco == null)
            {
                return NotFound();
            }

            return View(tbEndereco);
        }

        // POST: TbEnderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbEndereco = await _context.TbEndereco.FindAsync(id);
            _context.TbEndereco.Remove(tbEndereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbEnderecoExists(int id)
        {
            return _context.TbEndereco.Any(e => e.Codigo == id);
        }
    }
}
