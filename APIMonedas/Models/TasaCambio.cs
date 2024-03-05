
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using APIMonedas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIMonedas.Models
{
    public class TasaCambio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La Moneda es obligatorio.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El campo Moneda debe tener 3 caracteres.")]
        public string Moneda { get; set; }
        [Required(ErrorMessage = "La Tasa es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Tasa debe ser un número positivo.")]
        public decimal Tasa { get; set; }
    }
}
