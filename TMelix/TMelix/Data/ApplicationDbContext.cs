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
        public DbSet<TMelix.Models.Filme>? Filme { get; set; }
        public DbSet<TMelix.Models.Serie>? Serie { get; set; }
        public DbSet<TMelix.Models.Subscricao>? Subscricao { get; set; }
        public DbSet<TMelix.Models.Utilizador>? Utilizador { get; set; }
    }
}