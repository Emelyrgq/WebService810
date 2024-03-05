using APIMonedas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMonedas.Controllers
{
    [Route("webservices")]
    [ApiController]
    public class TasaCambioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasaCambioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ConsultarTasaMoneda")]
        public IActionResult GetExchangeRate(string moneda)
        {
            // Consulta la base de datos para obtener la tasa de cambio correspondiente al código de moneda proporcionado
            var exchangeRate = _context.TasasCambio
                .Where(t => t.Moneda == moneda)
                .Select(t => t.Tasa)
                .FirstOrDefault();

            // Verifica si se encontró la tasa de cambio para el código de moneda dado
            if (exchangeRate == null)
            {
                // Si no se encuentra, devolver un error 404 - Not Found
                return NotFound("No se encontró la tasa de cambio para el código de moneda especificado.");
            }

            // Si se encuentra la tasa de cambio, devolverla como respuesta
            return Ok(exchangeRate);
        }
    }
}
