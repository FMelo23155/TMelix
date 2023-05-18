using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMelix.Models;

namespace TMelix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<Serie>? Series { get; set; }
        public DbSet<Subscricao>? Subscricoes { get; set; }
        public DbSet<Utilizador>? Utilizadores { get; set; }
    }
}