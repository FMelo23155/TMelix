using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMelix.Data;
using TMelix.Models;

namespace TMelix.Controllers
{
    public class SubscricoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SubscricoesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private void PopulateFilmesSeries()
        {
            ViewBag.Filmes = _context.Filmes.ToList();
            ViewBag.Series = _context.Series.ToList();
        }


        // GET: Subscricoes
        public async Task<IActionResult> Index()
        {
            PopulateFilmesSeries();
            
            var applicationDbContext = _context.Subscricoes
                .Include(s => s.Utilizador)
                .Include(s => s.Filmes)
                .Include(s => s.Series);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subscricoes == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricoes
                .Include(s => s.Utilizador)
                .Include(s=> s.Filmes)
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscricao == null)
            {
                return NotFound();
            }
            
            var userData = await _userManager.GetUserAsync(User);
            var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Nome == userData.Nome);

            if (!User.IsInRole("Administrador"))
            {
                if (subscricao.UtilizadorFK != utilizador.Id)
                {
                    return Forbid();
                }
            }

            

            return View(subscricao);
        }

        // GET: Subscricoes/Create
        public IActionResult Create()
        {
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Nome");


            PopulateFilmesSeries();


            return View();
        }

        // POST: Subscricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtilizadorFK,Duracao,Preco,DataInicio,DataFim")] Subscricao subscricao)
        {
            
            subscricao.DataInicio = DateTime.Now;



            string aux = Request.Form["Preco"];
            
            float preco = float.Parse(aux);
            subscricao.Preco = preco;

            if (User.IsInRole("Administrador"))
            {
                if (subscricao.Preco < 12)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(1);
                    subscricao.Duracao = 1;
                }
                else if (subscricao.Preco < 45 && subscricao.Preco > 13)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(6);
                    subscricao.Duracao = 6;
                }
                else
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(12);
                    subscricao.Duracao = 12;
                }

                string lstTags = Request.Form["checkFilmes"];
                string lstTags1 = Request.Form["checkSeries"];


                if (!string.IsNullOrEmpty(lstTags))
                {
                    int[] splTags = lstTags.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags.Count() > 0)
                    {
                        var PostTags = _context.Filmes.Where(w => splTags.Contains(w.Id)).ToList();

                        subscricao.Filmes.AddRange(PostTags);
                    }
                }

                if (!string.IsNullOrEmpty(lstTags1))
                {
                    int[] splTags1 = lstTags1.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags1.Count() > 0)
                    {
                        var PostTags1 = _context.Series.Where(w => splTags1.Contains(w.Id)).ToList();

                        subscricao.Series.AddRange(PostTags1);
                    }
                }
            }
            else
            {

                var userData = await _userManager.GetUserAsync(User);
                var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Nome == userData.Nome);

                subscricao.UtilizadorFK = utilizador.Id;

                Console.WriteLine("");
                if (subscricao.Preco < 12)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(1);
                    subscricao.Duracao = 1;
                }
                else if (subscricao.Preco < 45 && subscricao.Preco > 13)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(6);
                    subscricao.Duracao = 6;
                }
                else
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(12);
                    subscricao.Duracao = 12;
                }

                string lstTags = Request.Form["checkFilmes"];
                string lstTags1 = Request.Form["checkSeries"];


                if (!string.IsNullOrEmpty(lstTags))
                {
                    int[] splTags = lstTags.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags.Count() > 0)
                    {
                        var PostTags = _context.Filmes.Where(w => splTags.Contains(w.Id)).ToList();

                        subscricao.Filmes.AddRange(PostTags);
                    }
                }

                if (!string.IsNullOrEmpty(lstTags1))
                {
                    int[] splTags1 = lstTags1.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags1.Count() > 0)
                    {
                        var PostTags1 = _context.Series.Where(w => splTags1.Contains(w.Id)).ToList();

                        subscricao.Series.AddRange(PostTags1);
                    }
                }
            }

            

            await AlterarRole(subscricao);


            try
                {
                    _context.Add(subscricao);
                    await _context.SaveChangesAsync();
                    

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Handle exceptions appropriately
                    return View(subscricao);
                }
            

        }

        // GET: Subscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subscricoes == null)
            {
                return NotFound();
            }

            PopulateFilmesSeries();

            var subscricao = await _context.Subscricoes.FindAsync(id);
            if (subscricao == null)
            {
                return NotFound();
            }

            var userData = await _userManager.GetUserAsync(User);
            var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Nome == userData.Nome);

            if (!User.IsInRole("Administrador"))
            {
                if (subscricao.UtilizadorFK != utilizador.Id)
                {
                    return Forbid();
                }
            }

            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizador>(), "Id", "Nome", subscricao.UtilizadorFK);
            return View(subscricao);
        }

        // POST: Subscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtilizadorFK,Duracao,Preco,DataInicio,DataFim")] Subscricao subscricao)
        {
            if (id != subscricao.Id)
            {
                return NotFound();
            }

            if (User.IsInRole("Administrador"))
            {
                subscricao.DataInicio = DateTime.Now;

                if (subscricao.Preco < 12)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(1);
                    subscricao.Duracao = 1;
                }
                else if (subscricao.Preco < 45 && subscricao.Preco > 13)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(6);
                    subscricao.Duracao = 6;
                }
                else
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(12);
                    subscricao.Duracao = 12;
                }

                string lstTags = Request.Form["checkFilmes"];
                string lstTags1 = Request.Form["checkSeries"];


                if (!string.IsNullOrEmpty(lstTags))
                {
                    int[] splTags = lstTags.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags.Count() > 0)
                    {
                        var PostTags = _context.Filmes.Where(w => splTags.Contains(w.Id)).ToList();

                        subscricao.Filmes.AddRange(PostTags);
                    }
                }

                if (!string.IsNullOrEmpty(lstTags1))
                {
                    int[] splTags1 = lstTags1.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags1.Count() > 0)
                    {
                        var PostTags1 = _context.Series.Where(w => splTags1.Contains(w.Id)).ToList();

                        subscricao.Series.AddRange(PostTags1);
                    }
                }
            }
            else
            {
                subscricao.DataInicio = DateTime.Now;
                var userData = await _userManager.GetUserAsync(User);
                var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Nome == userData.Nome);

                subscricao.UtilizadorFK = utilizador.Id;

                Console.WriteLine("");

                if (subscricao.Preco < 12)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(1);
                    subscricao.Duracao = 1;
                }
                else if (subscricao.Preco < 45 && subscricao.Preco > 13)
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(6);
                    subscricao.Duracao = 6;
                }
                else
                {
                    subscricao.DataFim = subscricao.DataInicio.AddMonths(12);
                    subscricao.Duracao = 12;
                }

                string lstTags = Request.Form["checkFilmes"];
                string lstTags1 = Request.Form["checkSeries"];


                if (!string.IsNullOrEmpty(lstTags))
                {
                    int[] splTags = lstTags.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags.Count() > 0)
                    {
                        var PostTags = _context.Filmes.Where(w => splTags.Contains(w.Id)).ToList();

                        subscricao.Filmes.AddRange(PostTags);
                    }
                }

                if (!string.IsNullOrEmpty(lstTags1))
                {
                    int[] splTags1 = lstTags1.Split(',').Select(Int32.Parse).ToArray();

                    if (splTags1.Count() > 0)
                    {
                        var PostTags1 = _context.Series.Where(w => splTags1.Contains(w.Id)).ToList();

                        subscricao.Series.AddRange(PostTags1);
                    }
                }
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
            ViewData["UtilizadorFK"] = new SelectList(_context.Set<Utilizador>(), "Id", "Nome", subscricao.UtilizadorFK);
            return View(subscricao);
        }

        // GET: Subscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subscricoes == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricoes
                .Include(s => s.Utilizador)
                .Include(s => s.Filmes)
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscricao == null)
            {
                return NotFound();
            }

            var userData = await _userManager.GetUserAsync(User);
            var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Nome == userData.Nome);

            if (!User.IsInRole("Administrador"))
            {
                if (subscricao.UtilizadorFK != utilizador.Id)
                {
                    return Forbid();
                }
            }

            return View(subscricao);
        }

        // POST: Subscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subscricoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subscricoes'  is null.");
            }
            var subscricao = await _context.Subscricoes.FindAsync(id);
            await AlterarRoleC(subscricao);
            if (subscricao != null)
            {
                _context.Subscricoes.Remove(subscricao);
            }

            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscricaoExists(int id)
        {
          return (_context.Subscricoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> AlterarRole(Subscricao subscricao)
        {
            if (User.IsInRole("Administrador"))
            {
                var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Id == subscricao.UtilizadorFK);
                var user = await _userManager.FindByIdAsync(utilizador.UserID.ToString());
                Console.WriteLine("");

                await _userManager.RemoveFromRoleAsync(user, "Cliente");
                user.Funcao = "Subscritor";
                await _userManager.UpdateAsync(user);
                await _userManager.AddToRoleAsync(user, "Subscritor");
                await _userManager.UpdateSecurityStampAsync(user);
            }
            else
            {
                var userData = await _userManager.GetUserAsync(User);
                await _userManager.RemoveFromRoleAsync(userData, "Cliente");
                userData.Funcao = "Subscritor";
                await _userManager.UpdateAsync(userData);
                await _userManager.AddToRoleAsync(userData, "Subscritor");
                await _signInManager.RefreshSignInAsync(userData);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AlterarRoleC(Subscricao subscricao)
        {

            if (User.IsInRole("Administrador"))
            {
                var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Id == subscricao.UtilizadorFK);
                var user = await _userManager.FindByIdAsync(utilizador.UserID.ToString());
             
                    await _userManager.RemoveFromRoleAsync(user, "Subscritor");
                    user.Funcao = "Cliente";
                    await _userManager.UpdateAsync(user);
                    await _userManager.AddToRoleAsync(user, "Cliente");
                    await _userManager.UpdateSecurityStampAsync(user);
            }
            else
            {
                var userData = await _userManager.GetUserAsync(User);
                await _userManager.RemoveFromRoleAsync(userData, "Subscritor");
                userData.Funcao = "Cliente";
                await _userManager.UpdateAsync(userData);
                await _userManager.AddToRoleAsync(userData, "Cliente");
                await _signInManager.RefreshSignInAsync(userData);
            }

           
            return RedirectToAction(nameof(Index));
        }
    }
}
