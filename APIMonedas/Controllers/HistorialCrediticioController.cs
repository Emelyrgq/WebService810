using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService810.Data;
using WebService810.Models;

namespace APIMonedas.Controllers
{
    /// <summary>
    /// Obtener historial crediticio
    /// </summary>
    [Route("webservices")]
    [ApiController]
    public class HistorialCrediticioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistorialCrediticioController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener el historial crediticio del cliente.
        /// </summary>
        /// <param name="cedula">Digite la cédula a consultar.</param>
        /// <returns>El .</returns>
        /// <response code="200">Retorna el la información solicitada.</response>
        /// <response code="404">La cédula no está en el diccionario de la tasa de cambio.</response>
        /// <response code="500">Error interno en el servidor.</response>

        [HttpGet("HistorialCrediticio")]
        public IActionResult GetFinanceSummaryByClient(string cedula)
        {
            DateTime fecha = DateTime.Now;

            if (string.IsNullOrEmpty(cedula))
            {
                return BadRequest("Debe proporcionar el parámetro 'cedula'.");
            }

            // Consultar el historial crediticio del cliente en la base de datos
            var creditHistory = _context.HistorialCrediticio.Where(hc => hc.Cedula == cedula).ToList();

            if (creditHistory.Count == 0)
            {
                return NotFound("No se encontró ningún historial crediticio para el cliente con la cédula proporcionada.");
            }

            // Calcular la deuda total del cliente sumando los montos adeudados en el historial crediticio
            decimal monto_total = creditHistory.Sum(hc => hc.MontoAdeudado);

            // Construir la respuesta
            var response = new
            {
                records = creditHistory.Select(hc => new
                {
                    rnc = hc.RNCEmpresa,
                    monto_total = hc.MontoAdeudado,
                    date = hc.Fecha,
                    concepto_deuda = hc.ConceptoDeuda
                })
            };

            var Historial = new WebServiceUsage
            {
                InvocationDate = fecha,
                ServiceName = "Historial crediticio",
                Content = cedula  
            };
            _context.WebServiceUsage.Add(Historial);
            _context.SaveChanges();

            return Ok(response);
        }
    }
}

