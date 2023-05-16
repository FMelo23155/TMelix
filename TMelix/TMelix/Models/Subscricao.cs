using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TMelix.Models
{
    public class Subscricao
    {
        /// <summary>
        /// Descreve as subscrições realizadas
        /// </summary>
        public Subscricao() { 

            Filmes = new HashSet<Filme>();

            Series = new HashSet<Serie>();
        }
        /// <summary>
        /// PK da tabela das subscrições
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FK para referenciar os utilizadores subscritos
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizador Utilizador { get; set; }


        /// <summary>
        /// Duração da subscrição
        /// </summary
        [Display(Name ="Duração (meses)")]
        public int Duracao { get; set; }


        /// <summary>
        /// Preço da subscrição
        /// </summary>
        [Display(Name ="Preço")]
        public int Preço{ get; set; }

        /// <summary>
        /// Data de inicio da subscrição
        /// </summary>
        [Display(Name ="Data de Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data de fim da subscrição
        /// </summary>
        [Display(Name ="Data de Fim")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        /// <summary>
        /// Define as séries que pertencem á subscrição
        /// </summary>
        public ICollection<Serie> Series { get; set; }

        /// <summary>
        /// Lista de filmes
        /// </summary>
        public ICollection<Filme> Filmes { get; set; }


    }
}
