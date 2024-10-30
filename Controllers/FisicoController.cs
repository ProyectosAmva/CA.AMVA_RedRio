using AMVA.REDRIO.Models;
using AMVA.REDRIO.Core;
using AMVA.REDRIO.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AMVA.REDRIO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FisicoController : ControllerBase
    {
        private readonly FisicoService _fisicoService;

        public FisicoController(FisicoService fisicoService)
        {
            _fisicoService = fisicoService;
        }
        [Route("ObtenerFisicos")]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllFisicos()
        {
            try
            {
                var Fisicos = await _fisicoService.GetAllAsync();
                var responseGetAll = new Response
                {
                    IsSuccess = true,
                    Message = "Fisicos retrieved successfully",
                    Result = Fisicos
                };
                return Ok(responseGetAll);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Fisicos",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpGet("ObtenerFisico/{id}")]
        public async Task<ActionResult<Response>> GetByIdFisico(int id)
        {
            try
            {
                var Fisico = await _fisicoService.GetByIdAsync(id);
                if (Fisico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Fisico not found"
                    };
                    return NotFound(responseNotFound);
                }

                var responseGetById = new Response
                {
                    IsSuccess = true,
                    Message = "Fisico retrieved successfully",
                    Result = Fisico
                };
                return Ok(responseGetById);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error retrieving Fisico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [Route("AgregarFisico")]
        [HttpPost]
        public async Task<ActionResult<Response>> AddFisico([FromBody] Fisico fisico)
        {
            try
            {
                fisico.Fecha_creacion = DateTime.Now;
                await _fisicoService.AddAsync(fisico);
                var responseCreated = new Response
                {
                    IsSuccess = true,
                    Message = "Fisico created successfully",
                    Result = fisico
                };
                return CreatedAtAction(nameof(GetByIdFisico), new { id = fisico.IdFisico }, responseCreated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error creating Fisico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpPut("ActualizarFisico/{id}")]
        public async Task<IActionResult> UpdateFisico(int id, [FromBody] Fisico fisico)
        {
            try
            {
                var existingFisico = await _fisicoService.GetByIdAsync(id);
                if (existingFisico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Fisico not found"
                    };
                    return NotFound(responseNotFound);
                }

                existingFisico.Caudal =fisico.Caudal;
                existingFisico.NumeroDeVerticales = fisico.NumeroDeVerticales;
                existingFisico.SolidosVolatilesTotales = fisico.SolidosVolatilesTotales;
                existingFisico.SolidosDisueltosTotales = fisico.SolidosDisueltosTotales;
                existingFisico.SolidosSedimentables = fisico.SolidosSedimentables;
                existingFisico.ClasificacionCaudal = fisico.ClasificacionCaudal;
                existingFisico.Caudal = fisico.Caudal;
                existingFisico.SolidosFijosTotales = fisico.SolidosFijosTotales;
                existingFisico.SolidosSuspendidosTotales = fisico.SolidosSuspendidosTotales;
                existingFisico.SolidosTotales = fisico.SolidosTotales;
                existingFisico.ColorVerdaderoUPC = fisico.ColorVerdaderoUPC;
                existingFisico.Fecha_actualizacion = DateTime.Now;
                existingFisico.Fecha_Muestra = fisico.Fecha_Muestra;
                existingFisico.ColorTriestimular436nm =fisico.ColorTriestimular436nm;
                existingFisico.ColorTriestimular525nm = fisico.ColorTriestimular525nm;
                existingFisico.ColorTriestimular620nm = fisico.ColorTriestimular620nm;
                

                await _fisicoService.UpdateAsync(existingFisico);

                var responseUpdated = new Response
                {
                    IsSuccess = true,
                    Message = "Fisico updated successfully"
                };
                return Ok(responseUpdated);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error updating Fisico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }

        [HttpDelete("EliminarFisico/{id}")]
        public async Task<IActionResult> DeleteFisico(int id)
        {
            try
            {
                var existingFisico = await _fisicoService.GetByIdAsync(id);
                if (existingFisico == null)
                {
                    var responseNotFound = new Response
                    {
                        IsSuccess = false,
                        MessageError = "Fisico not found"
                    };
                    return NotFound(responseNotFound);
                }

                await _fisicoService.DeleteAsync(id);

                var responseDeleted = new Response
                {
                    IsSuccess = true,
                    Message = "Fisico deleted successfully"
                };
                return Ok(responseDeleted);
            }
            catch (Exception ex)
            {
                var responseError = new Response
                {
                    IsSuccess = false,
                    MessageError = "Error deleting Fisico",
                    Error = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }
        }
    }
}
