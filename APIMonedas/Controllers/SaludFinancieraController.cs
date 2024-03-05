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
            var clientFinancialHealth = _context.SaludFinanciera.FirstOrDefault(sf => sf.Cedula == cedula);

            if (clientFinancialHealth == null)
            {
                return NotFound("No se encontró ningún cliente con la cédula proporcionada.");
            }

            // Calcular la deuda total del cliente
            decimal totalDebt = clientFinancialHealth.MontoTotalAdeudado;

            // Determinar si el cliente es confiable (por ejemplo, si la deuda total es menor que cierto umbral)
            bool isTrusted = totalDebt <= 1000; // Ejemplo arbitrario de umbral de deuda

            // Construir la respuesta
            var response = new
            {
                total_debt = totalDebt,
                is_ok = isTrusted ? "YES" : "NO"
            };

            return Ok(response);
        }
    }
}
