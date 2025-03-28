using AMVA.REDRIO.Core.DTO;
using AMVA.REDRIO.Core.Models;
using AMVA.REDRIO.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesLaboratorioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportesLaboratorioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ObtenerReportesLaboratorio")]
        public async Task<ActionResult<Response>> GetAllReportesLaboratorios()
        {
            try
            {
                var reportes = await _context.ReportesLaboratorios.ToListAsync();
                return Ok(new Response { IsSuccess = true, Message = "Reportes de laboratorio obtenidos exitosamente", Result = reportes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { IsSuccess = false, MessageError = "Error al obtener reportes", Error = ex.Message });
            }
        }

        [HttpGet("ObtenerReporteLaboratorio/{id}")]
        public async Task<ActionResult<Response>> GetByIdReportesLaboratorio(int id)
        {
            var reporte = await _context.ReportesLaboratorios.FindAsync(id);
            if (reporte == null)
                return NotFound(new Response { IsSuccess = false, MessageError = "Reporte no encontrado" });

            return Ok(new Response { IsSuccess = true, Message = "Reporte obtenido exitosamente", Result = reporte });
        }

        [HttpGet("ObtenerReporteLaboratorioPorCampaña/{idCampaña}")]
        public async Task<ActionResult<Response>> GetByCampañaAsync(int idCampaña)
        {
            var reportes = await _context.ReportesLaboratorios.Where(r => r.IdCampaña == idCampaña).ToListAsync();
            if (!reportes.Any())
                return NotFound(new Response { IsSuccess = false, MessageError = "No se encontraron reportes para la campaña" });

            return Ok(new Response { IsSuccess = true, Message = "Reportes obtenidos exitosamente", Result = reportes });
        }

        [HttpPost("AgregarReporteLaboratorio")]
        public async Task<ActionResult<Response>> AddReportesLaboratorio([FromBody] ReportesLaboratorio reporte)
        {
            reporte.Fecha_creacion = DateTime.Now;
            _context.ReportesLaboratorios.Add(reporte);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdReportesLaboratorio), new { id = reporte.IdReporte }, new Response { IsSuccess = true, Message = "Reporte creado exitosamente", Result = reporte });
        }

        [HttpPut("ActualizarLaboratorio/{id}")]
        public async Task<IActionResult> UpdateReportesLaboratorio(int id, [FromBody] ReportesLaboratorio reporte)
        {
            var existingReporte = await _context.ReportesLaboratorios.FindAsync(id);
            if (existingReporte == null)
                return NotFound(new Response { IsSuccess = false, MessageError = "Reporte no encontrado" });

            existingReporte.IdResultadoCampo = reporte.IdResultadoCampo;
            existingReporte.IdCampaña = reporte.IdCampaña;
            existingReporte.IdEstacion = reporte.IdEstacion;
            existingReporte.Fecha_actualizacion = DateTime.Now;
            
            await _context.SaveChangesAsync();
            return Ok(new Response { IsSuccess = true, Message = "Reporte actualizado exitosamente" });
        }

        [HttpDelete("EliminarReporteLaboratorio/{id}")]
        public async Task<IActionResult> DeleteReportesLaboratorio(int id)
        {
            var reporte = await _context.ReportesLaboratorios.FindAsync(id);
            if (reporte == null)
                return NotFound(new Response { IsSuccess = false, MessageError = "Reporte no encontrado" });

            _context.ReportesLaboratorios.Remove(reporte);
            await _context.SaveChangesAsync();
            return Ok(new Response { IsSuccess = true, Message = "Reporte eliminado exitosamente" });
        }
    }
}