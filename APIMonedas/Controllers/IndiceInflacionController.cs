using APIMonedas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMonedas.Controllers
{
    [Route("webservices")]
    [ApiController]
    public class IndiceInflacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IndiceInflacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ConsultarIndiceInflacion")]
        public IActionResult ConsultarIndiceInflacion(string periodo)
        {
            // Verificar si el formato del periodo es correcto
            if (!EsFormatoPeriodoValido(periodo))
            {
                return BadRequest("El formato del periodo debe ser 'YYYYMM'.");
            }

            // Obtener el índice de inflación para el periodo especificado
            decimal indiceInflacion = ObtenerIndiceInflacion(periodo);

            if (indiceInflacion == -1)
            {
                return NotFound("No se encontró el índice de inflación para el periodo especificado.");
            }

            // Devolver el índice de inflación como respuesta
            return Ok(new { IndiceInflacion = indiceInflacion.ToString("F2") + "%" });
        }

        // Método para verificar si el formato del periodo es válido (YYYYMM)
        private bool EsFormatoPeriodoValido(string periodo)
        {
            if (periodo.Length != 6)
            {
                return false;
            }

            if (!int.TryParse(periodo, out int _))
            {
                return false;
            }

            return true;
        }

        // Método para obtener el índice de inflación para el periodo especificado
        private decimal ObtenerIndiceInflacion(string periodo)
        {
            // Implementa la lógica para obtener el índice de inflación para el periodo especificado
            // Puedes consultar la base de datos u otro servicio para obtener el índice de inflación
            // Devuelve un valor de ejemplo por ahora
            Random random = new Random();
            return random.Next(1, 1000) / 10.0m; // Genera un número aleatorio entre 1 y 999.9 como índice de inflación
        }
    }
}

