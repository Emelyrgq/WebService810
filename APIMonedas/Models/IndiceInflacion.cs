using System.ComponentModel.DataAnnotations;

namespace APIMonedas.Models
{
    public class IndiceInflacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Periodo es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo Periodo debe tener 6 caracteres en formato yyyymm.")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "El Indice es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Indice debe ser un número positivo.")]
        public decimal Indice { get; set; }

    }
}
