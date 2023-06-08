using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
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
                new IdentityRole { Id = "c", Name = "Cliente", NormalizedName = "CLIENTE" },
                new IdentityRole { Id = "s", Name = "Subscritor", NormalizedName = "SUBSCRITOR" }
            );

            builder.Entity<Filme>()
        .HasMany(f => f.Subscricoes)
        .WithMany(s => s.Filmes)
        .UsingEntity<Dictionary<string, object>>(
            "FilmeSubscricao",
            j => j
                .HasOne<Subscricao>()
                .WithMany()
                .HasForeignKey("SubscricaoId")
                .HasConstraintName("FK_FilmeSubscricao_Subscricao_SubscricaoId")
                .OnDelete(DeleteBehavior.Cascade),
            j => j
                .HasOne<Filme>()
                .WithMany()
                .HasForeignKey("FilmeId")
                .HasConstraintName("FK_FilmeSubscricao_Filme_FilmeId")
                .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("FilmeId", "SubscricaoId");
                j.ToTable("FilmeSubscricao");
            }
        );

            builder.Entity<Serie>()
        .HasMany(s => s.Subscricoes)
        .WithMany(s => s.Series)
        .UsingEntity<Dictionary<string, object>>(
            "SerieSubscricao",
            j => j
                .HasOne<Subscricao>()
                .WithMany()
                .HasForeignKey("SubscricaoId")
                .HasConstraintName("FK_SerieSubscricao_Subscricao_SubscricaoId")
                .OnDelete(DeleteBehavior.Cascade),
            j => j
                .HasOne<Serie>()
                .WithMany()
                .HasForeignKey("SerieId")
                .HasConstraintName("FK_SerieSubscricao_Serie_SerieId")
                .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("SerieId", "SubscricaoId");
                j.ToTable("SerieSubscricao");
            }
        );
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Subscricao> Subscricoes { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
    }
}