using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using TMelix.Data;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace TMelix.Models
{
    public class Utilizador
    {

        public Utilizador()
        {
            Subscricoes =  new HashSet<Subscricao>();
        }

        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "O {0} não pode ter mais que {1} caractéres.")]
        [Display(Name ="Nome")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "Só pode escrever letras no {0}")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Escreva um {0} válido, por favor.")]
        public string Email { get; set; }

        [Display(Name = "NIF")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter 9 carateres.")]
        [RegularExpression("[123578][0-9]{8}", ErrorMessage = "O {0} deve começar por 1,2,3,5,7,8 seguido de 8 digitos numéricos.")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        public string NIF { get; set; }

        [Display(Name = "Morada")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Código Postal")]
        [RegularExpression("[0-9]{4}[-][0-9]{3}", ErrorMessage = "O {0} deve ter o seguinte formato: xxxx-xxx.")]
        public string CodPostal { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Sexo")]
        [RegularExpression("[MmFf]", ErrorMessage = "Só pode usar F, ou M, no campo {0}")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [Display(Name = "ID Utilizador")]
        public string UserID { get; set; }

        [Display(Name = "Tipo de Utilizador")]
        public string UserF { get; set; }

        public ICollection<Subscricao> Subscricoes { get; set; }
    }
}
