using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TMelix.Data;
using TMelix.Models;

namespace TMelix.Data
{

    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataRegisto { get; set; }
        public string Funcao { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "a", Name = "Administrador", NormalizedName = "ADMINISTRADOR" },
                new IdentityRole { Id="c", Name="Cliente", NormalizedName="CLIENTE"}
            );
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Subscricao> Subscricoes { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
    }
}