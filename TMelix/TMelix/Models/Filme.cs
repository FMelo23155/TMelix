using System.ComponentModel.DataAnnotations;
using TMelix.Data;

namespace TMelix.Models
{
    public class Filme
    {

        /// <summary>
        /// Descreve os filmes disponíveis
        /// </summary>

        public Filme()
        { 
        
            Subscricoes = new HashSet<Subscricao>();
        }

        /// <summary>
        /// PK da tabela de Filmes
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Título do filme
        /// </summary>

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(100, ErrorMessage ="O {0} não pode ter mais do que {1} caractéres.")]
        [Display(Name = "Título")]
        public string Título { get; set; }

        /// <summary>
        /// Imagem do filme
        /// </summary>
        
        public string Imagem { get; set; }

        /// <summary>
        /// Sinopse do filme
        /// </summary>
        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório.")]
        [StringLength(500, ErrorMessage ="O {0} não pode ter mais do que {1} caractéres.")]
        [Display(Name ="Sinopse")]
        public string Sinopse { get; set; }

        /// <summary>
        /// Data de lançamento do filme
        /// </summary>
        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        [Display(Name ="Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Classificação do filme 
        /// </summary
        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório.")]
        [Display(Name ="Classificação")]
        [RegularExpression("[0-5]", ErrorMessage ="A {0} deve-se encontrar entre 0-5")]
        public int Classificacao { get; set; }

        /// <summary>
        /// Elenco do Filme
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")]
        [Display(Name ="Elenco")]
        [StringLength(50, ErrorMessage ="O {0} não pode ter mais do que {1} caractéres.")]
        public string Elenco{ get; set; }

        /// <summary>
        /// Género do filme
        /// </summary
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")]
        [Display(Name ="Género")]
        [StringLength(20, ErrorMessage ="O {0} não pode ter mais do que {1} caractéres.")]
        public string Genero { get; set; }

        /// <summary>
        /// Lista de subscrições
        /// </summary
        public ICollection<Subscricao> Subscricoes { get; set; }


    }

}
