using System.ComponentModel.DataAnnotations;

namespace APIMonedas.Models
{
    public class SaludFinanciera
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cedula es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$", ErrorMessage = "El campo Cedula debe tener el formato correcto (###-#######-#).")]
        public string Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public char Indicador { get; set; }

        [StringLength(100, ErrorMessage = "El Comentario no puede tener más de 100 caracteres.")]
        public string Comentario { get; set;}

        [Required(ErrorMessage = "El Monto Total Adeudado es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El Monto Total Adeudado debe ser un número positivo.")]
        public decimal MontoTotalAdeudado { get; set;}


 
    }
}
