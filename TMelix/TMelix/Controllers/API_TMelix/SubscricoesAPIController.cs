using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TMelix.Data;
using TMelix.Models;

namespace TMelix.Controllers.API_TMelix
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscricoesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public SubscricoesAPIController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/SubscricoesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscricao>>> GetSubscricoes()
        {
            return await _context.Subscricoes
                              .Include(a => a.Utilizador)
                              .Include(a => a.Filmes)
                              .Include(a => a.Series)
                              .OrderByDescending(a => a.Id)
                              .Select(a => new Subscricao
                              {
                                  Id = a.Id,
                                  Utilizador = a.Utilizador,
                                  Duracao = a.Duracao,
                                  Preco = a.Preco,
                                  DataInicio = a.DataInicio,
                                  DataFim = a.DataFim,
                                  Filmes = a.Filmes,
                                  Series = a.Series,
                              })
                              .ToListAsync();
        }

        // GET: api/SubscricoesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscricao>> GetSubscricao(int id)
        {
            var subscricao = await _context.Subscricoes
                              .Include(a => a.Utilizador)
                              .Include(a => a.Filmes)
                              .Include(a => a.Series)
                                    .Select(a => new Subscricao
                                    {
                                        Id = a.Id,
                                        Utilizador = a.Utilizador,
                                        Preco = a.Preco,
                                        Duracao = a.Duracao,
                                        DataInicio = a.DataInicio,
                                        DataFim = a.DataFim,
                                        Filmes = a.Filmes,
                                        Series = a.Series,
                                    })
                                    .Where(a => a.Id == id)
                                    .FirstOrDefaultAsync();

            if (subscricao == null)
            {
                return NotFound();
            }

            return subscricao;
        }

        // PUT: api/SubscricoesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscricao(int id, Subscricao subscricao)
        {

            subscricao.Utilizador = await _context.Utilizadores.FindAsync(subscricao.UtilizadorFK);


            if (subscricao.Filmes.Count > 0)
            {
                subscricao.Filmes.Remove(subscricao.Filmes.First());
            }

            if (subscricao.Series.Count > 0)
            {
                subscricao.Series.Remove(subscricao.Series.First());
            }


            subscricao.Filmes = await _context.Filmes.Where(a => a.Id == subscricao.Filmes.Last().Id).ToListAsync();

            subscricao.Series = await _context.Series.Where(a => a.Id == subscricao.Series.Last().Id).ToListAsync();



       

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

            if (id != subscricao.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscricaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SubscricoesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        public async Task<ActionResult<Subscricao>> PostSubscricao(Subscricao subscricao)
        {

            subscricao.Utilizador = await _context.Utilizadores.FindAsync(subscricao.UtilizadorFK);

            var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Id == subscricao.UtilizadorFK);

            utilizador.UserF = "Subscritor";
                
            


            subscricao.Filmes = await _context.Filmes.Where(a => a.Id == subscricao.Filmes.First().Id).ToListAsync();

            subscricao.Series = await _context.Series.Where(a => a.Id == subscricao.Series.First().Id).ToListAsync();



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



            _context.Subscricoes.Add(subscricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscricao", new { id = subscricao.Id }, subscricao);


        }




        // DELETE: api/SubscricoesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscricao(int id)
        {
            var subscricao = await _context.Subscricoes.FindAsync(id);

            subscricao.Utilizador = await _context.Utilizadores.FindAsync(subscricao.UtilizadorFK);

            var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Id == subscricao.UtilizadorFK);

            utilizador.UserF = "Cliente";

            if (_context.Subscricoes == null)
            {
                return NotFound();
            }
            if (subscricao == null)
            {
                return NotFound();
            }

            _context.Subscricoes.Remove(subscricao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscricaoExists(int id)
        {
            return (_context.Subscricoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
