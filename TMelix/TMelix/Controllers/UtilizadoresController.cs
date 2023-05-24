using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMelix.Data;
using TMelix.Models;

namespace TMelix.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UtilizadoresController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
              return _context.Utilizadores != null ? 
                          View(await _context.Utilizadores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Utilizadores'  is null.");
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            var loggedInUserId = _userManager.GetUserId(User);
            if (!User.IsInRole("Administrador"))
            {
                if (utilizador.UserID != loggedInUserId)
                {
                    return Forbid();
                }
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,NIF,Morada,Pais,CodPostal,Sexo,DataNasc,UserID,UserF")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            var loggedInUserId = _userManager.GetUserId(User);
            if (!User.IsInRole("Administrador"))
            {
                if (utilizador.UserID != loggedInUserId)
                {
                    return Forbid();
                }
            }
           

            var user = await _userManager.FindByIdAsync(utilizador.UserID);
            if (user == null)
            {
                return NotFound();
            }

            // Compare the 'Funcao' field in the 'AspNetUsers' table with 'UserF' from 'Utilizadores'
            if (user.Funcao != utilizador.UserF)
            {
                utilizador.UserF = user.Funcao;
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,NIF,Morada,Pais,CodPostal,Sexo,DataNasc,UserID,UserF")] Utilizador utilizador)
        {
            if (id != utilizador.Id)
            {
                return NotFound();
            }

            if (!User.IsInRole("Administrador"))
            {
                ModelState.Remove("UserF");
                ModelState.Remove("UserID");

                var existingUtilizador = await _context.Utilizadores.FindAsync(id);

                if (existingUtilizador == null)
                {
                    return NotFound();
                }

                utilizador.UserF = existingUtilizador.UserF;
                utilizador.UserID = existingUtilizador.UserID;
            }



            if (ModelState.IsValid)
            {
                try 
                {
                    var existingUtilizador = await _context.Utilizadores.FindAsync(id);

                    if (existingUtilizador == null)
                    {
                        return NotFound();
                    }

                    existingUtilizador.Nome = utilizador.Nome;
                    existingUtilizador.Email = utilizador.Email;
                    existingUtilizador.NIF = utilizador.NIF;
                    existingUtilizador.Morada = utilizador.Morada;
                    existingUtilizador.Pais = utilizador.Pais;
                    existingUtilizador.CodPostal = utilizador.CodPostal;
                    existingUtilizador.Sexo = utilizador.Sexo;
                    existingUtilizador.DataNasc = utilizador.DataNasc;
                    existingUtilizador.UserID = utilizador.UserID;
                    existingUtilizador.UserF = utilizador.UserF;


                    _context.Update(existingUtilizador);
                    await _context.SaveChangesAsync();

                    var user = await _userManager.FindByIdAsync(existingUtilizador.UserID);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    // Update the 'Funcao' field in the 'AspNetUsers' table
                    user.Funcao = existingUtilizador.UserF;

                    // Update the user role based on 'UserF'
                    var roles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, roles.ToArray());

                    if (existingUtilizador.UserF == "Cliente")
                    {

                        await _userManager.AddToRoleAsync(user, "Cliente");

                    }
                    else if (existingUtilizador.UserF == "Administrador")
                    {
                        await _userManager.AddToRoleAsync(user, "Administrador");
                    }
                    else if (existingUtilizador.UserF == "Subscritor")
                    {
                        await _userManager.AddToRoleAsync(user, "Subscritor");
                    }


                    await _userManager.UpdateSecurityStampAsync(user);
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.Id))
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
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            var loggedInUserId = _userManager.GetUserId(User);
            if (!User.IsInRole("Administrador"))
            {
                if (utilizador.UserID != loggedInUserId)
                {
                    return Forbid();
                }
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utilizadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Utilizadores'  is null.");
            }
            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador != null)
            {
                _context.Utilizadores.Remove(utilizador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
          return (_context.Utilizadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
