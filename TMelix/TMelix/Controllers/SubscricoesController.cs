using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMelix.Data;
using TMelix.Models;

namespace TMelix.Controllers
{
    public class SubscricoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscricoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subscricoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subscricao.Include(s => s.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subscricao == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricao
                .Include(s => s.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscricao == null)
            {
                return NotFound();
            }

            return View(subscricao);
        }

        // GET: Subscricoes/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizador>(), "Id", "CodPostal");
            return View();
        }

        // POST: Subscricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtilizadorFK,Duracao,Preço,DataInicio,DataFim")] Subscricao subscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizador>(), "Id", "CodPostal", subscricao.UtilizadorFK);
            return View(subscricao);
        }

        // GET: Subscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subscricao == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricao.FindAsync(id);
            if (subscricao == null)
            {
                return NotFound();
            }
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizador>(), "Id", "CodPostal", subscricao.UtilizadorFK);
            return View(subscricao);
        }

        // POST: Subscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtilizadorFK,Duracao,Preço,DataInicio,DataFim")] Subscricao subscricao)
        {
            if (id != subscricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscricaoExists(subscricao.Id))
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
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizador>(), "Id", "CodPostal", subscricao.UtilizadorFK);
            return View(subscricao);
        }

        // GET: Subscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subscricao == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricao
                .Include(s => s.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscricao == null)
            {
                return NotFound();
            }

            return View(subscricao);
        }

        // POST: Subscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subscricao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subscricao'  is null.");
            }
            var subscricao = await _context.Subscricao.FindAsync(id);
            if (subscricao != null)
            {
                _context.Subscricao.Remove(subscricao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscricaoExists(int id)
        {
          return (_context.Subscricao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
