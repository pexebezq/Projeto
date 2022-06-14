﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octo1.Models;

namespace Octo1.Controllers
{
    public class TbClientesController : Controller
    {
        private readonly AppDbContext _context;

        public TbClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TbClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCliente.ToListAsync());
        }

        // GET: TbClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbCliente
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: TbClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,Tipo,CpfCnpj,RgIe,Email,DataNascFund,DataCadastro")] TbCliente tbCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCliente);
        }

        // GET: TbClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbCliente.FindAsync(id);
            if (tbCliente == null)
            {
                return NotFound();
            }
            return View(tbCliente);
        }

        // POST: TbClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nome,Tipo,CpfCnpj,RgIe,Email,DataNascFund,DataCadastro")] TbCliente tbCliente)
        {
            if (id != tbCliente.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbClienteExists(tbCliente.Codigo))
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
            return View(tbCliente);
        }

        // GET: TbClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbCliente
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // POST: TbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCliente = await _context.TbCliente.FindAsync(id);
            _context.TbCliente.Remove(tbCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbClienteExists(int id)
        {
            return _context.TbCliente.Any(e => e.Codigo == id);
        }
    }
}
