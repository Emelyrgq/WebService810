using APIMonedas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMonedas.Controllers
{
    [Route("webservices")]
    [ApiController]
    public class SaludFinancieraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SaludFinancieraController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ConsultarSaludFinanciera")]
        public IActionResult GetFinanceSummaryByClient(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
            {
                return BadRequest("Debe proporcionar el parámetro 'cedula'.");
            }

            // Consultar la base de datos para encontrar la salud financiera del cliente
            var clientFinancialHealth = _context.SaludFinanciera.Where(sf => sf.Cedula == cedula).ToList(); ;

            if (clientFinancialHealth == null)
            {
                return NotFound("No se encontró ningún cliente con la cédula proporcionada.");
            }

            // Calcular la deuda total del cliente
            decimal monto_total = clientFinancialHealth.Sum(sf => sf.MontoTotalAdeudado);

            // Determinar si el cliente es confiable (por ejemplo, si la deuda total es menor que cierto umbral)
            bool isTrusted = monto_total <= 1000; // Ejemplo arbitrario de umbral de deuda

            // Construir la respuesta
            var response = new
            {
                records = clientFinancialHealth.Select(sf => new
                {
                    indicador = sf.Indicador,
                    comentario = sf.Comentario,
                    MontoTotal = monto_total,

                })
                
            };

            return Ok(response);
        }
    }
}
