using System.ComponentModel.DataAnnotations;

namespace TMelix.Models
{
    public class Serie
    {

        public Serie()
        {
            Subscricoes = new HashSet<Subscricao>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Título da série
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais do que {1} carateres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        /// <summary>
        /// Imagem da série
        /// </summary>
        public string Imagem { get; set; }

        /// <summary>
        /// Sinopse da série
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [StringLength(500, ErrorMessage = "O {0} não pode ter mais do que {1} carateres.")]
        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        /// <summary>
        /// Data de criação do filme
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Classificação da série
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [Display(Name = "Classificação")]
        [RegularExpression("[0-5]", ErrorMessage = "A {0} deve-se encontrar entre 0-5.")]
        public int Classificacao { get; set; }

        /// <summary>
        /// Elenco da série
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Elenco")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais do que {1} carateres.")]
        public string Elenco { get; set; }

        /// <summary>
        /// Genero da série
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Género")]
        [StringLength(20, ErrorMessage = "O {0} não pode ter mais do que {1} carateres.")]
        public string Genero { get; set; }

        /// <summary>
        /// Número de temporadas da série
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [Display(Name = "Número de temporadas")]
        public int Temporada { get; set; }

        /// <summary>
        /// Número de episódios da série 
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [Display(Name = "Número de episódios")]
        public int Episodio { get; set; }

        /// <summary>
        /// Lista de subscrições
        /// </summary>
        public ICollection<Subscricao> Subscricoes { get; set; }
    }
}
