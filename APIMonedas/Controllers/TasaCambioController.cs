using APIMonedas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prometheus;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.Swagger.Annotations;
using WebService810.Data;
using WebService810.Models;

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

        /// <summary>
        /// Obtiene la tasa de cambio de una moneda específica.
        /// </summary>
        /// <param name="moneda">Código ISO de moneda a consultar.(ej: DOP)</param>
        /// <returns>La tasa de cambio de la moneda especificada.</returns>
        /// <response code="200">Retorna el valor de la moneda.</response>
        /// <response code="404">La moneda no está en el diccionario de la tasa de cambio.</response>
        /// <response code="500">Error interno en el servidor.</response>

        [HttpGet("ConsultarTasaMoneda")]
        public IActionResult GetExchangeRate(string moneda)
        {
            DateTime fecha = DateTime.Now;
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

            var Historial = new WebServiceUsage
            {
                InvocationDate = fecha,
                ServiceName = "Tasas de Cambio",
                Content = moneda

            };
            _context.WebServiceUsage.Add(Historial);
            _context.SaveChanges();

            // Si se encuentra la tasa de cambio, devolverla como respuesta
            return Ok(exchangeRate);
        }
    }
}
