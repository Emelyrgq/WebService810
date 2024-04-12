﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService810.Data;
using WebService810.Models;

namespace APIMonedas.Controllers
{
    [Route("webservices")]
    [ApiController]
    public class IndiceInflacionController : ControllerBase
    {
        DateTime fecha = DateTime.Now;

        private readonly ApplicationDbContext _context;

        public IndiceInflacionController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene el indice de inflación del año y mes a consultar.
        /// </summary>
        /// <param name="periodo">año/mes YYYY/MM a consultar.</param>
        /// <returns>El indice de inflación especificada.</returns>
        /// <response code="200">Retorna el valor del indice de inflación.</response>
        /// <response code="404">El año/mes no está en el diccionario del indice de inflación.</response>
        /// <response code="500">Error interno en el servidor.</response>
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

            var Historial = new WebServiceUsage
            {
                InvocationDate = fecha,
                ServiceName = "Indice inflacion",
                Content = periodo
            };
            _context.WebServiceUsage.Add(Historial);
            _context.SaveChanges();

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

        private decimal ObtenerIndiceInflacion(string periodo)
        {

            var indiceInflacion = _context.IndicesInflacion.FirstOrDefault(i => i.Periodo == periodo);

            if (indiceInflacion != null)
            {
                return indiceInflacion.Indice; // Devuelve el índice de inflación desde la base de datos
            }
            else
            {
                return -1; // Devuelve -1 si no se encontró el índice de inflación en la base de datos
            }
        }
    }
}