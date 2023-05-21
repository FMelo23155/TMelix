using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMelix.Data;
using TMelix.Models;

namespace TMelix.Controllers.API_TMelix
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeriesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SeriesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serie>>> GetSeries()
        {
            return await _context.Series
                              .OrderByDescending(a => a.Id)
                              .Select(a => new Serie
                              {
                                  Id = a.Id,
                                  Titulo = a.Titulo,
                                  Imagem = a.Imagem,
                                  Sinopse = a.Sinopse,
                                  DataLancamento = a.DataLancamento,
                                  Classificacao = a.Classificacao,
                                  Elenco = a.Elenco,
                                  Genero = a.Genero,
                                  Temporada = a.Temporada,
                                  Episodio = a.Episodio,
                              })
                              .ToListAsync();
        }

        // GET: api/SeriesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await _context.Series
                              .OrderByDescending(a => a.Id)
                              .Select(a => new Serie
                              {
                                  Id = a.Id,
                                  Titulo = a.Titulo,
                                  Imagem = a.Imagem,
                                  Sinopse = a.Sinopse,
                                  DataLancamento = a.DataLancamento,
                                  Classificacao = a.Classificacao,
                                  Elenco = a.Elenco,
                                  Genero = a.Genero,
                                  Temporada = a.Temporada,
                                  Episodio = a.Episodio,
                              })
                                    .Where(a => a.Id == id)
                                    .FirstOrDefaultAsync(); ;

            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }

        // PUT: api/SeriesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerie(int id, Serie serie)
        {
            if (id != serie.Id)
            {
                return BadRequest();
            }
            serie.Imagem = "semFoto.png";

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
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

        // POST: api/SeriesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Serie>> PostSerie(Serie serie)
        {
          if (_context.Series == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Series'  is null.");
          }
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.Id }, serie);
        }

        // DELETE: api/SeriesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieExists(int id)
        {
            return (_context.Series?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
