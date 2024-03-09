using APIMonedas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMonedas.Controllers
{
    [Route("webservices")]
    [ApiController]
    public class HistorialCrediticioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistorialCrediticioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("HistorialCrediticio")]
        public IActionResult GetFinanceSummaryByClient(string cedula)
        {
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

            return Ok(response);
        }
    }
}

