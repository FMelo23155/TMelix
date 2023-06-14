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

            builder.Entity<Serie>().HasData(
            new Serie
            {
                Id = 1,
                Titulo = "Rabo de Peixe",
                Imagem = "https://paginaum.pt/wp-content/uploads/2023/06/rabo-de-peixe.jpg",
                Sinopse = "Um barco carregado de cocaína naufraga nos Açores e Eduardo vê uma oportunidade arriscada, mas empolgante, de ganhar dinheiro e realizar sonhos impossíveis.",
                DataLancamento = new DateTime(2023, 05, 26),
                Classificacao = 5,
                Elenco = "Helena Caldeira, José Condessa ",
                Genero = "Drama",
                Temporada = 1,
                Episodio = 7
            },
            new Serie
            {
                Id = 2,
                Titulo = "Suits",
                Imagem = "https://br.web.img2.acsta.net/pictures/14/03/28/10/18/433386.jpg",
                Sinopse = "O grande advogado corporativo de Manhattan, Harvey Specter, e sua equipe, Donna Paulsen, Louis Litt e Alex Williams, são lançados em uma disputa pelo poder quando um novo sócio se junta à empresa. Com seus dois melhores associados desaparecidos e Jessica de volta a Chicago, Specter e a equipe tentam se adaptar a uma nova normal sem eles. A equipe enfrenta traições, relacionamentos ardentes e segredos que acabam sendo revelados. Velhas e novas rivalidades vêm à luz entre os membros da equipe.",
                DataLancamento = new DateTime(2011, 06, 23),
                Classificacao = 5,
                Elenco = "Gabriel Macht, Patrick J. Adams",
                Genero = "Drama, Comédia",
                Temporada = 9,
                Episodio = 134
            },
            new Serie
            {
                Id = 3,
                Titulo = "Game of Thrones",
                Imagem = "https://br.web.img3.acsta.net/pictures/19/03/21/16/15/4239577.jpg",
                Sinopse = "Sucesso entre os livros mais vendidos, a série de obras \"A Song of Ice and Fire\", de George R.R. Martin, é levada à tela quando HBO decide navegar a fundo pelo gênero e recriar a fantasia medieval épica. Este é o retrato de duas famílias poderosas - reis e rainhas, cavaleiros e renegados, homens honestos e mentirosos - disputando um jogo mortal pelo controle dos Sete Reinos de Westeros para assumir o Trono de Ferro.",
                DataLancamento = new DateTime(2011, 04, 17),
                Classificacao = 5,
                Elenco = "Emilia Clarke, Pedro Pascal",
                Genero = "Fantasia, Drama",
                Temporada = 8,
                Episodio = 73
            }
            );

            builder.Entity<Filme>().HasData(
            new Filme
            {
                Id = 1,
                Titulo = "The Little Mermaid",
                Imagem = "https://m.media-amazon.com/images/M/MV5BYTUxYjczMWUtYzlkZC00NTcwLWE3ODQtN2I2YTIxOTU0ZTljXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg",
                Sinopse = "Uma jovem sereia faz um acordo com uma bruxa do mar para trocar sua bela voz por pernas humanas para que possa descobrir o mundo acima da água e impressionar um príncipe.",
                DataLancamento = new DateTime(2023, 05, 25),
                Classificacao = 2,
                Elenco = "Halle Bailey, Jonah Hauer-King",
                Genero = "Fantasia, Musical",
            },
            new Filme
            {
                Id = 2,
                Titulo = "Maleficent",
                Imagem = "https://m.media-amazon.com/images/I/51yXUqukECL._AC_.jpg",
                Sinopse = "Malévola, uma jovem de coração puro, vive em um pacífico reino na floresta. Um dia, um exército invasor ameaça a harmonia da região e ela se transforma na mais feroz protetora do reino. No entanto, uma terrível traição a transforma em uma mulher amarga e vingativa. Como consequência, ela amaldiçoa Aurora, sua filha recém-nascida. Mas, aos poucos, Malévola percebe que a criança é a chave para a paz no reino e para sua verdadeira felicidade também.",
                DataLancamento = new DateTime(2014, 06, 05),
                Classificacao = 4,
                Elenco = "Angelina Jolie, Ellie Fanning",
                Genero = "Aventura, Drama",
            },
            new Filme
            {
                Id = 3,
                Titulo = "Dumbo",
                Imagem = "https://br.web.img3.acsta.net/pictures/19/01/17/16/28/3541107.jpg",
                Sinopse = "     Holt Farrier é uma ex-estrela de circo que retorna da guerra e encontra seu mundo virado de cabeça para baixo. O circo em que trabalhava está passando por grandes dificuldades, e ele fica encarregado de cuidar de um elefante recém-nascido, cujas orelhas gigantes fazem dele motivo de piada. No entanto, os filhos de Holt descobrem que o pequeno elefante é capaz de uma façanha enorme: voar.",
                DataLancamento = new DateTime(2019, 03, 29),
                Classificacao = 3,
                Elenco = "Collin Farrel, Eva Green",
                Genero = "Aventura, Fantasia",
            }
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