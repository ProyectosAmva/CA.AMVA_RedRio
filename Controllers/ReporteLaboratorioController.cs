using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Controllers
{
    /// <summary>
/// Controlador de API para gestionar los reportes de laboratorio.
/// Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los reportes de laboratorio.
/// Además, permite obtener los reportes filtrados por campaña.
/// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesLaboratorioController : ControllerBase
    {
        private readonly ReportesLaboratorioService _reportesLaboratorioService;

        public ReportesLaboratorioController(ReportesLaboratorioService ReportesLaboratorioService)
        {
            _reportesLaboratorioService = ReportesLaboratorioService;
        }

        [Route("ObtenerReportesLaboratorio")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllReportesLaboratorios()
        {
            try
            {
                var ReportesLaboratorios = await _reportesLaboratorioService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "ReportesLaboratorios retrieved successfull",
                    Result = ReportesLaboratorios
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving ReportesLaboratorios",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerReporteLaboratorio/{id}")]
        public async Task<ActionResult<Response>> GetByIdReportesLaboratorio(int id)
        {
            try
            {
                var ReportesLaboratorio = await _reportesLaboratorioService.GetByIdAsync(id);
                if (ReportesLaboratorio == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "ReportesLaboratorio not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "ReportesLaboratorio retrieved successfully",
                    Result = ReportesLaboratorio
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving ReportesLaboratorio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerReporteLaboratorioPorCampaña/{idCampaña}")]
        public async Task<ActionResult<Response>> GetByCampañaAsync(int idCampaña)
        {
            try
            {
                var reportesLaboratorio = await _reportesLaboratorioService.GetByCampañaAsync(idCampaña);
                if (reportesLaboratorio == null || !reportesLaboratorio.Any())
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "No se encontraron reportes de laboratorio para la campaña especificada."
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Reportes de laboratorio recuperados exitosamente.",
                    Result = reportesLaboratorio
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error al recuperar los reportes de laboratorio.",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarReporteLaboratorio")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddReportesLaboratorio([FromBody] ReportesLaboratorio reportesLaboratorio)
        {
            try
            {
                reportesLaboratorio.Fecha_creacion = DateTime.Now;
                await _reportesLaboratorioService.AddAsync(reportesLaboratorio);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "ReportesLaboratorio created successfully",
                    Result = reportesLaboratorio
                };
                return CreatedAtAction(nameof(GetByIdReportesLaboratorio), new { id = reportesLaboratorio.IdReporte }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating ReportesLaboratorio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarLaboratorio/{id}")]
        public async Task<IActionResult> UpdateReportesLaboratorio(int id, [FromBody] ReportesLaboratorio reportesLaboratorio)
        {
            try
            {
                var existingReportesLaboratorio = await _reportesLaboratorioService.GetByIdAsync(id);
                if (existingReportesLaboratorio == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "ReportesLaboratorio not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingReportesLaboratorio.IdResultadoCampo = reportesLaboratorio.IdResultadoCampo;
                existingReportesLaboratorio.IdCampaña = reportesLaboratorio.IdCampaña;
                existingReportesLaboratorio.IdEstacion = reportesLaboratorio.IdEstacion;
                existingReportesLaboratorio.Fecha_actualizacion = DateTime.Now;



                await _reportesLaboratorioService.UpdateAsync(existingReportesLaboratorio);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "ReportesLaboratorio updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating ReportesLaboratorio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarReporteLaboratorio/{id}")]
        public async Task<IActionResult> DeleteReportesLaboratorio(int id)
        {
            try
            {
                var existingReportesLaboratorio = await _reportesLaboratorioService.GetByIdAsync(id);
                if (existingReportesLaboratorio == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "ReportesLaboratorio not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _reportesLaboratorioService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "ReportesLaboratorio deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting ReportesLaboratorio",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
