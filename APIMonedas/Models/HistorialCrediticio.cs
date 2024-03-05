using System.ComponentModel.DataAnnotations;

namespace APIMonedas.Models
{
    public class HistorialCrediticio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cedula es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$", ErrorMessage = "El campo Cedula debe tener el formato correcto (###-#######-#).")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El RNC es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo RNC no puede tener más de 100 caracteres.")]
        public string RNCEmpresa { get; set; }

        [Required]
        public string ConceptoDeuda { get; set;}

        [Required(ErrorMessage = "La Fecha es obligatorio.")]
        public DateTime Fecha { get;set;}

        [Required(ErrorMessage = "El campo MontoAdeudado es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo MontoAdeudado debe ser un número positivo.")]
        public decimal MontoAdeudado { get;}

    }
}
